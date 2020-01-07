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
        GeneratePots(level);
        OnLevelGenerate();
    }

    void GeneratePots(int level){

        var entittyMan = MainLogic.GetMainLogic().GetEntityManager();
        var data = MainLogic.GetMainLogic().GetGameData();

        var currRoom = data.rooms[level];

        float random;
        GameObject gameObject;

        for (int i=0; i<SpawnPoints.Length; i++){
            random = Random.Range(0f, 1f);
            for (int j=0; j<currRoom.pots.Length; j++){

                // place pot
                if (random <= currRoom.pots[j].probability){

                    // TODO I need to isolate code that searches for an appropriate pot 
                    for (int k=0; k<data.pots.Length; k++){
                        if (data.pots[k].potID == currRoom.pots[j].potID){
                            gameObject = entittyMan.GetEntity(data.pots[k].prefab);
                            if (gameObject != null){
                            
                                gameObject.SetActive(true);
                                gameObject.transform.position = SpawnPoints[i].position;

                                AllLevelPots.Add(gameObject);
                            }
                            break;
                        }
                    }
                    break;
                }
            }           
        }
    }
}
