﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Bussines.Entites
{
    public class Curso
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public int CodigoUsuario { get; set; }
        public virtual Usuario usuario { get; set; }

    }
}
