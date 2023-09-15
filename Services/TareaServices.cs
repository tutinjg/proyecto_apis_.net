public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }


    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tarea.CategoriaId = tarea.CategoriaId;
            tareaActual.Descripcion = tarea.Descripcion;
            tarea.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = tarea.FechaCreacion;
            tarea.Resumen = tarea.Resumen;
            tareaActual.Responsable = tarea.Responsable;
            await context.SaveChangesAsync();
        }
    }


    public async Task Delete(Guid id)
    {
        var TareaActual = context.Tareas.Find(id);
        if(TareaActual != null)
        {
            context.Remove(TareaActual);

            await context.SaveChangesAsync();
        }
    }
}