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
        TextMeshProUGUI Coins;
        TextMeshProUGUI Level;
        TextMeshProUGUI Power;
        TextMeshProUGUI Spheres;
        TextMeshProUGUI Targets;
        Button MenuBtn;
        Button RestartBtn;
        Button ZoomBtn;
        Button ZoomPlusBtn;
        Button ZoomMinusBtn;
        //Button BuyLevelBtn;
        Button Level1Btn;
        Button Level2Btn;
        Button Level3Btn;
        Button Level4Btn;
        Button Level5Btn;
        Button Level6Btn;
        Button Level7Btn;
        Button Level8Btn;
        Button Level9Btn;
        Button Level10Btn;
        GameObject LevelOverPanel;
        TextMeshProUGUI LevelFinishText;
        Button LevelOverNextLevelBtn;
        Button LevelOverQuitBtn;
        string LevelText = "";
        string CoinsText = "Coins: ";
        string PowerText = "Power: ";
        string SpheresText = "Spheres: ";
        string TargetsText = "Targets: ";
        List<TextMeshProUGUI> infoTexts = new List<TextMeshProUGUI>();
        List<Button> allButtonsList = new List<Button>();
        List<Button> levelButtons = new List<Button>();
        List<Button> otherButtons = new List<Button>();
        string LevelFinishTextNormalLevel = "Level completed - Next Level (Space)";
        string LevelFinishTextLastLevel = "Game finished, go back to the main menu?";


        void Awake()
        {

        }
        void FullGameSetup()
        {
            try
            {
                FindGameObjectsButtonsAndTexts();
                GameGUIAssignButtonsToLists(infoTexts, allButtonsList, levelButtons, otherButtons);
                //MenuGUI.SetAllButtonColours(allButtonsList);
                DeactivatePanels();//DeactivatePanels(GOContainers);
                SetupClicks(allButtonsList);
            }
            catch (System.Exception e)
            {
                print(e.Message);
            }
        }

        void FindGameObjectsButtonsAndTexts()
        {
            //TODO: list empty buttons then find in a foreach?
            Coins = GameObject.Find(nameof(Coins)).GetComponent<TextMeshProUGUI>();
            Level = GameObject.Find(nameof(Level)).GetComponent<TextMeshProUGUI>();
            Power = GameObject.Find(nameof(Power)).GetComponent<TextMeshProUGUI>();
            Spheres = GameObject.Find(nameof(Spheres)).GetComponent<TextMeshProUGUI>();
            Targets = GameObject.Find(nameof(Targets)).GetComponent<TextMeshProUGUI>();

            MenuBtn = GameObject.Find(nameof(MenuBtn)).GetComponent<Button>();
            RestartBtn = GameObject.Find(nameof(RestartBtn)).GetComponent<Button>();
            ZoomBtn= GameObject.Find(nameof(ZoomBtn)).GetComponent<Button>();
            ZoomPlusBtn = GameObject.Find(nameof(ZoomPlusBtn)).GetComponent<Button>();
            ZoomMinusBtn = GameObject.Find(nameof(ZoomMinusBtn)).GetComponent<Button>();

            Level1Btn = GameObject.Find(nameof(Level1Btn)).GetComponent<Button>();
            Level2Btn = GameObject.Find(nameof(Level2Btn)).GetComponent<Button>();
            Level3Btn = GameObject.Find(nameof(Level3Btn)).GetComponent<Button>();
            Level4Btn = GameObject.Find(nameof(Level4Btn)).GetComponent<Button>();
            Level5Btn = GameObject.Find(nameof(Level5Btn)).GetComponent<Button>();
            Level6Btn = GameObject.Find(nameof(Level6Btn)).GetComponent<Button>();
            Level7Btn = GameObject.Find(nameof(Level7Btn)).GetComponent<Button>();
            Level8Btn = GameObject.Find(nameof(Level8Btn)).GetComponent<Button>();
            Level9Btn = GameObject.Find(nameof(Level9Btn)).GetComponent<Button>();
            Level10Btn = GameObject.Find(nameof(Level10Btn)).GetComponent<Button>();

            LevelFinishText = GameObject.Find(nameof(LevelFinishText)).GetComponent<TextMeshProUGUI>();
            LevelOverPanel = GameObject.Find(nameof(LevelOverPanel));
            LevelOverNextLevelBtn = GameObject.Find("NextLevelBtn").GetComponent<Button>();
            LevelOverQuitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
        }
        void GameGUIAssignButtonsToLists(List<TextMeshProUGUI> infoTexts, List<Button> allButtonsList, List<Button> levelButtons, List<Button> otherButtons)
        {
            //infoTexts, levelButtons, otherButtons
            // Find texts, buttons
            // add to GameObjects list and buttons list
            // SetButtonColors
            infoTexts.Clear();
            infoTexts.Add(Coins);
            infoTexts.Add(Level);
            infoTexts.Add(Power);
            infoTexts.Add(Spheres);
            infoTexts.Add(Targets);

            otherButtons.Clear();
            otherButtons.Add(MenuBtn);
            otherButtons.Add(RestartBtn);
            otherButtons.Add(ZoomBtn);
            otherButtons.Add(ZoomPlusBtn);
            otherButtons.Add(ZoomMinusBtn);
            otherButtons.Add(LevelOverNextLevelBtn);
            otherButtons.Add(LevelOverQuitBtn);

            levelButtons.Clear();
            levelButtons.Add(Level1Btn);
            levelButtons.Add(Level2Btn);
            levelButtons.Add(Level3Btn);
            levelButtons.Add(Level4Btn);
            levelButtons.Add(Level5Btn);
            levelButtons.Add(Level6Btn);
            levelButtons.Add(Level7Btn);
            levelButtons.Add(Level8Btn);
            levelButtons.Add(Level9Btn);
            levelButtons.Add(Level10Btn);

            foreach (Button button in otherButtons)
            {
                allButtonsList.Add(button);
            }
            foreach (Button button in levelButtons)
            {
                allButtonsList.Add(button);
            }
        }

        void SetupClicks(List<Button> allButtonsList, bool destroy = false)
        {
            if (destroy)
            {
                foreach (Button button in allButtonsList)
                {
                    //button.onClick.RemoveAllListeners();
                    //button.onClick.RemoveListener(() => ButtonHandler(button));
                }
            }
            else if(!destroy)
            {
                MenuBtn.onClick.AddListener(() => ButtonsActions.LoadLevelMainMenu());//ButtonHandler(button));
                RestartBtn.onClick.AddListener(() => ButtonsActions.RestartLevel());
                ZoomBtn.onClick.AddListener(() => ButtonsActions.ScrollWheelZoom());
                ZoomPlusBtn.onClick.AddListener(() => ButtonsActions.ZoomPlus());
                ZoomMinusBtn.onClick.AddListener(() => ButtonsActions.ZoomMinus());

                Level1Btn.onClick.AddListener(() => ButtonsActions.LoadLevel1());
                Level2Btn.onClick.AddListener(() => ButtonsActions.LoadLevel2());
                Level3Btn.onClick.AddListener(() => ButtonsActions.LoadLevel3());
                Level4Btn.onClick.AddListener(() => ButtonsActions.LoadLevel4());
                Level5Btn.onClick.AddListener(() => ButtonsActions.LoadLevel5());
                Level6Btn.onClick.AddListener(() => ButtonsActions.LoadLevel6());
                Level7Btn.onClick.AddListener(() => ButtonsActions.LoadLevel7());
                Level8Btn.onClick.AddListener(() => ButtonsActions.LoadLevel8());
                Level9Btn.onClick.AddListener(() => ButtonsActions.LoadLevel9());
                Level10Btn.onClick.AddListener(() => ButtonsActions.LoadLevel10());

                LevelOverNextLevelBtn.onClick.AddListener(() => NextLevel());//ButtonsActions.LoadNextLevel());
                LevelOverQuitBtn.onClick.AddListener(() => QuitLevel());
                //button.onClick.AddListener(() => ButtonHandler(button));
            }
        }
        void NextLevel()
        {
            DeactivatePanels();
            ButtonsActions.LoadNextLevel();
        }
        void QuitLevel()
        {
            DeactivatePanels();
            ButtonsActions.LoadLevelMainMenu();
        }
        void DeactivatePanels()
        {
            LevelOverNextLevelBtn.gameObject.SetActive(false);
            LevelOverQuitBtn.gameObject.SetActive(false);
            LevelOverPanel.SetActive(false);
        }

        private void Update()
        {
            // could do but affects performance
            GameManager.IsMenuSceneCheck();
            if (!GameManager.isMenuScene)
            {
                if (Coins == null && GameManager.minimumFramesRun)
                {
                    FullGameSetup();
                }
                else if (Coins != null)
                {
                    Coins.text = $"{CoinsText}{GameManager.coins}";
                    Level.text = $"{LevelText}{GameManager.currentLevel}";
                    Power.text = $"{PowerText}{GunScript.shotPower}";
                    Spheres.text = $"{SpheresText}{GunScript.activeSpheres}/{GunScript.maxSpheres}";
                    Targets.text = $"{TargetsText}{GameManager.targetsHitList.Count}/{GameManager.targetsList.Count}";
                }
                if (!GameManager.levelOver)
                {
                    if (LevelOverPanel.activeSelf)
                    {
                        DeactivatePanels();
                    }
                }
            }
        }

        public void LevelOver()
        {
            // display UI
            if (LevelOverPanel)
            {
                LevelOverPanel.SetActive(true);
                LevelOverNextLevelBtn.gameObject.SetActive(true);
                LevelFinishText.text = $"{LevelFinishTextNormalLevel}";
                LevelOverNextLevelBtn.Select();
            }
        }
        public void GameOver()
        {
            // display UI
            if (LevelOverPanel)
            {
                LevelOverPanel.SetActive(true);
                LevelOverNextLevelBtn.gameObject.SetActive(false);
                LevelOverQuitBtn.gameObject.SetActive(true);
                LevelFinishText.text = $"{LevelFinishTextLastLevel}";
                LevelOverQuitBtn.Select();
            }
        }

        #region oldUI
        //public void LevelButtons()
        //{
        //    GUILayout.BeginArea(new Rect(0, Screen.height - 60, Screen.width, 60));

        //    GUILayout.BeginHorizontal();
        //    GUILayout.BeginVertical();
        //    GUILayout.Box(GUIPower);
        //    GUILayout.EndVertical();

        //    if (GUILayout.Button("Restart (R)"))
        //        ButtonsActions.RestartLevel();//Application.GameManager.LoadLevel(Application.loadedLevel);
        //    GUILayout.BeginVertical();
        //    // Level selecters.
        //    if (GUILayout.Button("Level 1 (1)"))
        //        ButtonsActions.LoadLevel(1);//Application.GameManager.LoadLevel(1);
        //    if (GUILayout.Button("Level 2 (2)"))
        //        ButtonsActions.LoadLevel(2);
        //    GUILayout.EndVertical();

        //    GUILayout.BeginVertical();
        //    if (GUILayout.Button("Level 3 (3)"))
        //        ButtonsActions.LoadLevel(3);
        //    if (GUILayout.Button("Level 4 (4)"))
        //        ButtonsActions.LoadLevel(4);
        //    GUILayout.EndVertical();

        //    GUILayout.BeginVertical();
        //    if (GUILayout.Button("Level 5 (5)"))
        //        ButtonsActions.LoadLevel(5);
        //    if (GUILayout.Button("Level 6 (6)"))
        //        ButtonsActions.LoadLevel(6);
        //    GUILayout.EndVertical();

        //    GUILayout.BeginVertical();
        //    if (GUILayout.Button("Level 7 (7)"))
        //        ButtonsActions.LoadLevel(7);
        //    if (GUILayout.Button("Level 8 (8)"))
        //        ButtonsActions.LoadLevel(8);
        //    GUILayout.EndVertical();

        //    // Quit button.
        //    if (GUILayout.Button("Menu(ESC)"))
        //        ButtonsActions.LoadLevel(0);
        //    GUILayout.EndHorizontal();
        //    GUILayout.EndArea();
        //}

        //public void GameOver()
        //{
        //    // Game over.
        //    GUILayout.BeginArea(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 50, 250, 100));

        //    GUILayout.Box("Congratulations, you completed level " + SceneManager.GetActiveScene().buildIndex + "!");
        //    if (SceneManager.GetActiveScene().name != ButtonsActions.lastLevel)
        //    {
        //        if (GUILayout.Button("Next Level (Space)") || Input.GetKeyDown(KeyCode.Space))
        //            ButtonsActions.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        //    }
        //    else
        //    {
        //        GUILayout.Box("Game finished, go back to main menu?");
        //        if (GUILayout.Button("Back to main menu. (Space)") || Input.GetKeyDown(KeyCode.Space))
        //            ButtonsActions.LoadLevel(ButtonsActions.mainMenuName);
        //    }
        //    //gameOver = false;
        //    GUILayout.EndArea();
        //}
        #endregion
    }
}