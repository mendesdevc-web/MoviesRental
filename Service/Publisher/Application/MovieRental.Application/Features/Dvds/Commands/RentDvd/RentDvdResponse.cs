using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Dvds.Commands.RentDvd
{
    public record RentDvdResponse(string Id, DateTime UpdatedAt);
}
