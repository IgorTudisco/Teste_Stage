import { Endereco } from "./endereco";
import { Entrevista } from "./entrevista";

export class Candidato {
  id?: number;
  name?: string;
  genero?: string;
  numeroContato?: string;
  email?: string;
  descricao?: string;
  readEnderecoDto: Endereco;
  readEntrevistaDto: Entrevista;

  constructor(
    id: number,
    name: string,
    genero: string,
    numeroContato: string,
    email: string,
    descricao: string,
    readEnderecoDto: Endereco,
    readEntrevistaDto: Entrevista
  ) {
    this.id = id;
    this.name = name;
    this.genero = genero;
    this.numeroContato = numeroContato;
    this.email = email;
    this.descricao = descricao;
    this.readEnderecoDto = readEnderecoDto;
    this.readEntrevistaDto = readEntrevistaDto;
  }
}
