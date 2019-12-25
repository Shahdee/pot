using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

using UnityEngine.Tilemaps;

// visual representation of level


public class Level : MonoBehaviour, IInitable
{   

    [Header("Pot can be randomly placed here")]
    public Transform[] SpawnPoints;
    List<GameObject> AllLevelPots = new List<GameObject>();

    public void Init(){


    }

#region callbacks 
    UnityAction m_OnLevelGenerateCallback;

    public void AddLevelGenerateListener(UnityAction listener){
        m_OnLevelGenerateCallback += listener;
    }
    
    public void RemoveLevelGenerateListener(UnityAction listener){
        m_OnLevelGenerateCallback -= listener;
    }

    void OnLevelGenerate(){
        if (m_OnLevelGenerateCallback!=null)
            m_OnLevelGenerateCallback();
    } 
#endregion

    // put pots in place in level 
    public void Generate(int level){
        // var data = m_MainLogic.GetDataLoader().GetData();

        GeneratePots();

        OnLevelGenerate();
    }

    void GeneratePots(){
        var entittyMan = MainLogic.GetMainLogic().GetEntityManager();

        float random;
        GameObject gameObject;

        for (int i=0; i<SpawnPoints.Length; i++){
            random = Random.Range(0f, 1f);
            if (random > 0.5f){
                gameObject = entittyMan.GetEntity();
                if (gameObject != null){
                    gameObject.transform.SetParent(SpawnPoints[i], false);
                    AllLevelPots.Add(gameObject);
                }
            }
        }
    }
}
