import "./menuburger.css";
import React from "react";
import settingIcon from "./setting.svg";
import userIcon from "./user.svg";
import bookmarkIcon from "./bookmark.svg";
import leaveIcon from "./leave.svg";
import ButtonSetting from "../ButtonSetting/ButtonSetting";
import { Logout } from "../../services/AuthorizationService";


interface IMenuBurgerProps{
    menuBurgerState:boolean
    onMouseLeave?:(e:React.MouseEvent<HTMLDivElement>) => void
}


export default function MenuBurger({menuBurgerState,
    onMouseLeave}:IMenuBurgerProps){

    let classNameMenuBurger:string = "menuBurger"   

    if(menuBurgerState){
        classNameMenuBurger = "menuBurger activeMenu"
    }

    const leaveButtonHandler = async (e:React.MouseEvent<HTMLButtonElement>) => {
        if(await Logout() === 200){
            window.location.href = "/login";
        }
    }

    return(
       <div className={classNameMenuBurger}
            onMouseLeave={onMouseLeave}>
            <ButtonSetting text="Контакты" image={userIcon}/>
            <ButtonSetting text="Сохраненнные сообщения" image={bookmarkIcon}/>
            <ButtonSetting text="Настройки" image={settingIcon}/>
            <ButtonSetting text="Выход" onClick={leaveButtonHandler} image={leaveIcon}/>
            <div className="messengerVersion">PowerMessenger 0.0.1</div>
       </div>
    )
}