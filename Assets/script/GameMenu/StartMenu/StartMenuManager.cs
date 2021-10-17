using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject Menu;

    public static StartMenuManager instance;
    public ScreenShots screenShots;
    private bool isInMenu;
    
   
    private void Start()
    {       
        Menu.SetActive(false);//Hides the start Menu        
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1) & isInMenu == false )
        {
            ShowMenu();
        }
    }
    public void ShowMenu()
    {
        Menu.SetActive(true);
        isInMenu = true;
    }
    public void HideMenu()
    {
        Menu.SetActive(false);
        isInMenu = false;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("GameMenu");
        GameObject audio = GameObject.FindGameObjectWithTag("Music");
        Destroy(audio);
    }
    public void SaveGame()
    {        
        string name = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");        
        screenShots.TakeScreenShot();
        SerializationManager.Save(name, SaveData.current);
    }
    
}

