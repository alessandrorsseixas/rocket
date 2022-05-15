import { Router } from '@angular/router';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { ClienteService } from '../../shared/services/cliente.service';
import { ClienteReadDataSource, ClienteReadItem } from './cliente-read-datasource';

@Component({
  selector: 'app-cliente-read',
  templateUrl: './cliente-read.component.html',
  styleUrls: ['./cliente-read.component.css']
})
export class ClienteReadComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<ClienteReadItem>;
  dataSource: ClienteReadDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['nome','porte','editar','excluir'];

  constructor(private clienteService:ClienteService,private router:Router) {
    this.dataSource = new ClienteReadDataSource();
  }

  ngAfterViewInit(): void {

    this.clienteService.getAll(0,10,'',true,'').subscribe(webApireturn=>{
      if(webApireturn.transactionExecute){

        this.loadData(webApireturn.data); 
      }else{

        console.log(webApireturn);
      }
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
      
    })

    
    
  }

  loadData(data:ClienteReadItem[]):void{

      this.dataSource.data = data

  }


  editCliente(id:string):void{
    this.router.navigate([`update/${id}`])
  } 

  deleteCliente(id:string):void{
      this.clienteService.delete(id).subscribe(webApiReturn=>{
          
        if(webApiReturn.transactionExecute){

            window.location.reload();

          }else{

              console.log(webApiReturn);
          }

      })

  }
}
