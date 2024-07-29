import { Component, OnInit } from '@angular/core';
import { Endereco } from 'src/app/common/endereco';
import { EnderecoService } from 'src/app/services/endereco.service';

@Component({
  selector: 'app-endereco-list',
  templateUrl: './endereco-list.component.html',
  styleUrls: ['./endereco-list.component.css']
})
export class EnderecoListComponent implements OnInit {

  enderecos: Endereco[] = [];

  constructor(private enderecoService: EnderecoService) { }

  ngOnInit(): void {

    this.ListEndereco();

  }

  ListEndereco() {
    this.enderecoService.getEndereco().subscribe(
      data => {
        this.enderecos = data;
      }
    );
  }
}
