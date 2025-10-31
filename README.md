 
 # 🧩 API_FCG_F01

 ## 🚀 Aplicação ASP.NET Core 8 com Arquitetura Limpa

 A API_FCG_F01 é uma aplicação desenvolvida em .NET 8, estruturada segundo os princípios da Clean Architecture, garantindo baixo acoplamento, alta coesão e facilidade de manutenção. O projeto foi organizado em múltiplos projetos (camadas), promovendo separação clara de responsabilidades e escalabilidade.

 ---

 ## 🏗️ Estrutura do Projeto

 A solução está dividida nos seguintes projetos, cada um com uma responsabilidade bem definida:

 API_FCG_F01.sln
 ├── API_FCG_F01.API → Camada de apresentação (Controllers, Middlewares, Swagger)
 ├── API_FCG_F01.Application → Casos de uso, DTOs, serviços de aplicação e mapeamentos
 ├── API_FCG_F01.Domain → Entidades, agregados, enums e validações de negócio
 ├── API_FCG_F01.Infra.Data → Contexto do EF Core, repositórios e migrations
 └── API_FCG_F01.Infra.IoC → Configuração da injeção de dependências



 ---

 ## 🏛️ Diagrama da Arquitetura

 O diagrama abaixo ilustra como as dependências fluem entre as camadas, seguindo o princípio da Arquitetura Limpa, onde as dependências sempre apontam para o interior.

 ```mermaid
 graph TD
    subgraph "Apresentação"
        API[API_FCG_F01.API]
    end

    subgraph "Aplicação"
        App[API_FCG_F01.Application]
    end

    subgraph "Domínio (Núcleo)"
        Domain[API_FCG_F01.Domain]
    end

    subgraph "Infraestrutura"
        Data[API_FCG_F01.Infra.Data]
        IoC[API_FCG_F01.Infra.IoC]
    end

    API --> App
    API --> IoC
    App --> Domain
    Data --> Domain
    IoC -.-> App
    IoC -.-> Data

    style Domain fill:#f9f,stroke:#333,stroke-width:2px


 🔌 Pipeline de Injeção de Dependência

 O fluxo de configuração dos serviços começa no Program.cs da camada de API e é delegado para o projeto Infra.IoC, que centraliza todos os registros.

 flowchart TD
    A[Program.cs] --> B{Chama DependencyInjection.RegisterServices};
    B --> C[Registra DbContext<br/>(Infra.Data)];
    B --> D[Registra Repositórios<br/>(Infra.Data)];
    B --> E[Registra Serviços de Aplicação<br/>(Application)];
    B --> F[Registra AutoMapper<br/>(Application)];
    B --> G[Registra outras configurações<br/>(ex: Authentication)];
    C --> H[Container de DI do .NET];
    D --> H;
    E --> H;
    F --> H;
    G --> H;

 🔄 Fluxo de um Endpoint

 Este diagrama mostra o percurso de uma requisição HTTP desde sua chegada até a resposta, passando por todas as camadas da arquitetura.

 flowchart LR
    A[Requisição HTTP] --> B[API Controller];
    B --> C[Application Service<br/>(Caso de Uso)];
    C --> D[IRepository Interface<br/>(Definida no Domain)];
    D --> E[Repository Implementation<br/>(Implementada no Infra.Data)];
    E --> F[Entity Framework Core];
    F --> G[Base de Dados SQL Server];

    G -.-> F;
    F -.-> E;
    E -.-> D;
    D -.-> C;
    C -.-> B;
    B -.-> H[Resposta HTTP];


 ⚙️ Tecnologias Utilizadas

 .NET 8 / C#
 ASP.NET Core Web API
 Entity Framework Core 8
 SQL Server
 AutoMapper
 JWT Authentication (Exemplo, se aplicável)
 Swagger / Swashbuckle
 Dependency Injection (IoC)

 🧱 Padrões e Arquitetura

 A solução segue os princípios da Clean Architecture, proposta por Robert C. Martin (Uncle Bob):

 Camada
 Responsabilidade Principal
 Domain	Contém as regras de negócio e entidades centrais do sistema. É a camada mais interna, sem dependências externas.
 Application	Implementa os casos de uso e orquestra a lógica de aplicação, utilizando as entidades do domínio.
 Infra.Data	Cuida da persistência e acesso a dados via EF Core, implementando interfaces definidas no Domain.
 Infra.IoC	Faz o registro das dependências e módulos de injeção, conectando a infraestrutura à aplicação.
 API	Exposição dos endpoints RESTful e configuração de middlewares, atuando como a interface da aplicação.

 🧰 Configuração do Ambiente

 🔧 Requisitos

 Visual Studio 2022 ou VS Code
 .NET SDK 8.0+
 SQL Server LocalDB ou outro servidor compatível
 ▶️ Executando a Aplicação

 1- Clone o repositório:

 git clone https://github.com/seuusuario/API_FCG_F01.git
 cd API_FCG_F01

 2- Configure a connection string no arquivo API_FCG_F01.API/appsettings.json:

 "ConnectionStrings": {
   "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=API_FCG_F01;Trusted_Connection=True;"
 }

 3- Execute as migrações do Entity Framework para criar o banco de dados:

 dotnet ef database update --project API_FCG_F01.Infra.Data --startup-project API_FCG_F01.API

 4- Inicie a aplicação:

 dotnet run --project API_FCG_F01.API

 5- Acesse a documentação da API via Swagger no navegador:

 https://localhost:7123/swagger (A porta pode variar)



 📁 Estrutura de Diretórios (resumo)


 API_FCG_F01/
 │
 ├── API_FCG_F01.API/
 │   ├── Controllers/
 │   ├── Program.cs
 │   └── appsettings.json
 │
 ├── API_FCG_F01.Application/
 │   ├── Interfaces/
 │   ├── Services/
 │   └── Mappings/
 │
 ├── API_FCG_F01.Domain/
 │   ├── Entities/
 │   ├── Enums/
 │   └── Interfaces/
 │
 ├── API_FCG_F01.Infra.Data/
 │   ├── Context/
 │   ├── Migrations/
 │   └── Repositories/
 │
 └── API_FCG_F01.Infra.IoC/
     └── DependencyInjection.cs



 🧾 Licença

 Este projeto é distribuído sob a licença MIT. Sinta-se livre para usar, modificar e distribuir conforme necessário.


