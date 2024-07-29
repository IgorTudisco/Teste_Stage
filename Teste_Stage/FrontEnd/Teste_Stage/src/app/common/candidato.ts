import { Endereco } from "./endereco";

export class Candidato {
  id: number;
  nome: string;
  genero: string;
  numeroContato: string;
  email: string;
  descricao: string;
  readEnderecoDto: Endereco;

  constructor(
    id: number,
    nome: string,
    genero: string,
    numeroContato: string,
    email: string,
    descricao: string,
    readEnderecoDto: Endereco
  ) {
    this.id = id;
    this.nome = nome;
    this.genero = genero;
    this.numeroContato = numeroContato;
    this.email = email;
    this.descricao = descricao;
    this.readEnderecoDto = readEnderecoDto;
  }
}
