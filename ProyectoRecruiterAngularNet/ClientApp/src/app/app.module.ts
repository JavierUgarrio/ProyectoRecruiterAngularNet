import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; //ReactiveFormModule, son formularios controlados por plantillas
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { InicioComponent } from './inicio/inicio.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { LoginComponent } from './login/login.component';
import { ProcesoComponent } from './proceso/proceso.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    InicioComponent,
    UsuarioComponent,
    LoginComponent,
    ProcesoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: InicioComponent, pathMatch: 'full' },
      { path: 'inicio', component: InicioComponent },
      { path: 'usuario', component: UsuarioComponent },
      { path: 'login', component: LoginComponent },
      { path: 'proceso', component: ProcesoComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
