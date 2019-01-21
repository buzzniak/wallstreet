using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
	public float m_rotateSpeed_f = 300.0f;
	public float m_stepsize_f = 7f;
	//public GameObject sensor;
	
	public	bool m_isMovementFrozen_b = false;
	
	
	private void Start()
	{	
		
	}
	
	private void Update()
	{
		//Debug.Log (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 4));
	
		if (Input.GetKeyDown(KeyCode.D) && !m_isMovementFrozen_b &&
		    !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 4))
		{
			StartCoroutine(PlayerMove(Vector3.right * m_stepsize_f));
		}
		else if (Input.GetKeyDown(KeyCode.A) && !m_isMovementFrozen_b &&
		         !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 4))
		{
			StartCoroutine(PlayerMove(Vector3.left * m_stepsize_f));
		}
		else if (Input.GetKeyDown(KeyCode.W) && !m_isMovementFrozen_b &&
		         !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 4))
		{
			StartCoroutine(PlayerMove(Vector3.forward* m_stepsize_f));
		}
		else if (Input.GetKeyDown(KeyCode.S) && !m_isMovementFrozen_b &&
		         !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 4))
		{
			StartCoroutine(PlayerMove(Vector3.back * m_stepsize_f));
		}
		
		if (Input.GetKeyDown(KeyCode.Q) && !m_isMovementFrozen_b)
		{
			StartCoroutine(PlayerRotate( false));
		}
		else if (Input.GetKeyDown(KeyCode.E) && !m_isMovementFrozen_b)
		{
			StartCoroutine(PlayerRotate(true));
		}
		
	}
	
	private IEnumerator PlayerRotate(bool f_toRight_b)
	{
		m_isMovementFrozen_b = true;
		Quaternion l_targetRotation_q = transform.rotation;
		if (f_toRight_b)
		{
			l_targetRotation_q *= Quaternion.AngleAxis(90, Vector3.up);
		}
		else
		{
			l_targetRotation_q *= Quaternion.AngleAxis(90, Vector3.down);
		}
		
		while (this.transform.rotation.eulerAngles.y != l_targetRotation_q.eulerAngles.y)
		{
			transform.rotation = Quaternion.RotateTowards (transform.rotation, l_targetRotation_q, m_rotateSpeed_f * Time.deltaTime);
			yield return null;
		}
		m_isMovementFrozen_b = false;
	}
	
	private IEnumerator PlayerMove(Vector3 f_targetDirection_v3)
	{
		m_isMovementFrozen_b = true;
		//Vector3 l_targetTranslation_v3 = this.transform.position + f_targetDirection_v3;
		/*while (this.transform.position != f_targetDirection_v3) {
			this.transform.position = Vector3.MoveTowards(this.transform.position, 	l_targetTranslation_v3, 2);
		}*/
		Vector3 l_targetTranslation_v3 = this.transform.position + f_targetDirection_v3;
		transform.Translate(f_targetDirection_v3, Space.Self);
		
		m_isMovementFrozen_b = false;
		//Debug.Log("Vége");
		yield return null;
	}
}