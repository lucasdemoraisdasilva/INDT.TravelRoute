
# 🛫 INDT Travel Route API (.NET 8)

API REST para cadastrar e consultar rotas aéreas, retornando a **rota mais barata entre dois aeroportos**, mesmo com múltiplas conexões.

---

## ✅ Funcionalidades

- CRUD completo de Rotas (Create, Read, Update, Delete)
- Consulta da melhor rota com o menor custo
- Persistência com SQL Server Express LocalDB via Dapper
- Documentação com Swagger
- Scripts SQL incluídos
- Pronto para debug no Visual Studio
- Testes com NUnit (verificar implementação completa)

---

## 📌 Exemplo de Rotas Inseridas

```
Origem: GRU, Destino: BRC, Valor: 10
Origem: BRC, Destino: SCL, Valor: 5
Origem: GRU, Destino: CDG, Valor: 75
Origem: GRU, Destino: SCL, Valor: 20
Origem: GRU, Destino: ORL, Valor: 56
Origem: ORL, Destino: CDG, Valor: 5
Origem: SCL, Destino: ORL, Valor: 20
```

Consulta: `GRU-CDG`  
Resposta esperada: `GRU - BRC - SCL - ORL - CDG ao custo de $40`

---

## 🧰 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server Express LocalDB](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)

---

## 🚀 Como Executar

### 1. Clonar o projeto

```bash
git clone <repositorio>
cd INDT.TravelRoute
```

### 2. Criar e popular o banco

Execute os scripts localizados em:

```
/script/script.sql
```

Ou manualmente:

```bash
sqlcmd -S (localdb)\MSSQLLocalDB -i script/script.sql
```

### 3. Atualizar appsettings.json

Verifique se `appsettings.json` aponta para o LocalDB:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TravelRouteDb;Trusted_Connection=True;"
}
```

---

## ▶️ Executar a API

```bash
dotnet run --project src/INDT.TravelRoute.Api
```

Acesse:
```
https://localhost:5001/swagger
```

---

## 📬 Endpoints

### CRUD de Rotas

| Método | Endpoint           | Descrição             |
|--------|--------------------|------------------------|
| GET    | /api/routes        | Lista todas as rotas   |
| GET    | /api/routes/{id}   | Busca rota por ID      |
| POST   | /api/routes        | Cria uma nova rota     |
| PUT    | /api/routes/{id}   | Atualiza uma rota      |
| DELETE | /api/routes/{id}   | Remove uma rota        |

### Melhor Rota

| Método | Endpoint                                | Exemplo                                 |
|--------|-----------------------------------------|-----------------------------------------|
| GET    | /api/routes/best?origin=GRU&destination=CDG | Retorna melhor rota GRU → CDG |

---

## ✅ Executar Testes

Se a pasta de testes estiver presente e configurada corretamente:

```bash
dotnet test
```

---

## 📁 Estrutura

```
INDT.TravelRoute/
├── script/
│   ├── insert.sql
│   ├── delete.sql
│   ├── update.sql
│   └── select.sql
├── src/
│   └── INDT.TravelRoute.Api/
│       ├── Program.cs
│       ├── appsettings.json
│       └── ...
├── test/
│   └── UnitTests/
```

---

## ✍️ Autor

Lucas Silva  
Projeto para resolver o desafio de encontrar a **melhor rota de viagem com menor custo**, mesmo com conexões.
