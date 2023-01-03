import "./searchInput.css";
import searchIcon from "./searchIcon.svg";

interface ISearchInputProps{
    onFocus?:(e:React.FocusEvent<HTMLInputElement>) => void
    onBlur?:(e:React.FocusEvent<HTMLInputElement>)=> void
}

export default function SearchInput({onFocus,onBlur}:ISearchInputProps){


    return(
        <div className="searchPanel">
            <img src={searchIcon} width={25} height={25} alt="search"></img>
            <input onFocus={onFocus} onBlur={onBlur} type="text" 
                placeholder="Поиск" className="searchInput"></input>
        </div>   
    )
}