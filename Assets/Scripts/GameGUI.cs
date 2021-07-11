using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMarbles.V5
{
    public class GameGUI
    {
        string GUIPower = "";

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
            if (SceneManager.GetActiveScene().buildIndex < 8)
            {
                if (GUILayout.Button("Next Level (Space)") || Input.GetKeyDown(KeyCode.Space))
                    ButtonsActions.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                GUILayout.Box("Game finished, go back to main menu?");
                if (GUILayout.Button("Back to main menu. (Space)") || Input.GetKeyDown(KeyCode.Space))
                    ButtonsActions.LoadLevel(0);
            }
            //gameOver = false;
            GUILayout.EndArea();
        }

    }
}