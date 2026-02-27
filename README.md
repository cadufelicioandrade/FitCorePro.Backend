# FitCorePro.Backend
Abordagem Arquitetural

O projeto segue os princípios de:
- DDD (Domain-Driven Design)
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Modular Monolith
- JWT Authentication

A aplicação foi projetada como um Modular Monolith, permitindo alta coesão por domínio e baixo acoplamento entre módulos, 
com possibilidade de extração futura para microserviços sem refatoração estrutural.

src/
 ├── Api/
 │     FitCore.Api
 │
 ├── BuildingBlocks/
 │     FitCore.SharedKernel
 │
 └── Modules/
       ├── Identity/
       │     ├── FitCore.Identity.Domain
       │     ├── FitCore.Identity.Application
       │     └── FitCore.Identity.Infrastructure
       │
       ├── Nutrition/
       │     ├── Planning/
       │     │     ├── Domain
       │     │     ├── Application
       │     │     └── Infrastructure
       │     │
       │     └── Tracking/
       │           ├── Domain
       │           ├── Application
       │           └── Infrastructure
       │
       ├── Training/
       │     ├── Domain
       │     ├── Application
       │     └── Infrastructure
       │
       └── BodyComposition/
             ├── Domain
             ├── Application
             └── Infrastructure


Clean Architecture

Cada módulo é dividido em três camadas:

1️⃣  Domain

Entidades
Aggregates
Regras de negócio
Value Objects
Não depende de nenhuma outra camada.

2️⃣  Application

Use Cases
Commands e Queries
DTOs
Interfaces (repositórios, serviços)
Depende apenas do Domain.

3️⃣  Infrastructure

EF Core
Repositórios
Configurações de banco
Implementações técnicas
Depende da camada Application.
API Layer
Minimal APIs / Controllers
Middleware
Autenticação JWT
Versionamento de API
Swagger

🔄 CQRS

O projeto separa operações de:

-Commands (escrita)
Criar plano semanal
Adicionar refeição
Registrar alimento
Iniciar treino
Logar série

- Queries (leitura)
Buscar plano ativo
Buscar dieta do dia
Histórico de treinos
Evolução corporal

Essa separação permite:
Melhor organização de código
Escalabilidade futura
Otimização de leitura independente da escrita

🔐 Autenticação

Autenticação baseada em JWT (JSON Web Token):

Access Token
Refresh Token
Middleware de validação
Autorização via [Authorize]
Integração ideal para aplicações mobile (Android/iOS).

🗄️ Banco de Dados

Banco recomendado:
PostgreSQL (Azure Database for PostgreSQL)
Justificativas:
Excelente para dados históricos (time-series)
Alta performance
Compatível com EF Core (Npgsql)