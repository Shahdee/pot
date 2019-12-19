using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject m_Crate;
    public Vector3 m_SpawnValues;
    public float m_MinTimeToSpawn;
    public float m_MaxTimeToSpawn;
    public bool m_Spawning = true;
    public float m_WaitToSpawn;
    Transform m_Transform;
    Vector3 m_SpawnPosition;

    void Awake(){
        m_Transform = transform;
    }

    void Start()
    {
        m_WaitToSpawn = Random.Range(m_MinTimeToSpawn, m_MaxTimeToSpawn);
        StartCoroutine(WaitToSpawn());
    }

    IEnumerator WaitToSpawn(){
        yield return new WaitForSeconds(m_WaitToSpawn);

        while(m_Spawning){

            m_SpawnPosition.x = Random.Range(-m_SpawnValues.x, m_SpawnValues.x);
            m_SpawnPosition.y = m_SpawnValues.y;
            m_SpawnPosition.z = Random.Range(-m_SpawnValues.z, m_SpawnValues.z);

            Instantiate(m_Crate, m_SpawnPosition, m_Transform.rotation);

            m_WaitToSpawn = Random.Range(m_MinTimeToSpawn, m_MaxTimeToSpawn);

            yield return new WaitForSeconds(m_WaitToSpawn);
        }        
    }
}
