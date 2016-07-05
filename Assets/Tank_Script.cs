using UnityEngine;
using System.Collections;

public class Tank_Script : MonoBehaviour {

	public Vector3 targetPos, heighestPoint;
	public GameObject target;
	public GameObject projectileTemplate;

	public float a, b, c;

	//y = mx^2 + c
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3(1.0f, (2*a*1.0f) + b, 0);
//		heighestPoint = 
		if (target != null){
			transform.LookAt (targetPos);
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			FireProjectile ();
		}

		// f'(x) = 2ax + b 
	}

	private void FireProjectile(){
		GameObject projectile = Instantiate (projectileTemplate, transform.position, Quaternion.identity) as GameObject;
		Projectile_Script p = projectile.GetComponent<Projectile_Script> ();
		p.a = a;
		p.b = b;
		p.c = c;
		target = projectile;
		targetPos = projectile.transform.position;
	}
}
