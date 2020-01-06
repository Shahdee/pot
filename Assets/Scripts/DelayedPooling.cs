using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedPooling : MonoBehaviour
{
    public float waitBeforePooling = 2;

    void OnEnable()
    {
        StartCoroutine(WaitToPool());        
    }

    IEnumerator WaitToPool(){
        yield return new WaitForSeconds(waitBeforePooling);

        gameObject.SetActive(false); // this makes sure that the object returns back to pool. Check GetEntity method in EntityManager
    }
}
