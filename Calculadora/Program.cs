using System;
using System.Collections.Generic;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancia a calculadora com a data atual
            string dataAtual = DateTime.Now.ToString();
            Calculadora calc = new Calculadora(dataAtual);

            // Realiza algumas operações e exibe os resultados
            int soma = calc.Somar(10, 5);
            Console.WriteLine($"Soma: 10 + 5 = {soma}");

            int subtracao = calc.Subtrair(10, 5);
            Console.WriteLine($"Subtração: 10 - 5 = {subtracao}");

            int multiplicacao = calc.Multiplicar(10, 5);
            Console.WriteLine($"Multiplicação: 10 * 5 = {multiplicacao}");

            try
            {
                int divisao = calc.Dividir(10, 5);
                Console.WriteLine($"Divisão: 10 / 5 = {divisao}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            // Exibe o histórico das últimas operações
            Console.WriteLine("\nHistórico das últimas operações:");
            List<string> historico = calc.Historico();
            foreach (string entrada in historico)
            {
                Console.WriteLine(entrada);
            }
        }
    }
}
