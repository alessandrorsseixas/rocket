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
  displayedColumns = ['nome','porte','acao'];

  constructor(private clienteService:ClienteService) {
    this.dataSource = new ClienteReadDataSource();
  }

  ngAfterViewInit(): void {

    this.clienteService.getAll(0,10,'',true,'').subscribe(webApireturn=>{
      if(webApireturn.transactionExecute){

        this.dataSource.data = webApireturn.data
      }else{

        console.log(webApireturn);
      }
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
      
    })

    
  }
}
