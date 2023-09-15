public interface ITareaService
{
    IEnumerable<Tarea> Get();

    Task Save(Tarea tarea);

    Task Update(Guid TareaId, Tarea tarea);

    Task Delete(Guid TareaId);
}