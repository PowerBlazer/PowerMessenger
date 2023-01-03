import React from "react";
import IChatsDTO from "../interfaces/IChatsDTO";


interface IContentPanelContext{
    chat?:IChatsDTO
    setChat?:React.Dispatch<React.SetStateAction<IChatsDTO | undefined>>
}

const defaultState:IContentPanelContext = {
   
}

export const ContentPanelContext = React.createContext<IContentPanelContext>(defaultState);