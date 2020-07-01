using SUNDAY.Model.Enums;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies
{
    public class WeeklyTaxStrategy : TaxStrategyBase
    {
        public override Tuple<TaxTypes, DateTime, DateTime?> GetArguments(DateTime date) => Tuple.Create<TaxTypes, DateTime, DateTime?>(TaxTypes.Weekly, date.AddDays(-7), date.AddDays(7));
    }
}
