export interface IMessageDTO{
    id:number,
    content:string,
    dateCreate:string,
    messageOwner:string,
    messageOwnerAvatar:string
    isRead:boolean,
    isOwner:boolean
}