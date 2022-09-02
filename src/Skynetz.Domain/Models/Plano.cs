using System;
using System.Collections.Generic;
using System.Text;

namespace Skynetz.Domain.Models
{
    public class Plano : BaseEntity
    {
        public Plano() { }
        public Plano(string nome, int minutos)
        {
            ValidarDados(nome, minutos);
            Nome = nome;
            Minutos = minutos;
        }

        public string Nome { get; set; }

        public int Minutos { get; set; }

        public void Update(string nome, int minutos)
        {
            ValidarDados(nome, minutos);
        }
        public void ValidarDados(string nome, int minutos)
        {
            if (String.IsNullOrEmpty(nome))
                throw new Exception("O nome do plano é inválido");

            if (minutos == default) throw new Exception("A quantidade de minutos informada é inválida.");
        }
        public int DescontarMinutos(int tempo)
        {
            if (tempo <= Minutos) return 0;
            else return (tempo - Minutos);
        }
    }
}
