using SUNDAY.Model.Enums;
using SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy
{
    public class TaxStrategyContext : ITaxStrategyContext
    {
        public ITaxStrategy GetTaxStrategy(TaxTypes type)
        {
            return type switch
            {
                TaxTypes.Daily => IDailyTaxStrategy(),
                TaxTypes.Weekly => new WeeklyTaxStrategy(),
                TaxTypes.Monthly => new MonthlyTaxStrategy(),
                TaxTypes.Yearly => new MonthlyTaxStrategy(),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
