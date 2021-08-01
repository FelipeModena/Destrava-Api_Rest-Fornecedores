# Destrava-Api_Rest-Fornecedores
Api montada pra fazer tratamento de cadastros de informaçoes de fornecedores.

<<--->>

# Requisitos:



Fazer uso de algum editor de texto, e o mais recomendável é o Visual Studio, pois ele já vem com o NUGet para gerenciamento de pacotes.

Para iniciar a aplicação no Visual Studio, apenas compilar com Ctrl+f5;

Para outros, ir na raiz da aplicação onde se encontra o arquivo STARTUP.cs e rodar:

-dotnet restore (para baixar dependencias necessarias);

-dotnet run;

Logo apos, adicionar a URL localhost:xxxx//swagger/index.html, para assim fazer uso da interface grafica criada pelo Swagger;

(Toda a autenticação foi desativada por conta da interface grafica do swaager, porém ela pode ser reativada apenas removendo as tag's [AllowAnonymous])

Se nao achar interessante, é aconcelhavel usar o Postman para testar a autenticação da aplicaçao, que tem por sua vez dentro de Services/TokenSericeFornecedor.cs um gerador de tokens de autenticaçao.

<---->
# Descrição dos pacotes 
Foi usado na aplcação os seguintes pacotes:
Microsoft.EntityFrameworkCore: Para fazer a relacionamento de tabelas, geraçao de Migrations para banco de dados, e toda a sua camada de Contexto na Model/Context/MySQLContext;

Pomelo.EntityFrameworkCore: para fazer relacionamento de tabelas para o modelo especifico do banco de dados do MySQL.


Swashbuckle.AspNetCore: para versionamento da aplicação. Por ela estar em inicio, achei necessario gerar apenas a versao inicial em Startup.cs:
//Startup.cs

          public void ConfigureServices(IServiceCollection services){
              services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Fornecedor", Version = "v1" });
              });
         }
       
