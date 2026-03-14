
using FlexCliente;

try
{
    ACliente ana = new PessoaFisica("Ana H. Nuñes Beatriz8@", "981.779.988-38");
    Console.WriteLine($"PF: {ana.GetNome()}");
}
catch (ArgumentException e)
{
    Console.WriteLine($"Erro: {e.Message}");
}


try
{
    ACliente george = new PessoaFisica("George Carlos", "690.179.348-08");
    Console.WriteLine($"PF: {george.GetNome()}");
}
catch (ArgumentException e)
{
    Console.WriteLine($"Erro: {e.Message}");
}

try
{
    ACliente carlos = new PessoaFisica("Carlos Lacerda", "016.021.318-56");
    Console.WriteLine($"PF: {carlos.GetNome()}");
}
catch (ArgumentException e)
{
    Console.WriteLine($"Erro: {e.Message}");
}
