using UnityEngine;

public class CameraScript : MonoBehaviour {
	
	private float minY = -80f;
	private float maxY = 80f;
	
	private float sensitivity = 10f;
	
	private float rotX;
	private float rotY;
	
	void LateUpdate(){
		
		rotX += Input.GetAxis("Mouse X") * sensitivity;
		
		rotY += Input.GetAxis("Mouse Y") * sensitivity;
		rotY = Mathf.Clamp(rotY, minY, maxY);
		
		transform.rotation = Quaternion.Euler(-rotY, rotX, 0);
		
	}
}
