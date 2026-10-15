using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class State : MonoBehaviour
{
    public enum StateType {Paused, Played, Inventory};
    public StateType CurrentState = StateType.Played;

    public void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switchState();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory();
        }
    }
    public void switchState() {
        switch (CurrentState) {
            case StateType.Paused:
                CurrentState = StateType.Played;
                PauseState.toggleDisplay();
                break;
            case StateType.Inventory:
                CurrentState = StateType.Played;
                InventoryState.toggleDisplay();
                break;
            case StateType.Played:
                CurrentState = StateType.Paused;
                PauseState.toggleDisplay();
                break;
        }
        setTime();
    }

    public void inventory() {
        if (CurrentState == StateType.Played) //if in play, then you can access inventory menu
        {
            CurrentState = StateType.Inventory;
            InventoryState.toggleDisplay();
        }
        else if (CurrentState == StateType.Inventory) { //if already in inventory menu, toggle it off via switchState()
            switchState();
        }
        //no case for paused -- we want it to ignore the command if in pause menu
    }
    public StateType getState() {
        return CurrentState;
    }

    public bool isPaused() { 
        return CurrentState == StateType.Paused || CurrentState == StateType.Inventory;
    }

    public void setTime() {
        switch (CurrentState) { 
            case StateType.Paused:
                PauseState.setTime();
                break;
            case StateType.Played:
                PlayState.setTime();
                break;
            case StateType.Inventory:
                InventoryState.setTime();
                break;
        }
    }
}
