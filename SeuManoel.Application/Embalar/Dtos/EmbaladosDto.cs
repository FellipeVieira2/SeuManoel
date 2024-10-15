using System.Text.Json.Serialization;

namespace SeuManoel.Application.Embalar.Dtos
{
    public class EmbaladosDto
    {
        [JsonPropertyName("pedidos")]

        public List<Pedido> Pedidos { get; set; } = new();
        public class Pedido
        {
            [JsonPropertyName("pedido_id")]

            public int PedidoId { get; set; }
            [JsonPropertyName("caixas")]

            public List<Caixa> Caixas { get; set; }

            public class Caixa
            {
                [JsonPropertyName("caixa_id")]

                public string CaixaId { get; set; }
                [JsonPropertyName("produtos")]

                public List<string> Produtos { get; set; }

                [JsonPropertyName("observacao")]
                public string? Observacao { get; set; }
            }
        }
    }
}
