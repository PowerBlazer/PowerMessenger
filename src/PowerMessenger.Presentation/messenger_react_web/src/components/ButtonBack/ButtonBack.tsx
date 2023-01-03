import "./buttonBack.css";

interface IButtonBackProps{
    onClick?:(e:React.MouseEvent<HTMLButtonElement>) => void
}

export default function ButtonBack({onClick}:IButtonBackProps){
    return(
        <button className="buttonBack" onClick={onClick}>
            
        </button>
    )
}