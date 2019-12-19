using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    public float m_WaitToDie;
    
    void Start()
    {
        GameObject.Destroy(gameObject, m_WaitToDie);
    }
}
