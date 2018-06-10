using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Components
{
    [ViewComponent(Name = "GenreMenu")]
    public class GenreMenuComponent : ViewComponent
    {
        private readonly StoreContext context;

        public GenreMenuComponent(StoreContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(context.Genres.Where(g => g.GenreID <= 8).ToList());
        }
    }
}
