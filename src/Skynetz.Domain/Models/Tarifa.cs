using System;
using System.Collections.Generic;
using System.Text;

namespace Skynetz.Domain.Models
{
    public class Tarifa : BaseEntity
    {
        public Tarifa() { }
        public Tarifa(string origem, string destino, decimal tarifaMinuto)
        {
            ValidarDados(origem, destino, tarifaMinuto);
            Origem = origem;
            Destino = destino;
            TarifaMinuto = tarifaMinuto;
        }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public decimal TarifaMinuto { get; set; }

        public void Update(string origem, string destino, decimal tarifaMinuto)
        {
            ValidarDados(origem, destino, tarifaMinuto);
        }
        private void ValidarDados(string origem, string destino, decimal tarifaMinuto)
        {
            if (string.IsNullOrEmpty(origem))
                throw new InvalidOperationException("A origem informada é inválida.");

            if (string.IsNullOrEmpty(destino))
                throw new InvalidOperationException("O destino informado é inválido.");

            if(tarifaMinuto <= 0)
                throw new InvalidOperationException("A tarifa informada deve ser maior ou igual a zero.");
        }

        public decimal CalcularTarifa(int minutos)
        {
            return minutos * TarifaMinuto;
        }
    }
}
