import React, { useState } from 'react';
import Auth from '../APIs/Auth';

function Register() {
  const [email, setEmail] = useState("");
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [bio, setBio] = useState("");

    
    const onSubmitClick  = event =>
    {
         event.preventDefault(); // Prevent form submission reload
        if (email === "" || password === "") {
            alert("Please enter both email and password");
            return;
        }
        Auth.register(email, password, userName, bio);
    }
    return (
       <form>
        <h3>Sign Up</h3>

        <div className="mb-3">
          <label>Username</label>
          <input
            type="text"
            className="form-control"
            placeholder="Enter username"
            onBlur ={ (event) => setUserName(event.target.value)}
          />
        </div>

        <div className="mb-3">
          <label>Email address</label>
          <input
            type="email"
            className="form-control"
            placeholder="Enter email"
            onBlur ={ (event) => setEmail(event.target.value)}
          />
        </div>

        <div className="mb-3">
          <label>Password</label>
          <input
            type="password"
            className="form-control"
            placeholder="Enter password"
            onBlur ={ (event) => setPassword(event.target.value)}
            />
        </div>

        <div className="mb-3">
          <label>Bio</label>
          <textarea
            type="text"
            className="form-control"
            placeholder="Enter Bio"
            onBlur ={ (event) => setBio(event.target.value)}
          />
        </div>

        <div className="mb-3">
          <div className="custom-control custom-checkbox">
            <input
              type="checkbox"
              className="custom-control-input"
              id="customCheck1"
            />
            <label className="custom-control-label" htmlFor="customCheck1">
              Remember me
            </label>
          </div>
        </div>

        <div className="d-grid">
          <button type="submit" className="btn btn-primary" onClick={onSubmitClick}>
            Register
          </button>
        </div>
        <p className="forgot-password text-right">
          Already registered <a href="/">Login?</a>
        </p>
      </form>
    );
}

export default Register;