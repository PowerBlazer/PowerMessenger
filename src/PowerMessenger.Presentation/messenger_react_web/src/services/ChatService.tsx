import { IChatDTO } from "../interfaces/IChatDTO";
import IChatsDTO from "../interfaces/IChatsDTO";
import { instance } from "./apiInstance";

export async function GetChats(){
    const response = await instance.get<IChatsDTO[]>("/Chats/user");

    return response.data;
}

export async function GetChat(chatId:string){
    const response = await instance.get<IChatDTO>('/Chats/chat/'+chatId);

    return response.data;
}
