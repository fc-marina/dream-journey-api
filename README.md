# Dream Journey API 

![LoveDayDreamingGIF](https://user-images.githubusercontent.com/125232738/234369247-aab3298e-38bd-47f4-a7af-d0824ef5dd82.gif)

A API Dream Journey é um projeto de API realizado para que uma ou mais pessoas consigam gerenciar seus sonhos e objetivos. O projeto funciona possibilitando cadastramentos de usuários e sonhos que poderão ser associados e posteriormente gerenciados. 

## Link do Swagger: https://dreamjourney-api.azurewebsites.net/swagger/index.html 

## Cadastro de Sonhos 

Inicialmente para cadastrar um sonho é necessariamente obrigatório que o dono do sonho inclua valores nos campos de nome e descrição. 

Cada sonho tem um Enum (valores de 0 a 3) que possibilita que o usuário escolha o lugar que o sonho se encaixa na área da vida e o status do objetivo/sonho. Sendo as opções: 

### Area da vida: 

       0- Professional (Profissional) 
       1-  Relationships (Relacionamentos) 
       2- Spiritual (Espiritual) 
       3- Health (Saúde) 

### Status: 

        1- Idealized (Idealizado) 
        2- Planned (Planejado) 
        3- InProgress (Em andamento) 
        4- Achived (Alcançado) 

É obrigatório que cada sonho tenha uma descrição onde o usuário incluirá informações de como conseguir alcançar o seu objetivo. Outros campos como lifeArea, status e userId (associação com o dono) poderão ser incluídos posteriormente, caso preferível.  

Caso já exista um usuário cadastrado, o dono do sonho pode associar esse usuário na hora da criação do sonho ou posteriormente. 

Atenção: Caso seja incluído um id de usuário inexistente na hora do cadastro do sonho o sistema retornará um erro ao usuário. 

## Cadastro de Usuários 

Para cadastrar um usuário é necessário que os campos nome e data de nascimento sejam preenchidos. 

O usuário poderá ser associado a um sonho posteriormente. 

## Outras funcionalidades 

Após cadastrar um sonho ou dono, o projeto permite que o usuário possa modificar, buscar e excluir esses objetos. 

### Retorno de todos os sonhos/donos cadastrados 

A busca de sonhos/donos retornará uma lista de sonhos/donos em formato JSON, com as informações inseridas na hora do cadastramento, que poderão ser paginadas de acordo com a quantidade de sonhos/donos que usuário deseja ver (campo take). Também o usuário poderá escolher a quantidade de sonhos/donos que deseja pular no retorno da busca (campo skip). 

Exemplo de objeto sonho com usuário associado. 

  { 
  
    "id": 3, 
    
    "name": "Me tornar Escritora", 
    
    "description": "Começar a escrever um livro em novembro", 
    
    "lifeArea": 0, 
    
    "status": 1, 
    
    "userId": 3, 
    
    "user": { 
    
      "id": 3, 
      
      "name": "João Juliano", 
      
      "birthDate": "2002-05-30T06:40:22.282" 
      
    } 
    
  } 

### Retorno de um sonho/dono cadastrado 

O usuário poderá solicitar a busca de um único sonho informando como parâmetro o Id do sonho que deseja consultar. 

### Edição de um sonho/dono  

Para editar um sonho ou dono o usuário deverá informar o Id do sonho/dono que deseja ajustar e informar as informações do objeto. 

Nesse momento é possível associar sonhos a donos 

### Exclusão de um sonho/dono 

O usuário poderá excluir do banco de dados um sonho ou usuário após informar um id existente do objeto. Caso o id não exista o sistema retornará um erro. 

## Tecnologias 

A API Dream Journey foi construída em .NET6 (C#) com o auxílio do EntityFramework, utilizando SQL Server como banco de dados, e hospedada pelo Azure 
