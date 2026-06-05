using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieRental.Application.Features.Dvds.Commands.UpdateDvd
{
    public record UpdateDvdCommand(Guid Id,
                                    string Title,
                                    int Genre,
                                    DateTime Published,
                                    Guid DirectorId,
                                    int Copies) : IRequest<UpdateDvdResponse>;
}
