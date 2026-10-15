using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    public State stateMachine;
    public ColorState currColor;
    private void OnPause(InputValue value) {
        if (value.isPressed) {
            stateMachine.switchState();
        }
    }

    private void OnRemoveItem(InputValue value) {
        if (value.isPressed) {
            Debug.Log("Remove Item");
            GetComponent<Inventory>().RemoveItemFromInventory();
        }
    }

    private void OnChangeColor(InputValue value) {
        if (value.isPressed) {
            Debug.Log("Change Color Start" + currColor.GetColor());
            currColor.UpdateColor();
            Debug.Log("Change Color End" + currColor.GetColor());

        }
    }
}
