using SUNDAY.Model.Entities;
using SUNDAY.Model.Enums;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies
{
    public class YearlyTaxStrategy : TaxStrategyBase
    {
        public override Tuple<TaxTypes, DateTime, DateTime?> GetArguments(DateTime date) => Tuple.Create<TaxTypes, DateTime, DateTime?>(TaxTypes.Yearly, date.AddYears(-1), date.AddYears(1));
    }
}
