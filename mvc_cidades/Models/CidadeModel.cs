using System.ComponentModel.DataAnnotations;

namespace cidades.Models;

public class CidadeModel
{
    [Key]
    public int Id { get; set; }

    public String? Nome { get; set; }
    public String? Estado { get; set; }

}
