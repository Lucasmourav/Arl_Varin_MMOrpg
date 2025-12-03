# 1. Arl_Varin_MMOrpg

2. Introdução do Projeto

Nome do Projeto:
Alr Varin MMORPG Web Portal

Resumo:
Portal web oficial do MMORPG “Alr Varin”, apresentando conteúdo institucional, notícias, comunidade e acesso à conta.

Objetivo Geral:
Oferecer um hub centralizado para jogadores gerenciarem contas, acompanhar novidades e acessar recursos oficiais.

Objetivos Específicos:
Permitir autenticação e gerenciamento básico de contas de jogadores.
Publicar conteúdos de lore, guias, atualizações e eventos.
Disponibilizar opções de download/loja e serviços de suporte.

3. Escopo do Projeto

Escopo Funcional:
Autenticação com ASP.NET Core Identity + MongoDB (@Mmorpg.Web/Controllers/AccountController.cs#11-97).
Catálogo de páginas institucionais (Descubra, Community, News, Portal, Suporte, etc.).
Localização multi-idioma com persistência via cookie (@Mmorpg.Web/Controllers/LanguageController.cs#8-34).
Geração de PDFs via Rotativa (PDF controller e view).
Health check em /health (@Mmorpg.Web/Program.cs#98-103).
Escopo Não Funcional:

Suporte a 14 culturas com fallback pt-BR (@Mmorpg.Web/Program.cs#20-83).
Layout responsivo e tema visual consistente (@Mmorpg.Web/Views/Shared/_Layout.cshtml, wwwroot/css).
Estrutura preparada para envio de e-mails (integração MailKit) (@Mmorpg.Web/Services/EmailSender.cs#13-47). _

Fora do Escopo:
Integração com Supabase (explicitamente excluída; segue memória “User decided to stop using Supabase…”).
Sistemas internos de gameplay (matchmaking, inventário, etc.).
API pública para terceiros.

4. Público-alvo / Usuários

Jogadores de “Alr Varin”.
Equipe editorial/comunidade para publicar conteúdo.
Suporte ao jogador.

5. Requisitos

Requisitos Funcionais (RF):
RF001 – Registrar conta via formulário web.
RF002 – Autenticar e manter sessão com cookie seguro.
RF003 – Exibir conteúdo localizado conforme idioma selecionado.
RF004 – Gerar PDF de conteúdos específicos (Rotativa).
RF005 – Exibir páginas estáticas (notícias, guias, suporte).

Requisitos Não Funcionais (RNF):
RNF001 – Aplicação deve suportar múltiplos idiomas com fallback pt.
RNF002 – Build rodará em .NET 8.0.
RNF003 – Autenticação via cookie deve expirar em 7 dias (@Mmorpg.Web/Program.cs#50-56).
RNF004 – Responder health check em <500ms.
Regras de Negócio:

Usuário precisa confirmar credenciais para acessar áreas restritas.
Idioma escolhido permanece por 1 ano via cookie essencial.
E-mails só são enviados se host e remetente configurados.

6. Arquitetura do Sistema
   
Descrição/Diagrama textual:
Cliente (browser) → ASP.NET Core MVC (Controllers/Views) → MongoDB (Identidade) + Camadas auxiliares (Serviço de e-mail, Rotativa PDF).

Tecnologias: ASP.NET Core 8, Razor Pages/MVC, MongoDB.Driver, AspNetCore.Identity.MongoDbCore, MailKit, Rotativa, HTML/CSS/JS. Dependências listadas em @Mmorpg.Web/Mmorpg.Web.csproj#1-22.

Estrutura de Pastas (resumo):

Controllers/ – MVC controllers.
Models/ – Modelos domínio/Identity.
ViewModels/ – DTOs de entrada.
Views/ – Razor Views organizadas por área.
Resources/ – Arquivos .resx de localização.
Services/ – Serviços (EmailSender).
Settings/ – Classes de configuração tipada.
wwwroot/ – Assets estáticos (css/js/imagens).

7. Modelagem de Dados
Modelo Conceitual:

Entidade 
ApplicationUser
 (usuário) com chaves herdadas de Identity.
Entidade 
ApplicationRole
 (papéis).
Modelo Lógico:

Coleção MongoDB Users com campos padrão Identity (Email, PasswordHash, Claims, etc.) (@Mmorpg.Web/Models/ApplicationUser.cs#7-10).
Coleção Roles (@Mmorpg.Web/Models/ApplicationRole.cs#7-10).
Modelo Físico:

Banco mmorpg_db (appsettings) com collections gerenciadas pelo AspNetCore.Identity.MongoDbCore (@Mmorpg.Web/appsettings.json#9-20).

8. Fluxos e Diagramas
Fluxo do Usuário (alto nível):

Visitante acessa home → seleciona idioma (cookie salvo).
Pode navegar entre seções (páginas informativas, notícias, etc.).
Caso precise login → formulário -> valida credenciais -> redireciona.
Usuário autenticado acessa recursos restritos (ex.: downloads).
Diagramas UML: não produzidos nesta fase; sugerido futuro desenvolvimento.

9. Interface e UX
Wireframes/Protótipos: não fornecidos.
Guia de estilos: Dark theme com tons dourados (css), tipografia consistente, background Anor Calum (segui memória de UI).
Layout principal em @Mmorpg.Web/Views/Shared/_Layout.cshtml. _

10. Implementação
Instalação:

Requisitos: .NET 8 SDK, MongoDB local.
Clonar repositório e restaurar dependências (dotnet restore).
Como rodar:

dotnet run (@Mmorpg.Web).
Como configurar:

Ajustar MongoDb e Email em appsettings.
(Opcional) 
appsettings.Development.json
 para ambientes locais.

11. APIs
Não há API REST pública. Endpoints MVC principais:

/Account/Register, /Account/Login, /Account/Logout, /Account/AccessDenied.
/Language/Set?culture=<culture>&returnUrl=<url> (GET) – persiste cookie de idioma.
Health check /health (GET).

12. Segurança
Autenticação: ASP.NET Core Identity + cookies (ApplicationCookie).
Regras de acesso: atributos [Authorize] em rotas protegidas.
Validação de dados: DataAnnotations + validação server-side MVC.
Criptografia: hash de senha via Identity (default).

13. Testes
Testes automatizados ainda não implementados.
Recomendado adicionar testes de integração (login, seleção de idioma) e unit tests para serviços (Email).

14. Deploy
Ambiente atual: Desenvolvimento (localhost:5058).
Servidor alvo sugerido: ASP.NET Core hosting (IIS/Kestrel + reverse proxy).
Passos: build (dotnet publish), provisionar MongoDB, configurar appsettings, deploy binários.
Rollback: restaurar versão anterior do pacote publicado e reverter banco conforme snapshot.

15. Manutenção
Atualizações: acompanhar versões de pacotes NuGet (Identity.MongoDbCore, MongoDB.Driver, etc.).
Logs: padrão Microsoft.Extensions.Logging (configurações em appsettings).
Reporte de bugs: registrar issues com passo a passo, logs e cultura usada.

16. Cronograma e Gestão
Concluído: migração Supabase → MongoDB Identity, localização ampla, remoção de comentários, ajustes de layout.
Futuro: expandir conteúdo localizado, implementar testes automatizados, planejar deploy de produção.

17. Orçamento
Custos de desenvolvimento: horas internas (não contabilizadas).
Hospedagem: MongoDB + hosting ASP.NET (a definir).
Manutenção: monitorar licenças/infra (Rotativa requer wkhtmltopdf). Valores TBD.

18. Anexos
Recursos visuais: pasta 
img/
 com materiais (ex.: Anor Calum).
Logs de build/deploy: bin/Debug/net8.0 (gerados automaticamente).
