using System.ComponentModel.DataAnnotations;

namespace razorpages_alunos.Models
{
    public class AlunoModel
    {

        [Key]
        public int Id { get; set; }
        public String? Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

    }
}