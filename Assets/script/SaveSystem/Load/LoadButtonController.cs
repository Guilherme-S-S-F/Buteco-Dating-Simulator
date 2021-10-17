using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadButtonController : MonoBehaviour
{
    //Active a event on click    
    public void Click()
    {  
        transform.parent.GetComponent<LoadMenuSystem>().SelectedSave(this.name);
    }
}
