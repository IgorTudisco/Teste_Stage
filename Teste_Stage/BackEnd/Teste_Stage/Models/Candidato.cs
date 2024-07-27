using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Models;

public class Candidato
{
    [Key]
    [Required(ErrorMessage = "Campo id é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo name é obrigatório")]
    public String Name { get; set; }

    [Required(ErrorMessage = "Campo genero é obrigatório")]
    [MaxLength(1, ErrorMessage = "O tamanho da description não pode passar de 1 caracteres")]
    public String Genero { get; set; }

    [Required(ErrorMessage = "Campo numeroContato é obrigatório")]
    public String NumeroContato { get; set; }

    [Required(ErrorMessage = "Campo email é obrigatório")]
    public String Email { get; set; }

    [Required(ErrorMessage = "Campo description é obrigatório")]
    [MaxLength(250, ErrorMessage = "O tamanho da description não pode passar de 250 caracteres")]
    public string descricao { get; set; }

    public int EnderecoId { get; set; }

    public virtual Endereco Endereco { get; set; }

    public Candidato()
    {
    }

}
