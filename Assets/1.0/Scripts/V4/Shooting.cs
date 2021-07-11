using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// version 1.4
namespace SpaceMarbles.V4 {
    public class Shooting :MonoBehaviour
    {
        // Transforms to manipulate objects.
        public Transform gun; // Gun.
        public Transform sphere; // Sphere.
        Transform clone; // Clone of sphere.
        public Transform targetSphere; // Target spheres.
        public Transform wallLeft;  // Left wall of level.
        public Transform wallRight; // Right wall of level.
        public Transform wallTop; // Top wall of level.
        public Transform wallDown; // Down wall of level.
        public Transform capsule; // Shows mouse location.
        public Transform cameraMain; // Main camera.
        public Transform cameraWide; // Alternate camera.
        //public LineRenderer line; // .

        int frames = 0; // Count for each Update() frame ran.
        float movespeed; // Move speed of gun.
        Vector3 gunRotation; // Gun rotation towards mouse.

        int shotPowerStart = 10; // How much power the shot starts with.
        int shotPower = 10; // Force used to shoot Sphere.
        int shotPowerPlus = 1; // How fast shot power increaces.
        int shotPowerLimit = 100; // Max shot power.

        int spheres = 0; // Count for Sphere clones.
        int maxSpheres; // Max spheres that can be created.

        int targetSpheres = 0; // Count for target Spheres.
        float targetOrigin = 0; // Origin for target Sphere.
        string hitChecker = "Nothing"; // Hit check for target Spheres.

        int scrollLimit = 2; // Max scroll limit.
        int scrolled = 0; // Count for scroll.

        // Interface
        string GUIPower; // Displays shot power.
        string GUITime; // //Displays frames played so far.

        // Mouse Position
        Ray ray;
        RaycastHit hit;

        bool gameOver = false;

        Transform targetSphere2;
        Transform targetSphere3;
        float targetOrigin2;
        float targetOrigin3;
        void Start()
        {
            FindAllGameObjects();
            maxSpheres = Menu.startSpheres;
            movespeed = Menu.startSpeed;

            if (GameObject.FindGameObjectsWithTag("Finish").Length > 0)
                targetSphere = GameObject.FindGameObjectsWithTag("Finish")[0].transform;
            if (GameObject.FindGameObjectsWithTag("Finish").Length > 1)
                targetSphere2 = GameObject.FindGameObjectsWithTag("Finish")[1].transform;
            if (GameObject.FindGameObjectsWithTag("Finish").Length > 2)
                targetSphere3 = GameObject.FindGameObjectsWithTag("Finish")[2].transform;
        }

        void FindAllGameObjects()
        {
            gun = GameObject.Find("Gun").transform;
            //sphere = GameObject.Find("Gun").transform; // Sphere.
            targetSphere = GameObject.Find("TargetSphere").transform; // Target spheres.
            wallLeft = GameObject.Find("WallLeft").transform;  // Left wall of level.
            wallRight = GameObject.Find("WallRight").transform; // Right wall of level.
            wallTop = GameObject.Find("WallTop").transform; // Top wall of level.
            wallDown = GameObject.Find("WallDown").transform; // Down wall of level.
            capsule = GameObject.Find("Capsule").transform; // Shows mouse location.
            cameraMain = GameObject.Find("Main Camera").transform; // Main camera.
            cameraWide = GameObject.Find("CameraWide").transform; // Alternate camera.
        }

        // copied from the web
        float originalWidth = 400.0f;  // define here the original resolution 640
        float originalHeight = 400.0f; // you used to create the GUI contents 400
        private Vector3 scale;
        // Graphical User Interface
        void OnGUI()
        {
            originalWidth = 300;
            originalHeight = 400;
            scale.x = Screen.width / originalWidth; // calculate hor scale
            scale.y = Screen.height / originalHeight; // calculate vert scale
            scale.z = 1;
            var svMat = GUI.matrix; // save current matrix
                                    // substitute matrix - only scale is altered from standard
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
            // draw your GUI controls here:
            //...


            //GUI.Label(new Rect(0,Screen.height-60,100,60), GUIPower);
            // Box displaying shot power at top left of screen.

            /*
		    GUI.Box(new Rect(0,Screen.height-60,100,60), GUIPower);
		    //Box displaying total frames and time at top right of screen.
		    //GUI.Box(new Rect (Screen.width - 100,0,100,50), GUITime);



		    // Restart button.
		    if (GUI.Button (new Rect (100,Screen.height-50,100,50), "Restart (R)"))
			    SceneManager.LoadScene(Application.loadedLevel);

		    // Level selecters.
		    if (GUI.Button (new Rect (210,Screen.height-50,80,25), "Level 1 (1)"))
			    SceneManager.LoadScene(1);

		    if (GUI.Button (new Rect (210,Screen.height-25,80,25), "Level 2 (2)"))
			    SceneManager.LoadScene(2);

		    if (GUI.Button (new Rect (290,Screen.height-50,80,25), "Level 3 (3)"))
			    SceneManager.LoadScene(3);

		    if (GUI.Button (new Rect (290,Screen.height-25,80,25), "Level 4 (4)"))
			    SceneManager.LoadScene(4);

		    // Quit button.
		    if (GUI.Button (new Rect (380,Screen.height-50,100,50), "Menu(ESC)"))
			    SceneManager.LoadScene(0);
    */

            GUILayout.BeginArea(new Rect(0, 0, 100, 600));
            GUILayout.BeginVertical();
            GUILayout.Box(GUIPower);
            GUILayout.Box(Unlocks.coins + " Coins");
            GUILayout.EndArea();

            GUILayout.BeginArea(new Rect(0, 325, 90, 80));
            // Quit button.
            if (GUILayout.Button("Menu"))
                SceneManager.LoadScene(0);

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Zoom"))
            {
                cameraMain.GetComponent<Camera>().enabled = !cameraMain.GetComponent<Camera>().enabled;
                cameraWide.GetComponent<Camera>().enabled = !cameraWide.GetComponent<Camera>().enabled;
            }
            if (scrolled < scrollLimit)
            { // can move into button to keep zoom buttons visible
                if (GUILayout.Button("+"))
                {
                    // Move camera forward.
                    cameraMain.Translate(Vector3.forward * 5);
                    scrolled++;
                }
            }
            if (scrolled > ~scrollLimit)
            {
                if (GUILayout.Button("-"))
                {
                    cameraMain.Translate(Vector3.back * 5);
                    scrolled--;
                }
            }
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Restart"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GUILayout.EndArea();



            GUILayout.BeginArea(new Rect(100, 294, 190, 100));
            GUILayout.Box("Levels");
            // Level selecters.
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            if (GUILayout.Button("Level 1"))
                SceneManager.LoadScene(1);

            if (Unlocks.level2Lock == false)
                if (GUILayout.Button("Level 2"))
                    SceneManager.LoadScene(2);

            if (Unlocks.level3Lock == false)
                if (GUILayout.Button("Level 3"))
                    SceneManager.LoadScene(3);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (Unlocks.level4Lock == false)
                if (GUILayout.Button("Level 4"))
                    SceneManager.LoadScene(4);
            if (Unlocks.level5Lock == false)
                if (GUILayout.Button("Level 5"))
                    SceneManager.LoadScene(5);
            if (Unlocks.level6Lock == false)
                if (GUILayout.Button("Level 6"))
                    SceneManager.LoadScene(6);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (Unlocks.level7Lock == false)
                if (GUILayout.Button("Level 7"))
                    SceneManager.LoadScene(7);
            if (Unlocks.level8Lock == false)
                if (GUILayout.Button("Level 8"))
                    SceneManager.LoadScene(8);


            if (GUILayout.Button("Unlock -20"))
            {
                if (Unlocks.coins >= 20)
                {
                    if (Unlocks.nextUnlock == 8)
                        if (Unlocks.level8Lock == true)
                        {
                            Unlocks.coins -= 20;
                            Unlocks.level8Lock = false;
                        }
                    if (Unlocks.nextUnlock == 7)
                        if (Unlocks.level7Lock == true)
                        {
                            Unlocks.coins -= 20;
                            Unlocks.level7Lock = false;
                            Unlocks.nextUnlock = 8;
                        }
                    if (Unlocks.nextUnlock == 6)
                        if (Unlocks.level6Lock == true)
                        {
                            Unlocks.coins -= 20;
                            Unlocks.level6Lock = false;
                            Unlocks.nextUnlock = 7;
                        }
                    GUILayout.EndHorizontal();
                    if (Unlocks.nextUnlock == 5)
                        if (Unlocks.level5Lock == true)
                        {
                            Unlocks.coins -= 20;
                            Unlocks.level5Lock = false;
                            Unlocks.nextUnlock = 6;
                        }
                    if (Unlocks.nextUnlock == 4)
                        if (Unlocks.level4Lock == true)
                        {
                            Unlocks.coins -= 20;
                            Unlocks.level4Lock = false;
                            Unlocks.nextUnlock = 5;
                        }
                    if (Unlocks.nextUnlock == 3)
                        if (Unlocks.level3Lock == true)
                        {
                            Unlocks.coins -= 20;
                            Unlocks.level3Lock = false;
                            Unlocks.nextUnlock = 4;
                        }
                    if (Unlocks.nextUnlock == 2)
                        if (Unlocks.level2Lock == true)
                        {
                            Unlocks.coins -= 20;
                            Unlocks.level2Lock = false;
                            Unlocks.nextUnlock = 3;
                        }
                }
            }
            GUILayout.EndVertical();

            GUILayout.EndVertical();
            GUILayout.EndArea();


            // Game over.
            GUILayout.BeginArea(new Rect(90, 100, 150, 150));
            if (gameOver == true)
            {

                // Level progression
                if (Unlocks.level2Lock == true)
                    if (SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        Unlocks.level2Lock = false;
                        Unlocks.coins += 2;
                        Unlocks.nextUnlock = 3;
                    }
                if (Unlocks.level3Lock == true)
                    if (SceneManager.GetActiveScene().buildIndex == 2)
                    {
                        Unlocks.level3Lock = false;
                        Unlocks.coins += 5;
                        Unlocks.nextUnlock = 4;
                    }
                if (Unlocks.level4Lock == true)
                    if (SceneManager.GetActiveScene().buildIndex == 3)
                    {
                        Unlocks.level4Lock = false;
                        Unlocks.coins += 10;
                        Unlocks.nextUnlock = 5;
                    }
                if (Unlocks.level5Lock == true)
                    if (SceneManager.GetActiveScene().buildIndex == 4)
                    {
                        Unlocks.level5Lock = false;
                        Unlocks.coins += 20;
                        Unlocks.nextUnlock = 6;
                    }
                if (Unlocks.level6Lock == true)
                    if (SceneManager.GetActiveScene().buildIndex == 5)
                    {
                        Unlocks.level6Lock = false;
                        Unlocks.coins += 35;
                        Unlocks.nextUnlock = 7;
                    }
                if (Unlocks.level7Lock == true)
                    if (SceneManager.GetActiveScene().buildIndex == 6)
                    {
                        Unlocks.level7Lock = false;
                        Unlocks.coins += 50;
                        Unlocks.nextUnlock = 8;
                    }
                if (Unlocks.level8Lock == true)
                    if (SceneManager.GetActiveScene().buildIndex == 7)
                    {
                        Unlocks.level8Lock = false;
                        Unlocks.coins += 70;
                    }

                GUILayout.Box("Congratulations!" + "\n" + "You completed level " + SceneManager.GetActiveScene().buildIndex + "!");
                if (SceneManager.GetActiveScene().buildIndex < 8)
                {
                    if (GUILayout.Button("Next Level") || Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    GUILayout.Box("Game finished!" + "\n" + "Thank you for playing!" + "\n" + "Go back to main menu?");
                    if (GUILayout.Button("Back to main menu.") || Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene(0);
                }
                //gameOver = false;
            }
            GUILayout.EndArea();

            // restore matrix before returning
            GUI.matrix = svMat; // restore matrix
        }

        void Update()
        {
            //Debug.DrawLine(transform.position, hit.point);

            //line.SetPosition(0, transform.position);
            //line.SetPosition(1, hit.point);

            if (PlayerPrefs.GetFloat("coins") != Unlocks.coins)
            {
                PlayerPrefs.SetFloat("coins", Unlocks.coins);
            }
            PlayerPrefs.Save();

            // Set ray to mouse position.
            if (cameraMain.GetComponent<Camera>().enabled == true)
            {
                ray = cameraMain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                ray = cameraWide.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            }




            // Controls
            // W, A, S, D to move Gun left, right, up, down.
            // Left click to shoot, right click to switch camera.
            // 1, 2, 3, 4 for each level.
            // R to restart current level.
            // Escape to go back to main menu.

            // Menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }

            // Movement for gun.
            // Press W to go up.

            if (Input.GetKey("w"))
                GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x
                                                  , GetComponent<Rigidbody>().position.y + movespeed / 5
                                                  , GetComponent<Rigidbody>().position.z));
            // Press A to go Left.
            if (Input.GetKey("a"))
                GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x - movespeed / 5
                                                  , GetComponent<Rigidbody>().position.y
                                                  , GetComponent<Rigidbody>().position.z));
            // Press S to go Down.
            if (Input.GetKey("s"))
                GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x
                                                  , GetComponent<Rigidbody>().position.y - movespeed / 5
                                                  , GetComponent<Rigidbody>().position.z));
            // Press D to go Right.
            if (Input.GetKey("d"))
                GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x + movespeed / 5
                                                  , GetComponent<Rigidbody>().position.y
                                                  , GetComponent<Rigidbody>().position.z));



            // Limit Spheres created.
            if (spheres < maxSpheres)
            {
                // Increase shot power.
                // Check if left mouse button if pressed.
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    // Check if shot power is under limit.
                    if (shotPower < shotPowerLimit)
                        // Increase shot power.
                        shotPower += shotPowerPlus;
                    // Display shot power
                    GUIPower = "Power: " + shotPower;
                }

                // Launch Sphere clone.
                // Check if left mouse button is released.
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    // Set Clone instance of a Sphere and position at gun.
                    clone = Instantiate(sphere
                                       , transform.position
                                       , transform.rotation)
                                        as Transform;
                    // Push clone by shot power towards mouse location.
                    clone.GetComponent<Rigidbody>().AddRelativeForce(0
                                                    , 0
                                                    , shotPower * 20);
                    // Reset shot power.
                    shotPower = shotPowerStart;
                }
            }

            // Change cameras
            // Right click to invert to other camera.
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                cameraMain.GetComponent<Camera>().enabled = !cameraMain.GetComponent<Camera>().enabled;
                cameraWide.GetComponent<Camera>().enabled = !cameraWide.GetComponent<Camera>().enabled;
            }


            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");


            if (scrolled < scrollLimit)
            {
                // Mouse scroll forwards.
                if (scrollWheel > 0)
                {
                    // Move camera forward.
                    cameraMain.Translate(Vector3.forward * 5);
                    scrolled++;
                }
            }
            if (scrolled > ~scrollLimit)
            { // ~ means reverse.
              // Mouse scroll backwards.
                if (scrollWheel < 0)
                {
                    // Move camera back.
                    cameraMain.Translate(Vector3.back * 5);
                    scrolled--;
                }
            }

            // 1, 2, 3, 4 for each level.
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SceneManager.LoadScene(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SceneManager.LoadScene(5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                SceneManager.LoadScene(6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                SceneManager.LoadScene(7);
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                SceneManager.LoadScene(8);
            }

            // R to restart current level.
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }


            // Change timescale of game.
            // Press Q to increase timescale.
            /*
		    if(Input.GetKeyDown(KeyCode.Q))
			    Time.timeScale++;
		    // Press E to decrease timescale.
		    if(Input.GetKeyDown(KeyCode.E))
			    Time.timeScale--;
		    // Press R to reset timescale.
		    if(Input.GetKeyDown(KeyCode.R))
			    Time.timeScale = 1;
		    */


            // Restricting movement.

            // Restrict movement of gun.
            if (gun && gun.position.x > wallRight.position.x)
            {
                gun.GetComponent<Rigidbody>().MovePosition(new Vector3(wallLeft.position.x
                                                  , gun.position.y
                                                  , gun.position.z));
            }
            if (gun && gun.position.x < wallLeft.position.x)
            {
                gun.GetComponent<Rigidbody>().MovePosition(new Vector3(wallRight.position.x
                                                  , gun.position.y
                                                  , gun.position.z));
            }
            if (gun && gun.position.y < wallDown.position.y)
            {
                gun.GetComponent<Rigidbody>().MovePosition(new Vector3(gun.GetComponent<Rigidbody>().position.x
                                                  , wallTop.position.y
                                                  , gun.position.z));
            }
            if (gun && gun.position.y > wallTop.position.y)
            {
                gun.GetComponent<Rigidbody>().MovePosition(new Vector3(gun.GetComponent<Rigidbody>().position.x
                                                  , wallDown.position.y
                                                  , gun.position.z));
            }

            string clonePosition = "";
            // Restricting clone of Sphere movement.
            if (clone)
            {
                if (clone.position.x > wallRight.position.x || clone.position.x < wallLeft.position.x
                || clone.position.y < wallDown.position.y || clone.position.y > wallTop.position.y)
                {
                    clonePosition = "Outside";
                }
                else if (clone.position.x < wallRight.position.x || clone.position.x > wallLeft.position.x
                     || clone.position.y > wallDown.position.y || clone.position.y < wallTop.position.y)
                {
                    clonePosition = "Inside";
                }
            }
            if (clonePosition == "Outside")
            {
                // When clone is created and is outside the walls, destroy clone.
                Destroy(clone.gameObject);
            }
            if (clonePosition == "Inside")
            {
                // When clone is created and inside the walls, destroy clone in 10 seconds.
                Destroy(clone.gameObject, 5f);
            }

            /*
		    // While a target sphere exists
			    if(GameObject.FindGameObjectsWithTag ("Finish").Length > 0){

			    targetSphere = GameObject.FindGameObjectsWithTag ("Finish")[GameObject.FindGameObjectsWithTag ("Finish").Length-1].transform;
			    Vector3 tmp = targetSphere.transform.position;
			    tmp.x = targetOrigin;
			    targetSphere.transform.position = tmp;
			    //targetSphere.transform.position.x = targetOrigin;
		    }
		    */


            // Hitting target.
            if (targetOrigin != 0 && targetSphere)
            {
                //print ("target exists");
                //			if(hitChecker == "Nothing")
                //			if(targetSphere.transform.position.x == targetOrigin) {
                //				hitChecker = "Not Hit";
                //	print ("target has position");
                //			}
                //			if(hitChecker == "Nothing" || hitChecker == "Not Hit")
                if (targetSphere.transform.position.x != targetOrigin)
                {
                    Destroy(targetSphere.gameObject, 2f);
                    hitChecker = "Hit";
                    //	print ("target moved");
                }
            }

            // check hit for target 2
            if (targetOrigin2 != 0 && targetSphere2)
                if (targetSphere2.transform.position.x != targetOrigin2)
                    Destroy(targetSphere2.gameObject, 2f);

            // check hit for target 3
            if (targetOrigin3 != 0 && targetSphere3)
                if (targetSphere3.transform.position.x != targetOrigin3)
                    Destroy(targetSphere3.gameObject, 2f);

            // Every frame maintinance.

            // Check if raycast has been set, then draw line on Scene Screen.
            if (Physics.Raycast(ray, out hit, 1000))
                Debug.DrawLine(transform.position, hit.point); // Draw line from gun to mouse location.

            capsule.GetComponent<Rigidbody>().MovePosition(hit.point); // Set casule at mouse position.

            if (cameraMain)
            {
                Vector3 cameraPosition = new Vector3(transform.position.x-cameraMain.transform.position.x
                                                ,transform.position.y-cameraMain.transform.position.y
                                                ,0);
                cameraMain.Translate(cameraPosition); // Position camera above Gun.
            }

            // Rotation of gun towards mouse position.
            gunRotation = new Vector3(hit.point.x, hit.point.y, 0);
            transform.LookAt(gunRotation);

            // Setting target sphere origin
            if (targetSphere)
                targetOrigin = targetSphere.transform.position.x;
            if (targetSphere2)
                targetOrigin2 = targetSphere2.transform.position.x;
            if (targetSphere3)
                targetOrigin3 = targetSphere3.transform.position.x;

            capsule.Rotate(new Vector3(0, 0, 10)); // Rotate capsule.

            spheres = GameObject.FindGameObjectsWithTag("Respawn").Length; // Number of spheres in game.
            targetSpheres = GameObject.FindGameObjectsWithTag("Finish").Length; // Number of target spheres in game.
            GUIPower = "Power: " + shotPower + "\n Spheres: " + spheres + "\n Targets: " + targetSpheres; // Display shot power, spheres and target spheres.
            GUITime = "Time: " + (int)Time.time + "\n TimeScale: " + Time.timeScale + "\n Frames: " + frames; // //Display frames run.

            frames++; // Add to frames run.

            // Game Over.
            if (GameObject.FindGameObjectsWithTag("Finish").Length == 0)
            {
                gameOver = true;
            }
        }
    }
}