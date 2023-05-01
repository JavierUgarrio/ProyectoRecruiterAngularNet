import { Component } from '@angular/core'
import { Router } from '@angular/router'

@Component({
  selector: 'app-inicio-component',
  templateUrl:'./inicio.component.html'
})

export class InicioComponent{

  public Ejemplo = "Inicio Headhunter";

  //Realizo el constructor del router para enlazar a otro componente
  constructor(private router: Router) { }

  //En este paso realizo el enlace del componente y a la par que añado el 'this.router.navigate(['/usuario'])' recojo los parametros
  public Navegar() {
    this.router.navigate(['/Procesos']);
  }
}
