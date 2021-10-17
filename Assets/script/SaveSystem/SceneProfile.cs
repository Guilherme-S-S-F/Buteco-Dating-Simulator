using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class SceneProfile 
{
    public string currentScene = SceneManager.GetActiveScene().name;//Save the unity scene
    public int SaveIndex = Chapters.instance.index; //Save the current Scene
    public Sprite currentBackground = Backgrounds_ImagesChar.backgroundImage.sprite; //Save the Background Image
    public AudioClip currentMusic = AudioSystem.instance.Musicsource[0].clip; //Save the current music
    public List<CharacterData> characterDatas = new List<CharacterData>();

    private void Awake()
    {
        characterDatas.Add(new CharacterData(Backgrounds_ImagesChar.instance.character1));
        characterDatas.Add(new CharacterData(Backgrounds_ImagesChar.instance.character2));
        characterDatas.Add(new CharacterData(Backgrounds_ImagesChar.instance.character3));
        characterDatas.Add(new CharacterData(Backgrounds_ImagesChar.instance.character4));
    }
    //Character Image save data
    [System.Serializable]
    public class CharacterData
    {
        public string id;
        public Sprite currentCharacterImage; // save the characters image
        public GameObject Characters; //save the characters objects
        public Vector2 currentPositions;//save the characters positions
        
        public  CharacterData(GameObject chara)
        {            
            Characters = chara;
            currentPositions = chara.transform.position;
            currentCharacterImage = chara.GetComponent<Image>().sprite;
        }
    }
}
    
