using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public record CertificatesOffer(
        Guid Id,
        int Quantity,
        int? Year,
        string Country,
        double PricePerUnit,
        DateTime CreatedTime,
        Guid CreatedByUserId,
        List<CertificatesCounterOffer> CertificatesCounterOffersList);

    public record CertificatesOfferRequest(
        int Quantity,
        int CertificateType,
        int? Year,
        string Country,
        double PricePerUnit,
        int Currency);
}
