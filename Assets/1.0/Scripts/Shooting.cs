using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour {

	// Transforms to manipulate objects.
	public Transform gun; // Gun.
	public Transform sphere; // Sphere.
	Transform clone; // Clone of sphere.
	public Transform targetSphere; // Target spheres.
	public Transform wallLeft;	// Left wall of level.
	public Transform wallRight;	// Right wall of level.
	public Transform wallTop; // Top wall of level.
	public Transform wallDown; // Down wall of level.
	public Transform capsule; // Shows mouse location.
	public Transform cameraMain; // Main camera.
	public Transform cameraWide; // Alternate camera.

	int frames = 0; // Count for each Update() frame ran.
	float movespeed; // Move speed of gun.
	Vector3 gunRotation; // Gun rotation towards mouse.

	int shotPowerStart = 10; // How much power the shot starts with.
	float shotPower = 10; // Force used to shoot Sphere.
	float shotPowerPlus = 1f; // How fast shot power increases.
	int shotPowerLimit = 100; // Max shot power.

	int spheres = 0; // Count for Sphere clones.
	int maxSpheres; // Max spheres that can be created.

	int targetSpheres = 0; // Count for target Spheres.
	float targetOrigin = 0; // Origin for target Sphere.
	string hitChecker = "Nothing"; // Hit check for target Spheres.

	int scrollLimit = 2; // Max scroll limit.
	int scrolled = 0; // Count for scroll.
	int capsuleSpinSpeed = -10;

	// Interface
	string GUIPower; // Displays shot power.
#pragma warning disable CS0219 // Variable is assigned but its value is never used
	string GUITime; // //Displays frames played so far.
#pragma warning disable CS0219 // Variable is assigned but its value is never used
	string instructions =
		"Controls" +
		"\n Left click: Shoot" +
		"\n Right click: Change camera" +
		"\n Scroll: Change zoom" +
		"\n WASD: Movement" +
		"\n ESC: Quit" +
		"\n Space: Next level" +
		"\n 1-4: Level select" +
		"\n R: Reload level";

	// Mouse Position
	Ray ray;
 	RaycastHit hit;

	bool gameOver = false;
	//string MainMenuRedoneName = "MainMenuRedone";
	string MainMenuName = "MainMenu";
	bool increaseShotPower = false;

	void Start(){
		maxSpheres = Menu.shootingMaxSpheres;
		movespeed = Menu.shootingMoveSpeed;
	}

	// Graphical User Interface
	void OnGUI() {
		GUI.Box(new Rect(0,0,250,150), instructions);

		// Box displaying shot power at top left of screen.
		GUI.Box(new Rect(0,Screen.height-60,100,60), GUIPower);
		//Box displaying total frames and time at top right of screen.
		//GUI.Box(new Rect (Screen.width - 100,0,100,50), GUITime);



		// Restart button.
		if (GUI.Button (new Rect (100,Screen.height-50,100,50), "Restart (R)"))
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		// Level selecters.
		if (GUI.Button (new Rect (210,Screen.height-50,80,25), "Level 1 (1)"))
			SceneManager.LoadScene("1.0/Scenes/Level1");

		if (GUI.Button (new Rect (210,Screen.height-25,80,25), "Level 2 (2)"))
			SceneManager.LoadScene("1.0/Scenes/Level2");

		if (GUI.Button (new Rect (290,Screen.height-50,80,25), "Level 3 (3)"))
			SceneManager.LoadScene("1.0/Scenes/Level3");

		if (GUI.Button (new Rect (290,Screen.height-25,80,25), "Level 4 (4)"))
			SceneManager.LoadScene("1.0/Scenes/Level4");

		// Quit button.
		if (GUI.Button (new Rect (380,Screen.height-50,100,50), "Quit(ESC)"))
			SceneManager.LoadScene($"1.0/Scenes/{MainMenuName}");


		// Game over.
		if (gameOver == true){
			GUI.Box(new Rect(200,200,250,25), "Congratulations, you completed " + SceneManager.GetActiveScene().name + "!");
			if(SceneManager.GetActiveScene().name != "Level4"){
				if (GUI.Button (new Rect (220,220,200,40), "Next Level (Space)") || Input.GetKeyDown(KeyCode.Space))
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
			}
			else {
				GUI.Box(new Rect(200,220,250,25), "Game finished, go back to main menu?");
				if (GUI.Button (new Rect (220,240,200,40), "Back to main menu. (Space)") || Input.GetKeyDown(KeyCode.Space))
					SceneManager.LoadScene(MainMenuName);
			}
			//gameOver = false;
		}
	}

	void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, hit.point);
	}

	void Update () {
		// Set ray to mouse position.
		if(cameraMain.GetComponent<Camera>().enabled == true){
			ray = cameraMain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		}
		else{
			ray = cameraWide.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		}




		// Controls
		// W, A, S, D to move Gun left, right, up, down.
		// Left click to shoot, right click to switch camera.
		// 1, 2, 3, 4 for each level.
		// R to restart current level.
		// Escape to go back to main menu.

		// Menu
		if(Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene($"1.0/Scenes/{MainMenuName}");
		}

		// Movement for gun.
		// Press W to go up.

		if(Input.GetKey("w"))
			GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x
											  ,GetComponent<Rigidbody>().position.y+movespeed/5
											  ,GetComponent<Rigidbody>().position.z));
		// Press A to go Left.
		if(Input.GetKey("a"))
			GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x-movespeed/5
											  ,GetComponent<Rigidbody>().position.y
											  ,GetComponent<Rigidbody>().position.z));
		// Press S to go Down.
		if(Input.GetKey("s"))
			GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x
										      ,GetComponent<Rigidbody>().position.y-movespeed/5
											  ,GetComponent<Rigidbody>().position.z));
		// Press D to go Right.
		if(Input.GetKey("d"))
			GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x+movespeed/5
											  ,GetComponent<Rigidbody>().position.y
											  ,GetComponent<Rigidbody>().position.z));



		// Limit Spheres created.
		if(spheres < maxSpheres){
			// Increase shot power.
			// Check if left mouse button if pressed.
			if(Input.GetKey(KeyCode.Mouse0)){
				// Check if shot power is under limit.
				if (shotPower < shotPowerLimit)
				{
					// Increase shot power.
					increaseShotPower = true;
				}
				// Display shot power
				GUIPower = "Power: " + shotPower;
            }
            else
            {
				increaseShotPower = false;
			}

			// Launch Sphere clone.
			// Check if left mouse button is released.
			if (Input.GetKeyUp(KeyCode.Mouse0)){
				// Set Clone instance of a Sphere and position at gun.
				clone = Instantiate(sphere
								   ,transform.position
								   ,transform.rotation)
									as Transform;
				// Push clone by shot power towards mouse location.
				clone.GetComponent<Rigidbody>().AddRelativeForce(0
												,0
												,shotPower*20);
				// Reset shot power.
				shotPower = shotPowerStart;
			}
		}

		// Change cameras
		// Right click to invert to other camera.
		if(Input.GetKeyDown(KeyCode.Mouse1)) {
			cameraMain.GetComponent<Camera>().enabled = !cameraMain.GetComponent<Camera>().enabled;
			cameraWide.GetComponent<Camera>().enabled = !cameraWide.GetComponent<Camera>().enabled;
		}


		float scrollWheel = Input.GetAxis("Mouse ScrollWheel");


		if(scrolled < scrollLimit){
			// Mouse scroll forwards.
			if(scrollWheel > 0){
				// Move camera forward.
				cameraMain.Translate(Vector3.forward*5);
				scrolled++;
			}
		}
		if(scrolled > ~scrollLimit){ // ~ means reverse.
			// Mouse scroll backwards.
			if(scrollWheel < 0){
				// Move camera back.
				cameraMain.Translate(Vector3.back*5);
				scrolled--;
			}
		}

		// 1, 2, 3, 4 for each level.
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			SceneManager.LoadScene("1.0/Scenes/Level1");
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			SceneManager.LoadScene("1.0/Scenes/Level2");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			SceneManager.LoadScene("1.0/Scenes/Level3");
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			SceneManager.LoadScene("1.0/Scenes/Level4");
		}

		// R to restart current level.
		if(Input.GetKeyDown(KeyCode.R)){
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
		if(gun && gun.position.x > wallRight.position.x){
			gun.GetComponent<Rigidbody>().MovePosition(new Vector3(wallLeft.position.x
											  ,gun.position.y
											  ,gun.position.z));
		}
		if(gun && gun.position.x < wallLeft.position.x){
			gun.GetComponent<Rigidbody>().MovePosition(new Vector3(wallRight.position.x
											  ,gun.position.y
											  ,gun.position.z));
		}
		if(gun && gun.position.y < wallDown .position.y){
			gun.GetComponent<Rigidbody>().MovePosition(new Vector3(gun.GetComponent<Rigidbody>().position.x
											  ,wallTop.position.y
											  ,gun.position.z));
		}
		if(gun && gun.position.y > wallTop.position.y){
			gun.GetComponent<Rigidbody>().MovePosition(new Vector3(gun.GetComponent<Rigidbody>().position.x
											  ,wallDown.position.y
											  ,gun.position.z));
		}

		string clonePosition = "";
		// Restricting clone of Sphere movement.
		if(clone){
			if(clone.position.x > wallRight.position.x || clone.position.x < wallLeft.position.x
			|| clone.position.y < wallDown .position.y || clone.position.y > wallTop.position.y){
				clonePosition = "Outside";
			}
			else if(clone.position.x < wallRight.position.x || clone.position.x > wallLeft.position.x
				 || clone.position.y > wallDown .position.y || clone.position.y < wallTop.position.y){
				clonePosition = "Inside";
			}
		}
		if(clonePosition == "Outside"){
			// When clone is created and is outside the walls, destroy clone.
			Destroy(clone.gameObject);
		}
		if(clonePosition == "Inside"){
			// When clone is created and inside the walls, destroy clone in 10 seconds.
			Destroy(clone.gameObject, 5f);
		}






		// Hitting target.
		if(targetOrigin != 0 && targetSphere)
		{
			if(hitChecker == "Nothing")
			if(targetSphere.transform.position.x == targetOrigin) {
				hitChecker = "Not Hit";
			}
			if(hitChecker == "Nothing" || hitChecker == "Not Hit")
			if(targetSphere.transform.position.x != targetOrigin) {
				Destroy(targetSphere.gameObject,2f);
				hitChecker = "Hit";
			}
		}


		// Every frame maintinance.

		// Check if raycast has been set, then draw line on Scene Screen.
		if (Physics.Raycast(ray, out hit, 1000))
			Debug.DrawLine(transform.position, hit.point); // Draw line from gun to mouse location.

		capsule.GetComponent<Rigidbody>().MovePosition(hit.point); // Set casule at mouse position.

		if(cameraMain){
			Vector3 cameraPosition = new Vector3(transform.position.x-cameraMain.transform.position.x
											,transform.position.y-cameraMain.transform.position.y
											,0);
			cameraMain.Translate(cameraPosition); // Position camera above Gun.
		}

		// Rotation of gun towards mouse position.
		gunRotation = new Vector3(hit.point.x,hit.point.y,0);
		transform.LookAt(gunRotation);

		if(targetSphere)targetOrigin = targetSphere.transform.position.x;

		spheres = GameObject.FindGameObjectsWithTag("Respawn").Length; // Number of spheres in game.
		targetSpheres = GameObject.FindGameObjectsWithTag("Finish").Length; // Number of target spheres in game.
		GUIPower = "Power: " + (int)shotPower + "\n Spheres: " + spheres + "\n Targets: " + targetSpheres; // Display shot power, spheres and target spheres.
		GUITime = "Time: " + (int)Time.time + "\n TimeScale: " + Time.timeScale + "\n Frames: " + frames; // //Display frames run.

		frames++; // Add to frames run.

		// Game Over.
		if(GameObject.FindGameObjectsWithTag("Finish").Length == 0){
			gameOver = true;
		}
	}
    private void FixedUpdate()
    {
        if (increaseShotPower)
        {
			shotPower += shotPowerPlus;
		}

		capsule.Rotate(new Vector3(0,0, capsuleSpinSpeed)); // Rotate capsule.

	}
}
