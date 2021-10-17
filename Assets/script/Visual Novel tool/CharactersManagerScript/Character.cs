using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Character {

    public string characterName;

    public string IdName;

    public Color Color;
    
    public  Character(string getname, string charactername, string color)
    {
        characterName = charactername;

        IdName = getname;

        try
        {
            ColorUtility.TryParseHtmlString(color, out Color);
        }
        catch
        {
            Debug.LogError("Invalidate hex code color format");
        }
    }
    
}
