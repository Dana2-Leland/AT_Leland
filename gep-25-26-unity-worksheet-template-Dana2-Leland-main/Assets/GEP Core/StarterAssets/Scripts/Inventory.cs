using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
/*
 Can still add:
    abstract classes / base classes / derived classes
    inventory sorting alogrithm
 */
public class Inventory : MonoBehaviour
{
    private State gameManager;
    Transform worldItemsTransform;

    private List<Item> items = new List<Item>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<State>();

        Transform worldItemsTransform = GameObject.Find("Collectables").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         if (Input.GetKeyDown(KeyCode.B)) {
            AddItemToInventory("Generic Item");
        }
        else if (Input.GetKeyDown(KeyCode.C)) {
            RemoveItemFromInventory("Generic Item");
        }
         
         */
        
    }

    public void AddItemToInventory(Item item) {
        if (!gameManager.isPaused()){ 
            items.Add(item);
        }
    }
    public void RemoveItemFromInventory(Item item) {
            //Get the properties for where we want to spawn
            Vector3 currentPosition = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newPosition = currentPosition + forward;
            newPosition += new Vector3(0, 1, 0);

            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0, 0, 180);

            // Instantiate a copy of the held item
            GameObject newItem = Instantiate(item.gameObject, newPosition, newRotation, worldItemsTransform);
            newItem.SetActive(true);

            // Clean up the existing item
            items.Remove(item);
            item.gameObject.SetActive(false);
    }

    public void RemoveItemFromInventory()
    {
        //Check that we can remove an item from our inventory
        if (!gameManager.isPaused() && items.Count>0)
        {
            //Store the item at the top of the list as a variable
            Item item = items[0];
            RemoveItemFromInventory(item);
        }
    }

    public void RemoveItemFromInventory(int i) {
        //Check that we can remove an item from our inventory
        if (i<items.Count && i>=0)
        {
            //Store the item at the top of the list as a variable
            Item item = items[i];
            RemoveItemFromInventory(item);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item item = hit.gameObject.GetComponent<Item>();
        if (item != null) {
            items.Add(item);

            item.gameObject.SetActive(false);
        }
    }

    private void OnRemoveItem(InputValue value) {
        if (value.isPressed) {
            //Debug.Log("Remove Item");
            GetComponent<Inventory>().RemoveItemFromInventory();
        }
    }

    public List<Item> getItems() {
        return items;
    }
}
