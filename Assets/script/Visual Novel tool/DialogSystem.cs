using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;


public class DialogSystem : MonoBehaviour
{
    [HideInInspector]
    public string currentText = "";
    [HideInInspector]
    public bool isTyping;
    [HideInInspector]
    public string savetext;
    [HideInInspector]
    bool skipnow = false;
    [Range(0.01f, 0.2f)]
    public float TypingSpeed = 0.1f;
    [Header("Select the Dialog text")]
    public Text DialogText;

    CharacterManager chara;

    private void Start()
    {
        TypingSpeed = PlayerPrefs.GetFloat("TypingSpeed") /12;
    }
    #region Character
    //Creates a new character
    public void SetCharacter(CharacterManager character)
    {
        chara = character;
    }

    public void DefineCharacter(string IdName,string charaName,string hexCode)
    {
        chara.Define(IdName, charaName, hexCode);
    }
    //Remove a character of the list
    public void RemoveCharacter(string Id)
    {
        chara.Remove(Id);
    }
    #endregion Character

    #region Dialog
    //Write the Dialog with the effect of typing and with the character name set
    public void WriteDialog(string Id,string text)
    {
        
        chara.GetCharacter(Id);
        StartCoroutine(ShowText(text));
    }
    //Skip the typing effect
    public void skipTyping()
    {
        skipnow = true;        
    }
    //Write the Dialog with the effect of typing and without the character name set
    public IEnumerator ShowText(string fulltext)
    {
        savetext = fulltext;
        skipnow = false;
        for (int i = 0; i <= fulltext.Length; i++)
        {
            if (skipnow == false)
            {
                currentText = fulltext.Substring(0, i);
                DialogText.text = currentText;

                isTyping = true;
                yield return new WaitForSeconds(TypingSpeed);
            }
            else if (skipnow == true)
            {
                DialogText.text = fulltext;
            }
        }
        isTyping = false;
    }
    #endregion Dialog
}
