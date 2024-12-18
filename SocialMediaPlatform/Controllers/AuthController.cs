using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaPlatform.Data;
using SocialMediaPlatform.Encryption;
using SocialMediaPlatform.Helper;
using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly SocialMediaContext _context;

        private readonly JwtTokenGenerator _token;
        public AuthController(SocialMediaContext socialMediaContext, JwtTokenGenerator jwtTokenGenerator)
        {
            _context = socialMediaContext;
            _token = jwtTokenGenerator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] User user)
        {
            try
            {
                if (String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.PasswordHash) || String.IsNullOrEmpty(user.Username))
                {
                    return BadRequest("Please enter all details");

                }
                if (_context.Users.Any(x => user.Email == x.Email))
                {
                    return Ok("User Already Register");
                }
                // string password = new AESEncryption().EncryptStringToBytes(user.PasswordHash);
                User registerUser = new User
                {
                    Email = user.Email,
                    PasswordHash = user.PasswordHash,
                    Bio = user.Bio,
                    ProfilePicture = user.ProfilePicture,
                    Username = user.Username,
                    CreatedAt = DateTime.Now
                };
                await _context.Users.AddAsync(registerUser);
                await _context.SaveChangesAsync();
                return Ok(registerUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] Login loginUser)
        {
            try
            {
                if (String.IsNullOrEmpty(loginUser.Email) || loginUser.PasswordHash is null)
                {
                    return BadRequest("Please enter proper email and password");
                }
                // string password = new AESEncryption().EncryptStringToBytes(loginUser.PasswordHash);
                var user = await _context.Users.FirstOrDefaultAsync(x => loginUser.Email == x.Email && x.PasswordHash == x.PasswordHash);
                if (user is null)
                {
                    return BadRequest("Invalid Email or Password");
                }

                return Ok(new { Token = _token.GenerateToken(user.Username) });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromForm] EmailAddress user)
        {
            try
            {
                if(user.Email == null)
                {
                    return BadRequest("Please enter valid Email");
                }
                var userDetails = _context.Users.FirstOrDefault(x => x.Email == user.Email);
                if (userDetails != null)
                {
                    string otp = OtpGenerate.GenerateRandomOTP();
                    string emailBody = @"
                    <p>We received a request to reset your password. Please use the OTP below to proceed:</p>
                    <p style='text-align: center; font-size: 24px; font-weight: bold; color: #007bff; margin: 20px 0;'>
                        <span>#{[OTP_CODE]}#</span>
                    </p>";

                    await EmailService.SendEmailAsync(user.Email, "Forgot Password", emailBody.Replace("#{[OTP_CODE]}#", otp));
                    userDetails.OTP = Convert.ToInt32(otp);
                    _context.Users.Update(userDetails);
                    _context.SaveChanges();

                    return Ok();
                }
                return BadRequest("Email not found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            
        }


        [HttpPost("VerifyOTP")]
        public IActionResult VerifyOTP([FromForm] EmailAddress user)
        {   
            try
            {
                if (user.Email == null || String.IsNullOrEmpty(user.OTP.ToString()))
                {
                    return BadRequest("Please enter valid OTP");
                }
                var userDetails = _context.Users.FirstOrDefault(x => x.Email == user.Email);
                if (userDetails != null && (userDetails.OTP == user.OTP))
                {
                    return Ok();
                }
                return BadRequest("OTP is not matched");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }
}