using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarbles.V5
{
    public class GunScript :MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }
        public GameObject sphere;
        public GameObject clone;
        public GameObject capsule;
        int shotPower = 10;
        int shotPowerPlus = 2;
        int shotPowerLimit = 100;
        int shotPowerStart = 10;
        int multiplier = 20;

        // Mouse Position
        Ray ray;
        RaycastHit hit;
        // Gun rotation towards mouse.
        Vector3 gunRotation;


        // Update is called once per frame
        void Update()
        {
            LaunchSphere();
            CurserPointers();

            GunRotation();
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
                Debug.DrawLine(transform.position, hit.point);

            // Set capsule at mouse position.
            capsule.GetComponent<Rigidbody>().MovePosition(hit.point);
        }

        private void LaunchSphere()
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                shotPower = shotPowerLimit;
                InstantiateCloneAndLaunch();
            }


            // Increase shot power. - left click hold, increase shot power
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (shotPower < shotPowerLimit)
                {
                    shotPower += shotPowerPlus;
                }
            }


            // On left click release, Launch Sphere clone from Gun to mouse position at power level.
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                InstantiateCloneAndLaunch();
                shotPower = shotPowerStart;
            }
        }

        private void InstantiateCloneAndLaunch()
        {
            clone = Instantiate(sphere, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddRelativeForce(0, 0, shotPower * multiplier);
        }
    }
}