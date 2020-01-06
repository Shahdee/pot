using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureEntity : MonoBehaviour
{
    static string fracturedPotTag = "Crate Fractured";

    void OnMouseDown(){
        var entityMan = MainLogic.GetMainLogic().GetEntityManager();
        
        var gobj = entityMan.GetEntity(fracturedPotTag);
        gobj.SetActive(true);
        gobj.transform.position = transform.position;
        gobj.transform.rotation = transform.rotation;
        gameObject.SetActive(false);
    }
}
