using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Backgrounds_ImagesChar :MonoBehaviour
{
   public static Backgrounds_ImagesChar instance;
    #region Character Variables
    Transform a;
    Transform b;
    Transform c;
    Transform d;
    GameObject CharacterPanel;
    [Header("Character Images Holder")]
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;
    public Animator[] animator;

    public List<ImagesChar> Character_Image = new List<ImagesChar>();

    
    #endregion Character Variables

    #region background Variables
    Image BlackPanelImage;
    static GameObject BlackPanel;

    [HideInInspector]
    public bool isTransition = false;
   
    
    public List<Background> Backgrounds = new List<Background>();

    public static Image backgroundImage;
    Image CharacterImage;

    Animator trasition;
# endregion background Variables

    private void Start()
    {
        instance = this;
        #region Background 
        //Backgrounds getting components
        backgroundImage = GameObject.Find("Background1").GetComponent<Image>();
        BlackPanelImage = GameObject.Find("BlackPanel").GetComponent<Image>();
        BlackPanel = GameObject.Find("BlackPanel");
        trasition = GameObject.Find("BlackPanel").GetComponent<Animator>();

        BlackPanel.SetActive(false);
        #endregion Background

        #region Character
        HideAll();       
        
        CharacterPanel = GameObject.Find("Panel-Character");
         
       
        #endregion Character

    }
    #region Character Methods
    #region ShowChar
    public void ShowChar(int charField,string spriteName)
    {
         
        ImagesChar chara = new ImagesChar();
        
        foreach(ImagesChar c in Character_Image)
        {
            if(c.Name == spriteName)
            {
                chara.CharacterImage = c.CharacterImage;
            }
        }
        
        switch(charField)
        {
            case 1:
                character1.SetActive(true);
                character1.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
            case 2:
                character2.SetActive(true);
                character2.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
            case 3:
                character3.SetActive(true);
                character3.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
            case 4:
                character4.SetActive(true);
                character4.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
        }
    }
    public void ShowCharDissolve(int charField, string spriteName)
    {
        ImagesChar chara = new ImagesChar();

        foreach (ImagesChar c in Character_Image)
        {
            if (c.Name == spriteName)
            {
                chara.CharacterImage = c.CharacterImage;
            }
        }
        
        switch (charField)
        {
            case 1:
                character1.SetActive(true);
                animator[0].Play("FadeChar");
                character1.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
            case 2:
                character2.SetActive(true);
                animator[1].Play("FadeChar");
                character2.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
            case 3:
                character3.SetActive(true);
                animator[2].Play("FadeChar");
                character3.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
            case 4:
                character4.SetActive(true);
                animator[3].Play("FadeChar");
                character4.GetComponent<Image>().sprite = chara.CharacterImage;
                break;
        }
    }//Show the character with dissolve effects
    public void HideChar(int charField)
    {
        switch (charField)
        {
            case 1:
                character1.SetActive(false);
                character1.GetComponent<Image>().sprite = null;
                break;
            case 2:
                character2.SetActive(false);
                character2.GetComponent<Image>().sprite = null;
                break;
            case 3:
                character3.SetActive(false);
                character3.GetComponent<Image>().sprite = null;
                break;
            case 4:
                character4.SetActive(false);
                character4.GetComponent<Image>().sprite = null;
                break;
        }
    }
    public void HideCharDissolve(int charField)
    {
        switch (charField)
        {
            case 1:
                animator[0].Play("FadeOutChar");
                StartCoroutine(DissolveCharHide(1));
                break;
            case 2:
                animator[1].Play("FadeOutChar");
                StartCoroutine(DissolveCharHide(2));
                break;
            case 3:
                animator[2].Play("FadeOutChar");
                StartCoroutine(DissolveCharHide(3));
                break;
            case 4:
                animator[3].Play("FadeOutChar");
                StartCoroutine(DissolveCharHide(4));
                break;
        }
    }//Hide the character with dissolve effects
    public void HideAll()
    {
        character1.SetActive(false);
        character2.SetActive(false);
        character3.SetActive(false);
        character4.SetActive(false);
    }
    #endregion ShowChar
    public void MoveChar(int charField,Vector2 position,float speed)
    {
         a = character1.GetComponent<Transform>();
         b = character2.GetComponent<Transform>();
         c = character3.GetComponent<Transform>();
         d = character4.GetComponent<Transform>();
        speed = speed * 0.5f;
        switch (charField)
        {
            case 1:
                a.LeanMoveLocal(position, speed).setEaseLinear();
                break;
            case 2:
                b.LeanMoveLocal(position, speed).setEaseLinear();
                break;
            case 3:
                c.LeanMoveLocal(position, speed).setEaseLinear();
                break;
            case 4:
                d.LeanMoveLocal(position, speed).setEaseLinear();
                break;
        }
    }
    public void MoveCharEaseOut(int charField, Vector2 position, float speed)
    {
        a = character1.GetComponent<Transform>();
        b = character2.GetComponent<Transform>();
        c = character3.GetComponent<Transform>();
        d = character4.GetComponent<Transform>();
        switch (charField)
        {
            case 1:
                a.LeanMoveLocal(position, speed).setEaseOutQuart();
                break;
            case 2:
                b.LeanMoveLocal(position, speed).setEaseOutQuart();
                break;
            case 3:
                c.LeanMoveLocal(position, speed).setEaseOutQuart();
                break;
            case 4:
                d.LeanMoveLocal(position, speed).setEaseOutQuart();
                break;
        }
    }
    #endregion Character Methods


    #region Background Methods
    public void ChangeScene(string BackgroundName)
    {        
        foreach(Background b in Backgrounds)
        {
            if(b.Name == BackgroundName)
            {
                backgroundImage.sprite = b.background;
            }
        }
    }
    public void DefaultTransition(string BackgroundName)
    {
        StartCoroutine(DefaultTransitionDelay(BackgroundName));
    }
    #region delayTask
    public IEnumerator DefaultTransitionDelay(string BackgroundName)
    {
        isTransition = true;
        BlackPanel.SetActive(true);
        trasition.Play("Fade");
        yield return new WaitForSeconds(0.30f);
        ChangeScene(BackgroundName);
        trasition.Play("FadeReverse");
        yield return new WaitForSeconds(0.30f);
        BlackPanel.SetActive(false);
        isTransition = false;
    }
    public IEnumerator DissolveCharHide(int character)
    {
        switch(character)
        {
            case 1:
                yield return new WaitForSeconds(1);
                character1.SetActive(false);
                character1.GetComponent<Image>().sprite = null;                
                break;
            case 2:
                yield return new WaitForSeconds(1);
                character2.SetActive(false);
                character2.GetComponent<Image>().sprite = null;                
                break;
            case 3:
                yield return new WaitForSeconds(1);
                character3.SetActive(false);
                character3.GetComponent<Image>().sprite = null;                
                break;
            case 4:
                yield return new WaitForSeconds(1);
                character4.SetActive(false);
                character4.GetComponent<Image>().sprite = null;                
                break;
        }
    }
    #endregion delayTask

    #endregion Background Methods

    #region Class
    [Serializable]
    public class ImagesChar
    {
        public string Name;
        public Sprite CharacterImage;
    }
    [Serializable]
    public class Background
    {
       public string Name;
       public Sprite background;
    }
    #endregion

}
