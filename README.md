# Hero CRUD API 🚀

Este projeto foi criado com o objetivo de explorar a linguagem **C#** utilizando a plataforma de desenvolvimento **.NET 8**.

---

### 📚 Sobre o projeto

Trata-se de uma API simples para cadastro de pessoas, implementando um CRUD básico (Create, Read, Update, Delete) para fins acadêmicos e de aprendizado.

Utilizei o **SQLite** como banco de dados para armazenar as informações, o que facilita a configuração e o uso em ambiente local.

Além disso, a API conta com integração ao **Swagger UI**, que facilita a visualização e testes dos endpoints diretamente pelo navegador.

<br>

### 🛠️ Tecnologias Utilizadas

| Tecnologia                | Descrição                                     |
| :------------------------ | :-------------------------------------------- |
| **C#**                    | Linguagem principal utilizada no projeto      |
| **.NET 8**                | Framework utilizado para construção da API    |
| **Entity Framework Core** | ORM para manipulação de dados com SQLite      |
| **SQLite**                | Banco de dados relacional leve e portátil     |
| **Swagger UI**            | Interface para documentação e testes da API   |
| **Docker**                | Containerização da aplicação                  |
| **Render.com**            | Plataforma de hospedagem com suporte a Docker |

<br>

### Funcionalidades

* Cadastro de pessoas
* Listagem de todas as pessoas
* Consulta de pessoa por ID
* Atualização de cadastro
* Exclusão lógica (soft delete)
* Documentação e testes via Swagger UI | Insomnia

<br>

### 📊 Diagrama de Fluxo da API

``` mermaid
flowchart TD
    A[Usuário] -->|"Requisição HTTP"| B[Endpoints no Routes.cs]
    B --> C{Operação}
    C -->|"POST /person"| D[Cria Pessoa]
    C -->|"GET /person"| E[Lista Pessoas]
    C -->|"PUT /person/{id}"| G[Atualiza Pessoa]
    C -->|"DELETE /person/{id}"| H[Deleta Pessoa - Soft Delete]
    D --> I[Grava no SQLite via PersonContext]
    E --> I
    G --> I
    H --> I
    I --> J[Retorna resposta HTTP ao usuário]

```


* **PersonModel.cs**: Classe que representa a entidade Pessoa, contendo `Guid Id`, `string Name` e campos adicionais se necessário.
* **PersonContext.cs**: Contexto de banco de dados configurado via Entity Framework Core.
* **Routes.cs**: Definição das rotas e métodos HTTP da API.
* **PersonRequest.cs**: Record para receber parâmetros via JSON, contendo `string Name`.
* **Program.cs**: Configuração principal da aplicação ASP.NET Core.

<br>

### 💡 Experiência

Gostei bastante da experiência de trabalhar com C# e .NET, notei várias semelhanças com a linguagem Java, o que facilitou o aprendizado inicial. Com certeza pretendo me aprofundar mais tanto na linguagem quanto nas tecnologias do ecossistema .NET.

<br>

### 💻 Como rodar localmente

Para executar o projeto localmente, siga os passos abaixo:

1. Clone este repositório:

   ```bash
   git clone https://github.com/deizirrs/hero-crud-api.git
   ```

2. Navegue até a pasta do projeto:

   ```bash
   cd hero-crud-api
   ```

3. Restaure as dependências:

   ```bash
   dotnet restore
   ```

4. Execute a aplicação:

   ```bash
   dotnet run
   ```

5. Acesse o Swagger UI no navegador para testar os endpoints:

   ```
   http://localhost:5000/swagger
   ```
   
<br>

### 📡 Endpoints Principais

A API possui os seguintes endpoints para o gerenciamento de pessoas:

| Método | Endpoint           | Descrição                     |
| ------ | ------------------ | ----------------------------- |
| GET    | `/person`      | Retorna a lista de pessoas    |
| POST   | `/person`      | Cria uma nova pessoa          |
| PUT    | `/person/{id}` | Atualiza uma pessoa existente |
| DELETE | `/person/{id}` | Remove uma pessoa             |



* Para as operações de **atualização (PUT)** e **exclusão (DELETE)** é necessário informar o `id` da pessoa no endpoint. Esse `id` é utilizado para localizar o registro no banco de dados.

* No caso da exclusão (DELETE), foi implementada a estratégia de **Soft Delete**: o registro não é removido do banco de dados, apenas tem o campo `Name` alterado para `"Desativado"`.

<br>

### ☁️ Hospedagem

Fiz o deploy da API utilizando a plataforma **Render.com**.


> **Use Postman ou Insomnia para ver a aplicação em ação.**

[👉 Link  da API em produção](https://hero-crud-api.onrender.com)

---

### 📬 Testando via Postman ou Insomnia

Para testar os endpoints via **Postman** ou **Insomnia**, siga os passos:

1. Abra o Postman ou Insomnia.

2. Crie uma nova requisição.

3. Defina o método (GET, POST, PUT ou DELETE).

4. Insira a URL completa da API com o endpoint desejado. Exemplo:
   ```
   GET https://hero-crud-api.onrender.com/person
   ```

5. Para POST e PUT, no corpo da requisição selecione **raw** e o formato **JSON**.

### 📑 Exemplo de JSON para criação de pessoa (POST):

```json
{
  "name": "Tony Stark"
}
```

6. Clique em **Send** e verifique a resposta da API.
   > **OBS: Só será retornado o Status `200(OK)`, para conferir as inserções/modifições do dado no banco use o `GET` Para consultar.**

7. Para excluir ou atualizar, utilize os endpoints com ID e envie os dados conforme necessário. Exemplo:

   ```
   DELETE https://hero-crud-api.onrender.com/api/person/{id}
   ```
> **⚠️ Para operações DELETE e PUT, informe apenas o id na URL — não inclua o id no corpo da requisição. Caso contrário, será retornado um status 405 Method Not Allowed.**

---
<br>

### 👩‍💻 Feito por

**Deiziane Rodrigues**

💼 Vamos nos conectar:  [LinkedIn](https://www.linkedin.com/in/deizianer/)

📧 [deizianerodriguesdev@hotmail.com](deizianerodriguesdev@hotmail.com)
