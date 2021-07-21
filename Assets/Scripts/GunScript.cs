using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarbles.V5
{
    public class GunScript :MonoBehaviour
    {
        public GameObject sphere;
        public GameObject clone;
        public GameObject capsule;
        public GameObject line;
        LineRenderer lineR;
        public static int shotPower = 10;
        public static int shotPowerPlus = 2;
        public static int shotPowerLimit = 100;
        public static int shotPowerStart = 10;
        int multiplier = 20;
        float cloneDestroyTimer = 5f;
        public static int activeSpheres = 0;
        public static int maxSpheres = 5;
        public static int maxSpheresMaximum = 20;
        public static int maxSpheresMinimum = 1;
        // Mouse Position
        Ray ray;
        RaycastHit hit;
        // Gun rotation towards mouse.
        Vector3 gunRotation;
        string capsuleName = "Capsule";
        float capsuleRotateSpeed = -10f;

        private void Awake()
        {
            // Find capsule or create a new one
            GameObject foundObject = GameObject.Find(capsuleName);
            if (foundObject == null)
            {
                capsule = Instantiate(capsule);
                //print("capsule created");
            }
            else
            {
                capsule = GameObject.Find(capsuleName);
                //print("capsule found");
            }
        }
        void Start()
        {
            line = Instantiate(line);
            lineR = line.GetComponent<LineRenderer>();
        }

        void FixedUpdate()
        {
            //LaunchSphere();
            CountSpheres();
            CountTargetSpheres();
            CurserPointers();

            GunRotation();
        }
        private void CountSpheres()
        {
            activeSpheres = GameObject.FindGameObjectsWithTag("TargetSphere").Length;
        }
        private void CountTargetSpheres()
        {
            activeSpheres = GameObject.FindGameObjectsWithTag("Sphere").Length;
        }

        private void GunRotation()
        {
            // Rotation of gun towards mouse position.
            gunRotation = new Vector3(hit.point.x, hit.point.y, 0);
            transform.LookAt(gunRotation);
        }

        private void CurserPointers()
        {
            // Set ray to mouse position.
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Draw line from gun to mouse location.
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.DrawLine(transform.position, hit.point);
                lineR.SetPosition(0, transform.position); // gun position
                lineR.SetPosition(lineR.positionCount-1, hit.point); // mouse position
            }

            // Set capsule at mouse position.
            capsule.GetComponent<Rigidbody>().MovePosition(hit.point);
            capsule.transform.Rotate(new Vector3(0, 0, capsuleRotateSpeed)); // Rotate capsule.
        }

        public void LaunchSphereMaxPower()
        {
            shotPower = shotPowerLimit;
            InstantiateCloneAndLaunch();
        }
        public void PowerUpGun()
        {
            if (GunScript.shotPower < GunScript.shotPowerLimit && activeSpheres < maxSpheres)
            {
                GunScript.shotPower += GunScript.shotPowerPlus;
            }
        }

        public void InstantiateCloneAndLaunch()
        {
            if (activeSpheres < maxSpheres)
            {
                clone = Instantiate(sphere, transform.position, transform.rotation);
                clone.GetComponent<Rigidbody>().AddRelativeForce(0, 0, shotPower * multiplier);
                shotPower = shotPowerStart;
                Destroy(clone.gameObject, cloneDestroyTimer);
            }
            else
            {
                //print("Too many spheres");
            }
        }
    }
}