using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesRental.Query.Application.Features.Dvds.Commands.CreateDvid
{
    public record CreateDvdCommand(
       string Id,
       string Title,
       string Genre,
       DateTime Published,
       bool Available,
       int Copies,
       string DirectorId,
       DateTime CreatedAt,
       DateTime UpdatedAt) :  IRequest<bool>;
}
