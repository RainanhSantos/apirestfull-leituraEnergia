using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicemig.Models;
using apicemig.Models.DadosCliente;
using apicemig.Models.DadosContrato;
using Microsoft.EntityFrameworkCore;

namespace apicemig.Data;

//Representação do banco em memória
public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contato> ContatoClientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Fatura> Faturas { get; set; }
    public DbSet<Medidor> Medidores { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
}