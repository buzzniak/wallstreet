using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	
	float speed = 20.0f;
	float rotateSpeed = 150.0f;
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
		
		if (Input.GetAxis("Horizontal") > 0 && tr.position == pos) {
			pos += Vector3.right*stepsize;
		}
		else if (Input.GetAxis("Horizontal") < 0 && tr.position == pos) {
			pos += Vector3.left*stepsize;
		}
		else if (Input.GetAxis("Vertical") > 0 && tr.position == pos) {
			pos += Vector3.forward*stepsize;
		}
		else if (Input.GetAxis("Vertical") < 0 && tr.position == pos) {
			pos += Vector3.back*stepsize;
		}
		else if (Input.GetKeyDown(KeyCode.Q) && tr.position == pos) {
			//Rotate Left
			StartCoroutine (PlayerRotateLeft (originalRotation));
		}
		else if (Input.GetKeyDown(KeyCode.E) && tr.position == pos) {
			//Rotate Right
			StartCoroutine (PlayerRotateRight (originalRotation));
		}
		
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
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
