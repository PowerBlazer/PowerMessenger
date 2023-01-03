import "./login.css";
import backgroundImageLogin from "./Image.png";
import React, { useState } from "react";
import ErrorsAuthorize from "../../components/ErrorsAuthorize.tsx/ErrorsAuthorize";
import IAuthorizationResul from "../../interfaces/IAuthorizationResult";
import { Link, useNavigate } from "react-router-dom";
import { ILoginDTO } from "../../interfaces/ILoginDTO";
import { SignUp } from "../../services/AuthorizationService";


function Login(){

    const [errors,setErrors] = useState<string[]>([""]);
    const [email,setEmail] = useState<string>("");
    const [password,setPassword] = useState<string>("");
    
    const navigate = useNavigate();


    const buttonLoginHandler = (event:React.MouseEvent<HTMLButtonElement>)=>{

        let loginDto:ILoginDTO = {
            Email:email,
            Password:password
        };

        SignUp(loginDto).then(function(response){
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

    const inputEmailHandler = (event:React.ChangeEvent<HTMLInputElement>) =>{
        setEmail(event.currentTarget.value);
    }

    const inputPasswordHandler = (event:React.ChangeEvent<HTMLInputElement>) =>{
        setPassword(event.currentTarget.value);
    }


    return(
        <div className="login-background">
            <div className="login-window">
                <div className="login-image">
                    <img src={backgroundImageLogin} width={746} height={832} alt='img'></img>
                </div>
                <div className="login-form">
                    <div className="header">
                        <h1>Login</h1>
                        <p>Welcome back Please enter your details.</p>
                    </div>
                    <div className="inputs-panel">
                        <input type="text" onChange={(e)=>{inputEmailHandler(e)}} placeholder="Email"></input>
                        <input type="password" onChange={(e)=>{inputPasswordHandler(e)}} placeholder="Password"></input>
                        <Link to="#" className="forgot-password">Forgot password?</Link>
                    </div>
                    <ErrorsAuthorize errors={errors}/>
                    <button type="button" onClick={(e)=>{buttonLoginHandler(e)}} className="button-login">Login</button>
                    <div className="common-info">
                        <span>Dont have an account?</span>
                        <Link to="/signup">Sign up</Link>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Login;