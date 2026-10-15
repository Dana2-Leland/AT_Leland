using NUnit.Framework;
using System.Collections.Generic; //added for error on List<GameObject>
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> inventoryUIButtons = new List<GameObject>();

    private void OnEnable()
    {
        RefreshInventory();
    }

    void RefreshInventory() {
        //Disable each inventory UI button's game object
        foreach (GameObject uiButton in inventoryUIButtons)
        {
            uiButton.SetActive(false);
        }

        //Associate each inventory item with a Button in the UI menu
        for (int i = 0; i < inventory.getItems().Count; i++) { //changed from inventory.items.Count to inventory.getItems().Count, since items is private
            //Check that the inventory item index is not greater than the number of buttons
            if (i < inventoryUIButtons.Count) {
                //Create a freference to the UI button and item
                InventoryButtonUI uiButton = inventoryUIButtons[i].GetComponent<InventoryButtonUI>();
                Item item = inventory.getItems()[i]; //changed from inventory.items[i] to inventory.getItems()[i]
                
                //Make the button visible and update it with the item information
                uiButton.gameObject.SetActive(true);
                uiButton.SetButton(item);
            }
        }
    }
    
    public void OnInventoryUIButton(int i)
    {
        inventory.RemoveItemFromInventory(i);
        RefreshInventory();
    }
}
