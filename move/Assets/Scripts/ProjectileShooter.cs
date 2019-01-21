using UnityEngine;
using System.Collections;

public class ProjectileShooter : MonoBehaviour {
	
	GameObject prefab;
	public float projectilespeed;
	public float frequency = 10f;
	public float magnitude = 0.5f;
	public float shotLength = 100;
	public Vector3 targetVector;
	
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject projectile = Instantiate(prefab) as GameObject;
			//StartCoroutine(ShootProjectile(projectile, Vector3.forward*shotLength));
			projectile.transform.position = transform.position+Camera.main.transform.forward * 2;
			//projectile.transform.Translate
			
			//projectile.transform.Translate(new Vector3(0, Mathf.Sin(frequency * Time.time) * magnitude, projectilespeed), Space.Self);
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.velocity = Camera.main.transform.forward*projectilespeed;
			
		}
	}
	

	
}
