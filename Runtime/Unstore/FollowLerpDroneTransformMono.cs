using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLerpDroneTransformMono : MonoBehaviour
{
    public Transform m_toFollow;
    public Transform m_toMove;


    public float m_lerpSpeed = 0.4f;
    public float m_rotateSpeed = 0.9f;

    void Update()
    {

        m_toMove.transform.position = Vector3.Lerp(m_toMove.transform.position, m_toFollow.transform.position, Time.deltaTime * m_lerpSpeed);
        m_toMove.transform.rotation = Quaternion.Lerp(m_toMove.transform.rotation, m_toFollow.transform.rotation, Time.deltaTime * m_rotateSpeed);
    }

    private void Reset()
    {
        m_toMove= transform;
    }
}
