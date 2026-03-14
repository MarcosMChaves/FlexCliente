
using System.Text.RegularExpressions;

namespace FlexCliente
{
    internal class PessoaFisica : ACliente, ISanitizar, ICalcularDV
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
                cpf.Length != 11 ||
                cpf.Substring(9, 2) != CalcularDV(cpf))
            {
                return false;
            }
            return true;
        }

        public string Sanitizar(string cpf)
        {
            string pattern = "0-9"; //Válido: 0-9

            // Flag ^: Remove o que não for válido
            return Regex.Replace(cpf, @$"[^{pattern}]", string.Empty).Trim();
        }

        private string Formatar()
        {
            return $"{CPF.Substring(0, 3)}.{CPF.Substring(3, 3)}.{CPF.Substring(6, 3)}-{CPF.Substring(9)}";
        }
        public override string GetNome()
        {
            return $"{base.Nome} (CPF {Formatar()})";
        }

        public string CalcularDV(string númeroCPF)
        {
            // Implementa o cálculo do Dígito Verificador do CPF (Google Gemini, 2026)
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = númeroCPF.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();

            return digito;
        }
    }
}
