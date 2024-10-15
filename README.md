# SeuManoel.Web.API

Este é o repositório da **SeuManoel.Web.API**, uma API desenvolvida em .NET 8. A aplicação está containerizada com Docker, e utilizamos **Docker Compose** para facilitar o gerenciamento de múltiplos contêineres e dependências.

## Pré-requisitos

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (opcional, se desejar rodar a aplicação localmente)

## Configuração com Docker Compose

Com o **Docker Compose**, podemos orquestrar a execução de múltiplos contêineres, como banco de dados e a própria API, com um único comando.

### 1. Clone o Repositório

```bash
git clone https://github.com/seu-usuario/SeuManoel.Web.API.git
cd SeuManoel.Web.API
```
### 3. Executando o Docker Compose
```bash
docker-compose up --build
```

