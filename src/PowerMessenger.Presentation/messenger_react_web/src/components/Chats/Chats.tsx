import { useContext, useEffect, useState } from "react";
import { ContentPanelContext } from "../../contexts/ContentPanelContext";
import { GetChats } from "../../services/ChatService";
import IChatsDTO from "../../interfaces/IChatsDTO";
import IChatDTO from "../../interfaces/IChatsDTO";
import Chat from "../Chat/Chat";
import "./chats.css";


export default function Chats(){

    const [chats,setChats] = useState<IChatDTO[]>([]);
    const [selectedValue,setValueButton] = useState<number>();
    const {setChat} = useContext(ContentPanelContext);

    useEffect(()=>{
        let selectedChatId = parseInt(localStorage.getItem("selectedChat") as string);
        
        async function fetch(){
            let result = await GetChats();

            setChats(chats=>chats = result); 
            setChat!(result.find(p=>p.chatId === selectedChatId));   
        } 

        fetch();

        setValueButton(selectedChatId);     
    },[]);

    

    const buttonClickHandler = async(chat:IChatsDTO) => {
        localStorage.setItem("selectedChat",chat.chatId.toString());
        setValueButton(chat.chatId);
        setChat!(chat);
    }

    return(
        <ul className="chatsWindow">
            {chats.map((chat)=>
                <li key={chat.chatId}>  
                    <Chat chat={chat} 
                        selectedButton={selectedValue === chat.chatId ? (true) : (false)}
                        onClick={()=>buttonClickHandler(chat)}
                    />
                </li>
            )}
        </ul>
    )
}