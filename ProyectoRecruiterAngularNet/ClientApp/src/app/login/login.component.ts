import { Component } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login.component.html'
})

export class LoginComponent {

  constructor(private servicioProceso: UsuarioService)
  {

    servicioProceso.dameUsuarios().subscribe(res => { console.log(res) });

  }
}
