using System.ComponentModel.DataAnnotations;

namespace Teste_Stage.Models;

public class Candidato
{
    [Key]
    [Required(ErrorMessage = "Campo id é obrigatório")]
    private int id;

    [Required(ErrorMessage = "Campo name é obrigatório")]
    private String name;

    //[Required(ErrorMessage = "Campo genero é obrigatório")]
    //private String genero;

    [Required(ErrorMessage = "Campo numeroContato é obrigatório")]
    private String numeroContato;

    [Required(ErrorMessage = "Campo email é obrigatório")]
    private String email;

    [Required(ErrorMessage = "Campo endereco é obrigatório")]
    private String endereco;

    [Required(ErrorMessage = "Campo description é obrigatório")]
    [MaxLength(250, ErrorMessage = "O tamanho da description não pode passar de 250 caracteres")]
    private String description;

    public Candidato()
    {
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    //public string Genero { get => genero; set => genero = value; }
    public string NumeroContato { get => numeroContato; set => numeroContato = value; }
    public string Email { get => email; set => email = value; }
    public string Endereco { get => endereco; set => endereco = value; }
    public string Description { get => description; set => description = value; }
}
