using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyAmazon.Models;

namespace TinyAmazon.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket cart;
        public CartSummaryViewComponent(Basket cartservice)
        {
            cart = cartservice;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
