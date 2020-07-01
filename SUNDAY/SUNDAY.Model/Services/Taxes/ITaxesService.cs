using SUNDAY.Model.Entities;
using System;

namespace SUNDAY.Model.Services.Taxes
{
    public interface ITaxesService
    {
        Tax GetTax(string municipalityName, DateTime date);
    }
}