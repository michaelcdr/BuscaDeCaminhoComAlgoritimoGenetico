using AG.Web.Domain;
using Xunit;

namespace AG.Tests
{
    public class CalculadorDeAptidaoTestes
    {
        [Fact]
        public void TestarAptidaoComSaidaDoCenario()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular("001111111111");

            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = 100;

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }

        [Fact]
        public void TestarAptidaoComChegadaAteOFim()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular("000001010100");
            
            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = 0;

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }

        [Fact]
        public void TestarAptidaoComQuandoOcorreColisaoEmParedes()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular("000101010000");

            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = 20;

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }
    }
}
