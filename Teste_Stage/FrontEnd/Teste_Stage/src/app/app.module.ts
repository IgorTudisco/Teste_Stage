import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EntrevistaListComponent } from './components/entrevista-list/entrevista-list.component';
import { HttpClientModule } from '@angular/common/http';
import { EntrevistaService } from './services/entrevista.service';
import { CandidatoListComponent } from './components/candidato-list/candidato-list.component';
import { EnderecoListComponent } from './components/endereco-list/endereco-list.component';

@NgModule({
  declarations: [
    AppComponent,
    EntrevistaListComponent,
    CandidatoListComponent,
    EnderecoListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [EntrevistaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
