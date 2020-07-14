using AG.Web.Domain;
using Xunit;

namespace AG.Tests
{
    public class CalculadorDeAptidaoTestes
    {
        [Fact]
        public void TestarValorDeAptidaoComSaidaDoCenario()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular("001111111111");

            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = 100 + (Parametros.PontosPorCelulaOcupada * 6);

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }

        [Fact]
        public void TesteDeValorDeAptidaoComChegadaAteOFimDoLabirinto()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular("000001010100");
            
            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = (Parametros.PontosPorCelulaOcupada * 6);


            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }

        [Fact]
        public void TesteDeValorDeAptidaoQuandoOcorrerDuasColisoesEmParedes()
        {
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular("000101010000");

            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = (Parametros.PontosPorAtravessiaDeParedes * 2) + (Parametros.PontosPorCelulaOcupada * 6);

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }
    }
}
