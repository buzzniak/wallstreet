using UnityEngine;
using System.Collections;

public class ProjectileDestroy : MonoBehaviour {

	GameObject enemy;

	// Use this for initialization
	void Start () {
		enemy = Resources.Load ("enemy") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag != "Player") {
			if (collision.gameObject.tag != "Enemy") {
				Destroy(gameObject);
			}
			else {
				Destroy(collision.gameObject);
				Destroy(gameObject);
				Vector3 position = new Vector3(Mathf.RoundToInt(Random.Range(0, 9f))*7, 3, Mathf.RoundToInt(Random.Range(0, 9f))*7);
				GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity) as GameObject;
				
			}
		}
		
		
	}
}
