# B3 Desafio Cálculo de Investimento

Este repositório contém uma solução para o cálculo de investimentos, construída como parte de um desafio técnico. A solução está estruturada em cinco projetos:

1. **B3.DesafioCalculo.Api**: Este projeto contém a API REST que expõe os endpoints para cálculo de investimento.
2. **B3.DesafioCalculo.Business**: Este projeto contém a lógica de negócios e algoritmos para realizar os cálculos.
3. **B3.DesafioCalculo.Shared**: Este projeto contém utilitários e código compartilhado entre as diferentes camadas da aplicação.
4. **B3.DesafioCalculo.Web**: Este projeto contém o frontend construído com Angular 15.
5. **B3.DesafioCalculo.UnitTests**: Este projeto contém testes unitários escritos com NUnit.

## Requisitos

- .NET 6 ou superior
- Angular CLI
- Visual Studio 2022
- NUnit (para execução dos testes)

## Instruções de Instalação

1. **Clone o Repositório**

    ```
    git clone https://github.com/SamuelCunha96/B3-DesafioCalculo.git
    ```

2. **Abra a Solução no Visual Studio**

    Navegue até a pasta onde o repositório foi clonado e abra o arquivo `.sln` no Visual Studio.

3. **Restaure as Dependências**

    - Para os projetos .NET, você pode restaurar as dependências usando o NuGet Package Manager.
    - Para o projeto Angular, navegue até a pasta `B3.DesafioCalculo.Web` e execute `npm install`.

## Como Executar

1. **API .NET**

    Configure o projeto `B3.DesafioCalculo.Api` como projeto de inicialização e pressione `F5` para executá-lo.

2. **Aplicativo Angular**

    Navegue até a pasta `B3.DesafioCalculo.Web` e execute `ng serve`.

## Como Testar

### API .NET

O projeto possui cobertura de teste de mais de 90%. Você pode executar os testes usando o Test Runner do Visual Studio ou o NUnit.

### Testes Unitários com NUnit

Para executar os testes unitários, você pode usar o Test Runner do Visual Studio.

## Contribuições

Contribuições são bem-vindas. Sinta-se à vontade para abrir uma issue ou fazer um pull request.