using System;
using System.Collections.Generic;
using PantryMinder.Models;


namespace PantryMinder
{
	public interface IPantryItemRepository
	{

        public IEnumerable<PantryItem> GetAllPantryItems();
        PantryItem GetPantryItem(int id);
        void UpdatePantryItem(PantryItem pantryitem);
        public void AddPantryItem(PantryItem pantryitemToInsert);
        public void DeletePantryItem(PantryItem pantryitem);
        public IEnumerable<PantryItem> SearchPantryItem(string searchString);
    
    }
}

