using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	
	public TextMesh title;
	public TextMesh coins;
	public TextMesh buyNext;
	public TextMesh play;
	public TextMesh instructions;
	public TextMesh levelSelect;
	public TextMesh options;
	public TextMesh about;
	
	public TextMesh maxSpheres;
	public TextMesh maxSpheresValue;
	public TextMesh maxSpheresPlus;
	public TextMesh maxSpheresMinus;
	//public TextMesh moveSpeed;
	//public TextMesh moveSpeedValue;
	//public TextMesh moveSpeedPlus;
	//public TextMesh moveSpeedMinus;
	public TextMesh optionsClose;
	
	public TextMesh level1;
	public TextMesh level2;
	public TextMesh level3;
	public TextMesh level4;
	public TextMesh level5;
	public TextMesh level6;
	public TextMesh level7;
	public TextMesh level8;
	public TextMesh levelClose;

	public TextMesh instructionsDetails;
	public TextMesh instructionsClose;

	public TextMesh aboutDetails;
	public TextMesh aboutClose;

	public TextMesh quit;

	//M = Menu, 
	//Spheres = Shooting Spheres, 
	//Speed = Move Speed
	public static int startSpheres = 5;
	public static float startSpeed = 0;

	int mSpheres;
	int mSpheresMax = 15;
	int mSpheresMin = 1;
	int mSpheresDefault = 5;
	float mSpeed;
	float mSpeedMax = 3;
	float mSpeedMin = 0;
	float mSpeedDefault = 0;

	
	float charSize;
	
	void Start () {
		//shootingMaxSpheres = shooting.maxSpheres;
		//shootingMoveSpeed = shooting.movespeed;
		//oMaxSpheres = shooting.maxSpheres;
		//oMoveSpeed = shooting.movespeed;
		mSpheres = startSpheres;
		mSpeed = startSpeed;
		charSize = title.characterSize;
	}
	
	Ray ray;
	RaycastHit hit;
	
	void Update () {
		coins.text = Unlocks.coins + " Coins";

		// cheat
		if (Input.GetKeyDown (KeyCode.Mouse1))
			Unlocks.coins = 200;

		maxSpheresValue.text = "" + mSpheres;//shootingMaxSpheres;
		//moveSpeedValue.text =  "" + mSpeed;//shootingMoveSpeed;

		// Save spheres and speed
		startSpheres = mSpheres;
		startSpeed = mSpeed;
		//shooting.maxSpheres = shootingMaxSpheres;
		//shooting.movespeed = shootingMoveSpeed;

		// Remove + and - buttons if you are on max or min values.
		if(maxSpheres.GetComponent<Renderer>().enabled == true){ // When options is displayed
			if (mSpheres == mSpheresMax) {
				maxSpheresPlus.gameObject.SetActive(false);
			} else maxSpheresPlus.gameObject.SetActive(true);

			if (mSpheres == mSpheresMin) {
				maxSpheresMinus.gameObject.SetActive(false);
			} else maxSpheresMinus.gameObject.SetActive(true);

			//if (mSpeed == mSpeedMax) {
			//	moveSpeedPlus.gameObject.SetActive(false);
			//} else moveSpeedPlus.gameObject.SetActive(true);
			
			//if (mSpeed == mSpeedMin) {
			//	moveSpeedMinus.gameObject.SetActive(false);
			//} else moveSpeedMinus.gameObject.SetActive(true);
		}

		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit)){
			
			if(hit.transform.name == "Title"){
				title.fontStyle = FontStyle.BoldAndItalic;
				
				if(Input.GetMouseButtonDown(0)){
					if(title.characterSize < 0.5f)
						title.characterSize += 0.1f;
				}
			}

			if(hit.transform.name == "BuyNext"){
				buyNext.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					//
					if(Unlocks.coins >= 20){
						if(Unlocks.nextUnlock == 8)
						if(Unlocks.level8Lock == true){
							Unlocks.coins -= 20;
							Unlocks.level8Lock = false;
						}
						if(Unlocks.nextUnlock == 7)
						if(Unlocks.level7Lock == true){
							Unlocks.coins -= 20;
							Unlocks.level7Lock = false;
							Unlocks.nextUnlock = 8;
						}
						if(Unlocks.nextUnlock == 6)
						if(Unlocks.level6Lock == true){
							Unlocks.coins -= 20;
							Unlocks.level6Lock = false;
							Unlocks.nextUnlock = 7;
						}
						if(Unlocks.nextUnlock == 5)
						if(Unlocks.level5Lock == true){
							Unlocks.coins -= 20;
							Unlocks.level5Lock = false;
							Unlocks.nextUnlock = 6;
						}
						if(Unlocks.nextUnlock == 4)
						if(Unlocks.level4Lock == true){
							Unlocks.coins -= 20;
							Unlocks.level4Lock = false;
							Unlocks.nextUnlock = 5;
						}
						if(Unlocks.nextUnlock == 3)
						if(Unlocks.level3Lock == true){
							Unlocks.coins -= 20;
							Unlocks.level3Lock = false;
							Unlocks.nextUnlock = 4;
						}
						if(Unlocks.nextUnlock == 2)
						if(Unlocks.level2Lock == true){
							Unlocks.coins -= 20;
							Unlocks.level2Lock = false;
							Unlocks.nextUnlock = 3;
						}
					}
				}
			}

			if(hit.transform.name == "Play"){
				play.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(1);
			}

			if(hit.transform.name == "Instructions"){
				instructions.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					instructionsDetails.gameObject.SetActive(!instructionsDetails.gameObject.activeSelf);
					instructionsClose.GetComponent<Renderer>().enabled = !instructionsClose.GetComponent<Renderer>().enabled;
					instructionsClose.GetComponent<Collider>().enabled = true;

					maxSpheres.GetComponent<Renderer>().enabled = false;
					maxSpheresValue.GetComponent<Renderer>().enabled = false;
					maxSpheresPlus.GetComponent<Renderer>().enabled = false;
					maxSpheresMinus.GetComponent<Renderer>().enabled = false;
					//moveSpeed.GetComponent<Renderer>().enabled = false;
					//moveSpeedValue.GetComponent<Renderer>().enabled = false;
					//moveSpeedPlus.GetComponent<Renderer>().enabled = false;
					//moveSpeedMinus.GetComponent<Renderer>().enabled = false;
					maxSpheres.GetComponent<Collider>().enabled = false;
					maxSpheresPlus.GetComponent<Collider>().enabled = false;
					maxSpheresMinus.GetComponent<Collider>().enabled = false;
					//moveSpeed.GetComponent<Collider>().enabled = false;
					//moveSpeedPlus.GetComponent<Collider>().enabled = false;
					//moveSpeedMinus.GetComponent<Collider>().enabled = false;
					optionsClose.GetComponent<Renderer>().enabled = false;
					optionsClose.GetComponent<Collider>().enabled = false;

					level1.GetComponent<Renderer>().enabled = false;
					level2.GetComponent<Renderer>().enabled = false;
					level3.GetComponent<Renderer>().enabled = false;
					level4.GetComponent<Renderer>().enabled = false;
					level5.GetComponent<Renderer>().enabled = false;
					level6.GetComponent<Renderer>().enabled = false;
					level7.GetComponent<Renderer>().enabled = false;
					level8.GetComponent<Renderer>().enabled = false;
					level1.GetComponent<Collider>().enabled = false;
					level2.GetComponent<Collider>().enabled = false;
					level3.GetComponent<Collider>().enabled = false;
					level4.GetComponent<Collider>().enabled = false;
					level5.GetComponent<Collider>().enabled = false;
					level6.GetComponent<Collider>().enabled = false;
					level7.GetComponent<Collider>().enabled = false;
					level8.GetComponent<Collider>().enabled = false;
					levelClose.GetComponent<Renderer>().enabled = false;
					levelClose.GetComponent<Collider>().enabled = false;

					aboutDetails.gameObject.SetActive(false);
					aboutClose.GetComponent<Renderer>().enabled = false;
					aboutClose.GetComponent<Collider>().enabled = false;
				}
			}

			if(hit.transform.name == "Level Select"){
				levelSelect.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					level1.GetComponent<Renderer>().enabled = !level1.GetComponent<Renderer>().enabled;
					level2.GetComponent<Renderer>().enabled = !level2.GetComponent<Renderer>().enabled;
					level3.GetComponent<Renderer>().enabled = !level3.GetComponent<Renderer>().enabled;
					level4.GetComponent<Renderer>().enabled = !level4.GetComponent<Renderer>().enabled;
					level5.GetComponent<Renderer>().enabled = !level5.GetComponent<Renderer>().enabled;
					level6.GetComponent<Renderer>().enabled = !level6.GetComponent<Renderer>().enabled;
					level7.GetComponent<Renderer>().enabled = !level7.GetComponent<Renderer>().enabled;
					level8.GetComponent<Renderer>().enabled = !level8.GetComponent<Renderer>().enabled;


					level1.GetComponent<Collider>().enabled = !level1.GetComponent<Collider>().enabled;
					level2.GetComponent<Collider>().enabled = !level2.GetComponent<Collider>().enabled;
					level3.GetComponent<Collider>().enabled = !level3.GetComponent<Collider>().enabled;
					level4.GetComponent<Collider>().enabled = !level4.GetComponent<Collider>().enabled;
					level5.GetComponent<Collider>().enabled = !level5.GetComponent<Collider>().enabled;
					level6.GetComponent<Collider>().enabled = !level6.GetComponent<Collider>().enabled;
					level7.GetComponent<Collider>().enabled = !level7.GetComponent<Collider>().enabled;
					level8.GetComponent<Collider>().enabled = !level8.GetComponent<Collider>().enabled;

					if(Unlocks.level2Lock == true)
						level2.gameObject.SetActive(false);
					if(Unlocks.level2Lock == false)
						level2.gameObject.SetActive(true);
						
					if(Unlocks.level3Lock == true)
						level3.gameObject.SetActive(false);
					if(Unlocks.level3Lock == false)
						level3.gameObject.SetActive(true);

					if(Unlocks.level4Lock == true)
						level4.gameObject.SetActive(false);
					else
						level4.gameObject.SetActive(true);

					if(Unlocks.level5Lock == true)
						level5.gameObject.SetActive(false);
					else
						level5.gameObject.SetActive(true);

					if(Unlocks.level6Lock == true)
						level6.gameObject.SetActive(false);
					else
						level6.gameObject.SetActive(true);

					if(Unlocks.level7Lock == true)
						level7.gameObject.SetActive(false);
					else
						level7.gameObject.SetActive(true);

					if(Unlocks.level8Lock == true)
						level8.gameObject.SetActive(false);
					else
						level8.gameObject.SetActive(true);

					levelClose.GetComponent<Renderer>().enabled = !levelClose.GetComponent<Renderer>().enabled;
					levelClose.GetComponent<Collider>().enabled = true;
					
					maxSpheres.GetComponent<Renderer>().enabled = false;
					maxSpheresValue.GetComponent<Renderer>().enabled = false;
					maxSpheresPlus.GetComponent<Renderer>().enabled = false;
					maxSpheresMinus.GetComponent<Renderer>().enabled = false;
					//moveSpeed.GetComponent<Renderer>().enabled = false;
					//moveSpeedValue.GetComponent<Renderer>().enabled = false;
					//moveSpeedPlus.GetComponent<Renderer>().enabled = false;
					//moveSpeedMinus.GetComponent<Renderer>().enabled = false;
					maxSpheres.GetComponent<Collider>().enabled = false;
					maxSpheresPlus.GetComponent<Collider>().enabled = false;
					maxSpheresMinus.GetComponent<Collider>().enabled = false;
					//moveSpeed.GetComponent<Collider>().enabled = false;
					//moveSpeedPlus.GetComponent<Collider>().enabled = false;
					//moveSpeedMinus.GetComponent<Collider>().enabled = false;
					optionsClose.GetComponent<Renderer>().enabled = false;
					optionsClose.GetComponent<Collider>().enabled = false;

					instructionsDetails.gameObject.SetActive(false);
					instructionsClose.GetComponent<Renderer>().enabled = false;
					instructionsClose.GetComponent<Collider>().enabled = false;

					aboutDetails.gameObject.SetActive(false);
					aboutClose.GetComponent<Renderer>().enabled = false;
					aboutClose.GetComponent<Collider>().enabled = false;
				}
			}
			if(hit.transform.name == "Options"){
				options.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					maxSpheres.GetComponent<Renderer>().enabled = !maxSpheres.GetComponent<Renderer>().enabled;
					maxSpheresValue.GetComponent<Renderer>().enabled = !maxSpheresValue.GetComponent<Renderer>().enabled;
					maxSpheresPlus.GetComponent<Renderer>().enabled = !maxSpheresPlus.GetComponent<Renderer>().enabled;
					maxSpheresMinus.GetComponent<Renderer>().enabled = !maxSpheresMinus.GetComponent<Renderer>().enabled;
					//moveSpeed.GetComponent<Renderer>().enabled = !moveSpeed.GetComponent<Renderer>().enabled;
					//moveSpeedValue.GetComponent<Renderer>().enabled = !moveSpeedValue.GetComponent<Renderer>().enabled;
					//moveSpeedPlus.GetComponent<Renderer>().enabled = !moveSpeedPlus.GetComponent<Renderer>().enabled;
					//moveSpeedMinus.GetComponent<Renderer>().enabled = !moveSpeedMinus.GetComponent<Renderer>().enabled;
					optionsClose.GetComponent<Renderer>().enabled = !optionsClose.GetComponent<Renderer>().enabled;
					maxSpheres.GetComponent<Collider>().enabled = !maxSpheres.GetComponent<Collider>().enabled;
					maxSpheresPlus.GetComponent<Collider>().enabled = !maxSpheresPlus.GetComponent<Collider>().enabled;
					maxSpheresMinus.GetComponent<Collider>().enabled = !maxSpheresMinus.GetComponent<Collider>().enabled;
					//moveSpeed.GetComponent<Collider>().enabled = !moveSpeed.GetComponent<Collider>().enabled;
					//moveSpeedPlus.GetComponent<Collider>().enabled = !moveSpeedPlus.GetComponent<Collider>().enabled;
					//moveSpeedMinus.GetComponent<Collider>().enabled = !moveSpeedMinus.GetComponent<Collider>().enabled;
					optionsClose.GetComponent<Collider>().enabled = true;
					
					level1.GetComponent<Renderer>().enabled = false;
					level2.GetComponent<Renderer>().enabled = false;
					level3.GetComponent<Renderer>().enabled = false;
					level4.GetComponent<Renderer>().enabled = false;
					level5.GetComponent<Renderer>().enabled = false;
					level6.GetComponent<Renderer>().enabled = false;
					level7.GetComponent<Renderer>().enabled = false;
					level8.GetComponent<Renderer>().enabled = false;
					level1.GetComponent<Collider>().enabled = false;
					level2.GetComponent<Collider>().enabled = false;
					level3.GetComponent<Collider>().enabled = false;
					level4.GetComponent<Collider>().enabled = false;
					level5.GetComponent<Collider>().enabled = false;
					level6.GetComponent<Collider>().enabled = false;
					level7.GetComponent<Collider>().enabled = false;
					level8.GetComponent<Collider>().enabled = false;
					levelClose.GetComponent<Renderer>().enabled = false;
					levelClose.GetComponent<Collider>().enabled = false;

					instructionsDetails.gameObject.SetActive(false);
					instructionsClose.GetComponent<Renderer>().enabled = false;
					instructionsClose.GetComponent<Collider>().enabled = false;

					aboutDetails.gameObject.SetActive(false);
					aboutClose.GetComponent<Renderer>().enabled = false;
					aboutClose.GetComponent<Collider>().enabled = false;
				}
			}

			if(hit.transform.name == "About"){
				about.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					aboutDetails.gameObject.SetActive(!aboutDetails.gameObject.activeSelf);
					aboutClose.GetComponent<Renderer>().enabled = !aboutClose.GetComponent<Renderer>().enabled;
					aboutClose.GetComponent<Collider>().enabled = true;
					
					maxSpheres.GetComponent<Renderer>().enabled = false;
					maxSpheresValue.GetComponent<Renderer>().enabled = false;
					maxSpheresPlus.GetComponent<Renderer>().enabled = false;
					maxSpheresMinus.GetComponent<Renderer>().enabled = false;
					//moveSpeed.GetComponent<Renderer>().enabled = false;
					//moveSpeedValue.GetComponent<Renderer>().enabled = false;
					//moveSpeedPlus.GetComponent<Renderer>().enabled = false;
					//moveSpeedMinus.GetComponent<Renderer>().enabled = false;
					maxSpheres.GetComponent<Collider>().enabled = false;
					maxSpheresPlus.GetComponent<Collider>().enabled = false;
					maxSpheresMinus.GetComponent<Collider>().enabled = false;
					//moveSpeed.GetComponent<Collider>().enabled = false;
					//moveSpeedPlus.GetComponent<Collider>().enabled = false;
					//moveSpeedMinus.GetComponent<Collider>().enabled = false;
					optionsClose.GetComponent<Renderer>().enabled = false;
					optionsClose.GetComponent<Collider>().enabled = false;
					
					level1.GetComponent<Renderer>().enabled = false;
					level2.GetComponent<Renderer>().enabled = false;
					level3.GetComponent<Renderer>().enabled = false;
					level4.GetComponent<Renderer>().enabled = false;
					level5.GetComponent<Renderer>().enabled = false;
					level6.GetComponent<Renderer>().enabled = false;
					level7.GetComponent<Renderer>().enabled = false;
					level8.GetComponent<Renderer>().enabled = false;
					level1.GetComponent<Collider>().enabled = false;
					level2.GetComponent<Collider>().enabled = false;
					level3.GetComponent<Collider>().enabled = false;
					level4.GetComponent<Collider>().enabled = false;
					level5.GetComponent<Collider>().enabled = false;
					level6.GetComponent<Collider>().enabled = false;
					level7.GetComponent<Collider>().enabled = false;
					level8.GetComponent<Collider>().enabled = false;
					levelClose.GetComponent<Renderer>().enabled = false;
					levelClose.GetComponent<Collider>().enabled = false;

					instructionsDetails.gameObject.SetActive(false);
					instructionsClose.GetComponent<Renderer>().enabled = false;
					instructionsClose.GetComponent<Collider>().enabled = false;
				}
			}
			
			
			if(hit.transform.name == "Max Spheres"){
				maxSpheres.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					mSpheres = mSpheresDefault;
			}
			if(hit.transform.name == "Max Spheres Plus"){
				maxSpheresPlus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0) && mSpheres < mSpheresMax)
					mSpheres++;
			}
			if(hit.transform.name == "Max Spheres Minus"){
				maxSpheresMinus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0) && mSpheres > mSpheresMin)
					mSpheres--;
			}
			//if(hit.transform.name == "Move Speed"){
			//	moveSpeed.fontStyle = FontStyle.Bold;
			//	if(Input.GetMouseButtonDown(0))
			//		mSpeed = mSpeedDefault;
			//}
			//if(hit.transform.name == "Move Speed Plus"){
			//	moveSpeedPlus.fontStyle = FontStyle.Bold;
			//	if(Input.GetMouseButtonDown(0) && mSpeed < mSpeedMax)
			//		mSpeed++;
			//}
			//if(hit.transform.name == "Move Speed Minus"){
			//	moveSpeedMinus.fontStyle = FontStyle.Bold;
			//	if(Input.GetMouseButtonDown(0) && mSpeed > mSpeedMin)
			//		mSpeed--;
			//}
			if(hit.transform.name == "Options Close"){
				optionsClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					maxSpheres.GetComponent<Renderer>().enabled = !maxSpheres.GetComponent<Renderer>().enabled;
					maxSpheresValue.GetComponent<Renderer>().enabled = !maxSpheresValue.GetComponent<Renderer>().enabled;
					maxSpheresPlus.GetComponent<Renderer>().enabled = !maxSpheresPlus.GetComponent<Renderer>().enabled;
					maxSpheresMinus.GetComponent<Renderer>().enabled = !maxSpheresMinus.GetComponent<Renderer>().enabled;
					//moveSpeed.GetComponent<Renderer>().enabled = !moveSpeed.GetComponent<Renderer>().enabled;
					//moveSpeedValue.GetComponent<Renderer>().enabled = !moveSpeedValue.GetComponent<Renderer>().enabled;
					//moveSpeedPlus.GetComponent<Renderer>().enabled = !moveSpeedPlus.GetComponent<Renderer>().enabled;
					//moveSpeedMinus.GetComponent<Renderer>().enabled = !moveSpeedMinus.GetComponent<Renderer>().enabled;
					maxSpheres.GetComponent<Collider>().enabled = false;
					maxSpheresPlus.GetComponent<Collider>().enabled = false;
					maxSpheresMinus.GetComponent<Collider>().enabled = false;
					//moveSpeed.GetComponent<Collider>().enabled = false;
					//moveSpeedPlus.GetComponent<Collider>().enabled = false;
					//moveSpeedMinus.GetComponent<Collider>().enabled = false;
					optionsClose.GetComponent<Renderer>().enabled = !optionsClose.GetComponent<Renderer>().enabled;
					optionsClose.GetComponent<Collider>().enabled = false;
				}
			}
			
			
			if(hit.transform.name == "Level 1"){
				level1.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(1);
			}
			if(hit.transform.name == "Level 2"){
				level2.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(2);
			}
			if(hit.transform.name == "Level 3"){
				level3.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(3);
			}
			if(hit.transform.name == "Level 4"){
				level4.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(4);
			}
			if(hit.transform.name == "Level 5"){
				level5.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(5);
			}
			if(hit.transform.name == "Level 6"){
				level6.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(6);
			}
			if(hit.transform.name == "Level 7"){
				level7.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(7);
			}
			if(hit.transform.name == "Level 8"){
				level8.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					Application.LoadLevel(8);
			}
			if(hit.transform.name == "Level Select Close"){
				levelClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					level1.GetComponent<Renderer>().enabled = !level1.GetComponent<Renderer>().enabled;
					level2.GetComponent<Renderer>().enabled = !level2.GetComponent<Renderer>().enabled;
					level3.GetComponent<Renderer>().enabled = !level3.GetComponent<Renderer>().enabled;
					level4.GetComponent<Renderer>().enabled = !level4.GetComponent<Renderer>().enabled;
					level5.GetComponent<Renderer>().enabled = !level5.GetComponent<Renderer>().enabled;
					level6.GetComponent<Renderer>().enabled = !level6.GetComponent<Renderer>().enabled;
					level7.GetComponent<Renderer>().enabled = !level7.GetComponent<Renderer>().enabled;
					level8.GetComponent<Renderer>().enabled = !level8.GetComponent<Renderer>().enabled;
					level1.GetComponent<Collider>().enabled = false;
					level2.GetComponent<Collider>().enabled = false;
					level3.GetComponent<Collider>().enabled = false;
					level4.GetComponent<Collider>().enabled = false;
					level5.GetComponent<Collider>().enabled = false;
					level6.GetComponent<Collider>().enabled = false;
					level7.GetComponent<Collider>().enabled = false;
					level8.GetComponent<Collider>().enabled = false;
					levelClose.GetComponent<Renderer>().enabled = !levelClose.GetComponent<Renderer>().enabled;
					levelClose.GetComponent<Collider>().enabled = false;
				}
			}


			if(hit.transform.name == "Instructions Close"){
				instructionsClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					instructionsDetails.gameObject.SetActive(!instructionsDetails.gameObject.activeSelf);
					instructionsClose.GetComponent<Renderer>().enabled = !instructionsClose.GetComponent<Renderer>().enabled;
					instructionsClose.GetComponent<Collider>().enabled = false;
				}
			}


			if(hit.transform.name == "About Close"){
				aboutClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					aboutDetails.gameObject.SetActive(!aboutDetails.gameObject.activeSelf);
					aboutClose.GetComponent<Renderer>().enabled = !aboutClose.GetComponent<Renderer>().enabled;
					aboutClose.GetComponent<Collider>().enabled = false;
				}
			}

			if(hit.transform.name == "Quit"){
				quit.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					Application.Quit (); 
				}
			}
		}
		else
		{
			title.fontStyle = FontStyle.Bold;
			play.fontStyle = FontStyle.Normal;
			buyNext.fontStyle = FontStyle.Normal;
			instructions.fontStyle = FontStyle.Normal;
			levelSelect.fontStyle = FontStyle.Normal;
			options.fontStyle = FontStyle.Normal;
			about.fontStyle = FontStyle.Normal;
			
			maxSpheres.fontStyle = FontStyle.Normal;
			maxSpheresPlus.fontStyle = FontStyle.Normal;
			maxSpheresMinus.fontStyle = FontStyle.Normal;
			//moveSpeed.fontStyle = FontStyle.Normal;
			//moveSpeedPlus.fontStyle = FontStyle.Normal;
			//moveSpeedMinus.fontStyle = FontStyle.Normal;
			optionsClose.fontStyle = FontStyle.Normal;
			
			level1.fontStyle = FontStyle.Normal;
			level2.fontStyle = FontStyle.Normal;
			level3.fontStyle = FontStyle.Normal;
			level4.fontStyle = FontStyle.Normal;
			level5.fontStyle = FontStyle.Normal;
			level6.fontStyle = FontStyle.Normal;
			level7.fontStyle = FontStyle.Normal;
			level8.fontStyle = FontStyle.Normal;
			levelClose.fontStyle = FontStyle.Normal;

			instructionsClose.fontStyle = FontStyle.Normal;

			aboutClose.fontStyle = FontStyle.Normal;

			quit.fontStyle = FontStyle.Normal;

			title.characterSize = charSize;	
		}
	}
}
