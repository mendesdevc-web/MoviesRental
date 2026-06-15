using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRental.Application.Features.Directors.Commands.UpdateDirector
{
    public record UpdateDirectorCommand(Guid Id,
                                         string Name,
                                         string FullName) : IRequest<UpdateDirectorResponse>;
}
