using UnityEngine;
using System.Collections;

public class Tank_Script : MonoBehaviour {

	public Vector3 targetPos;
	public GameObject target;
	public GameObject projectileTemplate;

	public float a, b, c;

	//y = mx^2 + c
	// Use this for initialization
	void Start () {
		targetPos = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (targetPos);
		if (Input.GetKeyDown(KeyCode.Space)){
			FireProjectile ();
		}
	}

	private void FireProjectile(){
		GameObject projectile = Instantiate (projectileTemplate, transform.position, Quaternion.identity) as GameObject;
		Projectile_Script p = projectile.GetComponent<Projectile_Script> ();
		p.a = a;
		p.b = b;
		p.c = c;
	}
}
