using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Pais
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Foto { get; set; }
        public List<Estado> Estados { get; set; }
    }
}
