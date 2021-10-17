using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenuSystem : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject SavePrefab;
    public Image sceneimage;
    public Text sceneText;
    List<SavesPath> savesFiles = new List<SavesPath>();

   

    private void Start()
    {
        
    }
    public void ShowLoads()
    {
        
        string path = Application.persistentDataPath + @"/saves/";

        string[] files = Directory.EnumerateFiles(path).ToArray();
        

        foreach(string file in files)
        {
            GameObject item = Instantiate(SavePrefab);
            item.transform.SetParent(transform);
            item.name = Path.GetFileNameWithoutExtension(file);
            savesFiles.Add(new SavesPath( Path.GetFileName(file), file));
            Text text = item.GetComponentInChildren<Text>();
            text.text = Path.GetFileNameWithoutExtension(file);
            Debug.Log("funcionou");
            
        }

    }
    
    public void LoadSave(string SaveName)
    {
        foreach(SavesPath save in savesFiles)
        {
            if(save.saveName == SaveName)
            {
                sceneText.text = save.saveName;
                string name = save.saveName.Split('.').First();
              
                byte[] bytes = File.ReadAllBytes((Application.dataPath + "/Resources/SaveImage/" + name));
                sceneimage.sprite.texture.LoadImage(bytes);
                
                SerializationManager.Load(save.savePath);                
            }
        }
    }

}
public class SavesPath
{
    public  string saveName;
    public  string savePath;

    public SavesPath(string SaveName,string path)
    {
        saveName = SaveName;
        savePath = path;
    }
}

