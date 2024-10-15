using FluentValidation.TestHelper;
using SeuManoel.Application.Embalar.Commands;


namespace SeuManoel.Tests.Application.Embalar.Commands
{
    public class ApplicationTests
    {
        private readonly EmbalarCommandValidator _validator;

        public ApplicationTests()
        {
            _validator = new EmbalarCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Pedidos_Is_Empty()
        {
            var command = new EmbalarCommand { Pedidos = new List<EmbalarCommand.Pedido>() };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Pedidos)
                  .WithErrorMessage("A lista de pedidos não pode estar vazia.");
        }

        [Fact]
        public void Should_Have_Error_When_PedidoId_Is_Empty()
        {
            var command = new EmbalarCommand
            {
                Pedidos = new List<EmbalarCommand.Pedido>
                {
                    new EmbalarCommand.Pedido { PedidoId = 0, Produtos = new List<EmbalarCommand.Pedido.Produto>() }
                }
            };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor("Pedidos[0].PedidoId")
                  .WithErrorMessage("O ID do pedido deve ser preenchido");
        }

        [Fact]
        public void Should_Have_Error_When_Produtos_Is_Empty()
        {
            var command = new EmbalarCommand
            {
                Pedidos = new List<EmbalarCommand.Pedido>
                {
                    new EmbalarCommand.Pedido { PedidoId = 1, Produtos = new List<EmbalarCommand.Pedido.Produto>() }
                }
            };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor("Pedidos[0].Produtos")
                  .WithErrorMessage("A lista de produtos não pode estar vazia.");
        }

        [Fact]
        public void Should_Have_Error_When_ProdutoId_Is_Empty()
        {
            var command = new EmbalarCommand
            {
                Pedidos = new List<EmbalarCommand.Pedido>
                {
                    new EmbalarCommand.Pedido
                    {
                        PedidoId = 1,
                        Produtos = new List<EmbalarCommand.Pedido.Produto>
                        {
                            new EmbalarCommand.Pedido.Produto { ProdutoId = string.Empty, Dimensoes = new EmbalarCommand.Pedido.Produto.Dimensao() }
                        }
                    }
                }
            };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor("Pedidos[0].Produtos[0].ProdutoId")
                  .WithErrorMessage("O ID do produto deve ser preenchido");
        }

        [Theory]
        [InlineData(0, "A altura do produto deve ser maior que zero.")]
        [InlineData(-1, "A altura do produto deve ser maior que zero.")]
        public void Should_Have_Error_When_Altura_Is_Invalid(int altura, string errorMessage)
        {
            var command = new EmbalarCommand
            {
                Pedidos = new List<EmbalarCommand.Pedido>
                {
                    new EmbalarCommand.Pedido
                    {
                        PedidoId = 1,
                        Produtos = new List<EmbalarCommand.Pedido.Produto>
                        {
                            new EmbalarCommand.Pedido.Produto
                            {
                                ProdutoId = "1",
                                Dimensoes = new EmbalarCommand.Pedido.Produto.Dimensao { Altura = altura, Largura = 10, Comprimento = 10 }
                            }
                        }
                    }
                }
            };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor("Pedidos[0].Produtos[0].Dimensoes.Altura")
                  .WithErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(0, "A largura do produto deve ser maior que zero.")]
        [InlineData(-1, "A largura do produto deve ser maior que zero.")]
        public void Should_Have_Error_When_Largura_Is_Invalid(int largura, string errorMessage)
        {
            var command = new EmbalarCommand
            {
                Pedidos = new List<EmbalarCommand.Pedido>
                {
                    new EmbalarCommand.Pedido
                    {
                        PedidoId = 1,
                        Produtos = new List<EmbalarCommand.Pedido.Produto>
                        {
                            new EmbalarCommand.Pedido.Produto
                            {
                                ProdutoId = "1",
                                Dimensoes = new EmbalarCommand.Pedido.Produto.Dimensao { Altura = 10, Largura = largura, Comprimento = 10 }
                            }
                        }
                    }
                }
            };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor("Pedidos[0].Produtos[0].Dimensoes.Largura")
                  .WithErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(0, "O comprimento do produto deve ser maior que zero.")]
        [InlineData(-1, "O comprimento do produto deve ser maior que zero.")]
        public void Should_Have_Error_When_Comprimento_Is_Invalid(int comprimento, string errorMessage)
        {
            var command = new EmbalarCommand
            {
                Pedidos = new List<EmbalarCommand.Pedido>
                {
                    new EmbalarCommand.Pedido
                    {
                        PedidoId = 1,
                        Produtos = new List<EmbalarCommand.Pedido.Produto>
                        {
                            new EmbalarCommand.Pedido.Produto
                            {
                                ProdutoId = "1",
                                Dimensoes = new EmbalarCommand.Pedido.Produto.Dimensao { Altura = 10, Largura = 10, Comprimento = comprimento }
                            }
                        }
                    }
                }
            };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor("Pedidos[0].Produtos[0].Dimensoes.Comprimento")
                  .WithErrorMessage(errorMessage);
        }
    }
}