using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class ScreenShots : MonoBehaviour
{
    [Header("Panels")]
    public GameObject StartPanel;
    [HideInInspector]
    public ScreenShots instance;
    //Methods
    private void Start()
    {
        instance = this;
    }
    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        //Take the picture
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0,0,Screen.width,Screen.height), 0, 0);
        texture.Apply();
        //Save the picture
        string name = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".png";
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Resources/SaveImage/" + name,bytes);

        Destroy(texture);
        StartPanel.SetActive(true);
    }
    public void TakeScreenShot()
    {
        StartPanel.SetActive(false);
        StartCoroutine("Screenshot");
    }
}
