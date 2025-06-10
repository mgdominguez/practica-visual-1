using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculadoraMVVM.Models
{
    public class Calculadora
    {
        public Int64 Id { get; set; }
        public Int64 Numero1 { get; set; }
        public Int64 Numero2 { get; set; }
        public string Operacion { get; set; }
        public Int64 Resultado { get; set; }
    }
}