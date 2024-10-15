using MediatR;
using Microsoft.Extensions.Logging;
using SeuManoel.Application.Embalar.Dtos;
using SeuManoel.Domain;
using System.Text.Json.Serialization;
using static SeuManoel.Application.Embalar.Dtos.EmbaladosDto.Pedido;

namespace SeuManoel.Application.Embalar.Commands
{
    public class EmbalarCommand : IRequest<EmbaladosDto>
    {
        [JsonPropertyName("pedidos")]
        public List<Pedido> Pedidos { get; set; }

        public class Pedido
        {
            [JsonPropertyName("pedido_id")]
            public int PedidoId { get; set; }
            public List<Produto> Produtos { get; set; }

            public class Produto
            {
                [JsonPropertyName("produto_id")]
                public string ProdutoId { get; set; }
                [JsonPropertyName("dimensoes")]
                public Dimensao Dimensoes { get; set; }

                public class Dimensao
                {
                    [JsonPropertyName("altura")]
                    public int Altura { get; set; }
                    [JsonPropertyName("largura")]
                    public int Largura { get; set; }
                    [JsonPropertyName("comprimento")]
                    public int Comprimento { get; set; }
                }
            }
        }
    }
    public class EmbalarCommandHandler : IRequestHandler<EmbalarCommand, EmbaladosDto>
    {
        public async Task<EmbaladosDto> Handle(EmbalarCommand request, CancellationToken cancellationToken)
        {
            EmbaladosDto embaladosDto = new();

            foreach (var pedido in request.Pedidos)
            {
                List<Caixa> produtosCaixas = new();

                foreach (var produto in pedido.Produtos)
                {
                    string observacao = null;
                    string caixaSelecionada = null;

                    try
                    {
                        caixaSelecionada = CaixasPrefabricadas.EscolherCaixa(new(produto.Dimensoes.Altura, produto.Dimensoes.Largura, produto.Dimensoes.Comprimento));
                    }
                    catch (Exception e)
                    {
                        observacao = e.Message;
                    }

                    var caixaExistente = produtosCaixas.FirstOrDefault(x => x.CaixaId == caixaSelecionada);

                    if (caixaExistente != null)
                    {
                        caixaExistente.Produtos.Add(produto.ProdutoId);
                        caixaExistente.Observacao = observacao;
                    }
                    else
                    {
                        produtosCaixas.Add(new Caixa { CaixaId = caixaSelecionada, Produtos = new List<string> { produto.ProdutoId }, Observacao = observacao });
                    }
                }

                embaladosDto.Pedidos.Add(new EmbaladosDto.Pedido
                {
                    PedidoId = pedido.PedidoId,
                    Caixas = produtosCaixas
                });
            }

            return embaladosDto;
        }
    }
}
