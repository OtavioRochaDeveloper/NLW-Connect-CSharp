📄 Descrição

O NLW-Connect-CSharp é uma API REST desenvolvida em C# com .NET, ideal para servir como backend em aplicações web ou mobile. Ele integra diversas bibliotecas e frameworks comumente utilizados no ecossistema .NET para gerenciar dados, autenticação, validação e persistência com SQLite.

Funcionalidades principais

Manipulação de entidades de domínio por meio de ORM com Microsoft.EntityFrameworkCore (com banco SQLite via Microsoft.EntityFrameworkCore.Sqlite). 


Validação de dados de entrada usando FluentValidation. 


Autenticação e autorização via token JWT com uso de System.IdentityModel.Tokens.Jwt e Microsoft.AspNetCore.Authentication.JwtBearer. 


Hash de senhas seguro com BCrypt.Net-Next. 


Estrutura organizada em camadas — domínio, serviços, controllers, filtros, casos de uso — visando separação de responsabilidades e manutenção facilitada. 


🛠️ Tecnologias

[.NET / C#]

Microsoft.EntityFrameworkCore + SQLite

FluentValidation

BCrypt.Net-Next

JWT / Token-based Authentication (System.IdentityModel.Tokens.Jwt + JwtBearer)

ASP.NET Core Web API

🚀 Como rodar o projeto localmente
Pré-requisitos

.NET SDK instalado (versão compatível com o projeto)

Git para clonar o repositório

Passos
# 1. Clone o repositório
git clone https://github.com/OtavioRochaDeveloper/NLW-Connect-CSharp.git

# 2. Acesse a pasta do projeto
cd NLW-Connect-CSharp

# 3. (Opcional) restaure dependências
dotnet restore

# 4. Rode a aplicação
dotnet run


Ou, se preferir, abra a solução (.sln) no Visual Studio/VS Code e inicie a aplicação por IDE.

Se o banco estiver configurado para SQLite com arquivo local, a base de dados será criada automaticamente (dependendo da configuração de migrações / inicialização).

✅ Estrutura do projeto
/Controllers       → Endpoints da API  
/Domain/Entities   → Classes de domínio (modelos de dados)  
/Filters           → Filtros (middleware, autenticação, tratamento, etc.)  
/Services/LoggedUser → Serviços de autenticação / usuário  
/UseCases          → Lógica de negócio / casos de uso  
/infraestructure   → Configuração de infraestrutura (banco, contexto, etc.)  
Program.cs         → Configuração da aplicação e pipeline  
appsettings.json   → Configurações (conexão, JWT, etc.)  


Essas camadas ajudam a organizar o código de forma clara e modular. 


🔐 Autenticação & Segurança

O sistema utiliza JWT para autenticação/autorizaçāo, garantindo:

Senhas armazenadas de forma segura com hash via BCrypt.

Validação de dados de entrada com FluentValidation, evitando dados inválidos ou maliciosos.

Uso de middlewares/pipelines para verificar autenticação antes de acessar recursos protegidos.

🤝 Como contribuir

Contribuições são bem-vindas! Para contribuir:

Fork este repositório.

Crie uma branch com a feature/fix: git checkout -b minha-feature.

Faça suas modificações e commit: git commit -m "Minha contribuição".

Envie para sua branch: git push origin minha-feature.

Abra um Pull Request descrevendo as mudanças.
