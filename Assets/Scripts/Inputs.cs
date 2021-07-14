using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarbles.V5
{
    public class Inputs :MonoBehaviour
    {
        GameObject cameraMain;
        GameObject cameraWide;
        GunScript Gun_S;
        private void Awake()
        {
            try
            {
                Gun_S = GameObject.Find("Gun").GetComponent<GunScript>();
            }
            catch (System.Exception)
            {
                //
            }
        }
        void Start()
        {
        }

        void FixedUpdate()
        {
            // Increase shot power. - left click hold, increase shot power
            if (Input.GetKey(KeyCode.Mouse0))
            {
                try
                {
                    Gun_S.PowerUpGun();
                }
                catch (System.Exception)
                {
                    return;
                }
            }
        }

        void Update()
        {
            if (Gun_S == null)
            {
                try
                {
                    Gun_S = GameObject.Find("Gun").GetComponent<GunScript>();
                }
                catch (System.Exception)
                {
                    return;
                }
            }

            // Space for GameOver debug...
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //gameOver = !gameOver;
                //ButtonsActions.LoadLevel1();
            }


            // On left click release, Launch Sphere clone from Gun to mouse position at power level. And reset shot power.
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Gun_S.InstantiateCloneAndLaunch();
            }
            // Change cameras - Right click to invert to other camera.
            if (Input.GetKeyUp(KeyCode.Mouse2))
            {
                ButtonsActions.ChangeCamera();
            }
            //private void LaunchSphere()
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Gun_S.LaunchSphereMaxPower();
            }

            ButtonsActions.ScrollWheelZoom();
            //if (spheres < maxSpheres)
            //{
            //    if (Input.GetKey(KeyCode.Mouse0))
            //    {
            //        if (shotPower < shotPowerLimit)
            //            shotPower += shotPowerPlus;
            //        GUIPower = "Power: " + shotPower;
            //    }

            // Escape for quitting to main menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ButtonsActions.MainMenu();
            }
            #region LoadLevels
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ButtonsActions.LoadLevel1();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ButtonsActions.LoadLevel2();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ButtonsActions.LoadLevel3();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ButtonsActions.LoadLevel4();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ButtonsActions.LoadLevel5();
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                ButtonsActions.LoadLevel6();
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                ButtonsActions.LoadLevel7();
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                ButtonsActions.LoadLevel8();
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                ButtonsActions.LoadLevel9();
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                ButtonsActions.LoadLevel10();
            }
            #endregion
        }
    }
}