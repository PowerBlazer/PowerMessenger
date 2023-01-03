import React, { useContext, useState } from "react";
import ButtonBurger from "../../components/ButtonBurger/ButtonBurger";
import SearchInput from "../../components/SearchInput/SearchInput";
import MenuBurger from "../../components/MenuBurger/MenuBurger";
import "./chatPanelHeader.css";
import { MainPanelContext } from "../../contexts/MainPanelComtext";
import SearchPanel from "../../panels/SearchPanel/SearchPanel";
import { ButtonMenuContext } from "../../contexts/ButtonMenuContext";
import ButtonBack from "../../components/ButtonBack/ButtonBack";
import Chats from "../../components/Chats/Chats";



export default function ChatsPanelHeader(){

    const [menuWindowState,setMenuWindowState] = useState<boolean>(false);
    const [buttonMenuState,setButtonMenuState] = useState<boolean>(true);

    const {toogleWindow} = useContext(MainPanelContext);
   

    const burgerButtonClickHandler = (e:React.MouseEvent<HTMLButtonElement>):void => {
        setMenuWindowState(menuWindowState => menuWindowState ? (false):(true))
    }

    const burgerMenuMouseOutHandler = (e:React.MouseEvent<HTMLDivElement>):void =>{
        setTimeout(()=>{
           setMenuWindowState(menuWindowState=>menuWindowState = false);
        },300);
    }

    const searchInputFocusHandler = (e:React.FocusEvent<HTMLInputElement>):void =>{
        toogleWindow!(element=>element = <SearchPanel />);
        setButtonMenuState(isBack=> isBack = false);
    }

    const backInChatsHandler = (e:React.MouseEvent<HTMLButtonElement>):void =>{
        toogleWindow!(element=>element = <Chats />)
        setButtonMenuState(isBack=> isBack = true);
    } 

    const buttonMenu = buttonMenuState ? (
        <ButtonBurger  colorLines={"#AAAAAA"} 
            menuWindowState={menuWindowState} 
            onClick={burgerButtonClickHandler}
        />
    ) : 
    (
        <ButtonBack onClick={backInChatsHandler}/>
    );

    

    return(
        <div className="chats_header">
            <ButtonMenuContext.Provider value={{
                toogleButton:setButtonMenuState,
                isBack:buttonMenuState
            }}>
                {buttonMenu}
            </ButtonMenuContext.Provider>
            <SearchInput onFocus={searchInputFocusHandler}
            />
            <MenuBurger menuBurgerState={menuWindowState}
                onMouseLeave={burgerMenuMouseOutHandler}
            />
        </div>
    )
}