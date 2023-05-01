import { Component, Input,OnInit } from '@angular/core'
//Importa para recoger los datos de otros componentes
import { ActivatedRoute } from '@angular/router'
import { Usuario } from '../modelos/usuario';
import { UsuarioService } from '../services/usuario.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-usuario-component',
  templateUrl: './usuario.component.html'
})

export class UsuarioComponent {
   //Nombre del formulario
  altaForm!: FormGroup;
  enviado= false;

  constructor(private servicioUsuario: UsuarioService, private formBuilder: FormBuilder)
  {
    
  }
  //Validadores del formulario

  ngOnInit(): void
  {
    this.altaForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      apellidos: ['', Validators.required],
      telefono: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      password: ['', Validators.required],
    })
  }
  //Controladores del formulario

  get f(): {[key: string]: AbstractControl } {
    return this.altaForm.controls;
  }

  public Alta() {

    this.enviado = true;
    if (this.altaForm.invalid) {
      console.log("INVALIDO");
      return;
    }
    console.log("valido");
    /*
     * Objeto para enviar
     */
    let usuario: Usuario = {
      nombre: this.altaForm.controls['nombre'].value,
      apellidos: this.altaForm.controls['apellidos'].value,
      email: this.altaForm.controls['email'].value,
      password: this.altaForm.controls['password'].value,
      telefono: this.altaForm.controls['telefono'].value
    };

    /*
     * Llamada a la servicio.usuario y desde ahi se llama a la api
     */
    this.servicioUsuario.agregarUsuario(usuario).subscribe(res => {
      if (res.error != null && res.error != '') 
        console.log(res.error);
      else
        console.log("Todo correcto");

    });
    /*
     * Llamada a la servicio.usuario y desde ahi se llama a la api
     */
    //this.servicioUsuario.modificarUsuario(usuario).subscribe(res => {
    //  if (res.error != null && res.error != '')
    //    console.log(res.error);
    //  else
    //    console.log("Todo correcto");

    //});

    //this.servicioUsuario.eliminarUsuario(this.altaForm.controls['email'].value).subscribe(res => {
    //  if (res.error != null && res.error != '')
    //    console.log(res.error);
    //  else
    //    console.log("eliminado");

    //});

  }
}

