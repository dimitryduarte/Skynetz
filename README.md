# Skynetz
Esse projeto foi desenvolvido com foco em utilizar os princípios da arquitetura/design orientada a domínio (DDD), implementando também testes unitários e alguns conceitos de clean code e clean architeture, como injeção de dependências, modelo rico nas classes, princípios de responsabilidade única e máxima abstração de métodos (SOLID) entre outros.

LIBRARIES
-----------------
Foram utilizados para este projeto os seguintes recursos:
- Docker (SQL Server)
- .Net Core 3.1
- Entity Framework Core
- xUnit
- Moq
- Jquery (Ajax)
- Kestrel

ENVIRONMENTS
------------------
O arquivo ```appsettings.json``` contém a string de conexão com o banco dentro do container.

INSTRUÇÕES
---------------------
Algumas considerações importantes:
- Esse projeto trata-se de um MVP pra apresentar algumas ideias e conceitos, existem diversas melhorias a serem aplicadas.
- Nesse modelo orientado a domínio é possível implementar testes unitários em praticamente todas as camadas da aplicação. No teste por questão de tempo foi aplicado nas classes do domínio e no repositório.
- A utilização de containers pode ser otimizada com kubernets e demais ferramentas. 
- Foram criadas migrations para inserção dos dados solicitados no banco. Não sendo necessário scripts SQL.
- Os CRUDs de Planos e Tarifas que foram criados além dos solicitado, seria somente pra facilitar os testes, não compoem parte da arquitetura aqui apresentada.

É possível iniciar esse projeto via docker, ou de forma manual (debug).

INICIAR VIA DOCKER
-------------
Para iniciar subir o projeto via docker, do diretório do arquivo ```docker-compose.yml```  execute o comando:
```
docker-compose up --build -o
```
O comando build é importante para rodar as migrations.

INICIAR COMO DEBUG
--------------
Para inicializar o projeto pelo Visual Studio, pode ser utilizada uma instância de docker já configurada para banco de dados executando o comando a seguir:
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password#2022" -p 1450:1433 --name sqlserverdb -d mcr.microsoft.com/mssql/server
```
A autenticação desse container já está configurada no projeto.

Após inicializar o projeto, basta executar as migrations com o comando:
```
Update-Database
```
Feito isso o projeto será inicializado com sucesso via Kestrel (Inicializar ```Skynetz.Web```).
