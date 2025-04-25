# Developer Evaluation - Sales API

Este repositório contém a implementação da API de vendas conforme as instruções fornecidas na avaliação técnica. O projeto foi desenvolvido seguindo princípios de Clean Architecture e boas práticas de desenvolvimento com .NET 8.

## Requisitos Atendidos

- CRUD completo para entidade `Sale`
- Regras de negócio implementadas:
  - Desconto de 10% para 4–9 unidades do mesmo item
  - Desconto de 20% para 10–20 unidades
  - Proibição de venda acima de 20 unidades por item
  - Nenhum desconto para menos de 4 unidades
- Estrutura organizada em camadas: `Domain`, `Application`, `ORM`, `WebApi`, `IoC`
- Testes automatizados com XUnit, FluentAssertions, Bogus e NSubstitute
- Validação com mensagens específicas
- Cancelamento de vendas e itens
- Logs estruturados com Serilog
- Padrões RESTful seguidos

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- XUnit + FluentAssertions
- Serilog
- Bogus
- NSubstitute
- Docker

## Como Executar

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio
```

### 2. Subir via Docker

```bash
docker-compose up -d
```

A API estará disponível em `https://localhost:5001`

### 3. Executar manualmente (sem docker)

Configure a connection string no arquivo:

```
src/Ambev.DeveloperEvaluation.WebApi/appsettings.Development.json
```

E execute:

```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

## Como Executar os Testes

```bash
dotnet test Tests/Ambev.DeveloperEvaluation.Unit
```

Todos os testes devem passar com sucesso

## Estrutura do Projeto

```
├── src/
│   ├── Ambev.DeveloperEvaluation.Domain
│   ├── Ambev.DeveloperEvaluation.Application
│   ├── Ambev.DeveloperEvaluation.ORM
│   ├── Ambev.DeveloperEvaluation.WebApi
│   └── Ambev.DeveloperEvaluation.IoC
├── Tests/
│   └── Ambev.DeveloperEvaluation.Unit
└── docker-compose.yml
```

## Observações Finais

- Projeto modular e orientado a DDD
- Foco em legibilidade, escalabilidade e manutenção
- Cobertura completa das regras exigidas na cartilha
- Código pronto para produção com base em boas práticas

## Contato

Desenvolvido por Lucas Soares 
[lucas.soares.p@hotmail.com] [linkedin.com/in/lucas-pereira-soares/]
