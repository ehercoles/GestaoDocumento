# Teste Pratico Erasmus

## Considerações Gerais

Você deverá usar este repositório como o repositório principal do projeto.

ATENÇÃO: Queremos acompanhar a evolução do projeto e a maneira de como você trabalha com Git, desta forma todos os seus commits devem estar registrados aqui, evite enviar tudo em um único commit.

Crie um arquivo COMMENTS.md e inclua todos as decisões tomadas para a realização do projeto.

O projeto deve ser desenvolvido utilizando:

1. C#, .NET Framework 4.5 ou superior e MVC 5.
2. HTML 5
3. JavaScript ou biblioteca jQuery 3
4. Bootstrap 4
5. MySQL 5.6+ ou PostgreSQL 8+
6. Boas práticas de programação

## O Problema

Você deve desenvolver um sistema de cadastro de documentos que tenha uma interface acessível pela WEB aonde os usuários do sistema possam cadastrar os seus documentos.
Não é necessário autenticação.

## Regras de negócio

O usuário deverá visualizar uma tabela que conterá todos os documentos cadastrados no sistema.

O usuário deve ser capaz de cadastrar, editar e excluir os documentos persistindo no banco de dados.

O cadastro e a edição documento devem conter os seguintes campos de entrada:

- Código (Campo de Texto)
- Título (Campo de Texto)
- Revisão (Caixa de Seleção com os valores: 0, A, B, C, D, E, F, G)
- Data Planejada (Campo de Data)
- Valor (Campo de Numérico Monetário, deve aceitar números com casas decimais)

Todos os campos são obrigatórios no momento do cadastro e edição.
