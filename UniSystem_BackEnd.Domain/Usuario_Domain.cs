using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem_BackEnd.Domain
{
    public class Usuario_Domain
    {
        public long Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Login { get; set; }
        public required DateTime Dt_Nascimento { get; set; }
        public DateTime Dt_Criacao { get; set; }
    }
}
