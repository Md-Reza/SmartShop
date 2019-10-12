using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNew.Model
{
    public class CompanyInformation : BaseEntity
    {
        public int OfficeCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string FactoryAddress { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public byte[] Logo { get; set; }
        public string CEO { get; set; }
        public DateTime AppInstallDate { get; set; }
        public string AppVersion { get; set; }

    }
}
