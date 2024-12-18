import axios from "axios";
import React from 'react';
import OTP from "../components/OTP";
import Login from "../components/Login";
import { useNavigate } from 'react-router-dom';


    const Auth = {
        login: (email, password) => {
            let formData = new FormData();
            formData.append("Email", email);
            formData.append("PasswordHash", password);

            axios({
                url: "http://localhost:5049/api/Auth/Login",
                method: "POST",
                data: formData,
            })
                .then((res) => {
                    debugger;
                    alert("Login successful:" + res.data.token);
                })
                .catch((err) => {
                    alert("Login error:" + err);
                });
        },
        register: (email, password, userName, bio) => {
            let formData = new FormData();
            formData.append("Email", email);
            formData.append("PasswordHash", password);
            formData.append("Username", userName);
            formData.append("Bio", bio);

            axios({
                url: "http://localhost:5049/api/Auth/Register",
                method: "POST",
                data: formData,
            })
                .then((res) => {
                    alert("Login successful:" + res.data.token);
                    <Login />
                })
                .catch((err) => {
                    alert("Login error:" + err);
                });
        },

        ForgotPassword: (email) => {
            let formData = new FormData();
            formData.append("Email", email);

            axios({
                url: "http://localhost:5049/api/Auth/ForgotPassword",
                method: "POST",
                data: formData,
            })
                .then((res) => {
                    debugger;
                    alert("Login successful:" + res.data);
                    <OTP email={email} />
                })
                .catch((err) => {
                    alert("Login error:" + err);
                });
        },

        VerifyOTP: (OTP, email) => {
            let formData = new FormData();
            formData.append("OTP", OTP);
            formData.append("Email", email);

            axios({
                url: "http://localhost:5049/api/Auth/VerifyOTP",
                method: "POST",
                data: formData,
            })
                .then((res) => {
                    debugger;
                    alert("Login successful:" + res.data.token);
                    // window.location.href = "/Register";
                })
                .catch((err) => {
                    alert("Login error:" + err);
                });
        }
    }
    export default Auth;



