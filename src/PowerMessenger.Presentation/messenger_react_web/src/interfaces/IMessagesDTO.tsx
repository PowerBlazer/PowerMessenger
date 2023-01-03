import { IMessageDTO } from "./IMessageDTO";

export interface IMessagesDTO{
    messages:IMessageDTO[],
    countUnReadMessages:number,
}