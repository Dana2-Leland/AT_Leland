using TMPro;
using UnityEngine;

public class InventoryButtonUI : MonoBehaviour
{
    public TMP_Text text;

    public void SetButton(Item item)
    {
        text.text = item.getName(); // used getName() instead of .itemName, since itemName isn't public
    }
}
