using SUNDAY.Model.Entities;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy
{
    public interface ITaxStrategy
    {
        Tax GetTax(int municipalityId, DateTime date);
    }
}
