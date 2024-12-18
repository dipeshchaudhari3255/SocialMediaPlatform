import React, { useState } from 'react';
import Auth from '../APIs/Auth';

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    
    const onSubmitClick  = event =>
    {
         event.preventDefault(); // Prevent form submission reload
        if (email === "" || password === "") {
            alert("Please enter both email and password");
            return;
        }
        Auth.login(email, password);
    }
    return (
       <form>
        <h3>Sign In</h3>

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
            Submit
          </button>
        </div>
        <p className="forgot-password text-right">
          Forgot <a href="/ForgotPassword">password?</a>
        </p>
      </form>
    );
}

export default Login;