
interface IContainerProps{
    children?:React.ReactNode
}

export default function Container({children}:IContainerProps){

    const style:React.CSSProperties = {
        maxWidth:1700,
        margin:"0 auto"
    }


    return(
        <div style={style} className="container">
            {children}
        </div>
    )
}