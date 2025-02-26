var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); 

//app.UseAuthorization(); 

//app.MapControllers();

//By  AddEndpointsApiExplorer(), the /check endpoint will be included in the Swagger documentation, making it easier to discover and test through the Swagger UI.
app.MapGet("/check", () => "OK");

app.Run();
