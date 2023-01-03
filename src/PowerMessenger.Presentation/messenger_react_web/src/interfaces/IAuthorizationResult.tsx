export default interface IAuthorizationResul{
    isSuccess:boolean,
    errors:string[],
    token?:string,
}