using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Text;

public class Chapters : MonoBehaviour
{
    public static Chapters instance;
    #region Positions
    [Header("Vector2 Positions")]
    public Vector2[] position;
    #endregion Positions

    #region DialogueFiles
    string Chapter = "Chapter0";//Chapter which will be read
    public string Language;//language of the game as default PTBR
    int found = 0;
    string text;
    string readFilesPath; // To read the path of the file
    List<string> filesLines = new List<string>();//the list which will deposit the text lines 

    
    string character = "";
# endregion DialogueFiles
    #region Choices
    string ChoicesChapter = "Choices0";
    
    string readFilesPathChoices;
    List<string> ChoicesFile = new List<string>();
    #endregion Choices
    #region Variables

    //Gameobjects and other scripts
    DialogSystem dialog;
    AudioSystem audioplayer;
    Backgrounds_ImagesChar Sprites;
    ChoicesPanel choices;

    [Header("Get Character Manager")]
    public CharacterManager chara;
    public int index = 0;
    //Character movement defines
    #endregion Variables

    #region DefinePrincipalParameters
    private void Start()
    {
        instance = this;

        Language = PlayerPrefs.GetString("Language");
        //Gathering File Choices
        readFilesPathChoices = Application.streamingAssetsPath + "/Choices/" + ChoicesChapter + Language + ".txt";
        ChoicesFile = File.ReadAllLines(readFilesPathChoices).ToList();
        //Gathering the file
        readFilesPath = Application.streamingAssetsPath + "/StoryText/" + Chapter + Language + ".txt";
        filesLines = File.ReadAllLines(readFilesPath).ToList();

        //Definitions of objects
        Sprites = GameObject.Find("Scripts").GetComponent<Backgrounds_ImagesChar>();
        dialog = GameObject.Find("Scripts").GetComponent<DialogSystem>();
        //audioplayer = GameObject.Find("Scripts").GetComponent<AudioSystem>();
        choices = ChoicesPanel.instance;
        dialog.SetCharacter(chara);
        
        //start the new model of dialogues
        
        //Start game
        Prologue();
    }
    #endregion DefinePrincipalParameters
    private void Update()
    {        
    }
    
    /*This is a function to the button next and the event click,
     this events increases the variable index and in the prologue functions this variable define which dialog is the next*/
    public void NextDialog()
    {
        if (Sprites.isTransition == false)
        {
            if (dialog.isTyping == true)
            {
                dialog.skipTyping();
            }
            else if (dialog.isTyping == false)
            {
                index++;
                Prologue();
            }
        }
    }
    //This functions decrease the index to go back in the dialog and in the scenes
    public void BackDialog()
    {
        if (Sprites.isTransition == false)
        {
            if (index != 1)
            {
                if (dialog.isTyping == true)
                {
                    dialog.skipTyping();
                }
                else if (dialog.isTyping == false)
                {
                    index--;
                    Prologue();
                }
            }
        }
    }
    //<Summary> In the prologue are the dialog and scenes of the history which have to change according to the index
    #region Chapter Prologue
    void ChoiceGet(int ChoicesQuantity,int Line)
    {
        switch(ChoicesQuantity)
        {
            case 1:
                choices.text[0].text = ChoicesFile[Line].Split('+').First();
                break;
            case 2:
                choices.text[0].text = ChoicesFile[Line].Split('+').First();
                choices.text[1].text = ChoicesFile[Line].Split('+').Last();
                break;
            case 3:
                choices.text[0].text = ChoicesFile[Line].Split('+').First();
                choices.text[1].text = ChoicesFile[Line].Split('+')[1];
                choices.text[2].text = ChoicesFile[Line].Split('+').Last();
                break;
            case 4:
                choices.text[0].text = ChoicesFile[Line].Split('+').First();
                choices.text[1].text = ChoicesFile[Line].Split('+')[1];
                choices.text[2].text = ChoicesFile[Line].Split('+')[2];
                choices.text[3].text = ChoicesFile[Line].Split('+').Last();
                break;
        }
    }
    void StoryFormater(int Line)
    {
                                             
        if (filesLines[index].Contains("*"))
        {
           filesLines.Remove("*");
        }  
        else if(filesLines[Line].Contains("@"))
        {            
            //I dont know whats happen but it works, the current line of the text is splited and the first part
            //with the character prefix go to the variable character and the last to the text variable
            found = filesLines.IndexOf("@");
            character = filesLines[index].Split('+').First().Substring(found + 2);//First part of the line splited by "+"    
            text = filesLines[index].Split('+').Last();//Last part of the line splited by "+"
            
            dialog.WriteDialog(character, text);//Write the dialog
        }        
        
        
    }
    void Prologue()
    {        

        if (index == 1)
        {
            Sprites.HideChar(1); character = "j"; StoryFormater(1);
        }
        else if (index == 2)
        {
            Sprites.ShowCharDissolve(1, "Jeep-Happy"); StoryFormater(2);
        }
        else if (index == 3)
        {
            Sprites.DefaultTransition("bg_City"); StoryFormater(3); Sprites.MoveCharEaseOut(1, position[1], 3);
        }
        else if (index == 4)
        {
            Sprites.HideCharDissolve(1);StoryFormater(4);
        }
        else if (index == 5)
        {
            choices.ChoiceButtons(3); ChoiceGet(3, 1); StoryFormater(5);
        }        
    }
    # endregion Chapter Prologue
}
