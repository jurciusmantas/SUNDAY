using SUNDAY.Model.Entities;
using SUNDAY.Model.Enums;
using SUNDAY.Model.Repositories.Municipalities;
using SUNDAY.Model.Services.Taxes.TaxStrategy;
using System;
using System.Linq;

namespace SUNDAY.Model.Services.Taxes
{
    public class TaxesService : ITaxesService
    {
        private readonly IMunicipalitiesRepository _municipalitiesRepository;
        private readonly ITaxStrategyContext _taxStrategyContext;

        public TaxesService(IMunicipalitiesRepository municipalitiesRepository
            , ITaxStrategyContext taxStrategyContext)
        {
            _municipalitiesRepository = municipalitiesRepository;
            _taxStrategyContext = taxStrategyContext;
        }

        public Tax GetTax(string municipalityName, DateTime date)
        {
            try
            {
                var municipality = _municipalitiesRepository.GetMunicipality(municipalityName);
                if (municipality == null)
                    return null;

                var enumValues = Enum.GetValues(typeof(TaxTypes)).Cast<TaxTypes>().ToList();
                for(var i = 0; i < enumValues.Count; i++)
                {
                    var strategy = _taxStrategyContext.GetTaxStrategy(enumValues[i]);
                    var tax = strategy.GetTax(municipality.Id, date);
                    if (tax != null)
                        return tax;
                }

                return null;
            }
            catch (Exception exc)
            {
                /* Log error */
                return null;
            }
        }
    }
}
