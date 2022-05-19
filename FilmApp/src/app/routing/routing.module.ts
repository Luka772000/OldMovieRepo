import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { Film } from '../shared/film.model';
import { FilmComponent } from '../film/film.component';
import { AppComponent } from '../app.component';
import { RouterModule } from '@angular/router';
import { TablicaComponent } from '../tablica/tablica.component';
import { NovaComponent } from '../nova/nova.component';
import { GlumciComponent } from '../glumci/glumci.component';
const routes: Routes = [
  {path: 'filmovi',component: FilmComponent},
  {path: 'glumci', component: GlumciComponent},
  {path: 'tablica', component: TablicaComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class RoutingModule { }
export const routingComponents = [FilmComponent,AppComponent]
