using MoveisRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Contracts
{
    public interface IDvdsWriteRepository : IWriteRepository<Dvd>
    {
    }
}
