# AcmeSistemaServidor

Este repositório contém o backend do sistema de cadastro de pacientes e registro de tratamentos, desenvolvido como parte de um processo seletivo para desenvolvedor trainee.

## Contexto

O objetivo do projeto era criar um sistema capaz de realizar o cadastro de pacientes e registrar tratamentos associados a cada paciente. Esta aplicação representa a parte de backend do sistema, responsável por gerenciar a lógica de negócio, persistência de dados e disponibilização de endpoints para operações relacionadas a pacientes e tratamentos.

## Funcionalidades

- Cadastro, listagem, atualização e remoção de pacientes.
- Registro de tratamentos para pacientes cadastrados.
- Listagem de tratamentos associados a um paciente.
- Validações básicas dos dados recebidos.
- API RESTful para integração com o frontend ou outros clientes.

## Tecnologias Utilizadas

- **Linguagem:** C# (.NET 8)
- **Framework:** ASP.NET Core 8
- **ORM:** Entity Framework Core 8
- **Banco de Dados:** PostgreSQL
- **Documentação de API:** Swagger (Swashbuckle.AspNetCore)
- **Driver PostgreSQL:** Npgsql

### Principais Dependências

- `Microsoft.EntityFrameworkCore`
- `Microsoft.EntityFrameworkCore.Design`
- `Microsoft.EntityFrameworkCore.Tools`
- `Npgsql`
- `Npgsql.EntityFrameworkCore.PostgreSQL`
- `Swashbuckle.AspNetCore`

## Como executar

1. **Clone este repositório:**
   ```bash
   git clone https://github.com/bigparty1/AcmeSistemaServidor.git
   ```

2. **Acesse a pasta do projeto:**
   ```bash
   cd AcmeSistemaServidor
   ```

3. **Configure a string de conexão do banco de dados:**
   - Edite o arquivo `appsettings.json` (ou utilize variáveis de ambiente) para informar a string de conexão do PostgreSQL.

4. **Rode as migrations para criar a base de dados:**
   ```bash
   dotnet ef database update
   ```

5. **Execute o servidor:**
   ```bash
   dotnet run
   ```

6. **Acesse a documentação Swagger:**
   - Após iniciar o servidor, acesse: [http://localhost:5000/swagger](http://localhost:5000/swagger) (ou porta configurada) para visualizar e testar a API.

## Endpoints Principais

- `GET /pacientes` — Lista todos os pacientes
- `POST /pacientes` — Cadastra um novo paciente
- `PUT /pacientes` — Atualiza os dados de um paciente
- `GET /tratamentos` — Lista tratamentos de um paciente
- `POST /tratamentos` — Registra tratamento para um paciente
- `PUT /tratamentos` — Atualiza tratamento de um paciente

> Consulte o Swagger para detalhes de payload, parâmetros e respostas.

## Estrutura do Projeto

```
src/
├── Controllers/
├── Data/
├── Migrations/
├── repositorio/
├── Program.cs
├── appsettings.json
└── ...
```

> A estrutura pode variar, ajuste conforme o padrão adotado no projeto.

## Contribuição

Este projeto foi desenvolvido para fins avaliativos, mas sugestões e melhorias são bem-vindas!

## Licença

Este projeto está sob a licença MIT.

---

Desenvolvido por [bigparty1](https://github.com/bigparty1) durante processo seletivo para desenvolvedor trainee.
