using UnityEngine;

public class CameraScript : MonoBehaviour {
  private bool rotatePlayer = true;
	private float minY = -80f;
	private float maxY = 80f;
	
	private float sensitivity = 10f;
	
	private float rotX;
	private float rotY;
	
	void LateUpdate(){
		
		rotX += Input.GetAxis("Mouse X") * sensitivity;
		
		rotY += Input.GetAxis("Mouse Y") * sensitivity;
		rotY = Mathf.Clamp(rotY, minY, maxY);

    if (rotatePlayer)
    {
      transform.root.rotation = Quaternion.Euler(0, rotX, 0);
      transform.localRotation = Quaternion.Euler(-rotY, 0, 0);
    }
    else
    {
      transform.rotation = Quaternion.Euler(-rotY, rotX, 0);
    }
		
	}
}
