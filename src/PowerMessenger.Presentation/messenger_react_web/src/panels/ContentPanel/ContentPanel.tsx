import { useContext } from "react";
import { ContentPanelContext } from "../../contexts/ContentPanelContext";
import ContentPanelHeader from "../../headers/ContentPanelHeader/ContentPanelHeader";
import MessagesPanel from "../MessagesPanel/MessagesPanel";
import "./contentPanel.css";


export default function ContentPanel(){

    const {chat} = useContext(ContentPanelContext)

    return(
        <div className="contentPanel">
            {chat ? (
                <>
                    <ContentPanelHeader chat={chat}/>
                    <MessagesPanel />
                </>
           ):
           (<></>)} 
        </div>
           
    )
}