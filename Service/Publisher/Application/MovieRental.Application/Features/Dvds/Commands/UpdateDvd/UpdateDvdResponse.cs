using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Dvds.Commands.UpdateDvd
{
    public record UpdateDvdResponse(string Id,
        string Title,
        string Genre,
        DateTime Published,
        int Copies,
        string DirectorId,
        DateTime UpdatedAt);
}
