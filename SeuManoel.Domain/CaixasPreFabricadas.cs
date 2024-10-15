namespace SeuManoel.Domain
{
    public class CaixasPrefabricadas
    {
        public static readonly (int Altura, int Largura, int Comprimento) Caixa1 = (30, 40, 80);
        public static readonly (int Altura, int Largura, int Comprimento) Caixa2 = (80, 50, 40);
        public static readonly (int Altura, int Largura, int Comprimento) Caixa3 = (50, 80, 60);

        public static bool ValidaMaximoDimensoes(int dimensoesSoma)
        {
            return (Caixa3.Altura + Caixa3.Largura + Caixa3.Comprimento) >= dimensoesSoma;
        }

        public static string EscolherCaixa((int Altura, int Largura, int Comprimento) dimensoes)
        {

            if (dimensoes.Altura <= Caixa1.Altura && dimensoes.Largura <= Caixa1.Largura && dimensoes.Comprimento <= Caixa1.Comprimento)
            {
                return "Caixa1";
            }
            else if (dimensoes.Altura <= Caixa2.Altura && dimensoes.Largura <= Caixa2.Largura && dimensoes.Comprimento <= Caixa2.Comprimento)
            {
                return "Caixa2";
            }
            else if (dimensoes.Altura <= Caixa3.Altura && dimensoes.Largura <= Caixa3.Largura && dimensoes.Comprimento <= Caixa3.Comprimento)
            {
                return "Caixa3";
            }
            throw new Exception("Nenhuma caixa disponível para as dimensões informadas");
        }
    }
}
