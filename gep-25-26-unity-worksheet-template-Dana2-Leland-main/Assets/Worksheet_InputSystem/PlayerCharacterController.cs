using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    public State stateMachine;
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
}
