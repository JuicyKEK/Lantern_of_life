using System.Collections.Generic;
using Game.Scripts.Inventory.Runtime.Data;
using Game.Scripts.Inventory.Runtime.Data.Interfaces;

namespace Game.Scripts.Inventory.Controllers
{
    public class InventoryDataController : IInventoryDataController
    {
        private IInventoryData m_InventoryDataObjects = new InventoryData();
        
        public void AddItemToInventory(IInventoryObject item)
        {
            for (int i = 0; i < m_InventoryDataObjects.InventoryObjects.Count; i++)
            {
                if (m_InventoryDataObjects.InventoryObjects[i].Peek() == item)
                {
                    AddExistingItem(item, i);
                    return;
                }
            }

            AddNewItem(item);
        }

        public IInventoryData GetInventoryDataObjects()
        {
            return m_InventoryDataObjects;
        }

        public IInventoryObject PeekInventoryObject(int indexObject)
        {
            if (indexObject > m_InventoryDataObjects.InventoryObjects.Count)
            {
                return null;
            }
            
            return m_InventoryDataObjects.InventoryObjects[indexObject].Peek();
        }

        public void DeleteInventoryObject(int indexObject)
        {
            if (indexObject > m_InventoryDataObjects.InventoryObjects.Count)
            {
                return;
            }

            m_InventoryDataObjects.InventoryObjects[indexObject].Dequeue();

            if (m_InventoryDataObjects.InventoryObjects[indexObject].Count == 0)
            {
                m_InventoryDataObjects.InventoryObjects.RemoveAt(indexObject);
            }
        }

        private void AddNewItem(IInventoryObject item)
        {
            var queue = new Queue<IInventoryObject>();
            queue.Enqueue(item);
            
            m_InventoryDataObjects.InventoryObjects.Add(queue);
        }
        
        private void AddExistingItem(IInventoryObject item, int index)
        {
            m_InventoryDataObjects.InventoryObjects[index].Enqueue(item);
        }
    }
}