﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SpeedTutorMainMenuSystem
{
    public class MenuController : MonoBehaviour
    {
        #region Default Values
        [Header("Default Menu Values")]
   
        [SerializeField] private int defaultSen;
        [SerializeField] private bool defaultInvertY;

        [Header("Levels To Load")]
        public string _newGameButtonLevel;
        private string levelToLoad;

        private int menuNumber;
        #endregion

        #region Menu Dialogs
        [Header("Main Menu Components")]
        [SerializeField] private GameObject menuDefaultCanvas;
        [SerializeField] private GameObject GeneralSettingsCanvas;
        [SerializeField] private GameObject graphicsMenu;
        [SerializeField] private GameObject soundMenu;
        [SerializeField] private GameObject gameplayMenu;
        [SerializeField] private GameObject controlsMenu;
        [SerializeField] private GameObject confirmationMenu;
        [Space(10)]
        
        #endregion

        #region Slider Linking
        [Header("Menu Sliders")]
        [SerializeField] private Text controllerSenText;
        [SerializeField] private Slider controllerSenSlider;
        public float controlSenFloat = 2f;
        [Space(10)]
        [Space(10)]
        [SerializeField] private Text volumeText;
        [SerializeField] private Slider volumeSlider;
        [Space(10)]
        [SerializeField] private Toggle invertYToggle;
        #endregion

        #region Initialisation - Button Selection & Menu Order
        private void Start()
        {
            menuNumber = 1;
        }
        #endregion

        //MAIN SECTION
        public IEnumerator ConfirmationBox()
        {
            confirmationMenu.SetActive(true);
            yield return new WaitForSeconds(2);
            confirmationMenu.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuNumber == 2 || menuNumber == 7 || menuNumber == 8)
                {
                    GoBackToMainMenu();
                    ClickSound();
                }

                else if (menuNumber == 3 || menuNumber == 4 || menuNumber == 5)
                {
                    GoBackToOptionsMenu();
                    ClickSound();
                }

                else if (menuNumber == 6) //CONTROLS MENU
                {
                    GoBackToGameplayMenu();
                    ClickSound();
                }
            }
        }

        private void ClickSound()
        {
            GetComponent<AudioSource>().Play();
        }

        #region Menu Mouse Clicks
        public void MouseClick(string buttonType)
        {
            if (buttonType == "Controls")
            {
                gameplayMenu.SetActive(false);
                controlsMenu.SetActive(true);
                menuNumber = 6;
            }

            if (buttonType == "Graphics")
            {
                GeneralSettingsCanvas.SetActive(false);
                graphicsMenu.SetActive(true);
                menuNumber = 3;
            }

            if (buttonType == "Sound")
            {
                GeneralSettingsCanvas.SetActive(false);
                soundMenu.SetActive(true);
                menuNumber = 4;
            }

            if (buttonType == "Gameplay")
            {
                GeneralSettingsCanvas.SetActive(false);
                gameplayMenu.SetActive(true);
                menuNumber = 5;
            }

            if (buttonType == "Exit")
            {
                Debug.Log("YES QUIT!");
                Application.Quit();
            }

            if (buttonType == "Options")
            {
                menuDefaultCanvas.SetActive(false);
                GeneralSettingsCanvas.SetActive(true);
                menuNumber = 2;
            }

            if (buttonType == "NewGame")
            {
                menuDefaultCanvas.SetActive(false);
                
                //Esto sirve para pasar de escena.
                SceneManager.LoadScene(_newGameButtonLevel);
                menuNumber = 7;
            }
        }
        #endregion

        public void VolumeSlider(float volume)
        {
            AudioListener.volume = volume;
            volumeText.text = volume.ToString("0.0");
        }

        public void VolumeApply()
        {
            PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
            Debug.Log(PlayerPrefs.GetFloat("masterVolume"));
            StartCoroutine(ConfirmationBox());
        }

       
        public void ControllerSen()
        {
            controllerSenText.text = controllerSenSlider.value.ToString("0");
            controlSenFloat = controllerSenSlider.value;
        }

        public void GameplayApply()
        {
            if (invertYToggle.isOn) //Invert Y ON
            {
                PlayerPrefs.SetInt("masterInvertY", 1);
                Debug.Log("Invert" + " " + PlayerPrefs.GetInt("masterInvertY"));
            }

            else if (!invertYToggle.isOn) //Invert Y OFF
            {
                PlayerPrefs.SetInt("masterInvertY", 0);
                Debug.Log(PlayerPrefs.GetInt("masterInvertY"));
            }

            PlayerPrefs.SetFloat("masterSen", controlSenFloat);
            Debug.Log("Sensitivity" + " " + PlayerPrefs.GetFloat("masterSen"));

            StartCoroutine(ConfirmationBox());
        }

        #region ResetButton
        public void ResetButton(string GraphicsMenu)
        {


            if (GraphicsMenu == "Graphics")
            {
                controllerSenText.text = defaultSen.ToString("0");
                controllerSenSlider.value = defaultSen;
                controlSenFloat = defaultSen;

                invertYToggle.isOn = false;

                GameplayApply();
            }
        }
        #endregion

        #region Dialog Options - This is where we load what has been saved in player prefs!

        #endregion

        #region Back to Menus
        public void GoBackToOptionsMenu()
        {
            GeneralSettingsCanvas.SetActive(true);
            graphicsMenu.SetActive(false);
            soundMenu.SetActive(false);
            gameplayMenu.SetActive(false);

            GameplayApply();
            VolumeApply();

            menuNumber = 2;
        }

        public void GoBackToMainMenu()
        {
            menuDefaultCanvas.SetActive(true);
            GeneralSettingsCanvas.SetActive(false);
            graphicsMenu.SetActive(false);
            soundMenu.SetActive(false);
            gameplayMenu.SetActive(false);
            menuNumber = 1;
        }

        public void GoBackToGameplayMenu()
        {
            controlsMenu.SetActive(false);
            gameplayMenu.SetActive(true);
            menuNumber = 5;
        }

        public void ClickQuitOptions()
        {
            GoBackToMainMenu();
        }

        public void ClickNoSaveDialog()
        {
            GoBackToMainMenu();
        }
        #endregion
    }
}
