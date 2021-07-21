using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMarbles.V5
{
    public static class Canvas
    {
        public static GameObject canvas;
    }
    public class GameManager :MonoBehaviour
    {
        static GameObject canvas;
        GameGUI myGameGUI;
        GameObject myCapsule;
        public static bool levelOver = false;
#pragma warning disable CS0414 // Variable is assigned but its value is never used
        public static bool gameOver = false;
#pragma warning restore CS0414 // Variable is assigned but its value is never used
        public static GameObject cameraMain;
        public static GameObject cameraWide;
        public const string cameraTag = "MainCamera";
        public const string cameraMainName = "Main Camera";
        public const string cameraWideName = "Wide Camera";
        public static List<GameObject> targetsList = new List<GameObject>();
        public static List<GameObject> targetsHitList = new List<GameObject>();
        public static List<float> targetsStartsList = new List<float>(); // only checking the x coordinate
        public const string targetSphereTag = "TargetSphere";
        public static string currentLevel = "";
        public static int coins = 0;
        public static bool isMenuScene = true;
        public static bool hasMenuLoadedBefore = false;

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
                //Debug.Log("Warning: multiple " + this + " in scene!");
                Destroy(gameObject); //this.enabled = false;
            }
            DontDestroyOnLoad(this);
            //if (!GameObject.Find("Canvas") && canvas != null)
            //{
            //    Instantiate(canvas);
            //    print("canvas created");
            //}
            //if (canvas != null)
            //{
            //    print(canvas.name);
            //}
            //if (canvas == null)
            //{
            //    //print("canvas not set");
            //}
            LevelLoad();
        }
        void LevelLoad()
        {
            IsMenuSceneCheck();
            currentLevel = SceneManager.GetActiveScene().name;
            //print($"loaded...!{currentLevel}/ {SceneManager.GetActiveScene().name}");

            levelOver = false;
            gameOver = false;
            myGameGUI = GameObject.Find("GameManager").GetComponent<GameGUI>();
            if (!isMenuScene) //(currentLevel != ButtonsActions.mainMenuName)
            {
                //myCapsule = GameObject.Find("Capsule");
                FindCameras(); // TODO: this not running? error in buttons on game zooming
                ListTargetSpheres();
                //print("scene = not main menu");
                //print("level reset!");
            }
            GunScript.shotPower = 0;
        }
        void Start()
        {
            //canvas = GameObject.Find("Canvas");
            //if (canvas != null)
            //{
            //    //print(canvas.name + " set");
            //}
        }
        void FindCameras()
        {
            foreach (GameObject camera in GameObject.FindGameObjectsWithTag(cameraTag))
            {
                if (camera.name == cameraMainName)
                {
                    cameraMain = camera;
                }
                else if (camera.name == cameraWideName)
                {
                    cameraWide = camera;
                }
            }
        }
        private void ListTargetSpheres()
        {
            targetsList.Clear();
            targetsHitList.Clear();
            targetsStartsList.Clear();
            int count = 0;
            foreach (GameObject targetSphere in GameObject.FindGameObjectsWithTag(targetSphereTag))
            {
                count++;
                targetsList.Add(targetSphere);
                targetsHitList.Add(targetSphere);
                targetsStartsList.Add(targetSphere.transform.position.x);
            }
            if (count == 0)
            {
                LevelOver();
            }
        }

        public static int frame = 0;
        public static int frameCheck = 50; // 50 calls per second normally
        public static bool minimumFramesRun = false;
        public static void FrameReset()
        {
            if (frame > frameCheck)
            {
                minimumFramesRun = true;
                IsMenuSceneCheck();
                print("Min frames run");
                frame = 0;
            }
            frame++;
        }

        private void FixedUpdate()
        {
            // when only level is over
            if (levelOver && gameOver == false)
            {
                myGameGUI.LevelOver();
            }
            // when last level is over (level and game)
            if (levelOver && gameOver)
            {
                myGameGUI.GameOver();
            }
            if (currentLevel != SceneManager.GetActiveScene().name)
            {
                LevelLoad();
            }
            if (!levelOver && !isMenuScene)//SceneManager.GetActiveScene().name != ButtonsActions.mainMenuName)
            {
                if (targetsList.Count == 0)
                {
                    ListTargetSpheres(); // and check level end
                    //FindCameras();
                }
                if (targetsList.Count != 0)
                {
                    CheckTargetSpheresMoved();
                }
                //if (myCapsule != null)
                //{
                //    myCapsule.transform.Rotate(new Vector3(0, 0, capsuleRotateSpeed)); // Rotate capsule.
                //}
            }

            FrameReset();
        }
        private void CheckTargetSpheresMoved()
        {
            //error
            if (targetsList != null && targetsList[0] == null)
            {
                ListTargetSpheres();
                //print("list regen");
            }
            foreach (GameObject targetSphere in targetsList)
            {
                try
                {
                    if (targetsHitList.Count == 0)
                    {
                        //print("No targets left to hit");
                        LevelOver();
                        return;
                    }
                    if (targetSphere.transform.position.x != targetsStartsList[targetsList.IndexOf(targetSphere)])
                    {

                        targetsHitList.Remove(targetSphere);
                        Destroy(targetSphere, 2f);
                    }
                }
                catch (System.Exception)
                {
                    print("Failed to remove hit target");
                }
            }
        }

        void LevelOver()
        {
            // Level Over
            //if (GameObject.FindGameObjectsWithTag("Finish").Length == 0)
            //gameOver = true;
            levelOver = true;
            print("LevelOver");
            if (SceneManager.GetActiveScene().name == ButtonsActions.lastLevel)
            {
                gameOver = true;
                print("GameOver");
            }
        }
        //foreach target on level
        //if (targetSphere.transform.position.x != targetOrigin)
        //            {
        //                Destroy(targetSphere.gameObject, 2f);
        //hitChecker = "Hit";
        //            }
        public static void MaxSpheresPlus()
        {
            if (GunScript.maxSpheres < GunScript.maxSpheresMaximum)
            {
                GunScript.maxSpheres++;
            }
        }
        public static void MaxSpheresMinus()
        {
            if (GunScript.maxSpheres > GunScript.maxSpheresMinimum)
            {
                GunScript.maxSpheres--;
            }
        }

        public static void IsMenuSceneCheck()
        {
            if (minimumFramesRun)
            {
                isMenuScene = SceneManager.GetActiveScene().name == ButtonsActions.mainMenuName;
            }
        }
    }
}