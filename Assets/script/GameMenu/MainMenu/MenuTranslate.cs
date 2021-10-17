using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class MenuTranslate : MonoBehaviour
{
    [Header("Menu Texts")]
    public Text[] AllText;    
    [Header("File Reader")]
    string FilePath;
    string Language;
    List<string> AllLines = new List<string>();
    private void Start()
    {
        Language = PlayerPrefs.GetString("Language");
        FilePath = Application.streamingAssetsPath + "/Menu/Menu" + Language + ".txt";
        AllLines = File.ReadAllLines(FilePath).ToList();
        ChangeLanguage();
    }
    private void Update()
    {
        ChangeLanguage();
    }
    public void ChangeLanguage()
    {
        Language = PlayerPrefs.GetString("Language");
        FilePath = Application.streamingAssetsPath + "/Menu/Menu" + Language + ".txt";
        AllLines = File.ReadAllLines(FilePath).ToList();
        //Set the text language       
       for(int i = 0;i< AllText.Length; i++)
        {
            AllText[i].text = AllLines[i].ToString();
        }
    }
}
