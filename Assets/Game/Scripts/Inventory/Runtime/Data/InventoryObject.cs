using UnityEngine;

namespace Game.Scripts.Inventory.Runtime.Data
{
    public class InventoryObject : IInventoryObject
    {
        public string ObjectKey { get; }
        public Sprite ObjectIcon { get; }

        public InventoryObject(string objectKey, Sprite objectIcon)
        {
            ObjectKey = objectKey;
            ObjectIcon = objectIcon;
        }
    }
}