using Microsoft.EntityFrameworkCore;
using MoveisRental.Domain.Entities;
using MovieRental.Application.Contracts;
using MoviesRental.Infrastructure.Context;


namespace MoviesRental.Infrastructure.Repositories
{
    public class DvdWriteRepository : IDvdsWriteRepository
    {
        private readonly MoviesRentalWriteContext _context;

        public DvdWriteRepository(MoviesRentalWriteContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Dvd entity)
        {
            await _context.Dvds.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid Id)
        {
            await _context.Dvds
                               .Where(d => d.Id == Id)
                               .ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Dvd> Get(Guid Id) =>
            await _context.Dvds.FindAsync(Id);

        public async Task<bool> Update(Dvd entity)
        {
            _context.Dvds.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
