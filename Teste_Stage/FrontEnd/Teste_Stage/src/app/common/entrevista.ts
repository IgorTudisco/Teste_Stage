import { Candidato } from "./candidato";

export class Entrevista {
  id: number;
  cargo: string;
  fitCultral: string;
  testeFeito: boolean;
  pontuacaoTest: number;
  readCandidatoDto: Candidato[];

  constructor(
    id: number,
    cargo: string,
    fitCultral: string,
    testeFeito: boolean,
    pontuacaoTest: number,
    readCandidatoDto: Array<Candidato>
  ) {
    this.id = id;
    this.cargo = cargo;
    this.fitCultral = fitCultral;
    this.testeFeito = testeFeito;
    this.pontuacaoTest = pontuacaoTest;
    this.readCandidatoDto = readCandidatoDto;
  }
}
