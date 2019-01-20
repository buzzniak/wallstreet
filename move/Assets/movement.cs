using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {


	
	float speed = 20.0f;
	float rotateSpeed = 300.0f;
	float stepsize = 4f;
	bool isRotating = false;
	Vector3 pos;
	Transform tr;
	
	Quaternion originalRotation;
	
	
	void Start()
    {
		pos = transform.position;
		tr = transform;	
		originalRotation = transform.rotation;		
	}
	
	void Update()
    {
            transform.Translate(Vector3.right * Time.deltaTime, Space.World);
            if (Input.GetKeyDown(KeyCode.D))
            {
            //pos += Vector3.right*stepsize; 
                
            }
			else if (Input.GetKeyDown(KeyCode.A))
            {
				pos += Vector3.left*stepsize;
			}
			else if (Input.GetKeyDown(KeyCode.W))
            {
				pos += Vector3.forward*stepsize;
			}
			else if (Input.GetKeyDown(KeyCode.S))
            {
				pos += Vector3.back*stepsize;
			}
			
			if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
            {
                originalRotation = transform.rotation;
                StartCoroutine(PlayerRotate(originalRotation, false));
            }
			else if (Input.GetKeyDown(KeyCode.E) && !isRotating)
            {
                originalRotation = transform.rotation;
                StartCoroutine(PlayerRotate(originalRotation,true));
            }
			
			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
	
	IEnumerator PlayerRotate(Quaternion originalRotation, bool toRight)
    {
        isRotating = true;
		Quaternion targetRotation = originalRotation;
        if (toRight)
        {
            targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
        }
        else
        {
            targetRotation *= Quaternion.AngleAxis(90, Vector3.down);
        }

		while (this.transform.rotation.eulerAngles.y != targetRotation.eulerAngles.y)
        {
            transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
			yield return null;
        }
        isRotating = false;
    }

    IEnumerator PlayerMove(Quaternion originalRotation, bool toRight)
    {
        yield return null;
    }
}