using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShop.Models;

namespace SmartShop.Dtos
{
  public class PurchaseCreateDto
    {
        public PurchaseParent purchaseParent { get; set; }
        public List<PurchaseChild> purchaseChild { get; set; }
    }
}
