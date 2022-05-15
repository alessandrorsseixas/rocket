import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from '../../shared/models/cliente.model';
import { Portes } from '../../shared/models/porte.model';
import { ClienteService } from '../../shared/services/cliente.service';
import { PorteService } from '../../shared/services/porte.service';

@Component({
  selector: 'app-cliente-update',
  templateUrl: './cliente-update.component.html',
  styleUrls: ['./cliente-update.component.css']
})
export class ClienteUpdateComponent implements OnInit,AfterViewInit {
  cliente:Cliente={
    nome :'',
    porte:''
  };

  clientes!:Cliente[]
  portes!:Portes[]
  constructor(private clienteService:ClienteService,
              private porteSercvice:PorteService,
              private router:Router,
              private route:ActivatedRoute) {

                const id = this.route.snapshot.paramMap.get('id') as string
                this.clienteService.getById(id).subscribe(webApiReturn =>{
                    this.cliente = webApiReturn.data[0];
                })
               }

  ngOnInit(): void {
    
    this.porteSercvice.get().subscribe(portes=>{

      this.portes = portes

    })
  }

  ngAfterViewInit(): void {

   
  }


 

  updateCliente():void{
      this.clienteService.update(this.cliente).subscribe(WebApiReturn=>{
          
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
