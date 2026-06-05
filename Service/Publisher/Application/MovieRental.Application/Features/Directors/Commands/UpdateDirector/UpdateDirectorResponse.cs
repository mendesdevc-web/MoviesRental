using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Directors.Commands.UpdateDirector
{
    public record UpdateDirectorResponse(string Id, String FullName, DateTime UpdatedAt);
    
}
