using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

	//public GameObject SpawnPos;
	public GameObject Wall;
	public bool InWall;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (InWall);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (InWall && GetComponent <BoxCollider>()) {
				Destroy (GetComponent <BoxCollider>());
			}
			else {
				Instantiate(Wall, transform.position, transform.rotation);
			}
			
		}
	}
	
	void OnCollision(Collision other) 
	{
		if (other.gameObject.tag=="Wall") {
			InWall = true;
		}
	}
	
	void OnCollisionExit(Collision other)
	{
		InWall = false;
	}
}
