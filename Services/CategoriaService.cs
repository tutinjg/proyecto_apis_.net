using Microsoft.EntityFrameworkCore.Diagnostics;

public class CategoriaService : ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }


    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoria.Description = categoria.Description;
            categoria.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
    }


    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if(categoriaActual != null)
        {
            context.Remove(categoriaActual);

            await context.SaveChangesAsync();
        }
    }
}