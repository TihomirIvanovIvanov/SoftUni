namespace Musaca.App.ViewModels.Home
{
    using Orders;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.Orders = new List<OrderViewModel>();
        }

        public List<OrderViewModel> Orders { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
