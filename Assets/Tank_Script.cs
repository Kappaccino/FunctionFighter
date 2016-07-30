using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tank_Script : MonoBehaviour {

	public Vector3 targetPos, heighestPoint;
	public GameObject target;
	public GameObject[] targets;
	public GameObject projectileTemplate;
	public int fails;

	public GameObject eqstruct_Standard;
	public GameObject eqstruct_Intercept;
	public GameObject eqstruct_Vertex;
	public GameObject selected_Struct;

	public GameObject formatSelection;

	public Text eq1, eq2, eq3;
	public Button fire;
	public Text title;

	public Text hints;
	private string hint1, hint2, hint3;

	public int targetsRemaining;
	public bool canFire;

	public InputField input_A, input_B, input_C;
	public float a, b, c;

	public Text winAnnounce;
	public Button nextLevel;
	public Button quit;

	//y = mx^2 + c
	// Use this for initialization
	void Start () {
		fails = 0;
		canFire = true;
		targets = GameObject.FindGameObjectsWithTag ("target");
		targetsRemaining = targets.Length;
		hint1 = "This function is in standard form. In this form, changing the lowering the a variable will make the parabola steeper, and the projectile will not go as far.\n";
		hint2 = "In standard form, changing the b variable will affect the angle of the projectile\n";
		hint3 = "The correct equation for this problem is y=-0.3x^2+3x+0\n";

		winAnnounce.gameObject.SetActive (false);
		nextLevel.gameObject.SetActive (false);
		quit.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3(1.0f, (2*a*1.0f) + b, 0);
//		heighestPoint = 
		if (target != null){
			transform.LookAt (targetPos);
		}

//		if (Input.GetKeyDown(KeyCode.Space)){
//				FireProjectile ();
//		}

		// f'(x) = 2ax + b 
	}

	public void FireProjectile(){
		if (canFire) {
			a = -(float.Parse (input_A.text));
			b = float.Parse (input_B.text);
			c = 0;
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

	public void Win(){
		eq1.gameObject.SetActive (false);
		eq2.gameObject.SetActive (false);
		eq3.gameObject.SetActive (false);
		fire.gameObject.SetActive (false);
		hints.gameObject.SetActive (false);
		input_A.gameObject.SetActive (false);
		input_B.gameObject.SetActive (false);
		//input_C.gameObject.SetActive (false);
		title.gameObject.SetActive (false);

		winAnnounce.gameObject.SetActive (true);
		nextLevel.gameObject.SetActive (true);
		quit.gameObject.SetActive (true);
	}

	public void Fail(){
		if (fails == 0) {
		} else if (fails == 1) {
			hints.text = hint1;
		} else if (fails == 2) {
			hints.text = hint1 + hint2;
		} else if (fails > 2) {
			hints.text = hint1 + hint2 + hint3;
		}
	}

	public void Quit (){
		Application.Quit();
	}

	public void LoadScene (){
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	public void CheckAValue(){
		float input_a_value;
		input_a_value = Mathf.Abs(float.Parse (input_A.text));
		input_A.text = input_a_value.ToString();
	}

	public void ChooseStandardForm(){
		selected_Struct = eqstruct_Standard;
		Debug.Log ("Standard Form Selected");
		formatSelection.gameObject.SetActive (false);
		eqstruct_Standard.gameObject.SetActive (true);
	}

	public void ChooseInterceptForm(){
		selected_Struct = eqstruct_Intercept;
		Debug.Log ("Intercept Form Selected");
		formatSelection.gameObject.SetActive (false);
		eqstruct_Intercept.gameObject.SetActive (true);
	}

	public void ChooseVertexForm(){
		selected_Struct = eqstruct_Vertex;
		Debug.Log ("Vertex Form Selected");
		formatSelection.gameObject.SetActive (false);
		eqstruct_Vertex.gameObject.SetActive (true);
	}
}
