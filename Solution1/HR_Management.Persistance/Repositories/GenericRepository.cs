using HR_Management.Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistance.Repositories;

public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
{
    #region Constructor

    private readonly LeaveManagementDbContext _context;

    public GenericRepository(LeaveManagementDbContext context)
    {
        _context = context;
    }

    #endregion

    #region GetAsync

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    #endregion

    #region GetAll

    public async Task<IReadOnlyList<TEntity>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    #endregion

    #region Exist

    public async Task<bool> Exist(int id)
    {
        var entity = await GetByIdAsync(id);
        return entity != null;
    }

    #endregion

    #region Add

    public async Task<TEntity> Add(TEntity entity)
    {
        await _context.AddAsync(entity);

        await _context.SaveChangesAsync();
        return entity;
    }

    #endregion

    #region Update

    public async Task Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    #endregion

    #region Delete

    public async Task Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

    }

    #endregion
    
}