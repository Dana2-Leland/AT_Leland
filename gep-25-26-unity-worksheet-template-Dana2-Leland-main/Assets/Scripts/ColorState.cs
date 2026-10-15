using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class ColorState : MonoBehaviour
{
    private int colorIndex;
    private List<ColoredCube> allColoredCubes = new List<ColoredCube>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allColoredCubes.AddRange(GameObject.FindGameObjectsWithTag("ColoredCube")); //finds the object, won't add because it's a gameObject, not ColoredCube
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("Current " + GetColor());
            UpdateColor();
            Debug.Log("Updated" + GetColor());
        }
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
        UpdateColorCubeVis();
    }

    private void UpdateColorCubeVis() {
        //get all colored cubes, call toggle vis and pass color index
        //is it better to call every entry and have it check for color, then check to change, or to call change regardless?
        //I assume call every entry to call change regardless
        for (int i = 0; i < allColoredCubes.Count; i++) {
            allColoredCubes[i].toggleVis(colorIndex);
        }
        Debug.Log("Finished updateColorCubeVis count: " + allColoredCubes.Count);

    }
}
