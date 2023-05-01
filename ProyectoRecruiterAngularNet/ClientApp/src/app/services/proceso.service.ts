// Podre inyectar servicios en diferentes componentes directamente en el constructor
import { Injectable } from '@angular/core';
// Agrego la libreria para realizar las peticiones "get, post, put"
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';

@Injectable
  ({
    providedIn: 'root'
  })

export class ProcesoService {
  //En constructo aplicamos la libreria HttpClient y podre hacer `peticiones a mi API`
  //Se trata de un servicio preparado para hacer la consultad a la parte de .net

  url: string = 'https://localhost:7269/API/procesos/';
  constructor(private peticion: HttpClient) {

  }

  dameProcesos(): Observable<Resultado> {
    return this.peticion.get<Resultado>(this.url);

  }

}
