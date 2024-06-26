using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDebug_ProjectileDrawLine : MonoBehaviour
{

    public S_LinearProjectilePoolItemCreationEvent m_projectileCreation;

    public Transform m_debugSpawn;
    public Transform m_debugSpawnDirectionStart;
    public Transform m_debugSpawnDirectionEnd;

    public void SetWith(S_LinearProjectilePoolItemCreationEvent projectileCreation)
    {


        Vector3 start = projectileCreation.m_startPosition;
        Vector3 end = projectileCreation.m_startPosition + projectileCreation.m_startDirection * 5;

        m_projectileCreation = projectileCreation;
        m_debugSpawn.localPosition = projectileCreation.m_startPosition;
        m_debugSpawn.localRotation = projectileCreation.m_startRotation;
        m_debugSpawnDirectionStart.localPosition = start;
        m_debugSpawnDirectionEnd.localPosition = end;
        float r= projectileCreation. m_colliderRadius;
        Debug.DrawLine(m_debugSpawnDirectionStart.position, m_debugSpawnDirectionEnd.position, Color.yellow, 10);
        m_debugSpawn.localScale = new Vector3(r, r, r);
        m_debugSpawnDirectionStart.localScale = new Vector3(r, r, r);
        m_debugSpawnDirectionEnd.localScale = new Vector3(r, r, r);
    }
}
