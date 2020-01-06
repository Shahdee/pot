using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO 
// pots have different types - support it 

[System.Serializable]
public class PoolledEntity{
    public GameObject prototype;
    public int amountToPool;
    public bool expandable = false;

}

public class EntityManager : MonoBehaviour
{
    // pool for diff objects

    public List<PoolledEntity> entitiesToPool;
    
    Transform trsPoolParent;
    List<GameObject> objectsInPool;
    
    void Start(){
        trsPoolParent = transform;
        objectsInPool = new List<GameObject>();

        foreach(var entity in entitiesToPool){
            for (int i=0; i<entity.amountToPool; i++){
                AddEntityToPool(entity.prototype);            
            }
        }
    }

    GameObject AddEntityToPool(GameObject prototype){
        
        if (prototype == null) return null;

        var gobj = GameObject.Instantiate(prototype, Vector3.zero, Quaternion.identity);
        gobj.transform.SetParent(trsPoolParent);
        gobj.SetActive(false);
        objectsInPool.Add(gobj);

        return gobj;
    }

    public GameObject GetEntity(string tag){

        for (int i=0; i<objectsInPool.Count; i++){
            if (!objectsInPool[i].activeInHierarchy && objectsInPool[i].tag == tag){
                return objectsInPool[i]; // this can be accessed by several classes, cause it's not activated here
            }                
        }

        foreach(var entity in entitiesToPool){
            if (entity.expandable){
                if (entity.prototype.tag == tag){
                    return AddEntityToPool(entity.prototype);
                }
            }
        }

        return null;
    }   
}
