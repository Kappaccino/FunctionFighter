using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tank_Script : MonoBehaviour {

	public Vector3 targetPos, heighestPoint;
	public GameObject target;
	public GameObject[] targets;
	public GameObject targetTemplate;
	public GameObject projectileTemplate;
	public int fails;

	public GameObject eqstruct_Standard;
	public GameObject eqstruct_Intercept;
	public GameObject eqstruct_Vertex;
	public enum EquationStruct
	{
		Standard, Intercept, Vertex, None
	};

	public GameObject formatSelection;

	public Text eq1, eq2, eq3;
	public Button fire;
	public Text title;

	public Text hints;
	private string standardHint1, standardHint2, standardHint3,
					interceptHint1, interceptHint2, interceptHint3;

	public int targetsRemaining;
	public bool canFire;

	public InputField structStand_input_A, structStand_input_B, structStand_input_C, 
						structInter_input_A, structInter_input_B, structInter_input_C,
						structVert_input_A, structVert_input_B, structVert_input_C;
	public float a, b, c;

	public Text winAnnounce;
	public GameObject standardFormHelp;
	public GameObject interceptFormHelp;
	public Button nextLevel;
	public Button quit;
	public GameObject structSelect;
	public GameObject selectionUI;
	public GameObject[] equationUI;
	public GameObject ChangeEQStruct;

	public EquationStruct selectedStruct;

	public bool helpActive;

	public GameObject winScreen;
	public GameObject loseScreen;

	public int score;

	//y = mx^2 + c
	// Use this for initialization
	void Start () {

		GameObject target1 = Instantiate (targetTemplate, new Vector3(5, 7.5f, 0), Quaternion.identity) as GameObject;
		GameObject target2 = Instantiate (targetTemplate, new Vector3 (10, 0, 0), Quaternion.identity) as GameObject;
		GameObject target3 = Instantiate (targetTemplate, new Vector3 (2, 4.8f, 0), Quaternion.identity) as GameObject;

		score = 0;

		selectedStruct = EquationStruct.None;
		fails = 0;
		canFire = true;
		targets = GameObject.FindGameObjectsWithTag ("target");
		targetsRemaining = targets.Length;
		standardHint1 = "This function is in standard form. In this form, increasing the a variable will reduce the height and length of the parabola.\n";
		standardHint2 = "In this form, increasing the b variable will increase the angle of the cannon's barrel, making the projectile go higher and further.\n";
		standardHint3 = "The correct equation for this problem is y=-0.3x^2+3x+0.\n";

		interceptHint1 = "This function is in intercept form. In this form, increasing the a variable will make the parabola steeper, however it will not change the horizontal distance the projectile covers.\n";
		interceptHint2 = "In this form, increasing the b variable will increase the angle of the cannon's barrel, making the projectile go higher and further.\n";
		interceptHint3 = "The positions that the parabola crosses the x-axis are shown in this form by the numbers in the brackets. One of them is already given to you (0,0)\n";

		winAnnounce.gameObject.SetActive (false);
		nextLevel.gameObject.SetActive (false);
		quit.gameObject.SetActive (false);
		helpActive = false;

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

//		Debug.Log (targets.Length);
	}

	public void FireProjectile(){
		if (canFire) {
			if (selectedStruct == EquationStruct.Standard) {
				a = -(float.Parse (structStand_input_A.text));
				b = float.Parse (structStand_input_B.text);
				c = 0;
				GameObject projectile = Instantiate (projectileTemplate, transform.position, Quaternion.identity) as GameObject;
				Projectile_Script p = projectile.GetComponent<Projectile_Script> ();
				p.a = a;
				p.b = b;
				p.c = c;
				target = projectile;
				targetPos = projectile.transform.position;
				canFire = false;
			} else if (selectedStruct == EquationStruct.Intercept) {
				a = -(float.Parse (structInter_input_A.text));
				b = 0;
				c = float.Parse (structInter_input_C.text);
				GameObject projectile = Instantiate (projectileTemplate, transform.position, Quaternion.identity) as GameObject;
				Projectile_Script p = projectile.GetComponent<Projectile_Script> ();
				p.a = a;
				p.b = b;
				p.c = c;
				target = projectile;
				targetPos = projectile.transform.position;
				canFire = false;
			} else if (selectedStruct == EquationStruct.Vertex) {
				a = -(float.Parse (structVert_input_A.text));
				b = float.Parse (structVert_input_B.text);
				c = float.Parse (structVert_input_C.text);
				GameObject projectile = Instantiate (projectileTemplate, transform.position, Quaternion.identity) as GameObject;
				Projectile_Script p = projectile.GetComponent<Projectile_Script> ();
				p.a = a;
				p.b = b;
				p.c = c;
				target = projectile;
				targetPos = projectile.transform.position;
				canFire = false;

			} else if (selectedStruct == EquationStruct.None) {
				Debug.Log ("what are you doin' m8");

			}
		}
	}

	public void Win(){

//		GameObject[] UIpieces;
//		UIpieces = GameObject.FindGameObjectsWithTag ("InGameUI");
//		foreach (GameObject InGameUI in UIpieces) {
//			InGameUI.SetActive (false);
//		}

//		eq1.gameObject.SetActive (false);
//		eq2.gameObject.SetActive (false);
//		eq3.gameObject.SetActive (false);
//		fire.gameObject.SetActive (false);
//		hints.gameObject.SetActive (false);
//		input_A.gameObject.SetActive (false);
//		input_B.gameObject.SetActive (false);
//		input_C.gameObject.SetActive (false);
//		title.gameObject.SetActive (false);

//		winAnnounce.gameObject.SetActive (true);
//		nextLevel.gameObject.SetActive (true);
//		quit.gameObject.SetActive (true);

		GameObject[] equationUI;
		equationUI = GameObject.FindGameObjectsWithTag ("Equation");
		foreach (GameObject Equation in equationUI) {
			Equation.SetActive (false);
		}

//		GameObject fireButton;
//		fireButton = GameObject.FindGameObjectWithTag ("FireButton");
//		fireButton.SetActive (false);

//		structSelect.SetActive (true);

//		GameObject target1 = Instantiate (targetTemplate, new Vector3(6, 0, 0), Quaternion.identity) as GameObject;
//		GameObject target2 = Instantiate (targetTemplate, new Vector3 (3, 4.5f, 0), Quaternion.identity) as GameObject;

//		targets = GameObject.FindGameObjectsWithTag ("target");
		foreach (GameObject target in targets) {
			GameObject.Destroy(target);
		}
//		targetsRemaining = targets.Length;



		selectedStruct = EquationStruct.None;

		selectionUI.SetActive (false);

		winScreen.SetActive (true);

		if (fails == 0) {
			score += 3;
		} else if (fails == 1) {
			score += 2;
		} else if (fails == 2) {
			score += 1;
		}

	}

	public void Fail(){
		foreach (GameObject cannontarget in targets) {
			cannontarget.gameObject.SetActive (true);
		}

		targetsRemaining = targets.Length;

		if (fails == 0) {
		} else if (fails == 1) {
			if (selectedStruct == EquationStruct.Standard) {
				hints.text = standardHint1;
			} else if (selectedStruct == EquationStruct.Intercept) {
				hints.text = interceptHint1;
			}
		} else if (fails == 2) {
			if (selectedStruct == EquationStruct.Standard) {
				hints.text = standardHint1 + standardHint2;
			} else if (selectedStruct == EquationStruct.Intercept) {
				hints.text = interceptHint1 + interceptHint2;
			}
		} else if (fails == 3) {
			if (selectedStruct == EquationStruct.Standard) {
				hints.text = standardHint1 + standardHint2 + standardHint3;
			} else if (selectedStruct == EquationStruct.Intercept) {
				hints.text = interceptHint1 + interceptHint2 + interceptHint3;
			}
		} else if (fails > 3) {
			GameObject[] equationUI;
			equationUI = GameObject.FindGameObjectsWithTag ("Equation");
			foreach (GameObject Equation in equationUI) {
				Equation.SetActive (false);
			}

//			GameObject fireButton;
//			fireButton = GameObject.FindGameObjectWithTag ("FireButton");
//			fireButton.SetActive (false);

			structSelect.SetActive (true);

//			GameObject target1 = Instantiate (targetTemplate, new Vector3(6, 0, 0), Quaternion.identity) as GameObject;
//			GameObject target2 = Instantiate (targetTemplate, new Vector3 (3, 4.5f, 0), Quaternion.identity) as GameObject;

			targets = GameObject.FindGameObjectsWithTag ("target");
			Debug.Log (targets);
			targetsRemaining = targets.Length;

			selectedStruct = EquationStruct.None;

			selectionUI.SetActive (false);

			hints.text = "";

			loseScreen.SetActive (true);
		}
	}

	public void Quit (){
		Application.Quit();
	}

	public void NextLevel (){
		//SceneManager.LoadScene (0, LoadSceneMode.Single);
		winScreen.SetActive(false);
		GameObject target1 = Instantiate (targetTemplate, new Vector3 (6,0,0), Quaternion.identity) as GameObject;
		GameObject target2 = Instantiate (targetTemplate, new Vector3 (3, 4.5f, 0), Quaternion.identity) as GameObject;

		targets = GameObject.FindGameObjectsWithTag ("target");
		targetsRemaining = targets.Length;
		selectionUI.SetActive (true);
		canFire = true;
	}

	public void CheckAValue(){
		if (selectedStruct == EquationStruct.Standard) {
			float input_a_value;
			input_a_value = Mathf.Abs (float.Parse (structStand_input_A.text));

			if (input_a_value > 10) {
				input_a_value = 10;
				structStand_input_A.text = input_a_value.ToString ();
			} else {
				structStand_input_A.text = input_a_value.ToString ();
			}

			float input_b_value;
			input_b_value = Mathf.Abs(float.Parse (structStand_input_B.text));

			if (input_b_value > 10) {
				input_b_value = 10;
				structStand_input_B.text = input_b_value.ToString ();
			} else {
				structStand_input_B.text = input_b_value.ToString ();
			}

		} else if (selectedStruct == EquationStruct.Intercept) {
			Debug.Log ("Checking A value (intercept form)");
			float input_a_value;
			input_a_value = Mathf.Abs (float.Parse (structInter_input_A.text));

			if (input_a_value > 10) {
				input_a_value = 10;
				structInter_input_A.text = input_a_value.ToString ();
			} else {
				structInter_input_A.text = input_a_value.ToString ();
			}

//			float input_b_value;
//			input_b_value = Mathf.Abs (float.Parse (structInter_input_B.text));
//
//			if (input_b_value > 10) {
//				input_b_value = 10;
//				structInter_input_B.text = input_b_value.ToString ();
//			} else {
//				structInter_input_A.text = input_b_value.ToString ();
//			}

			float input_c_value;
			input_c_value = Mathf.Abs (float.Parse (structInter_input_C.text));

			if (input_c_value > 10) {
				input_c_value = 10;
				structInter_input_C.text = input_c_value.ToString ();
			} else {
				structInter_input_C.text = input_c_value.ToString ();
			}

		} else if (selectedStruct == EquationStruct.Vertex) {
			Debug.Log ("Checking A value (vertex form)");
			float input_a_value;
			input_a_value = Mathf.Abs (float.Parse (structVert_input_A.text));

			if (input_a_value > 10) {
				input_a_value = 10;
				structVert_input_A.text = input_a_value.ToString ();
			} else {
				structVert_input_A.text = input_a_value.ToString ();
			}

			float input_b_value;
			input_b_value = Mathf.Abs (float.Parse (structVert_input_B.text));

			if (input_b_value > 10) {
				input_b_value = 10;
				structVert_input_B.text = input_b_value.ToString ();
			} else {
				structVert_input_A.text = input_b_value.ToString ();
			}

			float input_c_value;
			input_c_value = Mathf.Abs (float.Parse (structVert_input_C.text));

			if (input_c_value > 10) {
				input_c_value = 10;
				structVert_input_C.text = input_c_value.ToString ();
			} else {
				structVert_input_C.text = input_c_value.ToString ();
			}


		} else if (selectedStruct == EquationStruct.None) {

		
		}

	}

	public void ChangeEquationStructure(){
		equationUI = GameObject.FindGameObjectsWithTag ("Equation");
		foreach (GameObject Equation in equationUI) {
			Equation.SetActive (false);
		}

		selectedStruct = EquationStruct.None;

//		GameObject selectionUI;
//		selectionUI = GameObject.FindGameObjectWithTag ("StructSelect");
//		selectionUI.SetActive (true);
		selectionUI.SetActive(true);
	}

	public void ChooseStandardForm(){
		selectedStruct = EquationStruct.Standard;
		Debug.Log ("Standard Form Selected");
		formatSelection.gameObject.SetActive (false);
		eqstruct_Standard.gameObject.SetActive (true);
		ChangeEQStruct.SetActive (true);
	}

	public void ChooseInterceptForm(){
		selectedStruct = EquationStruct.Intercept;
		Debug.Log ("Intercept Form Selected");
		formatSelection.gameObject.SetActive (false);
		eqstruct_Intercept.gameObject.SetActive (true);
		ChangeEQStruct.SetActive (true);
	}

	public void ChooseVertexForm(){
		selectedStruct = EquationStruct.Vertex;
		Debug.Log ("Vertex Form Selected");
		formatSelection.gameObject.SetActive (false);
		eqstruct_Vertex.gameObject.SetActive (true);
		ChangeEQStruct.SetActive (true);
	}

	public void StandardFormHelp(){
		if (standardFormHelp.gameObject.activeSelf == false && helpActive == false) {
			standardFormHelp.SetActive (true);
			helpActive = true;
		} else if(standardFormHelp.gameObject.activeSelf == true && helpActive == true){
			standardFormHelp.SetActive (false);
			helpActive = false;
		}
	}

	public void InterceptFormHelp(){
		if (interceptFormHelp.gameObject.activeSelf == false && helpActive == false) {
			interceptFormHelp.SetActive (true);
			helpActive = true;
		} else if(interceptFormHelp.gameObject.activeSelf == true && helpActive == true){
			interceptFormHelp.SetActive (false);
			helpActive = false;
		}
	}
}
