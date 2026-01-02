# Blazor Server + Identity + SQL Server + Docker

## 📦 Visão Geral

Este projeto é uma aplicação **Blazor Server** configurada com **ASP.NET Core Identity**, **Entity Framework Core**, **SQL Server** e totalmente containerizada utilizando **Docker** e **Docker Compose**.

A solução oferece um sistema completo de autenticação, persistência de dados e um exemplo de CRUD (`Contacts`) executando em um ambiente de desenvolvimento Dockerizado.

---

## 🔐 Autenticação e Autorização

- Utiliza **ASP.NET Core Identity** para autenticação e autorização
- Identity integrado ao **Entity Framework Core**
- Usuários, papéis e dados de autenticação armazenados no **SQL Server**
- Funcionalidades disponíveis:
  - Registro de usuários
  - Login e logout
  - Navegação autenticada utilizando `AuthorizeView`
- Esquema do banco gerenciado via **EF Core Migrations**
- A aplicação detecta automaticamente migrações pendentes e permite aplicá-las em tempo de execução

---

## 🗄️ Banco de Dados e Entity Framework

- **SQL Server 2022** como mecanismo de banco de dados
- **Entity Framework Core** configurado com:
  - `ApplicationDbContext` para Identity e entidades da aplicação
- Entidade de exemplo incluída:
  - `Contact` (CRUD totalmente implementado)
- Persistência garantida por meio de **Docker Volume**, evitando perda de dados ao reiniciar os containers

---

## 📋 CRUD de Contacts

O módulo de contatos foi implementado utilizando:

- Componentes Blazor
- **QuickGrid** para listagem
- **EF Core** para acesso a dados

Páginas disponíveis:
- Listagem
- Criação
- Edição
- Detalhes
- Exclusão

---

## 🐳 Docker e Docker Compose

Todo o ambiente é executado via **Docker Compose**.

### Serviços:
- Aplicação Blazor Server
- SQL Server 2022

### Infraestrutura:
- Comunicação entre containers via **Docker bridge network**
- Persistência do banco via **Docker named volume**
- Portas expostas:
  - Aplicação: `http://localhost:8081`
  - SQL Server: `localhost:1433`

---

## 🔄 Ambiente e Configuração

- Connection strings configuradas para funcionar corretamente dentro do Docker usando nomes de serviços
- Suporte a execução local e containerizada
- Redirecionamento HTTPS desabilitado no container para simplificação
- Endpoint de migrações habilitado para facilitar o setup em desenvolvimento

---

## ✅ Estado Atual do Projeto

- Aplicação executa corretamente em ambiente Docker
- Banco de dados persiste entre reinícios dos containers
- Autenticação via Identity funcionando
- CRUD de Contacts funcionando corretamente
- Projeto pronto para evolução ou ajustes para produção

---

## 🧠 Notas de Arquitetura

- **Blazor Server** foi escolhido para permitir renderização no servidor com atualizações em tempo real via SignalR
- A aplicação utiliza **injeção direta de `ApplicationDbContext`** com tempo de vida *scoped*, o que é adequado para:
  - Operações síncronas e assíncronas controladas
  - Integração com ASP.NET Core Identity
  - Cenários CRUD tradicionais em Blazor Server
- O gerenciamento do ciclo de vida do `DbContext` é feito pelo contêiner de DI do ASP.NET Core
- Docker Compose garante padronização de ambiente e facilita o onboarding de novos desenvolvedores
- EF Core Migrations fornecem versionamento e evolução controlada do esquema do banco de dados


--------------------------------------------------------------------------------------------------------------------------------------------

# Blazor Server + Identity + SQL Server + Docker

## 📦 Project Overview

This project is a **Blazor Server application** configured with **ASP.NET Core Identity**, **Entity Framework Core**, **SQL Server**, and fully containerized using **Docker** and **Docker Compose**.

The solution provides a complete authentication system, database persistence, and a sample CRUD module (`Contacts`) running in a Dockerized development environment.

---

## 🔐 Authentication & Authorization

- Uses **ASP.NET Core Identity** for authentication and authorization
- Identity integrated with **Entity Framework Core**
- User accounts, roles, and authentication data stored in **SQL Server**
- Supported features:
  - User registration
  - Login and logout
  - Authenticated navigation using `AuthorizeView`
- Database schema managed via **EF Core Migrations**
- The application automatically detects pending migrations and allows applying them at runtime

---

## 🗄️ Database & Entity Framework

- **SQL Server 2022** used as the database engine
- **Entity Framework Core** configured with:
  - `ApplicationDbContext` for Identity and application entities
- Sample entity included:
  - `Contact` (fully implemented CRUD)
- Database persistence guaranteed using a **Docker named volume**, preventing data loss across container restarts

---

## 📋 Contacts CRUD

The Contacts module is implemented using:

- Blazor components
- **QuickGrid** for listing
- **EF Core** for data access

Available pages:
- List
- Create
- Edit
- Details
- Delete

---

## 🐳 Docker & Docker Compose

The entire environment runs using **Docker Compose**.

### Services:
- Blazor Server application
- SQL Server 2022

### Infrastructure:
- Containers communicate via a dedicated **Docker bridge network**
- Database persistence via **Docker named volume**
- Exposed ports:
  - Application: `http://localhost:8081`
  - SQL Server: `localhost:1433`

---

## 🔄 Environment & Configuration

- Connection strings configured to work correctly inside Docker using service names
- Supports both local and containerized execution
- HTTPS redirection disabled in containers for simplicity
- Migrations endpoint enabled to simplify development setup

---

## ✅ Current State

- Application builds and runs fully inside Docker
- Database schema persists across container restarts
- Identity authentication works correctly
- Contacts CRUD works correctly
- Ready for further development or production hardening

---

## 🧠 Architecture Notes

- **Blazor Server** was chosen to enable server-side rendering with real-time updates via SignalR
- The application uses **direct injection of `ApplicationDbContext`** with a *scoped* lifetime, which is suitable for:
  - Controlled synchronous and asynchronous operations
  - Integration with ASP.NET Core Identity
  - Traditional CRUD scenarios in Blazor Server
- The `DbContext` lifecycle is managed by the ASP.NET Core dependency injection container
- Docker Compose ensures environment consistency and simplifies developer onboarding
- EF Core migrations provide versioned and repeatable database schema evolution


--------------------------------------------------------------------------------------------------------------------------------------------

## ▶️ Como Executar o Projeto

### Pré-requisitos
- [Docker](https://www.docker.com/get-started) instalado e em execução
- [Docker Compose](https://docs.docker.com/compose/install/) instalado
- .NET 9.0 SDK instalado (para execução local, opcional)
- Visual Studio 2022 ou superior / VS Code (opcional)
- Navegador web moderno

### Passos para Executar
1. Clone este repositório:
   ```bash
   git clone
2. Navegue até o diretório do projeto:
   ```bash
   cd BlazorSqlServerDev
3. Construa e inicie os containers usando Docker Compose:
   ```bash
   docker-compose up --build
4. Acesse a aplicação no navegador:
   ```
   http://localhost:8081
5. Use o endpoint de migrações para aplicar quaisquer migrações pendentes:
   ```
   http://localhost:8081/migrations
6. Registre um novo usuário ou faça login com uma conta existente.
7. Navegue até a seção de Contacts para testar o CRUD.
8. Para derrubar os containers, use:
   ```bash
   docker-compose down
9. Para manter os dados do banco, não use a flag `-v` ao parar os containers.
10. Para apenas pausar os containers, use:
	```bash
	docker-compose stop
11. Para reiniciar os containers pausados, use:
	```bash
    docker-compose start

### Observações
- Quando rodar pelo visual studio ele tenta rodar localmente e não via docker.
- Se já tiver os containers criados no docker, é só rodar o comando `docker-compose start` no terminal na pasta do projeto.
- E acessar a url http://localhost:8081 no navegador.