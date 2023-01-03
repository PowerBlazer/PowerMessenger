import MainMenuPanel from "../../panels/MainMenuPanel/MainMenuPanel";
import Container from "../../components/Container";
import ContentPanel from "../../panels/ContentPanel/ContentPanel";
import IChatsDTO from "../../interfaces/IChatsDTO";
import { ContentPanelContext } from "../../contexts/ContentPanelContext";
import { useState } from "react";
import "./main.css";

export default function Main(){
    const [chat,setChat] = useState<IChatsDTO>();

    return(
        <ContentPanelContext.Provider value={{
            chat:chat,
            setChat:setChat
        }}>
            <Container>
                <div className="main">
                    <MainMenuPanel />
                    <ContentPanel />
                </div>
            </Container>
        </ContentPanelContext.Provider>
    )
}