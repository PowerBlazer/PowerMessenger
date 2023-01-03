import axios, { AxiosError } from "axios";

export const instance = axios.create({
    withCredentials:true,
    baseURL:"https://localhost:7219"
})

instance.interceptors.response.use((response) => response, (error:AxiosError) => {
    if(error.response?.status === 401){
        window.location.href = "/login";
    }
});