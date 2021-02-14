using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private PlayerMovementSettingsSO playerMovementSettingsSO;
    [SerializeField] private PlayerInputSO playerInputSO;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Rigidbody rb;
    private float currentVelocity;

    private void FixedUpdate() {
        HandleMovement();
    }

    private void HandleMovement () {
        var movementInput = playerInputSO.GetMovementInput(true);
        HandleRotation(movementInput);
        var targetMovement = new Vector3(movementInput.x, rb.velocity.y, movementInput.z);
        rb.velocity = targetMovement * playerMovementSettingsSO.speed * Time.deltaTime;
    } 

    private void HandleRotation (Vector3 movementInput) {
        var angle = Mathf.Atan2 (movementInput.x, movementInput.z) * Mathf.Rad2Deg;
        var targetRot = Quaternion.Euler (0f, angle, 0f);
        var smoothRot = Quaternion.Slerp (rb.rotation, targetRot, Time.deltaTime*playerMovementSettingsSO.angularSpeed);
        rb.rotation = smoothRot;
    }

}
