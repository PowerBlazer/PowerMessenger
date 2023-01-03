import "./mainMenuPanel.css";
import ChatsPanelHeader from "../../headers/ChatsPanelHeader/ChatPanelHeader";
import Chats from "../../components/Chats/Chats";
import { useState } from "react";
import { MainPanelContext } from "../../contexts/MainPanelComtext";





export default function MainMenuPanel(){

    const [windowElement,setWindowElement] = useState<JSX.Element>(<Chats />)

    return(
        <MainPanelContext.Provider value={{
            element:windowElement,
            toogleWindow:setWindowElement
        }}>
            <div className="chatsPanel">
                <ChatsPanelHeader />
                {windowElement}
            </div>
        </MainPanelContext.Provider>
    )
}
