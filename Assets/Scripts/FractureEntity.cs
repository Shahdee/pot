using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureEntity : MonoBehaviour
{
    public GameObject m_Fractured;

    void OnMouseDown(){

        Instantiate(m_Fractured, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
