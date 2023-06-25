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

        public async Task<Avaliacao[]> GetAllAvalAsynch(bool IncludeCliente)
        {
            IQueryable<Avaliacao>? query = _context.Avaliacoes;

            if (IncludeCliente)
            {
                query = query!.Include(av => av.clientesAvaliados!).ThenInclude(av => av.Cliente);
            }

            query = query!.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente[]> GetAllClientAsynch(bool IncludeAvaliacao)
        {
            IQueryable<Cliente>? query = _context.Clientes;

            // if (IncludeAvaliacao)
            // {
            //     query = query!.Include(ca => ca.clientesAvaliados!).ThenInclude(av => av.Avaliacao);
            // }

            query = query!.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente[]> GetAllClientTwoFieldsAsynch(bool IncludeAvaliacao)
        {
            IQueryable<Cliente>? query = _context.Clientes;

            query = query!.Select(c => new Cliente()
            {
                Id = c.Id,
                RazaoSocial = c.RazaoSocial
            }).AsQueryable();

            return await query.ToArrayAsync();

        }

        public Task<Avaliacao> GetAvalAsynchById(int AvaliacaoId, bool IncludeCliente)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> GetClientAsyncByCnpj(string cnpjNumber)
        {
            IQueryable<Cliente>? query = _context.Clientes;

            query = query!.AsNoTracking().Where(cli => cli.Cnpj == cnpjNumber).OrderBy(cli => cli.Cnpj);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetClientAsynckById(int ClienteId, bool IncludeAvaliacao)
        {
            IQueryable<Cliente>? query = _context.Clientes;

            query = query!.AsNoTracking().Where(c => c.Id == ClienteId).OrderBy(c => c.Id);

            return await query.FirstOrDefaultAsync();


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