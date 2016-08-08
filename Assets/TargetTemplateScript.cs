using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetTemplateScript : MonoBehaviour {

	public Text positionDisplay;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		positionDisplay.text = (this.transform.position.x + "," + this.transform.position.y);
	}
}
