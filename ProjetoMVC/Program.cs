// Cria um construtor do aplicativo web
var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços MVC - permitindo o uso de controladores e visualizações
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Verifica se o ambiente não é de desenvolvimento para configurar o tratamento de exceções
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Habilita o uso de arquivos estáticos (como CSS, JavaScript, imagens, etc.)
app.UseStaticFiles();

// Permite o sistema de roteamento para direcionar as requisições HTTP para os controladores apropriados
app.UseRouting();

// Habilita a autorização para proteger rotas e recursos, se necessário
app.UseAuthorization();

// Configura a rota padrão para os controladores, onde "Home" é o controlador padrão e "Index" é a ação padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Inicia o aplicativo web e começa a escutar as requisições HTTP
app.Run();
