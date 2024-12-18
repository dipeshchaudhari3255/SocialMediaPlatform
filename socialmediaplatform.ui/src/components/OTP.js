import React, { useState } from 'react';
import Auth from '../APIs/Auth';

function OTP({email})
{
    debugger;
    const [OTP, setOTP] = useState("");

    const onSubmitClick = () =>
    {
        debugger;
        Auth.VerifyOTP(OTP, email);
    }

    return (
         <form>
        <h3>OTP Verification</h3>

        <div className="mb-3">
          <label>One time password</label>
          <input
            type="email"
            className="form-control"
            placeholder="Enter OTP"
            onBlur ={ (event) => setOTP(event.target.value)}
                />
                </div>
             <div className="d-grid">
          <button type="submit" className="btn btn-primary" onClick={onSubmitClick}>
            Submit
          </button>
        </div>
        </form>    
    )
}

export default OTP;