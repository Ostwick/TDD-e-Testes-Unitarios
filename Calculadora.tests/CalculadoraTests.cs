using System;
using Xunit;

namespace Calculadora.Tests
{
    public class CalculadoraTests
    {
        // Método auxiliar para instanciar a classe Calculadora com uma data de criação.
        private Calculadora CriarCalculadora()
        {
            string data = DateTime.Now.ToString(); // Define a data atual como string
            return new Calculadora(data); // Retorna uma nova instância da Calculadora
        }

        // Teste para o método de soma. Valida se a soma de dois números retorna o resultado esperado.
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(8, 5, 13)]
        public void SomarDoisNumeros_DeveRetornarResultadoCorreto(int valor1, int valor2, int resultadoEsperado)
        {
            Calculadora calc = CriarCalculadora();
            int resultadoSoma = calc.somar(valor1, valor2);
            Assert.Equal(resultadoEsperado, resultadoSoma);
        }

        // Teste para o método de subtração. Valida se a subtração de dois números retorna o resultado esperado.
        [Theory]
        [InlineData(2, 3, -1)]
        [InlineData(8, 5, 3)]
        public void SubtrairDoisNumeros_DeveRetornarResultadoCorreto(int valor1, int valor2, int resultadoEsperado)
        {
            Calculadora calc = CriarCalculadora();
            int resultadoSubtracao = calc.subtrair(valor1, valor2);
            Assert.Equal(resultadoEsperado, resultadoSubtracao);
        }

        // Teste para o método de multiplicação. Valida se a multiplicação de dois números retorna o resultado esperado.
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(8, 5, 40)]
        public void MultiplicarDoisNumeros_DeveRetornarResultadoCorreto(int valor1, int valor2, int resultadoEsperado)
        {
            Calculadora calc = CriarCalculadora();
            int resultadoMultiplicacao = calc.multiplicar(valor1, valor2);
            Assert.Equal(resultadoEsperado, resultadoMultiplicacao);
        }

        // Teste para o método de divisão. Valida se a divisão de dois números retorna o resultado esperado.
        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(9, 3, 3)]
        public void DividirDoisNumeros_DeveRetornarResultadoCorreto(int valor1, int valor2, int resultadoEsperado)
        {
            Calculadora calc = CriarCalculadora();
            int resultadoDivisao = calc.dividir(valor1, valor2);
            Assert.Equal(resultadoEsperado, resultadoDivisao);
        }

        // Teste para validar a exceção ao tentar dividir por zero.
        [Fact]
        public void DividirNumeroPorZero_DeveLancarExcecao()
        {
            Calculadora calc = CriarCalculadora();
            Assert.Throws<DivideByZeroException>(() => calc.dividir(6, 0));
        }

        // Teste para verificar o histórico de operações. Valida se o histórico armazena corretamente os últimos três resultados.
        [Fact]
        public void Historico_DeveConterUltimosTresResultados()
        {
            Calculadora calc = CriarCalculadora();

            // Realiza várias operações de soma para preencher o histórico
            calc.somar(1, 2);
            calc.somar(3, 4);
            calc.somar(4, 5);
            calc.somar(5, 6);

            // Obtém o histórico de operações da calculadora
            var lista = calc.historico();

            // Verifica se o histórico não está vazio e contém exatamente 3 itens
            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}
