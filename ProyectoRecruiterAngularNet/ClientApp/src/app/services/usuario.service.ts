// Podre inyectar servicios en diferentes componentes directamente en el constructor
import { Injectable } from '@angular/core';
// Agrego la libreria para realizar las peticiones "get, post, put"
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resultado } from '../modelos/resultado';
import { Usuario } from '../modelos/usuario';


@Injectable
  ({
    providedIn: 'root'
  })

export class UsuarioService
{
  //En constructo aplicamos la libreria HttpClient y podre hacer `peticiones a mi API`
  //Se trata de un servicio preparado para hacer la consultad a la parte de .net

  url: string = 'https://localhost:7269/API/usuarios/';
  constructor(private peticion: HttpClient)
  {

  }
  dameUsuarios(): Observable<Resultado>
  {
    return this.peticion.get<Resultado>(this.url);

  }
  /*
   * Servicio preparado para enviar la peticion a la api
   */
  agregarUsuario(usuario: Usuario): Observable<Resultado>
  {
    return this.peticion.post<Resultado>(this.url, usuario);
  }
  /*
   * Servicio preparado para enviar la peticion a la api
   */
  //modificarUsuario(usuario: Usuario): Observable<Resultado> {
  //  return this.peticion.put<Resultado>(this.url, usuario);
  //}

  /*
   * Servicio preparado para enviar la peticion a la api
   */
  eliminarUsuario(email: string): Observable<Resultado> {
    return this.peticion.delete<Resultado>(this.url + email);
  }
}
