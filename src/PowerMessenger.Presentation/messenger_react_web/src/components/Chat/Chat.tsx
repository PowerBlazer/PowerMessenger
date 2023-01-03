
import IChatDTO from "../../interfaces/IChatsDTO";
import "./chat.css";

interface IChatProps{
    chat:IChatDTO
    selectedButton?:boolean,
    onClick?:(id:number)=>void
}


export default function Chat({chat,selectedButton,onClick}:IChatProps){

    const active = selectedButton ? (" active"):("");

    const datetime = new Date(chat.lastMessageTime);
    const nowdate = new Date();

    let time = datetime.toLocaleTimeString([],{
        hour:'2-digit',
        minute:'2-digit'
    });

    if((nowdate.getDay()!==datetime.getDay())
        ||nowdate.getMonth()!==datetime.getMonth()){
        time = datetime.toLocaleDateString();
    }

    return(
        <button onClick={()=>onClick!(chat.chatId)} className={"chatBlock"+ active}>
            <div className="avatar-chat">
                <img src={"https://localhost:7219/"+chat.chatPhoto} 
                    width="30" height="30" alt="avt-cht"></img>
            </div>
            <div className="chatContent">
                <div className="header">
                    <div className="header-content">{chat.name}</div>
                    <div className={"time"+active}>{time}</div>
                </div>
                <div className="content">
                    <div className="message-content">
                        <div className="owner">{chat.lastMessageOwner}:</div>
                        <div className={"message"+active}>{chat.lastMessage}</div>
                    </div>
                    {chat.countUnReadMessages !== 0 ? 
                        (<div className={"countNoReadMessages"+active}>{chat.countUnReadMessages}</div>):(<></>)}
                </div>
            </div>
        </button>
    )
}