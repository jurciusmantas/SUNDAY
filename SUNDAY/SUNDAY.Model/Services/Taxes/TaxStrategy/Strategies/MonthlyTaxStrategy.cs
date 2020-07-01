using SUNDAY.Model.Enums;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies
{
    public class MonthlyTaxStrategy : TaxStrategyBase
    {
        public override Tuple<TaxTypes, DateTime, DateTime?> GetArguments(DateTime date) => Tuple.Create<TaxTypes, DateTime, DateTime?>(TaxTypes.Monthly, date.AddMonths(-1), date.AddMonths(1));
    }
}
