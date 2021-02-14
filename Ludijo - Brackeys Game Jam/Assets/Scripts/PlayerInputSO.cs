using UnityEngine;

[CreateAssetMenu]
public class PlayerInputSO : ScriptableObject {
    
	public string horizontalInput = "Horizontal";
	public string verticalInput = "Vertical";
	public KeyCode runInput = KeyCode.LeftShift;
	public string mouseHorizontalInput = "Mouse X";
	public string mouseVerticalInput = "Mouse Y";
	
	public bool IsRunning () {
		return Input.GetKey (runInput);
	}
	
	public float GetMouseHorizontalInput (bool raw) {
		return raw ? Input.GetAxisRaw(mouseHorizontalInput) :
			Input.GetAxis (mouseHorizontalInput);
	}
	
	public float GetMouseVerticalInput (bool raw) {
		return raw ? Input.GetAxisRaw(mouseVerticalInput) :
			Input.GetAxis (mouseVerticalInput);
	}
	
	public Vector3 GetMovementInput (bool raw) {
		var x = raw ? Input.GetAxisRaw (horizontalInput) :
			Input.GetAxis (horizontalInput);			
		var z = raw ? Input.GetAxisRaw (verticalInput) :
			Input.GetAxis (verticalInput);
					
		return (Vector3.right * x + Vector3.forward * z).normalized;
	}
	
	public Vector3 GetLocalMovementInput (bool raw, Transform transform) {
		var x = raw ? Input.GetAxisRaw (horizontalInput) :
			Input.GetAxis (horizontalInput);			
		var z = raw ? Input.GetAxisRaw (verticalInput) :
			Input.GetAxis (verticalInput);
					
		return (transform.right * x + transform.forward * z).normalized;
	}
}
