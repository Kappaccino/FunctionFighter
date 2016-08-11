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
		t += 2*Time.deltaTime;
		FireAtWill (a, b, c, t);
	}

	public void FireAtWill (float a, float b, float c, float t){
		Tank_Script tankscript = tank.GetComponent<Tank_Script> ();

		if (tankscript.selectedStruct == Tank_Script.EquationStruct.Standard) {
			transform.position = new Vector3 (t, (a * Mathf.Pow (t, 2)) + (b * t) + c, 0);
		} else if (tankscript.selectedStruct == Tank_Script.EquationStruct.Intercept) {
			transform.position = new Vector3 (t, (a * (t + b) * (t - c)), 0);
		} else if (tankscript.selectedStruct == Tank_Script.EquationStruct.Vertex) {
			transform.position = new Vector3 (t, (a * Mathf.Pow((t - b),2) + c), 0);
		} else if (tankscript.selectedStruct == Tank_Script.EquationStruct.None) {
			Debug.Log ("what are you doin' m8");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "target") {
			other.gameObject.SetActive (false);
			Tank_Script tankscript = tank.GetComponent<Tank_Script> ();
			tankscript.targetsRemaining--;
		}

		if (other.gameObject.tag == "boundry") {
			Tank_Script tankscript = tank.GetComponent<Tank_Script> ();
			tankscript.ChangeEQStruct.SetActive (true);
			if (tankscript.targetsRemaining == 0) {
				tankscript.Win ();
//				Destroy (this.gameObject);
			} else {
				tankscript.fails++;
				tankscript.canFire = true;
				tankscript.Fail ();
			}
		}
	}
}
