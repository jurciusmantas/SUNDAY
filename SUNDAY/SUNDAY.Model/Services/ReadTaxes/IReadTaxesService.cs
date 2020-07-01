using SUNDAY.Model.DAO;
using System;
using System.Threading.Tasks;

namespace SUNDAY.Model.Services.ReadTaxes
{
    public interface IReadTaxesService
    {
        Tax GetTaxAsync(string municipality, DateTime date);
    }
}