import { Timestamp } from "rxjs";


export interface WebApiReturn {

    transactionExecute:boolean,
    statusCode:number,
    messageCode:number,
    messageTitle:string,
    message:string,
    data:Array<any>,
    errors:Array<any>,
    currentPage:number,
    totalItems:number,
    totalPages:number,
    processingTime:string,
}

