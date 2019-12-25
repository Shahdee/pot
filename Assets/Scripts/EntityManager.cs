using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO 
// pool is working with gameobjects - improve it 
// pots have different types - support it 

public class EntityManager : MonoBehaviour, IInitable
{
    // instantiate objects  

    public GameObject m_Pot;
    public Transform m_TrsPoolParent;
    List<GameObject> m_ObjectsInPool = new List<GameObject>();

    public void Init(){

    }

    // pool

    public GameObject GetEntity(){

        GameObject gameObject = GetFromPool();

        if (gameObject != null){
            gameObject.SetActive(true);
            return gameObject;
        }
        else{            
            gameObject = GameObject.Instantiate(m_Pot, Vector3.zero, Quaternion.identity);
        }
        return gameObject;
    }

    public void ReturnToPool(GameObject gobj){

        // Debug.LogError("ReturnToPool " + obj);

        m_ObjectsInPool.Add(gobj);
        gobj.transform.SetParent(m_TrsPoolParent);
        gobj.gameObject.SetActive(false);
    }

    GameObject GetFromPool(){
        if (m_ObjectsInPool.Count > 0){
            GameObject gobj = m_ObjectsInPool[m_ObjectsInPool.Count-1];
            m_ObjectsInPool.RemoveAt(m_ObjectsInPool.Count-1);
            return gobj;
        }
        return null;
    }
}
