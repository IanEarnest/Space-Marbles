using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceMarbles.V5
{
    public class ButtonsActions :MonoBehaviour
    {
        //GameGUI myGameGUI = new GameGUI();
        public static string level1Name = "Level1Redone";
        public static string level2Name = "Level2Redone";
        public static string level3Name = "Level3Redone";
        public static string level4Name = "Level4Redone";
        public static string level5Name = "Level5Redone";
        public static string level6Name = "Level6Redone";
        public static string level7Name = "Level7Redone";
        public static string level8Name = "Level8Redone";
        public static string level9Name = "Level9Redone";
        public static string level10Name = "Level10Redone";
        public static string lastLevel = "Level10Redone";
        public static string mainMenuName = "MainMenuRedone";
        public static string mainMenuClassicName = "MainMenu";
        public static GameObject GM;

        #region LoadLevel
        public static void LoadLevel(string levelName)
        {
            LoadLevel(nullNum, levelName);
        }
        public static void LoadLevel(int levelNum)
        {
            LoadLevel(levelNum, null);
        }
        public static void RestartLevel()
        {
            LoadLevel();
        }
        public static void LoadNextLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex+1);
        }


        static int nullNum = 100; // same as levelNum default value
        static void LoadLevel(int levelNum = 100, string levelName = null)
        {
            // ERROR: stackoverflow exception
            try
            {
#pragma warning disable CS0219 // Variable is assigned but its value is never used
                string loadedFrom = "";
#pragma warning restore CS0219 // Variable is assigned but its value is never used
                if (levelNum != nullNum) // cannot set int to null as default
                {
                    SceneManager.LoadScene(levelNum);
                    loadedFrom = "levelNum";
                }
                else if (levelName != null)
                {
                    SceneManager.LoadScene(levelName);
                    loadedFrom = "levelName";
                }
                else
                {
                    // default reload level
                    LoadLevel(SceneManager.GetActiveScene().buildIndex);
                    loadedFrom = "reload";
                }
                //Debug.Log($"Level loaded from: {loadedFrom}"); //print
            }
            catch (System.Exception)
            {
                Debug.Log($"Failed to load level");
            }
        }


        public static void LoadLevelMainMenu()
        {
            LoadLevel(nullNum, mainMenuName);
        }
        public static void LoadLevelMainMenuClassic()
        {
            if (GM == null)
            {
                GM = GameObject.Find("GameManager");
            }
            GM.SetActive(false);
            //GameObject.Find("GameManager").SetActive(false);
            //GameObject GM = GameObject transform.Find("GameManager").gameObject;
            //GameObject.Find("GameManager").SetActive(true);
            LoadLevel(nullNum, mainMenuClassicName);
        }
        #endregion
        #region Load Levels 1-10
        public static void LoadLevel1()
        {
            LoadLevel(nullNum, level1Name);
        }
        public static void LoadLevel2()
        {
            LoadLevel(nullNum, level2Name);
        }
        public static void LoadLevel3()
        {
            LoadLevel(nullNum, level3Name);
        }
        public static void LoadLevel4()
        {
            LoadLevel(nullNum, level4Name);
        }
        public static void LoadLevel5()
        {
            LoadLevel(nullNum, level5Name);
        }
        public static void LoadLevel6()
        {
            LoadLevel(nullNum, level6Name);
        }
        public static void LoadLevel7()
        {
            LoadLevel(nullNum, level7Name);
        }
        public static void LoadLevel8()
        {
            LoadLevel(nullNum, level8Name);
        }
        public static void LoadLevel9()
        {
            LoadLevel(nullNum, level9Name);
        }
        public static void LoadLevel10()
        {
            LoadLevel(nullNum, level10Name);
        }
        #endregion


        public static void ChangeCamera()
        {
            // Change cameras - Right click to invert to other camera.
            GameManager.cameraMain.GetComponent<Camera>().enabled = !GameManager.cameraMain.GetComponent<Camera>().enabled;
            GameManager.cameraWide.GetComponent<Camera>().enabled = !GameManager.cameraWide.GetComponent<Camera>().enabled;
            // Change camera ray for clicking?
            //ray = cameraMain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        }

        public static int scrolled = 0;
        public static int scrollLimit = 3;
        public static int scrollMultiplier = 3;
        public static float scrollWheel;
        public static void ScrollWheelZoom()
        {
            scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if (scrollWheel < 0)
            {
                ZoomMinus();
            }
            if (scrollWheel > 0)
            {
                ZoomPlus();
            }
        }
        public static void ZoomMinus()
        {
            // Mouse scroll backwards - Move camera back.
            if (scrolled > ~scrollLimit) // ~ means reverse.
            {
                GameManager.cameraMain.transform.Translate(Vector3.back * scrollMultiplier);
                scrolled--;
            }
        }
        public static void ZoomPlus()
        {
            // Mouse scroll forwards - Move camera forward.
            if (scrolled < scrollLimit)
            {
                GameManager.cameraMain.transform.Translate(Vector3.forward * scrollMultiplier);
                scrolled++;
            }
        }
        public static void BuyLevel()
        {
            print("bought level");
        }
        public static void Exit()
        {
            Debug.Log("Quitting...");
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // original code to quit Unity player
#endif

        }
    }
}