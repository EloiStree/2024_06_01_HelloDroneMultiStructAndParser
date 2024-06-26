using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SDebug_DronePositions : MonoBehaviour
{
    public S_DroneSoccerPositions m_dronePositions;
    public S_DroneSoccerMatchStaticInformation m_matchStaticInfo;
    [Header("Transforms")]
    public Transform[] m_drones;
    public Transform[] m_setDroneSize;

    public UnityEvent<Vector3> m_onDroneScale;

    public void SetWith(S_DroneSoccerMatchStaticInformation matchStaticInfo)
    {
        m_matchStaticInfo = matchStaticInfo;
        float r = matchStaticInfo.m_droneSphereRadiusMeter;
        for (int i = 0; i < m_drones.Length; i++)
        {
            if (m_drones[i] != null)
                m_drones[i].localScale = new Vector3(r, r, r);
        }
        for (int i = 0; i < m_setDroneSize.Length; i++)
        {
            if (m_setDroneSize[i] != null)
                m_setDroneSize[i].localScale = new Vector3(r, r, r);
        }
        m_onDroneScale.Invoke(new Vector3(r,r,r));
    }


    public void SetWith(S_DroneSoccerPositions positions)
    {
            int droneCount = m_drones.Length;
            m_dronePositions = positions;
            if( droneCount>=1)  Set(m_drones[0 ], positions.m_redDrone0Stricker);
            if (droneCount>=2)  Set(m_drones[1 ], positions.m_redDrone1); 
            if( droneCount>=3)  Set(m_drones[2 ], positions.m_redDrone2); 
            if( droneCount>=4)  Set(m_drones[3 ], positions.m_redDrone3); 
            if( droneCount>=5)  Set(m_drones[4 ], positions.m_redDrone4); 
            if( droneCount>=6)  Set(m_drones[5 ], positions.m_redDrone5); 
            if( droneCount>=7)  Set(m_drones[6 ], positions.m_blueDrone0Stricker);
            if( droneCount>=8)  Set(m_drones[7 ], positions.m_blueDrone1); 
            if( droneCount>=9)  Set(m_drones[8 ], positions.m_blueDrone2); 
            if( droneCount>=10) Set(m_drones[9 ], positions.m_blueDrone3); 
            if( droneCount>=11) Set(m_drones[10], positions.m_blueDrone4); 
            if( droneCount>=12) Set(m_drones[11], positions.m_blueDrone5); 
    }

    private void Set(Transform transform, S_DronePositionCompressed drone)
    {
        if(transform == null) return;
        drone.GetPosition(out Vector3 position, out Quaternion rotation);
        transform.localPosition = position;
        transform.localRotation = rotation;


    }
}
