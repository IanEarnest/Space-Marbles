using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	
	public TextMesh title;
	public TextMesh play;
	public TextMesh instructions;
	public TextMesh levelSelect;
	public TextMesh options;
	public TextMesh about;
	
	public TextMesh maxSpheres;
	public TextMesh maxSpheresValue;
	public TextMesh maxSpheresPlus;
	public TextMesh maxSpheresMinus;
	public TextMesh moveSpeed;
	public TextMesh moveSpeedValue;
	public TextMesh moveSpeedPlus;
	public TextMesh moveSpeedMinus;
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
		maxSpheresValue.text = "" + mSpheres;//shootingMaxSpheres;
		moveSpeedValue.text =  "" + mSpeed;//shootingMoveSpeed;

		// Save spheres and speed
		startSpheres = mSpheres;
		startSpeed = mSpeed;
		//shooting.maxSpheres = shootingMaxSpheres;
		//shooting.movespeed = shootingMoveSpeed;

		// Remove + and - buttons if you are on max or min values.
		if(maxSpheres.renderer.enabled == true){ // When options is displayed
			if (mSpheres == mSpheresMax) {
				maxSpheresPlus.gameObject.SetActive(false);
			} else maxSpheresPlus.gameObject.SetActive(true);

			if (mSpheres == mSpheresMin) {
				maxSpheresMinus.gameObject.SetActive(false);
			} else maxSpheresMinus.gameObject.SetActive(true);

			if (mSpeed == mSpeedMax) {
				moveSpeedPlus.gameObject.SetActive(false);
			} else moveSpeedPlus.gameObject.SetActive(true);
			
			if (mSpeed == mSpeedMin) {
				moveSpeedMinus.gameObject.SetActive(false);
			} else moveSpeedMinus.gameObject.SetActive(true);
		}

		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit)){
			
			if(hit.transform.name == "Title"){
				title.fontStyle = FontStyle.BoldAndItalic;
				
				if(Input.GetMouseButtonDown(0)){
					if(title.characterSize < 0.8f)
						title.characterSize += 0.2f;
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
					instructionsClose.renderer.enabled = !instructionsClose.renderer.enabled;
					instructionsClose.collider.enabled = true;

					maxSpheres.renderer.enabled = false;
					maxSpheresValue.renderer.enabled = false;
					maxSpheresPlus.renderer.enabled = false;
					maxSpheresMinus.renderer.enabled = false;
					moveSpeed.renderer.enabled = false;
					moveSpeedValue.renderer.enabled = false;
					moveSpeedPlus.renderer.enabled = false;
					moveSpeedMinus.renderer.enabled = false;
					maxSpheres.collider.enabled = false;
					maxSpheresPlus.collider.enabled = false;
					maxSpheresMinus.collider.enabled = false;
					moveSpeed.collider.enabled = false;
					moveSpeedPlus.collider.enabled = false;
					moveSpeedMinus.collider.enabled = false;
					optionsClose.renderer.enabled = false;
					optionsClose.collider.enabled = false;

					level1.renderer.enabled = false;
					level2.renderer.enabled = false;
					level3.renderer.enabled = false;
					level4.renderer.enabled = false;
					level5.renderer.enabled = false;
					level6.renderer.enabled = false;
					level7.renderer.enabled = false;
					level8.renderer.enabled = false;
					level1.collider.enabled = false;
					level2.collider.enabled = false;
					level3.collider.enabled = false;
					level4.collider.enabled = false;
					level5.collider.enabled = false;
					level6.collider.enabled = false;
					level7.collider.enabled = false;
					level8.collider.enabled = false;
					levelClose.renderer.enabled = false;
					levelClose.collider.enabled = false;

					aboutDetails.gameObject.SetActive(false);
					aboutClose.renderer.enabled = false;
					aboutClose.collider.enabled = false;
				}
			}

			if(hit.transform.name == "Level Select"){
				levelSelect.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					level1.renderer.enabled = !level1.renderer.enabled;
					level2.renderer.enabled = !level2.renderer.enabled;
					level3.renderer.enabled = !level3.renderer.enabled;
					level4.renderer.enabled = !level4.renderer.enabled;
					level5.renderer.enabled = !level5.renderer.enabled;
					level6.renderer.enabled = !level6.renderer.enabled;
					level7.renderer.enabled = !level7.renderer.enabled;
					level8.renderer.enabled = !level8.renderer.enabled;
					level1.collider.enabled = !level1.collider.enabled;
					level2.collider.enabled = !level2.collider.enabled;
					level3.collider.enabled = !level3.collider.enabled;
					level4.collider.enabled = !level4.collider.enabled;
					level5.collider.enabled = !level5.collider.enabled;
					level6.collider.enabled = !level6.collider.enabled;
					level7.collider.enabled = !level7.collider.enabled;
					level8.collider.enabled = !level8.collider.enabled;
					levelClose.renderer.enabled = !levelClose.renderer.enabled;
					levelClose.collider.enabled = true;
					
					maxSpheres.renderer.enabled = false;
					maxSpheresValue.renderer.enabled = false;
					maxSpheresPlus.renderer.enabled = false;
					maxSpheresMinus.renderer.enabled = false;
					moveSpeed.renderer.enabled = false;
					moveSpeedValue.renderer.enabled = false;
					moveSpeedPlus.renderer.enabled = false;
					moveSpeedMinus.renderer.enabled = false;
					maxSpheres.collider.enabled = false;
					maxSpheresPlus.collider.enabled = false;
					maxSpheresMinus.collider.enabled = false;
					moveSpeed.collider.enabled = false;
					moveSpeedPlus.collider.enabled = false;
					moveSpeedMinus.collider.enabled = false;
					optionsClose.renderer.enabled = false;
					optionsClose.collider.enabled = false;

					instructionsDetails.gameObject.SetActive(false);
					instructionsClose.renderer.enabled = false;
					instructionsClose.collider.enabled = false;

					aboutDetails.gameObject.SetActive(false);
					aboutClose.renderer.enabled = false;
					aboutClose.collider.enabled = false;
				}
			}
			if(hit.transform.name == "Options"){
				options.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					maxSpheres.renderer.enabled = !maxSpheres.renderer.enabled;
					maxSpheresValue.renderer.enabled = !maxSpheresValue.renderer.enabled;
					maxSpheresPlus.renderer.enabled = !maxSpheresPlus.renderer.enabled;
					maxSpheresMinus.renderer.enabled = !maxSpheresMinus.renderer.enabled;
					moveSpeed.renderer.enabled = !moveSpeed.renderer.enabled;
					moveSpeedValue.renderer.enabled = !moveSpeedValue.renderer.enabled;
					moveSpeedPlus.renderer.enabled = !moveSpeedPlus.renderer.enabled;
					moveSpeedMinus.renderer.enabled = !moveSpeedMinus.renderer.enabled;
					optionsClose.renderer.enabled = !optionsClose.renderer.enabled;
					maxSpheres.collider.enabled = !maxSpheres.collider.enabled;
					maxSpheresPlus.collider.enabled = !maxSpheresPlus.collider.enabled;
					maxSpheresMinus.collider.enabled = !maxSpheresMinus.collider.enabled;
					moveSpeed.collider.enabled = !moveSpeed.collider.enabled;
					moveSpeedPlus.collider.enabled = !moveSpeedPlus.collider.enabled;
					moveSpeedMinus.collider.enabled = !moveSpeedMinus.collider.enabled;
					optionsClose.collider.enabled = true;
					
					level1.renderer.enabled = false;
					level2.renderer.enabled = false;
					level3.renderer.enabled = false;
					level4.renderer.enabled = false;
					level5.renderer.enabled = false;
					level6.renderer.enabled = false;
					level7.renderer.enabled = false;
					level8.renderer.enabled = false;
					level1.collider.enabled = false;
					level2.collider.enabled = false;
					level3.collider.enabled = false;
					level4.collider.enabled = false;
					level5.collider.enabled = false;
					level6.collider.enabled = false;
					level7.collider.enabled = false;
					level8.collider.enabled = false;
					levelClose.renderer.enabled = false;
					levelClose.collider.enabled = false;

					instructionsDetails.gameObject.SetActive(false);
					instructionsClose.renderer.enabled = false;
					instructionsClose.collider.enabled = false;

					aboutDetails.gameObject.SetActive(false);
					aboutClose.renderer.enabled = false;
					aboutClose.collider.enabled = false;
				}
			}

			if(hit.transform.name == "About"){
				about.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					aboutDetails.gameObject.SetActive(!aboutDetails.gameObject.activeSelf);
					aboutClose.renderer.enabled = !aboutClose.renderer.enabled;
					aboutClose.collider.enabled = true;
					
					maxSpheres.renderer.enabled = false;
					maxSpheresValue.renderer.enabled = false;
					maxSpheresPlus.renderer.enabled = false;
					maxSpheresMinus.renderer.enabled = false;
					moveSpeed.renderer.enabled = false;
					moveSpeedValue.renderer.enabled = false;
					moveSpeedPlus.renderer.enabled = false;
					moveSpeedMinus.renderer.enabled = false;
					maxSpheres.collider.enabled = false;
					maxSpheresPlus.collider.enabled = false;
					maxSpheresMinus.collider.enabled = false;
					moveSpeed.collider.enabled = false;
					moveSpeedPlus.collider.enabled = false;
					moveSpeedMinus.collider.enabled = false;
					optionsClose.renderer.enabled = false;
					optionsClose.collider.enabled = false;
					
					level1.renderer.enabled = false;
					level2.renderer.enabled = false;
					level3.renderer.enabled = false;
					level4.renderer.enabled = false;
					level5.renderer.enabled = false;
					level6.renderer.enabled = false;
					level7.renderer.enabled = false;
					level8.renderer.enabled = false;
					level1.collider.enabled = false;
					level2.collider.enabled = false;
					level3.collider.enabled = false;
					level4.collider.enabled = false;
					level5.collider.enabled = false;
					level6.collider.enabled = false;
					level7.collider.enabled = false;
					level8.collider.enabled = false;
					levelClose.renderer.enabled = false;
					levelClose.collider.enabled = false;

					instructionsDetails.gameObject.SetActive(false);
					instructionsClose.renderer.enabled = false;
					instructionsClose.collider.enabled = false;
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
			if(hit.transform.name == "Move Speed"){
				moveSpeed.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					mSpeed = mSpeedDefault;
			}
			if(hit.transform.name == "Move Speed Plus"){
				moveSpeedPlus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0) && mSpeed < mSpeedMax)
					mSpeed++;
			}
			if(hit.transform.name == "Move Speed Minus"){
				moveSpeedMinus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0) && mSpeed > mSpeedMin)
					mSpeed--;
			}
			if(hit.transform.name == "Options Close"){
				optionsClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					maxSpheres.renderer.enabled = !maxSpheres.renderer.enabled;
					maxSpheresValue.renderer.enabled = !maxSpheresValue.renderer.enabled;
					maxSpheresPlus.renderer.enabled = !maxSpheresPlus.renderer.enabled;
					maxSpheresMinus.renderer.enabled = !maxSpheresMinus.renderer.enabled;
					moveSpeed.renderer.enabled = !moveSpeed.renderer.enabled;
					moveSpeedValue.renderer.enabled = !moveSpeedValue.renderer.enabled;
					moveSpeedPlus.renderer.enabled = !moveSpeedPlus.renderer.enabled;
					moveSpeedMinus.renderer.enabled = !moveSpeedMinus.renderer.enabled;
					maxSpheres.collider.enabled = false;
					maxSpheresPlus.collider.enabled = false;
					maxSpheresMinus.collider.enabled = false;
					moveSpeed.collider.enabled = false;
					moveSpeedPlus.collider.enabled = false;
					moveSpeedMinus.collider.enabled = false;
					optionsClose.renderer.enabled = !optionsClose.renderer.enabled;
					optionsClose.collider.enabled = false;
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
					level1.renderer.enabled = !level1.renderer.enabled;
					level2.renderer.enabled = !level2.renderer.enabled;
					level3.renderer.enabled = !level3.renderer.enabled;
					level4.renderer.enabled = !level4.renderer.enabled;
					level5.renderer.enabled = !level5.renderer.enabled;
					level6.renderer.enabled = !level6.renderer.enabled;
					level7.renderer.enabled = !level7.renderer.enabled;
					level8.renderer.enabled = !level8.renderer.enabled;
					level1.collider.enabled = false;
					level2.collider.enabled = false;
					level3.collider.enabled = false;
					level4.collider.enabled = false;
					level5.collider.enabled = false;
					level6.collider.enabled = false;
					level7.collider.enabled = false;
					level8.collider.enabled = false;
					levelClose.renderer.enabled = !levelClose.renderer.enabled;
					levelClose.collider.enabled = false;
				}
			}


			if(hit.transform.name == "Instructions Close"){
				instructionsClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					instructionsDetails.gameObject.SetActive(!instructionsDetails.gameObject.activeSelf);
					instructionsClose.renderer.enabled = !instructionsClose.renderer.enabled;
					instructionsClose.collider.enabled = false;
				}
			}


			if(hit.transform.name == "About Close"){
				aboutClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					aboutDetails.gameObject.SetActive(!aboutDetails.gameObject.activeSelf);
					aboutClose.renderer.enabled = !aboutClose.renderer.enabled;
					aboutClose.collider.enabled = false;
				}
			}
		}
		else
		{
			title.fontStyle = FontStyle.Bold;
			play.fontStyle = FontStyle.Normal;
			instructions.fontStyle = FontStyle.Normal;
			levelSelect.fontStyle = FontStyle.Normal;
			options.fontStyle = FontStyle.Normal;
			about.fontStyle = FontStyle.Normal;
			
			maxSpheres.fontStyle = FontStyle.Normal;
			maxSpheresPlus.fontStyle = FontStyle.Normal;
			maxSpheresMinus.fontStyle = FontStyle.Normal;
			moveSpeed.fontStyle = FontStyle.Normal;
			moveSpeedPlus.fontStyle = FontStyle.Normal;
			moveSpeedMinus.fontStyle = FontStyle.Normal;
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

			title.characterSize = charSize;	
		}
	}
}
