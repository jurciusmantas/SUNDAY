using MySql.Data.MySqlClient;
using SUNDAY.Model.Entities;
using SUNDAY.Model.Enums;
using SUNDAY.Model.Repositories.Taxes;
using SUNDAY.Repository;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies
{
    public class DailyTaxStrategy : TaxStrategyBase
    {
        public override Tuple<TaxTypes, DateTime, DateTime?> GetArguments(DateTime date) => Tuple.Create<TaxTypes, DateTime, DateTime?>(TaxTypes.Daily, date, null);
    }
}
