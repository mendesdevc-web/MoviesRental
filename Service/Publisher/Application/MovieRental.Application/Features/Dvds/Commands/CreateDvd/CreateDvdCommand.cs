using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRental.Application.Features.Dvds.Commands.CreateDvd
{
    public record CreateDvdCommand(
        string Title,
        int Genre,
        DateTime Published,
        int Copies,
        Guid DirectorId) : IRequest<CreateDvdResponse>;
}
