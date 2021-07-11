using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMarbles.V5
{
    public class GameManager :MonoBehaviour
    {
        GameGUI myGameGUI = new GameGUI();
        bool gameOver = false;

        public static GameManager Instance
        {
            get; private set;
        }
        // currently there are multiple when changing scenes
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.Log("Warning: multiple " + this + " in scene!");
                Destroy(gameObject); //this.enabled = false;
            }
            DontDestroyOnLoad(this);
        }

        // Graphical User Interface
        void OnGUI()
        {
            //myGameGUI.LevelButtons();
            //if (gameOver == true)
            //{
            //    myGameGUI.GameOver();
            //}
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver = !gameOver;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ButtonsActions.MainMenu();
            }
        }

    }
}