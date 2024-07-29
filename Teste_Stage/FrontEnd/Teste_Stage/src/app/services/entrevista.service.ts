import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Entrevista } from '../common/entrevista';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EntrevistaService {

  private baseUrl = 'https://localhost:7284/entrevista?skip=0&take=100'

  constructor(private httpClient: HttpClient) { }

  getEntrevista(): Observable<Entrevista[]> {
    return this.httpClient.get<GetResponse>(this.baseUrl).pipe(
      map(response => response._embedded.entrevistas)
    );
  }

}

interface GetResponse {
  _embedded: {
    entrevistas: Entrevista[];
  };
}
