using ClienteApi.Domain.SeedWorks.AbstractClass;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Domain.Entities
{
    [NotMapped]
    public class ClienteViewModel : EntityModel
    {
       

        public string Nome { get; set; }

        public string Porte { get; set; }


    }
}
