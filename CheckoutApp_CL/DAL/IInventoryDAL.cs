using CheckoutApp_CL.Model;
using System.Collections.Generic;

namespace CheckoutApp_CL.DAL
{
    public interface IInventoryDAL
    {
        List<InventoryItem> GetInventoryItems();
        void SaveNewOrder(ItemOrder newOrder);
        void UpdateInventoryCount(List<InventoryItem> updatedList);
    }
}