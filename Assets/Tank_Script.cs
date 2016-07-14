using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tank_Script : MonoBehaviour {

	public Vector3 targetPos, heighestPoint;
	public GameObject target;
	public GameObject[] targets;
	public GameObject projectileTemplate;
	public int fails;

	public Text hints;
	private string hint1, hint2, hint3;

	public int targetsRemaining;
	public bool canFire;

	public InputField input_A, input_B, input_C;
	public float a, b, c;

	//y = mx^2 + c
	// Use this for initialization
	void Start () {
		fails = 0;
		canFire = true;
		targets = GameObject.FindGameObjectsWithTag ("target");
		targetsRemaining = targets.Length;
		hint1 = "This function is in standard form. In this form, changing the lowering the a variable will make the parabola steeper, and the projectile will not go as far.";
		hint2 = "In standard form, changing the b variable will affect the angle of the projectile";
		hint3 = "The correct equation for this problem is y=-0.3x^2+3x+0";
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

		if (fails == 0) {

		} else if (fails == 1) {
			hints.text = hint1;
		} else if (fails == 2) {
			hints.text = hint1 + hint2;
		} else if (fails > 2) {
			hints.text = hint1 + hint2 + hint3;
		}

		// f'(x) = 2ax + b 
	}

	public void FireProjectile(){
		if (canFire) {
			a = -(float.Parse (input_A.text));
			Debug.Log (a);
			b = float.Parse (input_B.text);
			c = float.Parse (input_C.text);
			GameObject projectile = Instantiate (projectileTemplate, transform.position, Quaternion.identity) as GameObject;
			Projectile_Script p = projectile.GetComponent<Projectile_Script> ();
			p.a = a;
			p.b = b;
			p.c = c;
			target = projectile;
			targetPos = projectile.transform.position;
			canFire = false;
		} else {

		}
	}
}
