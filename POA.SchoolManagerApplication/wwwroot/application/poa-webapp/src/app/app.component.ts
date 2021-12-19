import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ColDef } from 'ag-grid-community';
import { ResponseType } from '../response/response';
import { ReadingComponent } from './app-reading';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'poa-webapp';

  columnDefs: ColDef[] = [
    { field: 'Nome', sortable: true, filter: true, resizable: true },
    { field: 'Abr_Nome', sortable: true, filter: true, resizable: true },
    { field: 'Tipo', sortable: true, filter: true, resizable: true },
    { field: 'Dep_Admionistrativa', sortable: true, filter: true, resizable: true },
    { field: 'Bairro', sortable: true, filter: true, resizable: true },
    { field: 'Numero', sortable: true, filter: true, resizable: true },
    { field: 'Cep', sortable: true, filter: true, resizable: true },
    { field: 'Email', sortable: true, filter: true, resizable: true },
    { field: 'Url_WebSite', sortable: true, filter: true, resizable: true },
    { field: 'Telefone', sortable: true, filter: true, resizable: true }
  ];

  rowData: Observable<any[]>;

  constructor(private http: HttpClient) {
    this.rowData = this.http.get<any[]>("");
    this.GetAll();
  }

  async GetAll() {
    let url = "https://localhost:44350/api/v1/Schools";

    let response: ResponseType = {
      message: "",
      help: "",
      success: false,
      ApiResult: [],
      result: []
    }

    await fetch(url).then(data => data.json()).then(data => {
      response = data;
    })

    if (response.success) {
      let data = response.result.records;
      this.rowData = data;
    } else {
      alert(response.message);
      let _jsonUrl = '../data/data.json';
      let reader: ReadingComponent = new ReadingComponent(this.http);
      console.log(reader.getJSON());
      this.http.get
    }
  }
}


