using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Estado
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Foto { get; set; }
        public Pais Pais { get; set; }
        public int IdPais { get; set; }
    }
}
