using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesRental.Query.Application.Features.Directors.Commands.DeleteDirector
{
    public record DeleteDirectorCommand(string Id) : IRequest<bool>;
}
