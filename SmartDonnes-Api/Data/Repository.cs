using Microsoft.EntityFrameworkCore;
using SmartDonnes_Api.Models;

namespace SmartDonnes_Api.Data
{

    public class Repository : IRepository
    {
        private readonly MyDataContext _context;
        public Repository(MyDataContext context)
        {
            _context = context;
        }
        public void CreateData<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void DeleteData<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<Avaliacao[]> GetAllAvalAsynch(bool IncludeCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente[]> GetAllClientAsynch(bool IncludeAvaliacao)
        {
             IQueryable<Cliente>? query = _context.Clientes;

            if (IncludeAvaliacao)
            {
                query = query!.Include(ca => ca.ClienteAvaliacao!).ThenInclude(av => av.Avaliacao);
            }

            query = query!.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public Task<Avaliacao> GetAvalAsynchById(int AvaliacaoId, bool IncludeCliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetClientAsynckById(int ClienteId, bool IncludeAvaliacao)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveDataAsynch()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void UpdateData<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}