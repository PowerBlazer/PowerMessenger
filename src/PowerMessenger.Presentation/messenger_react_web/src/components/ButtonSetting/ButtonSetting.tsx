import "./buttonSetting.css";

export interface IButtonSettingProps{
    image:string,
    text:string,
    color?:string,
    onClick?:(e:React.MouseEvent<HTMLButtonElement>)=>void,
}

export default function ButtonSetting({image,text,color,onClick}:IButtonSettingProps){
    return(
        <button type="button" onClick={onClick} className="menuBurgerButton">
            <div>
                <img src={image} alt="menu" width={18} height={18}></img>
                <span style={{color:color}}>{text}</span>
            </div>
        </button>
    )
}