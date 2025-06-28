using Game.Scripts.Inventory.Controllers.Interfaces;
using Game.Scripts.Inventory.External.Controllers.Interfaces;
using JuicyDI.Attributes;
using UnityEngine;

namespace Game.Scripts.Inventory.Controllers
{
    [JDIMonoController]
    public class InventoryController : MonoBehaviour, IInventoryAdd, IInventoryGetObject
    {
        [SerializeField] private InventoryViewController m_InventoryViewController;
        
        private IInventoryDataController m_InventoryDataController = new InventoryDataController();
        
        public void AddItem(IInventoryObject item)
        {
            m_InventoryDataController.AddItemToInventory(item);
            m_InventoryViewController.UpdateInventoryView();
        }

        public void SelectedInventoryObject(int selectedIndex)
        {
            if (selectedIndex > m_InventoryDataController.GetInventoryDataObjects().InventoryObjects.Count)
            {
                return;
            }

            m_InventoryViewController.UpdateInventorySelectedView(selectedIndex);
        }

        public IInventoryObject GetInventoryObject(int itemId)
        {
            return m_InventoryDataController.PeekInventoryObject(itemId);
        }

        public void DeleteInventoryObject(int itemId)
        {
            m_InventoryDataController.DeleteInventoryObject(itemId);
            m_InventoryViewController.UpdateInventoryView();
        }
    }
}