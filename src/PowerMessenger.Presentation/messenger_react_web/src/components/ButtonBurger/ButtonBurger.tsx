import React from "react";
import "./buttonBurger.css";


interface IButtonBurgerProps{
    colorLines?:string,
    menuWindowState?:boolean
    onClick?:(e:React.MouseEvent<HTMLButtonElement>)=> void,
}



export default function ButtonBurger({onClick,colorLines
    ,menuWindowState}:IButtonBurgerProps){

    return(
        <button className={"buttonBurger"} 
            style={{backgroundColor:menuWindowState ? ("rgba(255,255,255,0.125)"):("")}} 
            type="button" onClick={onClick} >
                
            <div style={{backgroundColor:colorLines}}></div>
            <div style={{backgroundColor:colorLines}}></div>
            <div style={{backgroundColor:colorLines}}></div>
        </button>
    )
}