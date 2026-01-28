using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Repositorio.Contexto
{
    public class SmartCashContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        private readonly DbContextOptions _options;
        public SmartCashContexto()
        {
            
        }

        public SmartCashContexto(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options == null)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-58UEHOH\\SQLEXPRESS01;DataBase=SmartCashDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

    }
}