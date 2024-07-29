import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EntrevistaListComponent } from './components/entrevista-list/entrevista-list.component';
import { HttpClientModule } from '@angular/common/http';
import { EntrevistaService } from './services/entrevista.service';

@NgModule({
  declarations: [
    AppComponent,
    EntrevistaListComponent
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
