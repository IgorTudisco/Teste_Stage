import { Component, OnInit } from '@angular/core';
import { Candidato } from 'src/app/common/candidato';
import { CandidatoService } from 'src/app/services/candidato.service';

@Component({
  selector: 'app-candidato-list',
  templateUrl: './candidato-list.component.html',
  styleUrls: ['./candidato-list.component.css']
})
export class CandidatoListComponent implements OnInit {

  candidatos: Candidato[] = [];

  constructor(private candidatoService: CandidatoService) { }

  ngOnInit(): void {

    this.ListCandidato();

  }

  ListCandidato() {
    this.candidatoService.getCandidato().subscribe(
      data => {
        this.candidatos = data;
      }
    );
  }
}
