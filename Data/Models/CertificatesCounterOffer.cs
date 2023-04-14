using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public record CertificatesCounterOffer(
        Guid Id,
        int Quantity,
        decimal PricePerUnit,
        DateTime CreatedTime,
        Guid CreatedByUserId);
}
