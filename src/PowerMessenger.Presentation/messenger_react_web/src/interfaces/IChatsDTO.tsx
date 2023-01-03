export default interface IChatsDTO{
    chatId:number
    name:string
    lastMessage:string
    lastMessageOwner:string
    lastMessageTime:string
    countUnReadMessages:number
    chatPhoto:string
    countParticipants:number
}