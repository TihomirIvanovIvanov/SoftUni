using Musaca.Web.ViewModels.Orders;
using System.Collections.Generic;

namespace Musaca.Web.ViewModels.Users
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            this.Orders = new List<OrderProfileViewModel>();
        }

        public List<OrderProfileViewModel> Orders { get; set; }
    }
}
