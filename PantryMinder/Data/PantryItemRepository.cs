using System;
using System.Data;
using Dapper;
using PantryMinder.Models;


namespace PantryMinder
{
    public class PantryItemRepository : IPantryItemRepository
	{
        private readonly IDbConnection _conn;

        public PantryItemRepository(IDbConnection conn)
		{
			_conn = conn;

		}

        public IEnumerable<PantryItem> GetAllPantryItems()
        {
            return _conn.Query<PantryItem>("SELECT * FROM PANTRYITEMS ;");
        }

        public PantryItem GetPantryItem(int id)
        {
            return _conn.QuerySingle<PantryItem>("SELECT * FROM PANTRYITEMS WHERE ITEMID = @id", new { id = id });
        }

        public void UpdatePantryItem(PantryItem pantryitem)
        {
            _conn.Execute("UPDATE pantryitems SET ItemName = @itemname, Category = @category, Quantity = @quantity, Unit = @unit WHERE ItemID = @id",
    new { itemname = pantryitem.ItemName, category = pantryitem.Category, quantity = pantryitem.Quantity, unit = pantryitem.Unit, id = pantryitem.ItemID });
        }
    }
}

