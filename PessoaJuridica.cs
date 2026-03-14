
using System.Text.RegularExpressions;

namespace FlexCliente
{
    internal class PessoaFisica : Cliente
    {
        private readonly string CPF;
        public PessoaFisica(string nome, string cpf) : base(nome)
        {
            string cpfSanitizado = Sanitizar(cpf);
            if (!CPFEhValido(cpfSanitizado))
            {
                throw new ArgumentException($"Argumento 'CPF'='{cpf}' inválido!");
            }

            this.CPF = cpfSanitizado;
        }
        private bool CPFEhValido(string cpf)
        {
            if (String.IsNullOrEmpty(cpf) ||
                String.IsNullOrWhiteSpace(cpf) ||
                cpf.Length != 11)
            {
                return false;
            }
            return true;
        }

        private string Sanitizar(string cpf)
        {
            string pattern = "0-9"; //Válido: 0-9

            // Flag ^: Remove o que não for válido
            return Regex.Replace(cpf, @$"[^{pattern}]", string.Empty).Trim();
        }

        private string Formatar()
        {
            return $"{CPF.Substring(0, 3)}.{CPF.Substring(3, 3)}.{CPF.Substring(6, 3)}-{CPF.Substring(9)}";
        }
        public string GetNome()
        {
            return $"{base.GetNome()} (CPF {Formatar()})";
        }

    }
}
