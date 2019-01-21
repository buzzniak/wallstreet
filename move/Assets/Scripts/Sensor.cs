using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

	//public GameObject SpawnPos;
	public GameObject Wall;
	public GameObject player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (InWall);
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RaycastHit hit;
			//Debug.DrawRay(player.transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);			
			if (Physics.Raycast(player.transform.position, transform.TransformDirection(Vector3.forward), out hit, 5)) {
				if (hit.transform.tag == "Wall") {
					//Debug.Log("Wall is hit by the ray");
					Destroy(hit.transform.gameObject);
					//Debug.Log("Wall is destroyed!");
				}
			}
			else {
				Instantiate(Wall, transform.position, transform.rotation);
			}
			
		}
	}

}
