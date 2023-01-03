import axios from "axios";
import IAuthorizationResul from "../interfaces/IAuthorizationResult";
import { ILoginDTO } from "../interfaces/ILoginDTO";
import { RegisterDTO } from "../interfaces/IRegisterDTO";



export function SignIn(regsiterDTO:RegisterDTO){
    const instance = axios.create({
        withCredentials:true,
        baseURL:"https://localhost:7219"
    });
    
    return instance.post<IAuthorizationResul>("/Authorization/Register",regsiterDTO,{
        headers:{
            'Content-Type':'application/json',
        }
    });
}

export function SignUp(loginDto:ILoginDTO){
    const instance = axios.create({
        withCredentials:true,
        baseURL:"https://localhost:7219"
    });

    return instance.post<IAuthorizationResul>("/Authorization/Login",loginDto,{
        headers:{
            'Content-Type':'application/json',
        }
    });
}

export async function Logout(){
    const instance = axios.create({
        withCredentials:true,
        baseURL:"https://localhost:7219"
    });

    const response = await instance.post("/Authorization/Logout");

    return response.status;
}

export function SaveTokenLocalStorage(token:string){
    
}