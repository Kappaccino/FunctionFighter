using UnityEngine;
using System.Collections;

public class Projectile_Script : MonoBehaviour {
	public float a, b, c, t;
	// Use this for initialization
	void Start () {
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		FireAtWill (a, b, c, t);
	}

	public void FireAtWill (float a, float b, float c, float t){
		transform.position = new Vector3 (t, (a*Mathf.Pow(t,2)) + (b*t) + c, 0);
	}
}
