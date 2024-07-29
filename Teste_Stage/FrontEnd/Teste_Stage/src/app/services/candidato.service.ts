import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Candidato } from '../common/candidato';

@Injectable({
  providedIn: 'root'
})
export class CandidatoService {
  private baseUrl = 'https://localhost:7284/entrevista?skip=0&take=100'

  constructor(private httpClient: HttpClient) { }

  getCandidato(): Observable<Candidato[]> {
    return this.httpClient.get<GetResponse>(this.baseUrl).pipe(
      map(response => response._embedded.entrevistas)
    );
  }

}

interface GetResponse {
  _embedded: {
    entrevistas: Candidato[];
  };
}
