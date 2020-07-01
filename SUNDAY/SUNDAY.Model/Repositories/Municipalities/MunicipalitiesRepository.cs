using MySql.Data.MySqlClient;
using SUNDAY.Model.Entities;
using SUNDAY.Repository;

namespace SUNDAY.Model.Repositories.Municipalities
{
    public class MunicipalitiesRepository : IMunicipalitiesRepository
    {
        public Municipality GetMunicipality(string name)
        {
            var sql = new MySqlCommand(@"
                SELECT Id, Name
                FROM municipalities
                WHERE Name = ?name
            ");

            sql.Parameters.AddWithValue("?name", name);

            return DbRepository.FetchSingleRow<Municipality>(sql);
        }
    }
}
