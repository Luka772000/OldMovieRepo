import { NgModule , Inject} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule  } from '@angular/forms';
import { AppComponent } from './app.component';
import { FilmComponent } from './film/film.component';
import { FilmFormComponent } from './film/film-form/film-form.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import{ MatDialogModule, MatDialogRef, MAT_DIALOG_DATA} from "@angular/material/dialog"
import {MatCardModule} from"@angular/material/card"
import { WavesModule, TableModule } from 'angular-bootstrap-md';
import {MatInputModule} from '@angular/material/input'
import {MatTableModule} from '@angular/material/table';
import { NovaComponent } from './nova/nova.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { LayoutModule } from '@angular/cdk/layout';
import { TablicaComponent } from './tablica/tablica.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { NAVIGACIJAComponent } from './navigacija/navigacija.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import {RoutingModule, routingComponents} from './routing/routing.module';
import { GlumciComponent } from './glumci/glumci.component'


@NgModule({
  declarations: [
    AppComponent,
    FilmComponent,
    FilmFormComponent,
    NovaComponent,
    TablicaComponent,
    NAVIGACIJAComponent,
    routingComponents,
    GlumciComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgbModule,
    MatDialogModule,
    MatCardModule,
    WavesModule,
    TableModule,
    MatInputModule,
    MatTableModule,
    RoutingModule,
    MatGridListModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    LayoutModule,
    MatPaginatorModule,
    MatSortModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    RoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
