using UnityEngine;

public class MoveEntity : MonoBehaviour
{
    Transform m_Transform;
    public Vector3 m_Velocity;
    Vector3 m_VcMove;

    void Start()
    {
        m_Transform = transform;
    }

    void Update()
    {
        m_VcMove = m_Transform.position;
        m_VcMove.x += m_Velocity.x * Time.deltaTime;
        m_VcMove.y += m_Velocity.y * Time.deltaTime;
        m_VcMove.z += m_Velocity.z * Time.deltaTime;
        m_Transform.position = m_VcMove;
    }
}
