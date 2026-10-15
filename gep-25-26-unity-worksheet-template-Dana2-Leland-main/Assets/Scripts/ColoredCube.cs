using UnityEngine;

public class ColoredCube : MonoBehaviour
{
    //by default turn off vis tog for non-0 color cubes
    public int thisCubeColor = 0;
    void Start() {
        if (thisCubeColor != 0) {
            this.gameObject.SetActive(false);
        }
    }

    public void toggleVis(int visColorIndex) {
        Debug.Log("toggleVis called on ColoredCube");
        if (thisCubeColor == visColorIndex)
        {
            this.gameObject.SetActive(true);
        }
        else {
            this.gameObject.SetActive(false);
        }
    }
}
