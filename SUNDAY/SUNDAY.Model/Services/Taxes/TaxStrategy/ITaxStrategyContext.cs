using SUNDAY.Model.Enums;
using SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy
{
    public interface ITaxStrategyContext
    {
        ITaxStrategy GetTaxStrategy(TaxTypes type);
    }
}