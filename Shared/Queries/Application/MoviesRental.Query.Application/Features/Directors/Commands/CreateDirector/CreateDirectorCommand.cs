using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesRental.Query.Application.Features.Directors.Commands.CreateDirector
{
    public record CreateDirectorCommand(
        string Id,
        string FullName,
        DateTime CreatedAt,
        DateTime UpdatedAt) : IRequest<bool>;

}
