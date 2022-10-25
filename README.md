# ToDoList-back

## Repositório do backend para o projeto fullstack to-do-list feito em .NET Core 6 com o Entity Framework Core e MySQL Server

### Requisitos
- .NET 6 instalado
- MySQL Server instalado
- Entity Framework instalado e atualizado
- Comando para instalar o .NET Entity Framework
```dotnet tool install --global dotnet-ef ```
- Para atualizá-lo
```dotnet tool update --global dotnet-ef```
- Configure a string de conexão com os dados do seu MySQL Workbench no arquivo appsetings.json (normalmente só precisará atualizar o arquivo com sua senha e usuário) 
- Garanta que seu servidor MySQL Server esteja em execução
### Linux
- Execute ```dotnet build``` no diretório do projeto
- Rode também ```dotnet ef database update``` para realizar as migrações
- Quando for executar o projeto é importante ter o MySQL Server executando. 
- Utilize o comando ```dotnet run``` no diretório do projeto para iniciá-lo

### Windows
- Compile o projeto no Visual Studio 2022
- Faça as migrações com ```dotnet ef database update```
- Execute o projeto


Tendo o projeto em execução, é hora de executar o [projeto do frontend](https://github.com/rafaelfhsantos/to-do-list).


## Endpoints
- É possível verificar facilmente os endpoints pelo Swagger mas no geral são elas:

### [POST] /toDos 
Cadastra uma tarefa. O corpo da requisição comporta os seguintes dados (JSON):
``` 
{
  name: string,
  description: string, 
  isDone: boolean
}
```

### [GET] /toDos 
Lista todas as tarefas cadastradas

### [GET] /toDos/{id:int} 
Lista a tarefa do "id" referente

### [DELETE] /toDos/{id:int} 
Remove a tarefa com o "id" passado no parâmetro da requisição da base de dados.

### [PUT] /toDos/{id:int} 
Atualiza os dados da tarefa com o "id" passado no parâmetro. O corpo deve ser um JSON com os dados finais da tarefa em questão
``` 
{
  name: string,
  description: string, 
  isDone: boolean
}
```

### [POST] /toDos/{id:int}/setDone
Atualiza o status da tarefa para feito, se a mesma estiver como "não feita" ou altera para "não feita" se ela estiver como "feita"


