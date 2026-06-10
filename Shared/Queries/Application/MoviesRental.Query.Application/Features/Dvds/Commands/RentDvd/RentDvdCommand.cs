using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesRental.Query.Application.Features.Dvds.Commands.RentDvd
{
    public record RentDvdCommand(string Id, DateTime UpdatedAt) : IRequest<bool>;
}
