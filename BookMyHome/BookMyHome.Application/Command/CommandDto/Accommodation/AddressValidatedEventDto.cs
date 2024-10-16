using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyHome.Application.Command.CommandDto.Accommodation
{
    public record AddressValidatedEventDto(Guid DawaCorrelationId, Guid DawaId, AddressValidationStateDto ValidationState);
}
