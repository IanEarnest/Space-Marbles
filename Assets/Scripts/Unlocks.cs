using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceMarbles.V5
{
    public class Unlocks :MonoBehaviour
    {
		public static float coins = 0;

		public static bool level1Lock = false;
		public static bool level2Lock = true;
		public static bool level3Lock = true;
		public static bool level4Lock = true;
		public static bool level5Lock = true;
		public static bool level6Lock = true;
		public static bool level7Lock = true;
		public static bool level8Lock = true;
		public static bool level9Lock = true;
		public static bool level10Lock = true;
		public static List<string> levelLocksList = new	List<string>();
        public static Dictionary<string, bool> levelLockNameAndBool = new Dictionary<string, bool>();

		public static int nextUnlock = 2;
		public static float unlockCost = 30;
		public static float hintsUnlockCost = 100; //1000?
		public static bool hintsUnlockBought;
		public static bool allLevelsBought;

		void Start()
		{
			GameManager.coins = PlayerPrefs.GetFloat("coins");
            levelLocksList.Add(nameof(level1Lock));
            levelLocksList.Add(nameof(level2Lock));
            levelLocksList.Add(nameof(level3Lock));
            levelLocksList.Add(nameof(level4Lock));
            levelLocksList.Add(nameof(level5Lock));
            levelLocksList.Add(nameof(level6Lock));
            levelLocksList.Add(nameof(level7Lock));
            levelLocksList.Add(nameof(level8Lock));
            levelLocksList.Add(nameof(level9Lock));
            levelLocksList.Add(nameof(level10Lock));


            levelLockNameAndBool.Add(nameof(level1Lock), level1Lock);
			levelLockNameAndBool.Add(nameof(level2Lock), level2Lock);
			levelLockNameAndBool.Add(nameof(level3Lock), level3Lock);
			levelLockNameAndBool.Add(nameof(level4Lock), level4Lock);
			levelLockNameAndBool.Add(nameof(level5Lock), level5Lock);
			levelLockNameAndBool.Add(nameof(level6Lock), level6Lock);
			levelLockNameAndBool.Add(nameof(level7Lock), level7Lock);
			levelLockNameAndBool.Add(nameof(level8Lock), level8Lock);
			levelLockNameAndBool.Add(nameof(level9Lock), level9Lock);
			levelLockNameAndBool.Add(nameof(level10Lock), level10Lock);
		}

		void Update()
		{
			coins = GameManager.coins;
			if (PlayerPrefs.GetFloat("coins") != coins)
			{
				PlayerPrefs.SetFloat("coins", coins);
			}
			PlayerPrefs.Save();
            if (level10Lock == false) //TODO: simplify
            {
				allLevelsBought = true;
            }
			//UpdateLocks();
        }
		//void UpdateLocks()
		//{
		//	level1Lock = levelLockNameAndBool[nameof(level1Lock)];
		//	level2Lock = levelLockNameAndBool[nameof(level2Lock)];
		//	level3Lock = levelLockNameAndBool[nameof(level3Lock)];
		//	level4Lock = levelLockNameAndBool[nameof(level4Lock)];
		//	level5Lock = levelLockNameAndBool[nameof(level5Lock)];
		//	level6Lock = levelLockNameAndBool[nameof(level6Lock)];
		//	level7Lock = levelLockNameAndBool[nameof(level7Lock)];
		//	level8Lock = levelLockNameAndBool[nameof(level8Lock)];
		//	level9Lock = levelLockNameAndBool[nameof(level9Lock)];
		//	level10Lock = levelLockNameAndBool[nameof(level10Lock)];
		//}

		public static void CheckUnlocks()
        {
            if (nextUnlock == 3)    level2Lock = false;
            if (nextUnlock == 4)    level3Lock = false;
            if (nextUnlock == 5)    level4Lock = false;
            if (nextUnlock == 6)    level5Lock = false;
            if (nextUnlock == 7)    level6Lock = false;
            if (nextUnlock == 8)    level7Lock = false;
            if (nextUnlock == 9)    level8Lock = false;
            if (nextUnlock == 10)   level9Lock = false;
            if (nextUnlock == 11)	level10Lock = false;
        }
		public static void SetButtonsToLocks(List<Button> buttons)
		{
            //        foreach (Button button in buttons)
            //        {
            //button
   //         //        }
   //         for (int i = 1; i < buttons.Count; i++)
   //         {
			//	buttons[i].interactable = !levelLocksList[i];
   //         }
			buttons[0].interactable = !Unlocks.level1Lock;
			buttons[1].interactable = !Unlocks.level2Lock;
			buttons[2].interactable = !Unlocks.level3Lock;
			buttons[3].interactable = !Unlocks.level4Lock;
			buttons[4].interactable = !Unlocks.level5Lock;
			buttons[5].interactable = !Unlocks.level6Lock;
			buttons[6].interactable = !Unlocks.level7Lock;
			buttons[7].interactable = !Unlocks.level8Lock;
			buttons[8].interactable = !Unlocks.level9Lock;
			buttons[9].interactable = !Unlocks.level10Lock;
        }
		// press unlock, if >= coins 20, if next unlock = ... if true -20 coins, lock = false

	}
}