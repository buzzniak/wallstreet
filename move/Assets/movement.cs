using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	
	float speed = 20.0f;
	float rotateSpeed = 300.0f;
	float stepsize = 4f;
	bool isMoving = false;
	Vector3 pos;
	Transform tr;
	
	Quaternion originalRotation;
	
	
	void Start() {
		pos = transform.position;
		tr = transform;	
		originalRotation = transform.rotation;
		
	}
	
	void Update() {
		print(Input.GetAxis("Horizontal"));
		if (!isMoving) {
			if (Input.GetAxis("Horizontal") > 0 && tr.position == pos) {
				pos += Vector3.right*stepsize;
				isMoving = true;
			}
			else if (Input.GetAxis("Horizontal") < 0 && tr.position == pos) {
				pos += Vector3.left*stepsize;
				isMoving = true;
			}
			else if (Input.GetAxis("Vertical") > 0 && tr.position == pos) {
				pos += Vector3.forward*stepsize;
				isMoving = true;
			}
			else if (Input.GetAxis("Vertical") < 0 && tr.position == pos) {
				pos += Vector3.back*stepsize;
				isMoving = true;
			}
			
			if (Input.GetKeyDown(KeyCode.Q)) {
				//Rotate Left
				originalRotation = transform.rotation;
				StartCoroutine (PlayerRotateLeft (originalRotation));
				//transform.rotation *= Quaternion.Euler(0, 90f * rotateSpeed * Time.deltaTime, 0);
				
				isMoving = true;
			}
			else if (Input.GetKeyDown(KeyCode.E)) {
				//Rotate Right
				originalRotation = transform.rotation;
				StartCoroutine (PlayerRotateRight (originalRotation));
				//transform.rotation *= Quaternion.Euler(0, -90f * rotateSpeed * Time.deltaTime, 0);
				
				isMoving = true;
			}
			
			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
			isMoving = false;
		}
		
	}
	
	IEnumerator PlayerRotateRight(Quaternion originalRotation) {
		
		Quaternion targetRotation = originalRotation;
		targetRotation *= Quaternion.AngleAxis (90, Vector3.up);
		
		while (this.transform.rotation.y != targetRotation.y) {
			
			/*Debug.Log ("Current: " + this.transform.rotation.y);
			Debug.Log ("Target: " + targetRotation.y);*/
			
			isMoving = true;
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
			yield return null;
		}
		
		isMoving = false;
	}
	
	IEnumerator PlayerRotateLeft(Quaternion originalRotation) {
		
		Quaternion targetRotation = originalRotation;
		targetRotation *= Quaternion.AngleAxis (90, Vector3.down);
		
		while (this.transform.rotation.y != targetRotation.y) {
			
			/*Debug.Log ("Current: " + this.transform.rotation.y);
			Debug.Log ("Target: " + targetRotation.y);*/
			
			isMoving = true;
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
			yield return null;
		}
		
		isMoving = false;
	}
}
