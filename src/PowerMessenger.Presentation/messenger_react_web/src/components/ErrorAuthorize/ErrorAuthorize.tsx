
interface IProp{
    error:string
}

function ErrorAuthorize({error}:IProp){
    return(
        <li>
            <div style={{fontSize:"14px"}}>{error}</div>
        </li>
    );
}

export default ErrorAuthorize;