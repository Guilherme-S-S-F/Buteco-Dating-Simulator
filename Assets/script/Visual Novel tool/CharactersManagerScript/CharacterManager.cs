using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    Character character;
    
    public List<Character> charactersList = new List<Character>();

    [HideInInspector]
    public Text nametext;

    private void Start()
    {        
        nametext = GameObject.Find("TextName").GetComponent<Text>();
    }

    //Creates a new character
    public void Define(string IdName,string charaName,string hexCode)
    {             
        character = new Character(IdName, charaName, hexCode);
        charactersList.Add(character);          
        
    }

    //Remove a character from the characterList using the IdName as parameter
    public void Remove(string IdName)
    {
        foreach(Character c in charactersList)
        {
            if(c.IdName == IdName)
            {
                charactersList.Remove(c);
            }
            else
            {
                Debug.LogWarning($"Character with ID: {IdName} Doesn't exist. ");
            }
        }
    }

    //Get a character from list using the character id.
    public void GetCharacter(string IdName)
    {
        foreach(Character c in charactersList)
        {
            if(c.IdName == IdName)
            {
                nametext.text = c.characterName;
                nametext.color = c.Color;
            }
        }
    }
}
