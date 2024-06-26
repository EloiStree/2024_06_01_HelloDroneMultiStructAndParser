using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SNetworkToDebugArenaMono : MonoBehaviour
{
    public string m_devNote = "This script will be obsolete quickly.";
    public PullOfNetworkFromBytesMono m_pullOfNetworkFromBytesMono;
    public SDebug_BallGoals m_ballGoals;
    public SDebug_BallPosition m_ballPosition;
    public SDebug_DronePositions m_dronePositions;
    public SDebug_ProjectileDrawLine m_projectileDrawLine;
    public SDebug_SoccerArena m_soccerArena;


    public void Awake()
    {
        m_pullOfNetworkFromBytesMono.m_events.m_onBallPosition.AddListener(UpdateBallPosition);
        m_pullOfNetworkFromBytesMono.m_events.m_onDronePositions.AddListener(UpdateDronePosition);
        m_pullOfNetworkFromBytesMono.m_events.m_onMatchState.AddListener(UpdateMatchScore);
        m_pullOfNetworkFromBytesMono.m_events.m_onProjectileCreation.AddListener(ProjectileCreated);
        m_pullOfNetworkFromBytesMono.m_events.m_onDoubleGuidItemSpawn.AddListener(SpawnGUID);
        m_pullOfNetworkFromBytesMono.m_events.m_onDoubleGuidItemSpawn.AddListener(DestroyGUID);

        InvokeRepeating("Refresh", 1f, 1f);
        Refresh();
    }

    private void UpdateBallPosition(S_DroneSoccerBallPosition arg0)
    {
        m_ballPosition.SetWith(arg0);
    }

    private void UpdateDronePosition(S_DroneSoccerPositions arg0)
    {
        m_dronePositions.SetWith(arg0);
    }



    private void UpdateMatchScore(S_DroneSoccerMatchState arg0)
    {
    }

    private void ProjectileCreated(S_LinearProjectilePoolItemCreationEvent arg0)
    {
        m_projectileDrawLine.SetWith(arg0);
    }

    private void DestroyGUID(S_DoubleGuidItemSpawn arg0)
    {
    }

    private void SpawnGUID(S_DoubleGuidItemSpawn arg0)
    {
    }

    private void Refresh()
    {
        m_ballPosition.SetWith(m_pullOfNetworkFromBytesMono.m_lastReceived.m_ballPosition);
        m_ballPosition.SetWith(m_pullOfNetworkFromBytesMono.m_lastReceived.m_ballGoals);
        m_ballGoals.SetWith(m_pullOfNetworkFromBytesMono.m_lastReceived.m_ballGoals);
        m_dronePositions.SetWith(m_pullOfNetworkFromBytesMono.m_lastReceived.m_dronePositions);
        m_dronePositions.SetWith(m_pullOfNetworkFromBytesMono.m_lastReceived.m_matchStaticInfo);
        m_soccerArena.SetWith(m_pullOfNetworkFromBytesMono.m_lastReceived.m_matchStaticInfo);
    }
}
