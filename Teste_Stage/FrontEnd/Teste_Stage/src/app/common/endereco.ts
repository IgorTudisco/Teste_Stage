export class Endereco {
  id: number;
  logradouro: string;
  numero: string;
  cidade: string;
  estado: string;
  uf: string;

  constructor(
    id: number,
    logradouro: string,
    numero: string,
    cidade: string,
    estado: string,
    uf: string
  ) {
    this.id = id;
    this.logradouro = logradouro;
    this.numero = numero;
    this.cidade = cidade;
    this.estado = estado;
    this.uf = uf;
  }
}
