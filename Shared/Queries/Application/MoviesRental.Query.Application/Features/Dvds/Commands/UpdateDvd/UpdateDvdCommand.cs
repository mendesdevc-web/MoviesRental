using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesRental.Query.Application.Features.Dvds.Commands.UpdateDvd
{
    public record UpdateDvdCommand(
        string Id,
        string Title,
        string Genre,
        DateTime Published,
        int Copies,
        string DirectorId,
        DateTime UpdatedAt
        ) : IRequest<bool>;
}
