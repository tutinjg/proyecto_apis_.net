using Microsoft.EntityFrameworkCore;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Tarea> Tareas {get; set;}
    public TareasContext(DbContextOptions<TareasContext> Options) :base(Options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("2b5cfdbf-b49d-4e97-a748-96acf68dd005"), Nombre = "Actividades Pendientes", Peso = 20});
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("2b5cfdbf-b49d-4e97-a748-96acf68dd006"), Nombre = "Actividades Personales", Peso = 50});
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("2b5cfdbf-b49d-4e97-a748-96acf68dd007"), Nombre = "Actividades hechas", Peso = 0});


        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Description).IsRequired(false);
            categoria.Property(p=> p.Peso);

            // Esto nos permite pasar la coleccion creada anteriormente para luego ser cargada en la BD
            categoria.HasData(categoriasInit);
        }); 


        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("b928d690-af50-40e2-9272-26294b9df4ba"), CategoriaId = Guid.Parse("2b5cfdbf-b49d-4e97-a748-96acf68dd005"), Titulo = "Darle comida al gato", Descripcion = "Servir comida a Luna", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now, Responsable = "Natalia"});
        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("b928d690-af50-40e2-9272-26294b9df4bb"), CategoriaId = Guid.Parse("2b5cfdbf-b49d-4e97-a748-96acf68dd006"), Titulo = "Terminar curso de EF", Descripcion = "Finalizar las lecciones del curso EF", PrioridadTarea = Prioridad.Media, FechaCreacion = new DateTime(2023, 8, 20), Responsable = "Natalia"});
        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("b928d690-af50-40e2-9272-26294b9df4bc"), CategoriaId = Guid.Parse("2b5cfdbf-b49d-4e97-a748-96acf68dd007"), Titulo = "Cargar BD", Descripcion = "Poner a funcionar la BD", PrioridadTarea = Prioridad.Baja, FechaCreacion = new DateTime(2023, 8, 28), Responsable = "Natalia"});


        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            // Dentro de tarea existe una propiedad llamada tarea
            // Esta 'tarea' puede tener relacion con multiples Tareas que se encuentra dentro de categoria
            // Entonces estamos haciendo la relacion de la propiedad categoria dentro de tarea.cs con la coleccion tareas dentro de categoria.cs
            // Por utlimo agregamos la llave foranea para esta relacion 
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);

            tarea.Ignore(p=> p.Resumen);
            // IGNORAR ESTA PROPIEDAD 

            tarea.Property(p=> p.Responsable);

            // Esto nos permite pasar la coleccion creada anteriormente para luego ser cargada en la BD
            tarea.HasData(tareasInit);
        });
    }
}