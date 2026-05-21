var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços de controladores ao pipeline.
builder.Services.AddControllers();

var app = builder.Build();

// Mapeia os controladores para as rotas.
app.MapControllers();

app.Run();

