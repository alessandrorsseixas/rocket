import { ResourceModel } from "./resource.model";


export interface Cliente extends ResourceModel<Cliente>{
    nome:string,
    porte:string
}