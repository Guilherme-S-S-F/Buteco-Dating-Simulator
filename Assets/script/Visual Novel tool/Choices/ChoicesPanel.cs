using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ChoicesPanel : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] button;    
    public Text[] text;   

    Chapters chapter;    
    public  GameObject choicePanel;
    [HideInInspector]
    public static ChoicesPanel instance;    
    [HideInInspector]
    public int selectedbutton = 0;
    [Header("Configs")]
    public float spacing;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        chapter = GameObject.Find("Scene Manager").GetComponent<Chapters>();
        
        choicePanel.SetActive(false);
        selectedbutton = 0;
        
    }
    public void ChoiceButtons(int Quantity)
    {
        choicePanel.SetActive(true);
        if (Quantity == 1)
        {
            button[0].SetActive(true);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
        }
        if (Quantity == 2)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
            button[2].SetActive(false);
            button[3].SetActive(false);
        }
        if (Quantity == 3)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
            button[2].SetActive(true);
            button[3].SetActive(false);
        }
        if (Quantity == 4)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
            button[2].SetActive(true);
            button[3].SetActive(true);
        }
    }
    #region ButtonSelected
    public void Button1()
    {
        selectedbutton = 1;
        choicePanel.SetActive(false);
        chapter.NextDialog();
    }
    public void Button2()
    {
        selectedbutton = 2;
        choicePanel.SetActive(false);
        chapter.NextDialog();
    }
    public void Button3()
    {
        selectedbutton = 3;
        choicePanel.SetActive(false);
        chapter.NextDialog();
    }
    public void Button4()
    {
        selectedbutton = 4;
        choicePanel.SetActive(false);
        chapter.NextDialog();
    }
    #endregion ButtonSelected
}
