import { IMessageDTO } from "../../interfaces/IMessageDTO"
import "./message.css";

interface IMessageProps{
    message:IMessageDTO

}


export default function Message({message}:IMessageProps){

    return(
        <div className="message">
            <div className="owner-avatar">
                <img src={"https://localhost:7219/"+message.messageOwnerAvatar} width={30} height={30}></img>
            </div>
            <div className="message-content">

            </div>
        </div>
    )
}