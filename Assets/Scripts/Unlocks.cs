using UnityEngine;
using System.Collections;
using System.IO;

public class Unlocks : MonoBehaviour {

	public static float coins = 0;

	public static bool level2Lock = true;
	public static bool level3Lock = true;
	public static bool level4Lock = true;
	public static bool level5Lock = true;
	public static bool level6Lock = true;
	public static bool level7Lock = true;
	public static bool level8Lock = true;

	public static int nextUnlock = 2;

	void Start(){
		coins = PlayerPrefs.GetFloat ("coins");
	}

	void Update(){
		if(PlayerPrefs.GetFloat("coins") != coins){
			PlayerPrefs.SetFloat ("coins", coins);
		}
		PlayerPrefs.Save ();
	}
}
