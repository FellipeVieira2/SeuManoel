using SeuManoel.Domain;

namespace SeuManoel.Tests.Domain
{
    public class CaixasPrefabricadasTests
    {
        [Theory]
        [InlineData(30, 40, 80, "Caixa1")]
        [InlineData(80, 50, 40, "Caixa2")]
        [InlineData(50, 80, 60, "Caixa3")]
        public void EscolherCaixa_ValidDimensions_ReturnsCorrectCaixa(int altura, int largura, int comprimento, string expectedCaixa)
        {
            var result = CaixasPrefabricadas.EscolherCaixa((altura, largura, comprimento));

            Assert.Equal(expectedCaixa, result);
        }

        [Theory]
        [InlineData(100, 100, 100)]
        [InlineData(90, 60, 50)]
        public void EscolherCaixa_InvalidDimensions_ThrowsException(int altura, int largura, int comprimento)
        {
            Assert.Throws<Exception>(() => CaixasPrefabricadas.EscolherCaixa((altura, largura, comprimento)));
        }

        [Theory]
        [InlineData(190, true)]
        [InlineData(130, true)]
        [InlineData(200, false)]
        [InlineData(201, false)]
        public void ValidaMaximoDimensoes_ValidatesCorrectly(int dimensoesSoma, bool expectedResult)
        {
            var result = CaixasPrefabricadas.ValidaMaximoDimensoes(dimensoesSoma);

            Assert.Equal(expectedResult, result);
        }
    }
}