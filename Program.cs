using apicemig.Data;
using apigerenciamentocontrato.Repository;
using apigerenciamentocontrato.Repository.ClientRepository;
using apigerenciamentocontrato.Repository.ContractRepository;
using apigerenciamentocontrato.Services;
using apigerenciamentocontrato.Services.ClientService;
using apigerenciamentocontrato.Services.ClientServices;
using apigerenciamentocontrato.Services.ContractServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

//Chamada para se conectar ao banco de dados
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
  options =>
  options.UseMySql(
      //Pegando as configurações de acesso ao BD
      builder.Configuration.GetConnectionString("ConexaoBanco"),
      //Detectando o Servidor de BD
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
  )
);

// Add services to the container.
builder.Services.AddScoped<ServiceClient>();
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<ServiceContact>();
builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<ServiceAddress>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<ServiceContract>();
builder.Services.AddScoped<ContractRepository>();
builder.Services.AddScoped<ServiceEnergyMeters>();
builder.Services.AddScoped<EnergyMetersRepository>();
builder.Services.AddScoped<ServiceInvoice>();
builder.Services.AddScoped<InvoiceRepository>();
builder.Services.AddScoped<ServicePayment>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<ServicesReading>();
builder.Services.AddScoped<ReadingRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
