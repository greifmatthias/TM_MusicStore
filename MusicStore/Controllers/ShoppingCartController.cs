using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreContext _context;


        public ShoppingCartController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ShoppingCart ShoppingCart = new ShoppingCart(HttpContext, _context);
            return View(ShoppingCart.GetCartItems());
        }

        public IActionResult AddToCart(int id)
        {
            ShoppingCart ShoppingCart = new ShoppingCart(HttpContext, _context);
            ShoppingCart.AddToCart(_context.Albums.Where(a => a.AlbumID == id).Single());

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            ShoppingCart ShoppingCart = new ShoppingCart(HttpContext, _context);
            ShoppingCart.RemoveFromCart(id);

            return RedirectToAction("Index");
        }
    }
}