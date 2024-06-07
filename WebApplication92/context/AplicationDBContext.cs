using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApplication92.context
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions options): base(options) { }

        //Modelos a mapear

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Libro> Libros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Thiago",
                    UserName = "Usuario1",
                    Password = "123",
                    FkRol = 1
                });

            //Insertar en la tabla Rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "SA"
                });
        }

    }
}
