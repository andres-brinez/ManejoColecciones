using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reactividad
{
    public class Cliente
    {

        public int Id { get; set; }
        public string name { get; set; }


        public Cliente(int id, string name)
        {
            Id = id;
            this.name = name;
        }
    }
}
