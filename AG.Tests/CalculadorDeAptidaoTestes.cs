using AG.Web.Domain;
using System.Collections.Generic;
using Xunit;

namespace AG.Tests
{
    public class CalculadorDeAptidaoTestes
    {
        [Fact]
        public void TestarValorDeAptidaoComSaidaDoCenario()
        {
            var bits = new List<IDirecao> {
                new Leste(), new Sul(), new Sul(), new Sul(), new Sul(), new Sul()
            };
            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular(bits);

            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = 100 + (Parametros.PontosPorCelulaOcupada * 6);

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }

        [Fact]
        public void TesteDeValorDeAptidaoComChegadaAteOFimDoLabirinto()
        {
            var bits = new List<IDirecao> 
            {
                new Leste(), new Leste(), new Norte(), new Norte(), new Norte(), new Leste()
            };

            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular(bits);
            
            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = (Parametros.PontosPorCelulaOcupada * 6); 

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }

        [Fact]
        public void TesteDeValorDeAptidaoQuandoOcorrerDuasColisoesEmParedes()
        {
            var bits = new List<IDirecao>
            {
                new Leste(), new Norte(),new Norte(),new Norte(), new Leste(), new Leste()
            };

            DetalhamentoCalculoDeAptidao detalhamentoCalculoDeAptidao = CalculadorDeAptidao.Calcular(bits);

            int valorDeAptidadoObtida = detalhamentoCalculoDeAptidao.Aptidao;

            int valorDeAptidadoEsperada = (Parametros.PontosPorAtravessiaDeParedes * 2) + (Parametros.PontosPorCelulaOcupada * 6);

            Assert.Equal(valorDeAptidadoEsperada, valorDeAptidadoObtida);
        }
    }
}
