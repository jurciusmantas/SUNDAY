using MySql.Data.MySqlClient;
using SUNDAY.Model.Entities;
using SUNDAY.Model.Enums;
using SUNDAY.Model.Services.Taxes.TaxStrategy.Strategies;
using SUNDAY.Repository;
using System;

namespace SUNDAY.Model.Services.Taxes.TaxStrategy
{
    public abstract class TaxStrategyBase : ITaxStrategy
    {
        //Todo: change to private?
        public abstract Tuple<TaxTypes, DateTime, DateTime?> GetArguments(DateTime date);

        public Tax GetTax(int municipalityId, DateTime date)
        {
            var arguments = GetArguments(date);

            var sql = new MySqlCommand($@"
                SELECT Id, MunicipalityId, Value, Date, Type
                FROM taxes
                WHERE
                    MunicipalityId = ?municipalityId AND
                    {(arguments.Item3.HasValue ? "Date BETWEEN ?dateFrom AND ?dateTo" : "Date = ?dateFrom")} AND
                    Type = {(int)arguments.Item1}
            ;");

            sql.Parameters.AddWithValue("?municipalityId", municipalityId);
            sql.Parameters.AddWithValue("?dateFrom", arguments.Item2);

            if (arguments.Item3.HasValue)
                sql.Parameters.AddWithValue("?dateTo", arguments.Item3);

            var taxes = DbRepository.FetchList<Tax>(sql);
            if (taxes == null || taxes.Count == 0)
                return null;

            if (taxes.Count > 1)
                throw new Exception("Multiple daily taxes");

            return taxes[0];
        }
    }
}
