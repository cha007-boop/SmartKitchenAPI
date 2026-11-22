using KitchenLib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;
        public GroceryService(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }
    }
}
