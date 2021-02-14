using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    public void Move (InputAction.CallbackContext callbackContext) {

        var movementInput = callbackContext.ReadValue<Vector2>();
        Debug.Log(movementInput);

    } 

}
