using UnityEngine;
using System.Collections;

public class Projectile_Script : MonoBehaviour {
	public float a, b, c, t;
	public GameObject tank;

	// Use this for initialization
	void Start () {
		t = 0;
		tank = GameObject.FindGameObjectWithTag ("tank");
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		FireAtWill (a, b, c, t);
	}

	public void FireAtWill (float a, float b, float c, float t){
		//Tank_Script tankscript = tank.GetComponent<Tank_Script> ();

		//if (tankscript.selected_Struct = eqstruct_Standard) {
			transform.position = new Vector3 (t, (a * Mathf.Pow (t, 2)) + (b * t) + c, 0);
		//}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "target") {
			other.gameObject.SetActive (false);
			Tank_Script tankscript = tank.GetComponent<Tank_Script> ();
			tankscript.targetsRemaining--;
		}

		if (other.gameObject.tag == "boundry") {
			Tank_Script tankscript = tank.GetComponent<Tank_Script> ();
			if (tankscript.targetsRemaining == 0) {
				tankscript.Win ();
			} else {
				tankscript.fails++;
				tankscript.canFire = true;
				tankscript.Fail ();
			}
		}
	}
}
