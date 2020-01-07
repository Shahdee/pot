using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureEntity : MonoBehaviour
{
    static string fracturedPotTag = "Crate Fractured"; // TODO how do I retrieve prefab name and isolate it?

    void OnMouseDown(){
        SubstituteWithFractured();
    }

    void SubstituteWithFractured(){
        var entityMan = MainLogic.GetMainLogic().GetEntityManager();
        
        var gobj = entityMan.GetEntity(fracturedPotTag);
        gobj.SetActive(true);
        gobj.transform.position = transform.position;
        gobj.transform.rotation = transform.rotation;
        gameObject.SetActive(false);
    }
}
