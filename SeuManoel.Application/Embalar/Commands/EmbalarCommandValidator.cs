using FluentValidation;
using SeuManoel.Domain;

namespace SeuManoel.Application.Embalar.Commands
{
    public class EmbalarCommandValidator : AbstractValidator<EmbalarCommand>
    {
        public EmbalarCommandValidator()
        {
            RuleFor(command => command.Pedidos)
                .NotEmpty().WithMessage("A lista de pedidos não pode estar vazia.");

            RuleForEach(command => command.Pedidos).ChildRules(pedido =>
            {
                pedido.RuleFor(p => p.PedidoId)
                    .NotEmpty().WithMessage("O ID do pedido deve ser preenchido");

                pedido.RuleFor(p => p.Produtos)
                    .NotEmpty().WithMessage("A lista de produtos não pode estar vazia.");

                pedido.RuleForEach(p => p.Produtos).ChildRules(produto =>
                {
                    produto.RuleFor(p => p.ProdutoId)
                        .NotEmpty().WithMessage("O ID do produto deve ser preenchido");

                    produto.RuleFor(p => p.Dimensoes)
                        .NotNull().WithMessage("As dimensões do produto não podem ser nulas.");

                    produto.RuleFor(p => p.Dimensoes.Altura)
                        .GreaterThan(0).WithMessage("A altura do produto deve ser maior que zero.");

                    produto.RuleFor(p => p.Dimensoes.Largura)
                        .GreaterThan(0).WithMessage("A largura do produto deve ser maior que zero.");

                    produto.RuleFor(p => p.Dimensoes.Comprimento)
                        .GreaterThan(0).WithMessage("O comprimento do produto deve ser maior que zero.");

                    produto.RuleFor(p => CaixasPrefabricadas.ValidaMaximoDimensoes(p.Dimensoes.Altura + p.Dimensoes.Largura + p.Dimensoes.Comprimento))
                        .Equal(true).WithMessage("As dimensões do produto excedem o máximo permitido para embalagem.");
                });
            });
        }
    }
}