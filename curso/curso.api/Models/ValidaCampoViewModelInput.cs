using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models
{
    public class ValidaCampoViewModelInput
    {
        public IEnumerable<string> Erros { get; private set; }

        public ValidaCampoViewModelInput(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }                   
}
