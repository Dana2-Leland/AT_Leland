using UnityEngine;
/*
  Can still add:
    encapsulation, abstraction, inheritance
    additional item properties
    source 3D assets for items
    additional interactive components
 */
public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string getName() {
        return itemName;
    }

}
