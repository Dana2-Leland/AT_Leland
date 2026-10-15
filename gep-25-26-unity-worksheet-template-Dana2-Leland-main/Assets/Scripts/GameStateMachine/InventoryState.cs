using UnityEngine;

public  class  InventoryState : State
{
    static GameObject canvas = GameObject.Find("Canvas"); //find disabled inventory
    static GameObject inventoryMenu = canvas.transform.GetChild(0).gameObject;
    static bool displayOn = false; 
    new static public void setTime()
    {
        Time.timeScale = 0.0f;
    }
    static public void toggleDisplay()
    {
        displayOn = !displayOn;
        inventoryMenu.SetActive(displayOn);
        switch (displayOn)
        {
            case (true):
                Cursor.lockState = CursorLockMode.None;
                break;
            case (false):
                Cursor.lockState = CursorLockMode.Locked;
                break;

        }
    }
}
