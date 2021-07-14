using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceMarbles.V5
{
    public class GameGUI :MonoBehaviour
    {
        //GunScript myGunScript;
        string GUIPower = "";
        TextMeshProUGUI Level;
        TextMeshProUGUI Power;
        TextMeshProUGUI Spheres;
        TextMeshProUGUI Targets;
        Button PlayBtn;
        string LevelText = "";
        string PowerText = "Power: ";
        string SpheresText = "Spheres: ";
        string TargetsText = "Targets: ";
        bool isMenuScene;

        void Awake()
        {
            //myGunScript = GameObject.Find("GameManager").GetComponent<GunScript>();
            if (isMenuScene)
            {
                GUITryAssign();
            }
            else if (!isMenuScene)
            {
                PlayBtn = GameObject.Find("PlayBtn").GetComponent<Button>();
                PlayBtn.Select();
            }
        }
        void GUITryAssign()
        {
            try
            {
                Level = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
                Power = GameObject.Find("Power").GetComponent<TextMeshProUGUI>();
                Spheres = GameObject.Find("Spheres").GetComponent<TextMeshProUGUI>();
                Targets = GameObject.Find("Targets").GetComponent<TextMeshProUGUI>();
            }
            catch (System.Exception e)
            {
                //print(e.Message);
            }
        }
        int frame = 0;
        int frameCheck = 60;
        private void Update()
        {
            if (frame > frameCheck)
            {
                isMenuScene = SceneManager.GetActiveScene().name == ButtonsActions.mainMenuName;
                //print($"Main Scene? {isMenuScene}");
            }

            if (Power == null && frame > frameCheck)
            {
                GUITryAssign();
            }
            else if (Power != null)
            {
                Level.text = $"{LevelText}{GameManager.currentLevel}";
                Power.text = $"{PowerText}{GunScript.shotPower}";
                Spheres.text = $"{SpheresText}{GunScript.activeSpheres}/{GunScript.maxSpheres}";
                Targets.text = $"{TargetsText}{GameManager.targetsHitList.Count}/{GameManager.targetsList.Count}";
            }


            if (frame > frameCheck)
            {
                frame = 0;
            }
            frame++;
        }

        public void LevelButtons()
        {
            GUILayout.BeginArea(new Rect(0, Screen.height - 60, Screen.width, 60));

            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Box(GUIPower);
            GUILayout.EndVertical();

            if (GUILayout.Button("Restart (R)"))
                ButtonsActions.ReloadLevel();//Application.GameManager.LoadLevel(Application.loadedLevel);
            GUILayout.BeginVertical();
            // Level selecters.
            if (GUILayout.Button("Level 1 (1)"))
                ButtonsActions.LoadLevel(1);//Application.GameManager.LoadLevel(1);
            if (GUILayout.Button("Level 2 (2)"))
                ButtonsActions.LoadLevel(2);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("Level 3 (3)"))
                ButtonsActions.LoadLevel(3);
            if (GUILayout.Button("Level 4 (4)"))
                ButtonsActions.LoadLevel(4);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("Level 5 (5)"))
                ButtonsActions.LoadLevel(5);
            if (GUILayout.Button("Level 6 (6)"))
                ButtonsActions.LoadLevel(6);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("Level 7 (7)"))
                ButtonsActions.LoadLevel(7);
            if (GUILayout.Button("Level 8 (8)"))
                ButtonsActions.LoadLevel(8);
            GUILayout.EndVertical();

            // Quit button.
            if (GUILayout.Button("Menu(ESC)"))
                ButtonsActions.LoadLevel(0);
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        public void GameOver()
        {
            // Game over.
            GUILayout.BeginArea(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 50, 250, 100));

            GUILayout.Box("Congratulations, you completed level " + SceneManager.GetActiveScene().buildIndex + "!");
            if (SceneManager.GetActiveScene().name != ButtonsActions.lastLevel)
            {
                if (GUILayout.Button("Next Level (Space)") || Input.GetKeyDown(KeyCode.Space))
                    ButtonsActions.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                GUILayout.Box("Game finished, go back to main menu?");
                if (GUILayout.Button("Back to main menu. (Space)") || Input.GetKeyDown(KeyCode.Space))
                    ButtonsActions.LoadLevel(ButtonsActions.mainMenuName);
            }
            //gameOver = false;
            GUILayout.EndArea();
        }

    }
}