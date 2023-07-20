# FinanceControl - Projeto ASP.NET 6 com Testes de Integração

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)

## Descrição do Projeto

O projeto FinanceControl é uma demonstração de como implementar testes de integração em um projeto ASP.NET 6. Todos os passos implementados neste projeto foram baseados na aula do canal [![Implementando Testes de Integração em .NET com Docker](https://www.youtube.com/watch?v=o5Q73A-rrlg).

A API principal, denominada "FinanceControl.Api", é uma Web API para o controle de finanças que expõe três controladores: `BalanceController`, `ExpensesController` e `IncomesController`. A aplicação utiliza o banco de dados Postgres para armazenar as informações financeiras e o Kafka para armazenar os eventos criados. Os endpoints da API são documentados e testáveis por meio do Swagger.

## Configurando o Ambiente de Teste

Para executar os testes de integração, é necessário configurar um ambiente em Docker para executar as imagens localmente. Neste projeto, utilizamos o Docker Desktop em um ambiente Windows para realizar os testes.

### Pré-requisitos

- [FinanceControl](https://github.com/bufaonanet/FinanceControl) instalado em seu sistema.

### Configuração do Ambiente de Teste

1. Clone este repositório em seu computador:

```bash
git clone https://github.com/seu-usuario/FinanceControl.git
cd FinanceControl
```

2. Execute o seguinte comando para levantar as instâncias do Postgres e Kafka para realizar os testes manuais:

```bash
docker-compose up -d
```

## Projeto de Testes de Integração

Os testes de integração estão implementados no projeto "FinanceControl.IntegrationTests". Utilizamos o framework xUnit e Microsoft.AspNetCore.Mvc.Testing para executar os testes de integração.

Os pacotes "Testcontainers", "Testcontainers.Kafka" e "Testcontainers.PostgreSql" são utilizados para levantar os contêineres no ambiente de teste. O objetivo desses testes é garantir que a API funcione corretamente em um ambiente real e integrado, utilizando os recursos do Kafka e do banco de dados Postgres.

## Executando os Testes de Integração

Para executar os testes de integração, certifique-se de ter o ambiente Docker configurado e as instâncias do Postgres e Kafka em execução. Em seguida, abra o projeto "FinanceControl.IntegrationTests" e execute os testes utilizando um dos seguintes métodos:

- Utilize a linha de comando (CLI):

```bash
dotnet test
```

- Utilize a interface gráfica do Visual Studio ou uma ferramenta compatível com testes xUnit.

## Contribuição

Contribuições são bem-vindas! Se você deseja contribuir com melhorias, correções de bugs ou novos recursos, sinta-se à vontade para abrir um "Pull Request" neste repositório.

## Licença

Este projeto está licenciado sob a Licença MIT - consulte o arquivo [LICENSE](LICENSE) para obter detalhes.