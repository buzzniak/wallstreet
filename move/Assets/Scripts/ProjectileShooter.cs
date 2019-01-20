using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour {
	
	GameObject prefab;
	public float projectilespeed;
	public float frequency = 10f;
	public float magnitude = 0.5f;
	
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject projectile = Instantiate(prefab) as GameObject;
			projectile.transform.position = transform.position+Camera.main.transform.forward * 2;
			//projectile.transform.position.y = projectile.transform.position.y + Mathf.Sin(frequency*Time.time)* magnitude;
			//Vector3 currpos = transform.position;
			//projectile.transform.position = new Vector3 (transform.position.x, transform.position.y + (Mathf.Sin(frequency*Time.time)* magnitude), transform.position.z);
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.velocity = Camera.main.transform.forward*projectilespeed;
			
		}
	}
}
