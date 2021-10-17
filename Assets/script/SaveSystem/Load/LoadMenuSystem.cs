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

    string SaveName = "";

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

    public void SelectedSave(string saveName)
    {
        SaveName = saveName;
    }

    public void LoadSave()
    {
        foreach(SavesPath save in savesFiles)
        {
            if(save.saveName == SaveName)
            {
                sceneText.text = save.saveName;
                string name = save.saveName.Split('.').First();

                sceneimage.sprite = Resources.Load<Sprite>(@"/SaveImage/16 - 10 - 2021 22 - 03 - 28.png") as Sprite;

                SerializationManager.Load(save.savePath);                
            }
        }
    }
    public void DeleteSave()
    {
        string path = Application.persistentDataPath + @"/saves/";
        File.Delete(path + SaveName + @".png");
        File.Delete(@"Assets/Resources/SaveImage/" + SaveName + @".png");
        ShowLoads();
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

