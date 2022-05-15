import { ResourceModel } from "./resource.model";


export interface Cliente extends ResourceModel<Cliente>{
    code?:string,
    nome:string,
    porte:string
}