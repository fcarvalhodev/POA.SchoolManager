import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
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
    { field: 'nome', sortable: true, filter: true, resizable: true },
    {
      field: 'logradouro', sortable: true, filter: true, resizable: true, cellRenderer: function (params: any) {
        let latitude = params.data.latitude;
        let longitude = params.data.longitude;
        let mapUrl = `https://www.google.com/maps/search/?api=1&query=${latitude},${longitude}`;
        return `<a title="Open Map" href="${mapUrl}" target="_blank">${params.value} <i class='fas fa-map-marker'></i></a>`
      }
    },
    { field: 'abr_nome', headerName: "Nome Abreviado", sortable: true, filter: true, resizable: true },
    { field: 'tipo', headerName: "Tipo", sortable: true, filter: true, resizable: true },
    { field: 'dep_administrativa', headerName: "Departamento Administrativo", sortable: true, filter: true, resizable: true },
    { field: 'bairro', headerName: "Bairro", sortable: true, filter: true, resizable: true },
    { field: 'numero', headerName: "Numero", sortable: true, filter: true, resizable: true },
    { field: 'cep', headerName: "Cep", sortable: true, filter: true, resizable: true },
    { field: 'email', headerName: "Email", sortable: true, filter: true, resizable: true },
    {
      field: 'url_website', headerName: "Site", sortable: true, filter: true, resizable: true, cellRenderer: function (params) {
        return `<a href="${params.value}" target="_blank">${params.value}</a>`
      }
    },
    { field: 'telefone', headerName: "Telefone", sortable: true, filter: true, resizable: true }
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
      window.console.clear();
      response = data;
    })

    if (response.success) {
      let data = response.result.records;
      this.rowData = of(data);
    } else {
      let resultado: boolean = window.confirm("The host is not responding, do you want to proceed with the static data ?");
      let _jsonUrl = '../data/data.json';
      if (resultado) {
        let reader: ReadingComponent = new ReadingComponent(this.http);
        let data: Observable<any[]> = reader.getJSON();
        this.rowData = data;
      }
    }
  }
}


