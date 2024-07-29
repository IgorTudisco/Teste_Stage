import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Endereco } from '../common/endereco';

@Injectable({
  providedIn: 'root'
})
export class EnderecoService {

  private baseUrl = 'https://localhost:7284/endereco?skip=0&take=100'

  constructor(private httpClient: HttpClient) { }

  getEndereco(): Observable<Endereco[]> {
    return this.httpClient.get<GetResponse>(this.baseUrl).pipe(
      map(response => response._embedded.entrevistas)
    );
  }

}

interface GetResponse {
  _embedded: {
    entrevistas: Endereco[];
  };
}
