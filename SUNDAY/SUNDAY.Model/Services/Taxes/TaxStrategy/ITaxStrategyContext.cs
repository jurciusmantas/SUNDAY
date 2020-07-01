using SUNDAY.Model.Enums;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy
{
    public interface ITaxStrategyContext
    {
        ITaxStrategy GetTaxStrategy(TaxTypes type);
    }
}