using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FlexCliente
{
    internal abstract class ACliente
    {
        private readonly int Id;
        protected readonly string Nome;

        public ACliente(string nome)
        {
            string nomeSanitizado = Sanitizar(nome);
            if (!NomeEhValido(nomeSanitizado)) {
                throw new ArgumentException($"Argumento 'nome'='{nome}' inválido!");
            }

            Nome = nomeSanitizado;
        }

        private bool NomeEhValido(string nome)
        {
            if(String.IsNullOrEmpty(nome) ||
                String.IsNullOrWhiteSpace(nome))
            {
                return false;
            }
            return true;
        }

        private string Sanitizar(string nome)
        {
            string pattern = "\\p{L}\\s."; //Válido: UTF-8, espaço e . (ponto)

            // Flag ^: Remove o que não for válido
            return Regex.Replace(nome, @$"[^{pattern}]", string.Empty).Trim();
        }
        public abstract string GetNome();
    }
}
