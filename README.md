Controle de Estoque API

Esta API foi desenvolvida para gerenciar o controle de estoque, permitindo o cadastro de produtos, movimentações de entrada e saída e a categorização dos produtos.

Tecnologias Utilizadas:

C# com .NET 8
Entity Framework Core
MySQL (Banco de Dados)
Swagger para documentação
Git para versionamento

Configuração e Execução:

1.Clonar o repositório

git clone https://github.com/matheus464/ControleEstoqueAPI.git
cd ControleEstoqueAPI

2.Configurar o Banco de Dados

Esta API utiliza MySQL. Certifique-se de que o servidor MySQL esteja rodando e crie um banco de dados chamado inventorycontrol.
Se ainda não tiver o banco criado, execute no MySQL:

CREATE DATABASE inventorycontrol;
USE inventorycontrol;

3.Configurar appsettings.json

Crie um arquivo appsettings.json na raiz do projeto e configure a string de conexão com seu banco:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=inventorycontrol;User=root;Password=;"
  }
}

Importante: Não suba este arquivo para o Git, pois ele contém informações sensíveis!!!

4.Restaurar Pacotes NuGet

dotnet restore

5.Executar a API

dotnet run

A API será iniciada e estará disponível em:

http://localhost:5049

Para acessar a documentação do Swagger, abra no navegador:

http://localhost:5049/swagger
