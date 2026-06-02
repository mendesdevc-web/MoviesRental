using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Directors.Commands.CreateDirector
{
    public record CreateDirectorCommand(
        string Name,
        string Surname) : IRequest<CreateDirectorResponse>;
}
