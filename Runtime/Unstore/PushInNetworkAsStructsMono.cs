using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushInNetworkAsStructsMono : MonoBehaviour
{

    public CPSGroup.Structs m_lastReceived;
    public CPSGroup.Events m_events;


    [ContextMenu("Push All Structs")]
    public void PushAllStructs() { 
    
        m_events.m_timeValue.Invoke(m_lastReceived.m_timeValue);
        m_events.m_ballGoals.Invoke(m_lastReceived.m_ballGoals);
        m_events.m_dronePositions.Invoke(m_lastReceived.m_dronePositions);
        m_events.m_indexIntegerClaim.Invoke(m_lastReceived.m_indexIntegerClaim);
        m_events.m_rsa1024Claim.Invoke(m_lastReceived.m_rsa1024Claim);
        m_events.m_matchState.Invoke(m_lastReceived.m_matchState);
        m_events.m_matchStaticInfo.Invoke(m_lastReceived.m_matchStaticInfo);
        m_events.m_projectileCreation.Invoke(m_lastReceived.m_projectileCreation);
        m_events.m_destructionEvent.Invoke(m_lastReceived.m_destructionEvent);
        m_events.m_serverFrameTime.Invoke(m_lastReceived.m_serverFrameTime);
        m_events.m_ballPosition.Invoke(m_lastReceived.m_ballPosition);

    }

    [ContextMenu("Push Randomize Data")]
    public void PushRandomizedData() {
        RandomizedData();
        PushAllStructs();

    }

    [ContextMenu("Randomize Data")]
    public void RandomizedData() {

        CPS.CPS_NetworkGameFramePushTiming.Randomize(m_lastReceived.m_serverFrameTime, out m_lastReceived.m_serverFrameTime);
        CPS.CPS_DroneSoccerTimeValue.Randomize(m_lastReceived.m_timeValue , out m_lastReceived.m_timeValue);
        CPS.CPS_DroneSoccerBallPosition.Randomize(m_lastReceived.m_ballPosition , out m_lastReceived.m_ballPosition);
        CPS.CPS_DroneSoccerBallGoals.Randomize(m_lastReceived.m_ballGoals , out m_lastReceived.m_ballGoals);
        CPS.CPS_DroneSoccerPositions.Randomize(m_lastReceived.m_dronePositions , out m_lastReceived.m_dronePositions);
        CPS.CPS_DroneSoccerMatchState.Randomize(m_lastReceived.m_matchState , out m_lastReceived.m_matchState);
        CPS.CPS_DroneSoccerMatchStaticInformation.Randomize(m_lastReceived.m_matchStaticInfo , out m_lastReceived.m_matchStaticInfo);
        CPS.CPS_DroneSoccerIndexIntegerClaim.Randomize(m_lastReceived.m_indexIntegerClaim , out m_lastReceived.m_indexIntegerClaim);
        CPS.CPS_DroneSoccerPublicXmlRsaKey1024Claim.Randomize(m_lastReceived.m_rsa1024Claim , out m_lastReceived.m_rsa1024Claim);
        CPS.CPS_LinearProjectilePoolItemCreationEvent.Randomize(m_lastReceived.m_projectileCreation , out m_lastReceived.m_projectileCreation);
        CPS.CPS_PoolItemDestructionEvent.Randomize(m_lastReceived.m_destructionEvent , out m_lastReceived.m_destructionEvent);

    }
}
