import { ResourceModel } from "./resource.model";

export interface Portes extends ResourceModel<Portes>{
    id?:string,
    nome:string
}