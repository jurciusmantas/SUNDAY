using MySql.Data.MySqlClient;
using SUNDAY.Model.Entities;
using SUNDAY.Model.Repositories.Municipalities;
using SUNDAY.Repository;
using System;

namespace SUNDAY.Model.Services.Taxes
{
    public class TaxesService : ITaxesService
    {
        private readonly IMunicipalitiesRepository _municipalitiesRepository;

        public TaxesService(IMunicipalitiesRepository municipalitiesRepository)
        {
            _municipalitiesRepository = municipalitiesRepository;
        }

        public Tax GetTax(string municipalityName, DateTime date)
        {
            var municipality = _municipalitiesRepository.GetMunicipality(municipalityName);
            return new Tax();
        }
    }
}
