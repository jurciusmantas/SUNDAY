using SUNDAY.Model.Entities;
using SUNDAY.Model.Repositories.Taxes;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies
{
    public class DailyTaxStrategy : IDailyTaxStrategy
    {
        private readonly ITaxesRepository _taxesRepository;

        public DailyTaxStrategy() { }

        public DailyTaxStrategy(ITaxesRepository taxesRepository)
        {
            _taxesRepository = taxesRepository;
        }

        public Tax GetTax(int municipalityId, DateTime date)
        {
            var taxes = _taxesRepository.GetTaxes(municipalityId, Enums.TaxTypes.Daily, date);
            if (taxes == null || taxes.Count == 0)
                return null;

            if (taxes.Count > 1)
                throw new Exception("Multiple daily taxes");

            return taxes[0];
        }
    }
}
