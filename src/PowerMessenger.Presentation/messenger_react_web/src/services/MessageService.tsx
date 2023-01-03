import { IMessagesDTO } from "../interfaces/IMessagesDTO";
import { instance } from "./apiInstance";


export async function GetMessagesByChat(chatId:string){
    const repsonse = await instance.get<IMessagesDTO>("/Message/getMessages/"+chatId);
    
    return repsonse.data;
}