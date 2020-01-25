using Panda.Data.Models;
using Panda.Services;
using Panda.Web.ViewModels.Packages;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Collections.Generic;
using System.Linq;

namespace Panda.Web.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackagesService packagesService;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesService packagesService, IUsersService usersService)
        {
            this.packagesService = packagesService;
            this.usersService = usersService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var list = this.usersService.GetUsernames();
            return this.View(list);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packagesService.Create(input.Description, input.Weight, input.ShippingAddress, input.RecipientName);

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = this.packagesService
                .GetAllByStatus(PackageStatus.Delivered)
                .Select(package => new PackageViewModel
                {
                    Id = package.Id,
                    Description = package.Description,
                    Weight = package.Weight,
                    ShippingAddress = package.ShippingAddress,
                    RecipientName = package.Recipient.Username
                }).ToList();

            return this.View(new PackagesListViewModel { Packages = packages });
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = this.packagesService
                .GetAllByStatus(PackageStatus.Pending)
                .Select(package => new PackageViewModel
                {
                    Id = package.Id,
                    Description = package.Description,
                    Weight = package.Weight,
                    ShippingAddress = package.ShippingAddress,
                    RecipientName = package.Recipient.Username
                }).ToList();

            return this.View(new PackagesListViewModel { Packages = packages });
        }
    }
}
