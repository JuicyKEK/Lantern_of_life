using Game.Scripts.Inventory.Controllers.Interfaces;
using JuicyDI.Attributes;
using UnityEngine;

namespace Game.Scripts.Inventory.Controllers
{
    [JDIMonoController]
    public class InventoryController : MonoBehaviour, IInventoryAdd
    {
        public void AddItem(IInventoryObject item)
        {
            Debug.Log(item.ObjectKey);
        }
    }
}