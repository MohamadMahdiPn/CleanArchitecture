namespace HR_Management.Application.Persistance.Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IReadOnlyList<TEntity>> GetAll();
    Task<bool> Exist(int id);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> Delete(TEntity entity);

}