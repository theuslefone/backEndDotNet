﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models.Usuario
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage ="O login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

    }
}
