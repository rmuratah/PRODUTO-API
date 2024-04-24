# PRODUTO-API
Projeto Estudo de API em C#

Desafio PowerShop
Faça uma api em aspnet core seguindo o modelo padrão de controller e utilizando clean arquitecture.

Considere o seguinte modelo de negócio. Você deverá criar uma simples web api onde será possível realizar o CRUD de uma entidade "PRODUTO".
Durante esse crud, considere que será importante enviar toda operação de criação, alteração e deleção para um tópico kafka de fatos.
Durante esse desafio, considere que no payload de sua api será passado o valor do produto em dolar, e você deverá bater em um backend para realizar a conversão do valor para real para então armazenar na base.
é de extrema importancia que a entrada seja validada na controller.

Também, siga um modelo simples de Clean Arquitecture, fazendo com que hajam 3 csproj:

PowerShop.WebApi
PowerShop.Domain
PowerShop.Infrastructure
PowerShop.Application

Será obrigatório a criação de testes unitários e integrados

PowerShop.UnitTests
PowerShop.IntegratedTests

A persistência será feita em um banco SqlServer, onde deverá ter um docker compose para realizar a subida do mesmo em ambiente local

Considere os seguintes pacotes nuget  para a realização do projeto
-> Utilize Dapper como ORM
-> Para validação, utilize fluent validator
-> Para os testes, utilize o fluent assertions
-> Para teste integrados, utilize WireMock