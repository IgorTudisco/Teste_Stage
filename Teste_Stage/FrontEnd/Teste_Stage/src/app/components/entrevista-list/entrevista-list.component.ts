import { Component, OnInit } from '@angular/core';
import { Entrevista } from 'src/app/common/entrevista';
import { EntrevistaService } from 'src/app/services/entrevista.service';

@Component({
  selector: 'app-entrevista-list',
  templateUrl: './entrevista-list.component.html',
  styleUrls: ['./entrevista-list.component.css']
})
export class EntrevistaListComponent implements OnInit {

  entrevistas: Entrevista[] = [];

  constructor(private entrevistaService: EntrevistaService) { }

  ngOnInit(): void {

    this.ListEntrevista();

  }

  ListEntrevista() {
    this.entrevistaService.getEntrevista().subscribe(
      data => {
        this.entrevistas = data;
      }
    );
  }

}
