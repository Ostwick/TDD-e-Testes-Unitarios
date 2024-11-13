using System;
using System.Collections.Generic;

namespace Calculadora
{
    public class Calculadora
    {
        // Armazena o histórico das operações realizadas
        private List<string> listaHistorico;
        // Armazena a data de criação da instância da calculadora
        private string data;

        // Construtor que inicializa a lista de histórico e define a data
        public Calculadora(string data)
        {
            listaHistorico = new List<string>();
            this.data = data;
        }

        // Método para somar dois valores inteiros
        public int Somar(int valor1, int valor2)
        {
            int resultado = valor1 + valor2;
            AdicionarAoHistorico("Somar", valor1, valor2, resultado);
            return resultado;
        }
        
        // Método para subtrair dois valores inteiros
        public int Subtrair(int valor1, int valor2)
        {
            int resultado = valor1 - valor2;
            AdicionarAoHistorico("Subtrair", valor1, valor2, resultado);
            return resultado;
        }

        // Método para multiplicar dois valores inteiros
        public int Multiplicar(int valor1, int valor2)
        {
            int resultado = valor1 * valor2;
            AdicionarAoHistorico("Multiplicar", valor1, valor2, resultado);
            return resultado;
        }

        // Método para dividir dois valores inteiros, considerando a exceção para divisão por zero
        public int Dividir(int valor1, int valor2)
        {
            if (valor2 == 0) throw new DivideByZeroException("Não é possível dividir por zero.");
            int resultado = valor1 / valor2;
            AdicionarAoHistorico("Dividir", valor1, valor2, resultado);
            return resultado;
        }

        // Método que retorna o histórico das últimas três operações
        public List<string> Historico()
        {
            // Garante que a lista tenha no máximo 3 itens, ajustando a contagem se necessário
            if (listaHistorico.Count > 3)
            {
                listaHistorico = listaHistorico.GetRange(0, 3);
            }
            return listaHistorico;
        } 

        // Método auxiliar para adicionar uma operação ao histórico
        private void AdicionarAoHistorico(string operacao, int valor1, int valor2, int resultado)
        {
            // Formata a entrada de histórico com os detalhes da operação e data
            string entradaHistorico = $"Operação: {operacao}, Valores: {valor1} e {valor2}, Resultado: {resultado}, Data: {data}";
            listaHistorico.Insert(0, entradaHistorico);
        }
    }
}
