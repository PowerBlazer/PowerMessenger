import "./contentPanelHeader.css";
import  IChatsDTO  from "../../interfaces/IChatsDTO";

interface IContentPanelHeaderProps{
    chat:IChatsDTO
}

export default function ContentPanelHeader({chat}:IContentPanelHeaderProps){

    return(
        <div className="contentPanelHeader">
            <button className="chatInformation">
                <img src={"https://localhost:7219/"+chat.chatPhoto} alt={chat.name} width={40} height={40}></img>
                <div className="name_countParticipants">
                    <div className="name">{chat.name}</div>
                    <div className="participants">{chat.countParticipants} участников</div>
                </div>
            </button>
        </div>
    )
}