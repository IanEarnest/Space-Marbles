using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
using System;
using SpaceMarbles.V5;

public class Menu : MonoBehaviour {
	public TextMesh title;
	public TextMesh play;
	public TextMesh levelSelect;
	public TextMesh options;
	public TextMesh quit;

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
	public TextMesh levelClose;

	public static int shootingMaxSpheres = 5;
	public static float shootingMoveSpeed = 1;
	int oMaxSpheres;
	float oMoveSpeed;

	float charSize;
	string MainMenuRedoneName = "MainMenuRedone";
	//string MainMenuName = "MainMenu";

	void Start () {
		//shootingMaxSpheres = shooting.maxSpheres;
		//shootingMoveSpeed = shooting.movespeed;
		//oMaxSpheres = shooting.maxSpheres;
		//oMoveSpeed = shooting.movespeed;
		charSize = title.characterSize;

	}

	Ray ray;
	RaycastHit hit;



	void Update () {
		maxSpheresValue.text = "" + shootingMaxSpheres;
		moveSpeedValue.text =  "" + shootingMoveSpeed;

		//shooting.maxSpheres = shootingMaxSpheres;
		//shooting.movespeed = shootingMoveSpeed;

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit)){

			if(hit.transform.name == "Title"){
				title.fontStyle = FontStyle.BoldAndItalic;

				if(Input.GetMouseButtonDown(0)){
					if(title.characterSize < charSize + 1)
						title.characterSize++;
				}
			}

			if(hit.transform.name == "Play"){
				play.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					SceneManager.LoadScene(LevelsEnum.levelsListNoSpace[0]);
			}
			if(hit.transform.name == "Level Select"){
				levelSelect.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					level1.GetComponent<Renderer>().enabled = !level1.GetComponent<Renderer>().enabled;
					level2.GetComponent<Renderer>().enabled = !level2.GetComponent<Renderer>().enabled;
					level3.GetComponent<Renderer>().enabled = !level3.GetComponent<Renderer>().enabled;
					level4.GetComponent<Renderer>().enabled = !level4.GetComponent<Renderer>().enabled;
					levelClose.GetComponent<Renderer>().enabled = !levelClose.GetComponent<Renderer>().enabled;

					maxSpheres.GetComponent<Renderer>().enabled = false;
					maxSpheresValue.GetComponent<Renderer>().enabled = false;
					maxSpheresPlus.GetComponent<Renderer>().enabled = false;
					maxSpheresMinus.GetComponent<Renderer>().enabled = false;
					moveSpeed.GetComponent<Renderer>().enabled = false;
					moveSpeedValue.GetComponent<Renderer>().enabled = false;
					moveSpeedPlus.GetComponent<Renderer>().enabled = false;
					moveSpeedMinus.GetComponent<Renderer>().enabled = false;
					optionsClose.GetComponent<Renderer>().enabled = false;
				}
			}
			if(hit.transform.name == "Options"){
				options.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					maxSpheres.GetComponent<Renderer>().enabled = !maxSpheres.GetComponent<Renderer>().enabled;
					maxSpheresValue.GetComponent<Renderer>().enabled = !maxSpheresValue.GetComponent<Renderer>().enabled;
					maxSpheresPlus.GetComponent<Renderer>().enabled = !maxSpheresPlus.GetComponent<Renderer>().enabled;
					maxSpheresMinus.GetComponent<Renderer>().enabled = !maxSpheresMinus.GetComponent<Renderer>().enabled;
					moveSpeed.GetComponent<Renderer>().enabled = !moveSpeed.GetComponent<Renderer>().enabled;
					moveSpeedValue.GetComponent<Renderer>().enabled = !moveSpeedValue.GetComponent<Renderer>().enabled;
					moveSpeedPlus.GetComponent<Renderer>().enabled = !moveSpeedPlus.GetComponent<Renderer>().enabled;
					moveSpeedMinus.GetComponent<Renderer>().enabled = !moveSpeedMinus.GetComponent<Renderer>().enabled;
					optionsClose.GetComponent<Renderer>().enabled = !optionsClose.GetComponent<Renderer>().enabled;

					level1.GetComponent<Renderer>().enabled = false;
					level2.GetComponent<Renderer>().enabled = false;
					level3.GetComponent<Renderer>().enabled = false;
					level4.GetComponent<Renderer>().enabled = false;
					levelClose.GetComponent<Renderer>().enabled = false;
				}
			}
			if(hit.transform.name == "Quit"){
				quit.fontStyle = FontStyle.Bold;
				if (Input.GetMouseButtonDown(0))
				{
					ButtonsActions.GM.SetActive(true); //GameObject.Find("GameManager").SetActive(true);
					SceneManager.LoadScene(MainMenuRedoneName);
				}
			}


			if (hit.transform.name == "Max Spheres"){
				maxSpheres.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					shootingMaxSpheres = oMaxSpheres;
			}
			if(hit.transform.name == "Max Spheres Plus"){
				maxSpheresPlus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					shootingMaxSpheres++;
			}
			if(hit.transform.name == "Max Spheres Minus"){
				maxSpheresMinus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					shootingMaxSpheres--;
			}
			if(hit.transform.name == "Move Speed"){
				moveSpeed.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					shootingMoveSpeed = oMoveSpeed;
			}
			if(hit.transform.name == "Move Speed Plus"){
				moveSpeedPlus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					shootingMoveSpeed++;
			}
			if(hit.transform.name == "Move Speed Minus"){
				moveSpeedMinus.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0))
					shootingMoveSpeed--;
			}
			if(hit.transform.name == "Options Close"){
				optionsClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					maxSpheres.GetComponent<Renderer>().enabled = !maxSpheres.GetComponent<Renderer>().enabled;
					maxSpheresValue.GetComponent<Renderer>().enabled = !maxSpheresValue.GetComponent<Renderer>().enabled;
					maxSpheresPlus.GetComponent<Renderer>().enabled = !maxSpheresPlus.GetComponent<Renderer>().enabled;
					maxSpheresMinus.GetComponent<Renderer>().enabled = !maxSpheresMinus.GetComponent<Renderer>().enabled;
					moveSpeed.GetComponent<Renderer>().enabled = !moveSpeed.GetComponent<Renderer>().enabled;
					moveSpeedValue.GetComponent<Renderer>().enabled = !moveSpeedValue.GetComponent<Renderer>().enabled;
					moveSpeedPlus.GetComponent<Renderer>().enabled = !moveSpeedPlus.GetComponent<Renderer>().enabled;
					moveSpeedMinus.GetComponent<Renderer>().enabled = !moveSpeedMinus.GetComponent<Renderer>().enabled;
					optionsClose.GetComponent<Renderer>().enabled = !optionsClose.GetComponent<Renderer>().enabled;
				}
			}

			List<TextMesh> levelTextMeshes = new List<TextMesh>();
			levelTextMeshes.Add(level1);
			levelTextMeshes.Add(level2);
			levelTextMeshes.Add(level3);
			levelTextMeshes.Add(level4);

            foreach (string level in LevelsEnum.levelsList)
            {
				if (hit.transform.name == level)
				{
					levelTextMeshes[LevelsEnum.levelsList.IndexOf(level)].fontStyle = FontStyle.Bold;
					if (Input.GetMouseButtonDown(0))
						SceneManager.LoadScene(LevelsEnum.RemoveWhitespace(level));
				}
			}

			//if (hit.transform.name == "Level 1"){
			//	level1.fontStyle = FontStyle.Bold;
			//	if(Input.GetMouseButtonDown(0))
			//		SceneManager.LoadScene(LevelsEnum.Level1);
			//}
			//if(hit.transform.name == "Level 2"){
			//	level2.fontStyle = FontStyle.Bold;
			//	if(Input.GetMouseButtonDown(0))
			//		SceneManager.LoadScene(2);
			//}
			//if(hit.transform.name == "Level 3"){
			//	level3.fontStyle = FontStyle.Bold;
			//	if(Input.GetMouseButtonDown(0))
			//		SceneManager.LoadScene(3);
			//}
			//if(hit.transform.name == "Level 4"){
			//	level4.fontStyle = FontStyle.Bold;
			//	if(Input.GetMouseButtonDown(0))
			//		SceneManager.LoadScene(4);
			//}
			if(hit.transform.name == "Level Select Close"){
				levelClose.fontStyle = FontStyle.Bold;
				if(Input.GetMouseButtonDown(0)){
					level1.GetComponent<Renderer>().enabled = !level1.GetComponent<Renderer>().enabled;
					level2.GetComponent<Renderer>().enabled = !level2.GetComponent<Renderer>().enabled;
					level3.GetComponent<Renderer>().enabled = !level3.GetComponent<Renderer>().enabled;
					level4.GetComponent<Renderer>().enabled = !level4.GetComponent<Renderer>().enabled;
					levelClose.GetComponent<Renderer>().enabled = !levelClose.GetComponent<Renderer>().enabled;
				}
			}
		}
		else
		{
			title.fontStyle = FontStyle.Bold;
			play.fontStyle = FontStyle.Normal;
			levelSelect.fontStyle = FontStyle.Normal;
			options.fontStyle = FontStyle.Normal;
			quit.fontStyle = FontStyle.Normal;

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
			levelClose.fontStyle = FontStyle.Normal;
			title.characterSize = charSize;
		}
	}
}

public static class LevelsEnum
{
	public const string
		Level1 = "Level 1",
		Level2 = "Level 2",
		Level3 = "Level 3",
		Level4 = "Level 4";

	public static List<string> levelsList = new List<string>();
	public static List<string> levelsListNoSpace = new List<string>();
    static LevelsEnum()
    {
		levelsList.Add(Level1);
		levelsList.Add(Level2);
		levelsList.Add(Level3);
		levelsList.Add(Level4);

		levelsListNoSpace.Add(RemoveWhitespace(Level1));
		levelsListNoSpace.Add(RemoveWhitespace(Level2));
		levelsListNoSpace.Add(RemoveWhitespace(Level3));
		levelsListNoSpace.Add(RemoveWhitespace(Level4));
    }
        //Level5 = "Level5",
        //Level6 = "Level6",
        //Level7 = "Level7",
        //Level8 = "Level8",
        //Level9 = "Level9",
        //Level10 = "Level10";

	public static string RemoveWhitespace(this string input)
	{
		return new string(input.ToCharArray()
			.Where(c => !Char.IsWhiteSpace(c))
			.ToArray());
	}
}