import React from 'react'

export interface IButtonSettingContext{
    isBack:boolean,
    toogleButton?:React.Dispatch<React.SetStateAction<boolean>>
}

const defaultState:IButtonSettingContext ={
    isBack:false
} 

export  const ButtonMenuContext = React.createContext<IButtonSettingContext>(defaultState);