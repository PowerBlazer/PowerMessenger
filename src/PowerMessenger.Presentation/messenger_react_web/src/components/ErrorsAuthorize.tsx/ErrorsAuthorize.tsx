import ErrorAuthorize from "../ErrorAuthorize/ErrorAuthorize";


interface IProps{
    errors:string[]
}



function ErrorsAuthorize({errors}:IProps){
    return(  
    <ul style={{display:'flex',flexDirection:'column',gap:"10px",color:"red",fontFamily:"Inter"}}>
        {errors.map((error,index)=>
            <ErrorAuthorize error={error} key={index}/>
        )}
    </ul>
    )
}

export default ErrorsAuthorize;