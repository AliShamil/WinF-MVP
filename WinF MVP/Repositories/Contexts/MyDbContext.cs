using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinF_MVP.Models;

namespace WinF_MVP.Repositories.Contexts;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var path = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(path, false);
        IConfigurationRoot root = builder.Build();
        var sqlConnectionString = root.GetConnectionString("DefaultConnectionStr");

        optionsBuilder.UseSqlServer(sqlConnectionString);

        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Student>? Students { get; set; }
}
