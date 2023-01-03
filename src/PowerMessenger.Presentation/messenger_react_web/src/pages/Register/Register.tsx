import "./register.css";
import backgroundImageRegister from "./backgroundRegister.png";
import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import ErrorsAuthorize from "../../components/ErrorsAuthorize.tsx/ErrorsAuthorize";
import IAuthorizationResul from "../../interfaces/IAuthorizationResult";
import { RegisterDTO } from "../../interfaces/IRegisterDTO";
import { SignIn } from "../../services/AuthorizationService";


function Register(){
    const [errors,setErrors] = useState<string[]>([""]);
    const [userName,setUserName] = useState<string>("");
    const [email,setEmail] = useState<string>("");
    const [password,setPassword] = useState<string>("");
    const [confirmPassword,setConfirmPassword] = useState<string>("");

    const navigate = useNavigate();

    const inputUserNameHandler = (event:React.ChangeEvent<HTMLInputElement>) => {
        setUserName(event.currentTarget.value);
    }

    const inputEmailHandler = (event:React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.currentTarget.value);
    }

    const inputPasswordHandler = (event:React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.currentTarget.value);
    }

    const inputConfirmPasswordHandler = (event:React.ChangeEvent<HTMLInputElement>) => {
        setConfirmPassword(event.currentTarget.value);
    }

    const buttonLoginHandler = (event:React.MouseEvent<HTMLButtonElement>) => {

        let regsiterDTO:RegisterDTO = {
            userName:userName,
            email:email,
            password:password,
            passwordConfirm:confirmPassword
        }
        
        SignIn(regsiterDTO).then(function(response){
            let authorizationResult:IAuthorizationResul = response.data;

            if(authorizationResult.isSuccess){
                navigate("/");    
            }
        })
        .catch(function(response){
            let authorizationResult:IAuthorizationResul = response.response.data;
            setErrors(authorizationResult.errors);
        });
    }


    return(
        <div className="register-background">
            <div className="register-window">
                <div className="register-form">
                    <div className="header">
                        <h1>Register</h1>
                        <p>Welcome back Please enter your details.</p>
                    </div>
                    <div className="inputs-panel">
                        <input type="text" onChange={(e)=>{inputUserNameHandler(e)}} placeholder="UserName"></input>
                        <input type="text" onChange={(e)=>{inputEmailHandler(e)}} placeholder="Email"></input>
                        <input type="password" onChange={(e)=>{inputPasswordHandler(e)}} placeholder="Password"></input>
                        <input type="password" onChange={(e)=>{inputConfirmPasswordHandler(e)}} placeholder="Password Confirm"></input>
                        <Link  className="forgot-password" to="#">Forgot password?</Link>
                    </div>
                    <ErrorsAuthorize errors={errors}/>
                    <button type="button" onClick={(e)=>{buttonLoginHandler(e)}} className="button-register">Sign In</button>
                    <div className="common-info">
                        <span>You already have an account?</span>
                        <Link to="/login">Sign up</Link>
                    </div>
                </div>
                <div className="register-image">
                    <img src={backgroundImageRegister} width={746} height={832} alt='img'></img>
                </div>
            </div>
        </div>
    )
}

export default Register;