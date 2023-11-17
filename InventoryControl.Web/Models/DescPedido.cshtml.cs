using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using AlmacenSQLiteEntities;
using AlmacenDataContext;

namespace InventoryControlPages
{
    public class DescPedidoModel : PageModel
    {
        private Almacen db;

        public DescPedidoModel(Almacen context)
        {
            db = context;
        }

        public List<DescPedido>? descPedidos { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "";
        }

        [BindProperty]
        public DescPedido? DescPedido { get; set; }

        public IActionResult OnPost()
        {
        }
    }
}
