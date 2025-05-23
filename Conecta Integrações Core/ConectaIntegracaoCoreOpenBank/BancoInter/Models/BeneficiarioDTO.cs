﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models
{
    public class BeneficiarioDTO
    {
        public string nome { get; set; }
        public string cpfCnpj { get; set; }
        public string tipoPessoa { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
    }
}
