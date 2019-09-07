# Projeto BookStore - Loja de livros

Esse projeto é composto basicamente, por uma API REST construída em ASP.NET Core e um SPA com React e Bootstrap

## Execução

Para executar esse projeto é necessário ter instalado, o SQL Server instalado, a SQL do .NET Core 2.2 e uma linha de comando CMD ou o Visual Studio 2019 (ou outra versão que tenha suporte ao asp.net core 2.2)

- Criar um banco de dados com o Nome Book Store
- Executar o script SQL de criação das tabelas que está em `db\tabelas.sql`
- Verificar e se necessário alterar as credenciais de acesso ao banco de dados no arquivo `src\api\BookStore.WebApp\appsettings.json` na chave `ConnectionStrings`
- No diretório `src\api` executar o comando `dotnet restore` ou abrir o arquivo `src\api\BookStore.sln` no visual studio, para fazer download das dependencias.
- No mesmo diretório executar o comando `dotnet run --project BookStore.WebApp\BookStore.WebApp.csproj` e após um tempo,abrir o navegador em `http://localhost:5000` ou `https://localhost:5001`
- Caso esteja no Visual Studio, basta executar o Projeto `BookStore.WebApp` e o Visual Studio abrirá o navegador
- Para executar os testes unitários é preciso estar no diretório `src\api` e executar `dotnet test` ou utilizar a ferramenta de testes do Visual Studio.

## Solução Realizada

Nesse projeto foi utilizado um SPA utilizando React, que está dentro do projeto WebApp. Nesse projeto até de executar o SPA, está a API REST que utiliza o Asp.net Core e acessa um banco de dados SQL Server.

Essas tecnologias foram utilizadas visando performance e velocidade de desenvolvimento. O React proporciona velocidade na renderização do HTML, além de no estado atual do projeto atribuir poucas e leves dependencias e se caso o projeto venha a crescer é possível buscar bibliotecas complementares e escalar de forma que não se perca a organização e a performance do projeto SPA. 
A API com Asp.net core foi escolhida por proporiconar também boa performance e se comportar bem em uma aplicação sem estado como uma API REST. O sistema como um todo foi dividido em camadas, visando melhor organização e separação das responsabilidades, o projeto WebApp expõe o SPA e recebe as requisições através dos controllers; o Domain guarda o domínio do sistema, os modelos e as interfaces de comunicação necessárias; o Service guarda a lógica de negócio, faz validações, caso sejam necessárias e mapeia objetos modelo dos dados para objetos modelo de exposição (Model e ViewModel); e por fim o Infra guarda os repositorios de acesso a dados, esse projeto é o único que de fato sabe onde estão sendo armazenados os dados e tem a responsabilidade de salvar e buscar os dados.
A escolha do banco de dados foi por afinidade do desenvolvedor e também por se comportar melhor com o ORM escolhido para acessar os dados, o Entity Framework.

Os testes unitários testam os controllers da API do WebApp e verificam se os retornos estão de acordo com os dados inseridos, para isso foi necessário fazer o mock dos services