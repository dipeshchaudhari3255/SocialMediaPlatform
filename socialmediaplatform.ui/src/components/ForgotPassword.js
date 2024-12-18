import React, { useState } from 'react';
import Auth from '../APIs/Auth';

function ForgotPassword()
{
    const [email, setEmail] = useState("");

    const onSubmitClick = () =>
    {
        debugger;
        Auth.ForgotPassword(email);
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
             <div className="d-grid">
          <button type='button' className="btn btn-primary"  onClick={onSubmitClick}>
            Submit
          </button>
        </div>
        </form>    
    )
}

export default ForgotPassword;