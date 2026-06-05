using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Directors.Commands.DeleteDirector
{
    public record DeleteDirectorCommand(Guid Id) : IRequest<bool>;
    
}
