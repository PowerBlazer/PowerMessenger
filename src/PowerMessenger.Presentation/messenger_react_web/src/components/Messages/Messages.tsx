import { useContext, useEffect, useRef, useState } from "react"
import { ContentPanelContext } from "../../contexts/ContentPanelContext"
import { IMessagesDTO } from "../../interfaces/IMessagesDTO";
import { GetMessagesByChat } from "../../services/MessageService";
import Message from "../Message/Message";
import "./messages.css"




export default function Messages(){

    const {chat} = useContext(ContentPanelContext);
    const [messages,setMessages] = useState<IMessagesDTO>();
    const [firstUnreadMessageId,setFirstUnreadMessageId] = useState<number>(0);

    const messagesBlock = useRef<HTMLUListElement>(null);
    const firstUnReadMessageBlock = useRef<HTMLLIElement>(null);

    
    useEffect(()=>{
        const fetch = async () =>{
            let messagesResult = await GetMessagesByChat(chat!.chatId.toString());
            
            let firstUnreadMessage = messagesResult.messages
                .find(p=>p.isRead === false);

            if(firstUnreadMessage === undefined){
                firstUnreadMessage = messagesResult
                    .messages[messagesResult.messages.length-1];
            }

            setFirstUnreadMessageId(firstUnreadMessage.id);

            setMessages(messagesResult);
        }
        fetch();
    },[chat]);

    useEffect(()=>{
        if(messages!==undefined && firstUnReadMessageBlock !== null){
            messagesBlock.current?.scrollTo({
                top:firstUnReadMessageBlock.current?.offsetTop
            })
        }
    },[messages])

    return(
        <ul className="messages" ref={messagesBlock}>
            {messages?.messages.map((message)=>
                <li ref={firstUnreadMessageId === message.id ?
                        (firstUnReadMessageBlock):(null)}
                    key={message.id}
                >
                    <Message 
                        message = {message}
                        key={message.id}
                    />
                </li>
            )}
           
        </ul>
    )
}