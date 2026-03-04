# 🏍️ Mottu Desafio - Back-End (.NET)

API desenvolvida em **.NET 9** utilizando **Arquitetura em Camadas (Domain, Application, InfraData, InfraIoC, API)** com autenticação JWT e persistência em PostgreSQL.

---

## 🚀 Tecnologias Utilizadas

* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* JWT Authentication
* xUnit (Testes Unitários)
* Docker (opcional)

---

## 📂 Estrutura do Projeto

```
MottuDesafio
│
├── MottuDesafio.API          → Controllers e configuração da API
├── MottuDesafio.Domain       → Entidades e enums
├── MottuDesafio.Application  → Regras de negócio (Services)
├── MottuDesafio.InfraData    → DbContext e Repositories
├── MottuDesafio.InfraIoC     → Injeção de Dependência
└── MottuDesafio.Tests        → Testes unitários
```

---

## 🔐 Autenticação

A API utiliza autenticação via **JWT Bearer Token**.

Fluxo:

1. Criar usuário
2. Realizar login
3. Copiar o token retornado
4. Inserir no Swagger no botão **Authorize**:

```
Bearer {seu_token}
```

---

## 🗄️ Banco de Dados

Banco utilizado: **PostgreSQL**

Configuração no `appsettings.json`:

```json
"ConnectionStrings": {
  "MotoConnection": "Host=localhost;Port=5432;Database=NomeBanco;Username=postgres;Password=senha"
}
```

Para aplicar migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 📌 Principais Entidades

### 🏍️ Motorcycle

* Id
* Model
* Year
* Plate

### 👤 DeliveryMen

* Id
* UserId
* Name
* Cnpj
* DateOfBirth
* CnhNumber
* CnhType
* CnhImagePath

### 📄 Lease

* Id
* MotorcycleId
* DeliveryMenId
* StartDate
* EndDate
* ExpectedEndDate
* Plans

---

## 🧪 Testes

O projeto possui testes unitários utilizando **xUnit**.

Para rodar os testes:

```bash
dotnet test
```

Os testes cobrem:

* Entidades
* Regras básicas
* Instanciação correta dos objetos

---

## ▶️ Como Executar o Projeto

1. Clonar o repositório
2. Configurar a string de conexão
3. Executar as migrations
4. Rodar a aplicação

```bash
dotnet run --project MottuDesafio.API
```

A API estará disponível em:

```
https://localhost:5001/swagger
```

---

## 🐳 Docker (Opcional)

Caso utilize Docker para o PostgreSQL:

```yaml
version: '3.8'
services:
  postgres:
    image: postgres:latest
    container_name: postgres
    environment:
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: senha
      POSTGRES_DB: MottuDB
    ports:
      - "5432:5432"
```

---

## 📌 Melhorias Futuras

* Validações de domínio mais robustas
* Testes de integração com banco InMemory
* Controle de concorrência
* Upload real de imagem da CNH
* CI/CD com GitHub Actions

---

## 👨‍💻 Autor

Desenvolvido como desafio técnico focado em boas práticas de arquitetura, autenticação e persistência de dados com .NET.

---

## 📄 Licença

Projeto para fins educacionais e de portfólio.
