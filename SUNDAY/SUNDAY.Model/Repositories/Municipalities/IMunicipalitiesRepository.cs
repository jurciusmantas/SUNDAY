using SUNDAY.Model.Entities;

namespace SUNDAY.Model.Repositories.Municipalities
{
    public interface IMunicipalitiesRepository
    {
        Municipality GetMunicipality(string name);
    }
}