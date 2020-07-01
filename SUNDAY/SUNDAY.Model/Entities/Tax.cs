using SUNDAY.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUNDAY.Model.Entities
{
    public class Tax
    {
        public int Id { get; set; }
        public int MunicipalityId { get; set; }
        public DateTime Date { get; set; }
        public TaxTypes Type { get; set; }
    }
}
