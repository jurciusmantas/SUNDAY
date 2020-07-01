using SUNDAY.Model.Entities;
using SUNDAY.Model.Enums;
using System;
using System.Collections.Generic;

namespace SUNDAY.Model.Repositories.Taxes
{
    public interface ITaxesRepository
    {
        List<Tax> GetTaxes(int municipalityId, TaxTypes type, DateTime dateFrom, DateTime? dateTo = null);
    }
}