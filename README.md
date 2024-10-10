# Gerenciador de Tarefas

![GitHub repo size](https://img.shields.io/github/repo-size/iuricode/README-template?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/iuricode/README-template?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/iuricode/README-template?style=for-the-badge)
![Bitbucket open issues](https://img.shields.io/bitbucket/issues/iuricode/README-template?style=for-the-badge)
![Bitbucket open pull requests](https://img.shields.io/bitbucket/pr-raw/iuricode/README-template?style=for-the-badge)
### Descrição
> Esta API permite que os usuários organizem e monitorem suas tarefas, além de colaborar com colegas de equipe.

### Desenvolvimento
- [x] Criação de Projetos - criar um novo projeto
- [x] Listagem de Projetos - listar todos os projetos do usuário
- [x] Criação de Tarefas - adicionar uma nova tarefa a um projeto
- [x] Visualização de Tarefas - visualizar todas as tarefas de um projeto específico
- [x] Atualização de Tarefas - atualizar o status ou detalhes de uma tarefa
- [x] Remoção de Tarefas - remover uma tarefa de um projeto

### Ajustes e melhorias

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas para as seguintes tarefas:

- [ ] - Desenvolver FrontEnd
- [ ] - Colaboração entre usuários
- [ ] - Gerenciamento de prioridades
- [ ] - Filtragem e ordenação de tarefas

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

- ASP.NET Core
- Entity Framework Core
- Visual Studio 2022
- NET 8 SDK
- Banco de dados (SQL Server, SQLite)

## 🚀 Instalando Gerenciador de Tarefas

Windows:

```bash
git clone https://github.com/cdsantostecnologia/gerenciador-tarefas.git
cd gerenciador-tarefas
dotnet restore
dotnet build

```

## ☕ API Gerenciador de Tarefas

Para testar API Gerenciador de tarefas, siga estas etapas:

-  Na listagem é só clicar no botão executar e obter retorno abaixo:
- /api/Projeto/ListarProjetos

```
{
  "dados": [
    {
      "id": 0,
      "nomeProjeto": "string"
    }
  ],
  "mensagem": "string",
  "status": true
}

```
-  Para criar um projeto, substituir "string" pelo nome do projeto e executar para em seguida obter o retorno.
- /api/Projeto/CriarProjeto

```
{
  "nomeProjeto": "string"
}

```
- Retorno ao Criar Projeto

```
{
  "dados": {
    "id": 0,
    "nomeProjeto": "string"
  },
  "mensagem": "string",
  "status": true
}

```
- Para buscar tarefas por projeto, digitar o id do projeto e receber a lista de tarefas.
- /api/Tarefa/BuscarTarefasPorIdProjeto/{idProjeto}

```
{
  "dados": [
    {
      "id": 0,
      "nomeTarefa": "string",
      "descricao": "string",
      "dtCriacao": "2024-10-09T15:57:08.814Z",
      "dtVencimento": "2024-10-09T15:57:08.814Z",
      "prioridade": "string",
      "status": "string",
      "projeto": "string",
      "usuario": "string"
    }
  ],
  "mensagem": "string",
  "status": true
}

```
-  Para criar a tarefa, preencha os campos do exemplo abaixo e execute:
- /api/Tarefa/CriarTarefa

```
{
  "nomeTarefa": "string",
  "descricao": "string",
  "dtCriacao": "2024-10-09T15:58:55.975Z",
  "dtVencimento": "2024-10-09T15:58:55.975Z",
  "prioridadeId": 0,
  "usuarioId": 0,
  "projetoId": 0
}

```
- Retorno ao criar tarefa:

```
{
  "dados": {
    "id": 0,
    "nomeTarefa": "string",
    "descricao": "string",
    "dtCriacao": "2024-10-09T15:58:55.977Z",
    "dtVencimento": "2024-10-09T15:58:55.977Z",
    "prioridadeId": 0,
    "statusId": 0,
    "projetoId": 0,
    "projeto": {
      "id": 0,
      "nomeProjeto": "string"
    },
    "usuarioId": 0,
    "prioridade": {
      "id": 0,
      "descricao": "string"
    },
    "status": {
      "id": 0,
      "descricao": "string"
    },
    "usuario": {
      "id": 0,
      "nome": "string",
      "perfilId": 0,
      "perfil": {
        "id": 0,
        "nomePerfil": "string"
      }
    }
  },
  "mensagem": "string",
  "status": true
}
```
- Para atualizar, preencha os campos do exemplo abaixo e execute:
- /api/Tarefa/EditarTarefa

```
{
  {
  "id": 0,
  "descricao": "string",
  "statusId": 0,
  "usuarioId": 0,
  "projeto": {
    "id": 0,
    "nomeProjeto": "string"
  }
}

```

- Retorno da atualização na respota abaixo:

```
{
  {
  "dados": [
    {
      "id": 0,
      "nomeTarefa": "string",
      "descricao": "string",
      "dtCriacao": "2024-10-09T16:01:32.902Z",
      "dtVencimento": "2024-10-09T16:01:32.902Z",
      "prioridadeId": 0,
      "statusId": 0,
      "projetoId": 0,
      "projeto": {
        "id": 0,
        "nomeProjeto": "string"
      },
      "usuarioId": 0,
      "prioridade": {
        "id": 0,
        "descricao": "string"
      },
      "status": {
        "id": 0,
        "descricao": "string"
      },
      "usuario": {
        "id": 0,
        "nome": "string",
        "perfilId": 0,
        "perfil": {
          "id": 0,
          "nomePerfil": "string"
        }
      }
    }
  ],
  "mensagem": "string",
  "status": true
}

```
- Para excluir, digite o número da tarefa no campo IdTarefa:
- /api/Tarefa/ExcluirTarefa

```
{
  "dados": [
    {
      "id": 0,
      "nomeTarefa": "string",
      "descricao": "string",
      "dtCriacao": "2024-10-09T16:06:00.749Z",
      "dtVencimento": "2024-10-09T16:06:00.749Z",
      "prioridadeId": 0,
      "statusId": 0,
      "projetoId": 0,
      "projeto": {
        "id": 0,
        "nomeProjeto": "string"
      },
      "usuarioId": 0,
      "prioridade": {
        "id": 0,
        "descricao": "string"
      },
      "status": {
        "id": 0,
        "descricao": "string"
      },
      "usuario": {
        "id": 0,
        "nome": "string",
        "perfilId": 0,
        "perfil": {
          "id": 0,
          "nomePerfil": "string"
        }
      }
    }
  ],
  "mensagem": "string",
  "status": true
}

```
- Para comentar uma tarega, digite o comentário dentro da "string" e execute:
- /api/Tarefa/InserirComentario

```
{
  "comentario": "string",
  "tarefaId": 0
}

```
- Retorno da tarefa com o devido comentário inserido:

```
{
  "dados": {
    "id": 0,
    "comentario": "string",
    "tarefaId": 0,
    "tarefa": {
      "id": 0,
      "nomeTarefa": "string",
      "descricao": "string",
      "dtCriacao": "2024-10-09T16:09:33.595Z",
      "dtVencimento": "2024-10-09T16:09:33.595Z",
      "prioridadeId": 0,
      "statusId": 0,
      "projetoId": 0,
      "projeto": {
        "id": 0,
        "nomeProjeto": "string"
      },
      "usuarioId": 0,
      "prioridade": {
        "id": 0,
        "descricao": "string"
      },
      "status": {
        "id": 0,
        "descricao": "string"
      },
      "usuario": {
        "id": 0,
        "nome": "string",
        "perfilId": 0,
        "perfil": {
          "id": 0,
          "nomePerfil": "string"
        }
      }
    }
  },
  "mensagem": "string",
  "status": true
}

```

## 📫 Contribuindo para o Gerenciador de Tarefas

Para contribuir com Gerenciador de Tarefas, siga estas etapas:

1. Bifurque este repositório.
2. Crie um branch: `git checkout -b <nome_branch>`.
3. Faça suas alterações e confirme-as: `git commit -m '<mensagem_commit>'`
4. Envie para o branch original: `git push origin <nome_do_projeto> / <local>`
5. Crie a solicitação de pull.

Como alternativa, consulte a documentação do GitHub em [como criar uma solicitação pull](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request).

## 🤝 Contato
Desenvolvedor: Celso dos Santos - celso@cdsantostecnologia.com.br
