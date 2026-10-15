using UnityEngine;

public class ColorState : MonoBehaviour
{
    private int colorIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetColor() {
        return colorIndex;
    }

    public void UpdateColor()
    {
        if (colorIndex == 2)
        {
            colorIndex = 0;
        }
        else {
            colorIndex++;
        }
    }
}
