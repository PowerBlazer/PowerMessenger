import React from "react";


export interface IMainPanelContext{
    element:JSX.Element
    toogleWindow?:React.Dispatch<React.SetStateAction<JSX.Element>>
}

const defaultState:IMainPanelContext = {
    element:<></>,
}

export const MainPanelContext = React.createContext<IMainPanelContext>(defaultState);