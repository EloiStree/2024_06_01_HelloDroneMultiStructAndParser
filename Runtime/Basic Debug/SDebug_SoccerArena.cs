using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDebug_SoccerArena : MonoBehaviour
{

    public S_DroneSoccerMatchStaticInformation m_soccerArena;

    public Transform m_ground;
    public Transform m_goalRedInner;
    public Transform m_goalRedOuter;
    public Transform m_goalBlueInner;
    public Transform m_goalBlueOuter;


    [ContextMenu("Refresh")]
    public void Refresh()
    {

        SetWith(m_soccerArena);
    }

    public float m_groundHeight = 0.5f;
    public void SetWith(S_DroneSoccerMatchStaticInformation arena)
    {
        m_soccerArena = arena;
        m_ground.position= new Vector3(
            0,
            -m_groundHeight*0.5f,
            0
            );
        m_ground.localScale = new Vector3(
            arena.m_arenaWidthMeter,
            m_groundHeight,
            arena.m_arenaDepthMeter
            );

        Vector3 position = new Vector3(
            0,
            arena.m_goalCenterHeightMeter/2f,
            arena.m_goalDistanceOfCenterMeter
            );
        Vector3 inner = new Vector3(
            arena.m_goalInnerRadiusMeter,
            arena.m_goalInnerRadiusMeter,
            arena.m_goalDepthMeter
            );
        Vector3 outer = new Vector3(
            arena.m_goalOuterRadiusMeter,
            arena.m_goalOuterRadiusMeter,
            arena.m_goalDepthMeter*1.05f
            );

        m_goalRedInner.localScale = inner;
        m_goalRedOuter.localScale = outer;
        m_goalBlueInner.localScale = inner;
        m_goalBlueOuter.localScale = outer;

        m_goalRedInner.localPosition = SDebug_Relocation.RotatePointAroundPivot(position, Vector3.zero, new Vector3(0, 90, 0));
        m_goalBlueInner.localPosition = SDebug_Relocation.RotatePointAroundPivot(position, Vector3.zero, new Vector3(0, -90, 0));
        m_goalRedInner.localRotation = Quaternion.Euler(0, 90, 0);
        m_goalBlueInner.localRotation = Quaternion.Euler(0, -90, 0);
        m_goalBlueOuter.localPosition= m_goalBlueInner.localPosition;
        m_goalRedOuter.localPosition = m_goalRedInner.localPosition;
        m_goalBlueOuter.localRotation = m_goalBlueInner.localRotation;
        m_goalRedOuter.localRotation = m_goalRedInner.localRotation;


    }


    
}
