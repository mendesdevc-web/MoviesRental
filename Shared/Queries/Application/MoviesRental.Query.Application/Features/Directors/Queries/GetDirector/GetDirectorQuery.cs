using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Directors.Queries.GetDirector
{
    public record GetDirectorQuery(string FullName) : IRequest<GetDirectorResponse>;
}
