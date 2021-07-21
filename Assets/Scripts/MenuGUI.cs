using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SpaceMarbles.V5
{
    public class MenuGUI :MonoBehaviour
    {
        //string GUIPower = "";
        //string TitleText = "Space Marbles";
        string CoinsText = "Coins: ";
        //string InstructionsText = "...";
        //string OptionsText = "...";
        //string AboutText = "...";
        TextMeshProUGUI Title;
        TextMeshProUGUI Coins;
        Button PlayBtn;
        Button PlayClassicBtn;
        Button QuitBtn;
        Button LevelSelectBtn;
        Button OptionsBtn;
        Button InstructionsBtn;
        Button AboutBtn;
        GameObject LevelSelect;
        GameObject Options;
        GameObject Instructions;
        GameObject About;
        Button MaxSpheresMinusBtn;
        Button MaxSpheresPlusBtn;
        TextMeshProUGUI MaxSpheresValue;
        Button BuyLevelBtn;
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
        //bool isMenuScene;
        List<GameObject> GOContainers = new List<GameObject>();
        List<Button> buttons = new List<Button>();
        List<Button> buttonsForPanels = new List<Button>();
        GameObject[] closeButtons;
        Button lastSelectedButton;
        Color normalTextColor = Color.black;
        Color clickedTextColor = Color.white;

        #region FullMenuSetup
        void Awake()
        {
            //if (GameManager.isMenuScene)
            //{
            //    FullMenuSetup(); //InstructionsBtn.Select(); didn't set font colour on awake...
            //}
        }
        void FullMenuSetup()
        {
            try
            {
                FindGameObjectsButtonsAndTexts();
                MenuGUIAssignButtonsToLists(GOContainers, buttonsForPanels, buttons, closeButtons);
                SetAllButtonColours(buttons);
                DeactivatePanels(GOContainers);
                SetupClicks(buttons);

                if (!GameManager.hasMenuLoadedBefore)
                {
                    MenuStartConfigs();
                    print("menu setup finished");
                    GameManager.hasMenuLoadedBefore = true;
                }
                else
                {
                    PlayBtn.Select(); // shortcut for debugging
                    SetAllButtonsFontColor(PlayBtn);
                }
            }
            catch (System.Exception e)
            {
                print(e.Message);
            }
        }
        private void FindGameObjectsButtonsAndTexts()
        {
            //GameObject.FindObjectsOfType...?
            Title = GameObject.Find("Title").GetComponent<TextMeshProUGUI>();
            Coins = GameObject.Find("Coins").GetComponent<TextMeshProUGUI>();
            MaxSpheresValue = GameObject.Find("MaxSpheresValue").GetComponent<TextMeshProUGUI>();
            LevelSelect = GameObject.Find("LevelSelect");
            Options = GameObject.Find("Options");
            Instructions = GameObject.Find("Instructions");
            About = GameObject.Find("About");

            PlayBtn = GameObject.Find(nameof(PlayBtn)).GetComponent<Button>();
            PlayClassicBtn = GameObject.Find("ClassicBtn").GetComponent<Button>();
            QuitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
            LevelSelectBtn = GameObject.Find("LevelSelectBtn").GetComponent<Button>();
            OptionsBtn = GameObject.Find("OptionsBtn").GetComponent<Button>();
            InstructionsBtn = GameObject.Find("InstructionsBtn").GetComponent<Button>();
            AboutBtn = GameObject.Find("AboutBtn").GetComponent<Button>();
            closeButtons = GameObject.FindGameObjectsWithTag("CloseBtn"); //.getcomponent...
            BuyLevelBtn = GameObject.Find("BuyLevelBtn").GetComponent<Button>();
            MaxSpheresMinusBtn = GameObject.Find("MaxSpheresMinusBtn").GetComponent<Button>();
            MaxSpheresPlusBtn = GameObject.Find("MaxSpheresPlusBtn").GetComponent<Button>();
            Level1Btn = GameObject.Find("Level1Btn").GetComponent<Button>(); //...level10
            Level2Btn = GameObject.Find("Level2Btn").GetComponent<Button>();
            Level3Btn = GameObject.Find("Level3Btn").GetComponent<Button>();
            Level4Btn = GameObject.Find("Level4Btn").GetComponent<Button>();
            Level5Btn = GameObject.Find("Level5Btn").GetComponent<Button>();
            Level6Btn = GameObject.Find("Level6Btn").GetComponent<Button>();
            Level7Btn = GameObject.Find("Level7Btn").GetComponent<Button>();
            Level8Btn = GameObject.Find("Level8Btn").GetComponent<Button>();
            Level9Btn = GameObject.Find("Level9Btn").GetComponent<Button>();
            Level10Btn = GameObject.Find("Level10Btn").GetComponent<Button>();

            PlayBtn.onClick.AddListener(() => ButtonsActions.LoadLevel1());
        }
        void MenuGUIAssignButtonsToLists(List<GameObject> GOList, List<Button> goButtonsList, List<Button> allButtonsList, GameObject[] closeButtonsList)
        {
            // Find texts, GameObject containers, buttons
            // add to GameObjects list and buttons list
            // SetButtonColors

            // two identically listed lists
            GOList.Clear(); // gocontainers
            GOList.Add(LevelSelect);
            GOList.Add(Instructions);
            GOList.Add(Options);
            GOList.Add(About);

            goButtonsList.Clear(); //buttonsforgocontainers
            goButtonsList.Add(LevelSelectBtn);
            goButtonsList.Add(InstructionsBtn);
            goButtonsList.Add(OptionsBtn);
            goButtonsList.Add(AboutBtn);
            // level, ...

            allButtonsList.Clear();
            allButtonsList.Add(PlayBtn);
            allButtonsList.Add(PlayClassicBtn);
            allButtonsList.Add(QuitBtn);
            allButtonsList.Add(LevelSelectBtn);
            allButtonsList.Add(InstructionsBtn);
            allButtonsList.Add(OptionsBtn);
            allButtonsList.Add(AboutBtn);
            foreach (GameObject goClose in closeButtonsList)
            {
                allButtonsList.Add(goClose.GetComponent<Button>());
            }
            //GameObject[] closeBtns = GameObject.FindObjectsOfType(System.Type s); //...level10
            allButtonsList.Add(MaxSpheresMinusBtn);
            allButtonsList.Add(MaxSpheresPlusBtn);
            allButtonsList.Add(BuyLevelBtn);
            allButtonsList.Add(Level1Btn);
            allButtonsList.Add(Level2Btn);
            allButtonsList.Add(Level3Btn);
            allButtonsList.Add(Level4Btn);
            allButtonsList.Add(Level5Btn);
            allButtonsList.Add(Level6Btn);
            allButtonsList.Add(Level7Btn);
            allButtonsList.Add(Level8Btn);
            allButtonsList.Add(Level9Btn);
            allButtonsList.Add(Level10Btn);
        }
        public static void SetAllButtonColours(List<Button> buttonsList)
        {
            // Set all button colours
            foreach (Button button in buttonsList)
            {
                SetButtonColors(button);
            }
        }
        public static void SetButtonColors(Button button)
        {
            ColorBlock cols = button.colors;
            cols.highlightedColor = new Color(0.6415094f, 0.6415094f, 0.6415094f); //164 //0.6415094
            cols.selectedColor = new Color(0.01902175f, 0, 0.4716981f); //0.01902175, , 0.4716981
            button.colors = cols; // 5, 0, 120
                                      //Color col;
                                      //ColorUtility.TryParseHtmlString("A4A4A4", out col);
                                      //OptionsBtn.colors.highlightedColor = col;//col => ColorUtility.TryParseHtmlString("A4A4A4", out col);
                                      //A4A4A4 - higlighted
                                      //050078 - selected
        }
        void DeactivatePanels(List<GameObject> panelsList)
        {
            foreach (GameObject go in panelsList)
            {
                go.gameObject.SetActive(false);
            }
        }
        void SetupClicks(List<Button> buttonsList, bool destroy = false)
        {
            foreach (Button button in buttonsList)
            {
                if (destroy)
                {
                    //button.onClick.RemoveAllListeners();
                    //button.onClick.RemoveListener(() => ButtonHandler(button));
                }
                else
                {
                    button.onClick.AddListener(() => ButtonHandler(button));
                }
            }
            //OptionsBtn.OnSelect(UnityEngine.EventSystems.EventSystem.current.c);
            //OptionsBtn.onClick.AddListener(() => ButtonHandler(OptionsBtn));
            //InstructionsBtn.onClick.AddListener(() => ButtonHandler(InstructionsBtn));
            //AboutBtn.onClick.AddListener(() => ButtonHandler(AboutBtn));

            //foreach closeBtns, addListener close
            //ButtonNext.onClick.AddListener(delegate{SwitchButtonHandler(1);});
            //myselfButton.onClick.AddListener(() => actionToMaterial(index));
        }
        void MenuStartConfigs()
        {
            //Title.text = $"{TitleText}";
            InstructionsBtn.Select();
            //SetFontColor(InstructionsBtn);
            //SetButtonColors(InstructionsBtn);
            //InstructionsBtn.onClick.Invoke(); // or could set as selected
            //ButtonHandler(InstructionsBtn); // set instructions as clicked
            //PlayBtn.Select(); // instructions displayed instead - if coins > 0 (played before) then set play as first button
        }
        void SetAllButtonsFontColor(Button selectedBtn = null)
        {
            foreach (Button button in buttons)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().color = normalTextColor;
            }
            if (selectedBtn != null)
            {
                selectedBtn.GetComponentInChildren<TextMeshProUGUI>().color = clickedTextColor;
            }
        }
        #endregion
        // start finished
        bool closedPressed = false;
        void ButtonHandler(Button btn)
        {
            lastSelectedButton = btn;
            // deselect then select button and set panel active
            //if an options button pressed... dont unfocus
            SetAllButtonsFontColor(btn);

            //if (btn.name == "Close") //UnFocusButtons // already done

            if (btn.name == PlayBtn.name)
            {
                //ButtonsActions.LoadLevel1();//LoadLevelMainMenu(); // load last played level?
                return;
            }
            if (btn.name == PlayClassicBtn.name)
            {
                ButtonsActions.LoadLevelMainMenuClassic();
                return;
            }
            if (btn.name == QuitBtn.name)
            {
                ButtonsActions.Exit();
                return;
            }
            if (btn.name == MaxSpheresMinusBtn.name)
            {
                GameManager.MaxSpheresMinus();
                return;
            }
            if (btn.name == MaxSpheresPlusBtn.name)
            {
                GameManager.MaxSpheresPlus();
                return;
            }
            if (btn.name == BuyLevelBtn.name)
            {
                ButtonsActions.BuyLevel();
                return;
            }
            try
            {
                if (btn.GetComponentInChildren<TextMeshProUGUI>().text == "Close")
                {
                    //foreach (Button btnSel in buttons)//buttonsForGOContainers)
                    //{
                    //    if (btnSel.gameObject == EventSystem.current.currentSelectedGameObject)
                    //    {
                    //        print($"button: {btnSel}");
                    //        EventSystem.current.firstSelectedGameObject = GameObject.Find("GameManager");
                    //        print($"GO: {EventSystem.current.currentSelectedGameObject}");
                    //        //btnSel.sele;
                    //    }
                    //}
                    //lastSelectedButton = null;
                    //UnFocusButtons();
                    //print("Close clicked");
                    //return;s
                    closedPressed = true;
                }
            }
            catch (System.Exception e)
            {
                print(e.Message);
            }

            #region loading levels
            if (btn.name == Level1Btn.name)
            {
                ButtonsActions.LoadLevel1();
            }
            if (btn.name == Level2Btn.name)
            {
                ButtonsActions.LoadLevel2();
            }
            if (btn.name == Level3Btn.name)
            {
                ButtonsActions.LoadLevel3();
            }
            if (btn.name == Level4Btn.name)
            {
                ButtonsActions.LoadLevel4();
            }
            if (btn.name == Level5Btn.name)
            {
                ButtonsActions.LoadLevel5();
            }
            if (btn.name == Level6Btn.name)
            {
                ButtonsActions.LoadLevel6();
            }
            if (btn.name == Level7Btn.name)
            {
                ButtonsActions.LoadLevel7();
            }
            if (btn.name == Level8Btn.name)
            {
                ButtonsActions.LoadLevel8();
            }
            if (btn.name == Level9Btn.name)
            {
                ButtonsActions.LoadLevel9();
            }
            if (btn.name == Level10Btn.name)
            {
                ButtonsActions.LoadLevel10();
            }
            #endregion

            // show panel for corresponding button
            UnFocusButtons();
            foreach (Button button in buttonsForPanels)
            {
                if (btn == button)
                {
                    GameObject go = GOContainers[buttonsForPanels.IndexOf(button)];
                    go.gameObject.SetActive(!go.gameObject.activeSelf);
                    //button.GetComponent<Button>().Select(); // button already active?
                }
            }
        }
        void UnFocusButtons()
        {
            foreach (GameObject panel in GOContainers)
            {
                if (panel.gameObject.activeSelf == true)
                {
                    DeactivatePanels(GOContainers);
                    //foreach (Button button in buttons)
                    //{
                    //    //button.Select();
                    //    button.onClick.Invoke();
                    //    //var a = button.onClick();
                    //}
                }
            }
        }

        //void Destroy()
        //{
        //    SetupClicks(true);
        //}
        void SelectedActAsClickedCheck()
        {
            //print(EventSystem.current.currentSelectedGameObject);
            if (EventSystem.current.currentSelectedGameObject == null) //Null
            {
                //UnFocusButtons(); // when nothing is clicked, show no panels
                if (lastSelectedButton != null)
                {
                    lastSelectedButton.Select(); // reselect last selected button
                    SetAllButtonsFontColor(lastSelectedButton);
                }
                else
                {
                    SetAllButtonsFontColor();
                }
            }
            foreach (Button button in buttons)//buttonsForGOContainers)
            {
                CheckSelectedClicked(button); // check if a button is selected, then click it
            }
        }
        void CheckSelectedClicked(Button button)
        {
            if (button != null && EventSystem.current.currentSelectedGameObject == button.gameObject && !closedPressed)
            {
                //print($"selected: {button}");
                // click button if selected if a button for a panel
                if (buttonsForPanels.Contains(button))
                {
                    button.onClick.Invoke();
                }
                else if (buttons.Contains(button))
                {
                    button.Select();
                }
                SetAllButtonsFontColor(button); // this fixes button text not resetting?
            }
            else
            {
                //print("closedPressed reset");
                //closedPressed = false;
            }
        }

        //int frame = 0;
        //int frameCheck = 60;
        private void Update()
        {
            // could do but affects performance
            GameManager.IsMenuSceneCheck();
            if (!GameManager.isMenuScene)
            {
                SetupClicks(buttons, true); // destroy click handlers
            }
            else if (GameManager.isMenuScene)
            {
                // On menu scene...
                if (Coins == null && GameManager.minimumFramesRun) // playbtn example
                {
                    FullMenuSetup();
                    SelectedActAsClickedCheck(); // always checking if button is selected
                }
                else if (Coins != null)
                {
                    UpdateUITexts();
                    SelectedActAsClickedCheck(); // always checking if button is selected
                }
            }
        }

        private void UpdateUITexts()
        {
            //Title.text = $"{TitleText}";
            Coins.text = $"{CoinsText}{GameManager.coins}";
            MaxSpheresValue.text = $"{GunScript.maxSpheres}";
            //Instructions.text = $"{LevelText}{GameManager.currentLevel}";
            //Options.text = $"{LevelText}{GameManager.currentLevel}";
            //About.text = $"{LevelText}{GameManager.currentLevel}";
        }
    }
}