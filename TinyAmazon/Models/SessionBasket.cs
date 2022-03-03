using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TinyAmazon.Infrastructure;

namespace TinyAmazon.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            //see if its a new session or another one

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }


        public override void AddItem(Book bo, int qty)
        {
            base.AddItem(bo, qty);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book bo)
        {
            base.RemoveItem(bo);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}

