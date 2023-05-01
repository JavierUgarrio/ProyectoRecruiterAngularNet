import { Component, OnInit } from '@angular/core';
import { ProcesoService } from '../services/proceso.service';

@Component({
  selector: 'app-proceso-component',
  templateUrl: './proceso.component.html'
})

export class ProcesoComponent implements OnInit {

  public listaProcesos!: any[];
  constructor(private servicioProceso: ProcesoService) {

  }
  
  ngOnInit(): void {
    this.dameProcesos()
  }

  dameProcesos() {
    this.servicioProceso.dameProcesos().subscribe(res => {
      this.listaProcesos = res.objetoGenerico;
      console.log(this.listaProcesos);
    });


  }
}
