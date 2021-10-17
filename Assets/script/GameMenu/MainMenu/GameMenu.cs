using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    //Variables
    
    [Header("Panels")]
    public GameObject MenuPanel;
    public GameObject LoadPanel;
    public GameObject[] OptionsPanel;

    [Header("Musics & Audio")]
    public Slider volumeSlider;    
    public AudioSystem audioSystem;    
    public Text AudioVolume;
    public float volumeValue;

    [Header("Typing")]
    public Slider typingSlider;
    float typeSpeed;

    [Header("Language")]
    public Dropdown Languages;

    
    //Methods
    private void Start()
    {
        //Starts Menu Alloweds
        MenuPanel.SetActive(true);
        OptionsPanel[0].SetActive(false);
        LoadPanel.SetActive(false);
        //Gets the volume saved value
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeGeneral");
        //gets the typing speed saved value
        typingSlider.value = PlayerPrefs.GetFloat("TypingSpeed") * 100;
        //Gets Language
        Languages.value = PlayerPrefs.GetInt("LanguageSelected");
        LanguageSelect();
    }
    private void Update()
    {
        audioSystem.PlayPlaylist();
        Volume();
        Typing();
        LanguageSelect();
    }
    
    #region Principal
    public void StartButton()
    {
        SceneManager.LoadScene("PrologueDemo");
    }
    public void LoadGame()
    {
        LoadPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
    public void Settings()
    {
        MenuPanel.SetActive(false);
        OptionsPanel[0].SetActive(true);
    }
    public void ExitButton()
    {
        //Use this on unity editor
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        //Use This was application
        //Application.Exit();
    }
    #endregion Principal
    #region Options
    public void OptionsBack()
    {
        MenuPanel.SetActive(true);
        OptionsPanel[0].SetActive(false);
    }
    public void Volume()
    {
        audioSystem.Musicsource[0].volume = volumeSlider.value / 100;
        AudioVolume.text = volumeSlider.value.ToString("F0");
        volumeValue = volumeSlider.value;        
    }    
    public void Typing()
    {
        typeSpeed = typingSlider.value / 100;
    }
    public void LanguageSelect()
    {
        PlayerPrefs.SetInt("LanguageSelected", Languages.value);
        switch (Languages.options[Languages.value].text)
        {
            case "Português BR":                
                PlayerPrefs.SetString("Language", "PTBR");
                break;
            case "English":
                PlayerPrefs.SetString("Language", "EN");
                break;
            case "Français":
                PlayerPrefs.SetString("Language", "FR");
                break;
        }
    }
    public void ApplyOptions()
    {
        PlayerPrefs.SetFloat("TypingSpeed", typeSpeed);
        PlayerPrefs.SetFloat("VolumeGeneral", volumeValue);
    }
    #endregion Options
    #region LoadGame
    public void BackLoad()
    {
        LoadPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    #endregion LoadGame
}
