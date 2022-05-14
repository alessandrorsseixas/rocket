using ClienteApi.Domain.SeedWorks.AbstractClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApi.Domain.Entities
{
    public class Cliente :Entity
    {
       
        public string Nome { get; set; }

        public string Porte { get; set; }


    }
}
