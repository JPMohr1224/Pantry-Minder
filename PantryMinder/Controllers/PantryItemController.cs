using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using PantryMinder.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PantryMinder.Controllers
{
    public class PantryItemController : Controller
    {
        private readonly IPantryItemRepository repo;

        public PantryItemController(IPantryItemRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var pantryItem = repo.GetAllPantryItems();
            return View(pantryItem);
        }

        public IActionResult ViewPantryItem(int id)
        {
            var pantryItem = repo.GetPantryItem(id);
            return View(pantryItem);
        }

        public IActionResult UpdatePantryItem(int id)
        {
            PantryItem pantryitem = repo.GetPantryItem(id);
            if (pantryitem == null)
            {
                return View("ProductNotFound");
            }
            return View(pantryitem);
        }

        public IActionResult UpdatePantryItemToDatabase(PantryItem pantryitem)
        {
            repo.UpdatePantryItem(pantryitem);

            return RedirectToAction("ViewPantryItem", new { id = pantryitem.ItemID });
        }

        public IActionResult AddPantryItem(PantryItem pantryitemToAdd)
        {

            return View(pantryitemToAdd);
        }

        public IActionResult AddPantryItemToDatabase(PantryItem pantryitem)
        {
            repo.AddPantryItem(pantryitem);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePantryItem(PantryItem pantryitem)
        {
            repo.DeletePantryItem(pantryitem);
            return RedirectToAction("Index");
        }
    }
}

