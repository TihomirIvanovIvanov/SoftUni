using System.Collections.Generic;

namespace Musaca.Web.ViewModels.Orders
{
    public class OrderProfileViewModel
    {
        public string Id { get; set; }

        public string Price { get; set; }

        public string IssuedOn { get; set; }

        public string CashierName { get; set; }
    }
}
