import { WebApiReturn } from './../../shared/models/webapireturn.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from '../../shared/models/cliente.model';
import { Portes } from '../../shared/models/porte.model';
import { ClienteService } from '../../shared/services/cliente.service';
import { PorteService } from '../../shared/services/porte.service';



@Component({
  selector: 'app-cliente-create',
  templateUrl: './cliente-create.component.html',
  styleUrls: ['./cliente-create.component.css']
})
export class ClienteCreateComponent implements OnInit {
  cliente:Cliente={
    nome :'',
    porte:''
  };

  portes!:Portes[]

  constructor(private clienteService:ClienteService,
              private porteSercvice:PorteService,
              private router:Router) { }

  ngOnInit(): void {

      this.porteSercvice.get().subscribe(portes=>{

        this.portes = portes

      })

  }


  createCliente():void{
    debugger;
      this.clienteService.create(this.cliente).subscribe(WebApiReturn=>{
          
        if(WebApiReturn.transactionExecute){

            this.router.navigate([''])

          }else{

              console.log(WebApiReturn)
          }

      })

  }
  
  cancel():void{

    this.router.navigate([''])

  }

}
