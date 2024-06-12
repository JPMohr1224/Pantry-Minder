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
    }
}

