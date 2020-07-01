using MySql.Data.MySqlClient;
using SUNDAY.Model.Entities;
using SUNDAY.Model.Enums;
using SUNDAY.Repository;
using System;
using System.Collections.Generic;

namespace SUNDAY.Model.Repositories.Taxes
{
    public class TaxesRepository : ITaxesRepository
    {
        public List<Tax> GetTaxes(int municipalityId, TaxTypes type, DateTime dateFrom, DateTime? dateTo = null)
        {
            var sql = new MySqlCommand($@"
                SELECT Id, MunicipalityId, Value, Date, Type
                FROM taxes
                WHERE
                    MunicipalityId = ?municipalityId AND
                    {(dateTo.HasValue ? "Date BETWEEN ?dateFrom AND ?dateTo" : "Date = ?dateFrom")} AND
                    Type = ?type
            ;");

            sql.Parameters.AddWithValue("?municipalityId", municipalityId);
            sql.Parameters.AddWithValue("?dateFrom", dateFrom);
            sql.Parameters.AddWithValue("?type", (int)type);
            
            if (dateTo.HasValue)
                sql.Parameters.AddWithValue("?dateTo", dateTo.Value);

            return DbRepository.FetchList<Tax>(sql);
        }
    }
}
