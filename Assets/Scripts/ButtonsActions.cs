using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMarbles.V5
{
    public class ButtonsActions :MonoBehaviour
    {
        //GameGUI myGameGUI = new GameGUI();
        public static string level1Name = "Level1Redone";
        public static string mainMenuName = "MainMenuRedone";
        public static string mainMenuClassicName = "MainMenu";

        #region LoadLevel
        public static void ReloadLevel()
        {
            LoadLevel();
        }
        public static void LoadLevel(string levelName)
        {
            LoadLevel(nullNum, levelName);
        }
        public static void LoadLevel(int levelNum)
        {
            LoadLevel(levelNum, null);
        }


        static int nullNum = 100; // same as levelNum default value
        static void LoadLevel(int levelNum = 100, string levelName = null)
        {
            // ERROR: stackoverflow exception
            try
            {
                string loadedFrom = "";
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
                    LoadLevel(SceneManager.GetActiveScene().buildIndex);
                    loadedFrom = "reload";
                }
                Debug.Log($"Level loaded from: {loadedFrom}"); //print
            }
            catch (System.Exception)
            {
                Debug.Log($"Failed to load level");
            }
        }


        public static void MainMenu()
        {
            LoadLevel(nullNum, mainMenuName);
        }
        public static void MainMenuClassic()
        {
            LoadLevel(nullNum, mainMenuClassicName);
        }

        public static void LoadLevel1()
        {
            LoadLevel(nullNum, level1Name);
        }
        #endregion

        public static void Quit()
        {
            Debug.Log("Quitting...");
            Application.Quit();
        }
    }
}