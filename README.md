# TesteWTime

Projeto de teste utilizando as seguintes ferramentas.

  - SQLServer 2017
  - AspNET Web API
  - Swagger
  - AngularJS

# Requisitos minimos

  - Visual studio versão 2017
  - SQLServer 2017
  
### Utilizaçao

 - Navegar até a pasta TesteWTime.Infra\Context abrir o arquivo CreateDB.sql e executar no banco de dados.
 - Alterar webconfig adicionando a conexão da instância do servidor
 - Navegar até a pasta TesteWTime.WebApi\bin\Release\PublishOutput copiar os arquivos e colar no IIS do servidor
 - Utilizei Swagger no projeto para documentar a api e executar testes. O caminho deverá ser a url do servidor. Ex: http://localhost/swagger/ui/index
 
### Referencias

* [Swagger](https://swagger.io/)- Documentaço de API
* [AngularJS](https://angularjs.org/) 

