using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSoccerStructRelayMono : MonoBehaviour
{


    public void PushIn(CPSGroup.Structs relay)
    {
        m_events.m_onBallGoals.Invoke(relay.m_ballGoals);
        m_events.m_onBallPosition.Invoke(relay.m_ballPosition);
        m_events.m_onIndexIntegerClaim.Invoke(relay.m_indexIntegerClaim);
        m_events.m_onMatchState.Invoke(relay.m_matchState);
        m_events.m_onMatchStaticInfo.Invoke(relay.m_matchStaticInfo);
        m_events.m_onDronePositions.Invoke(relay.m_dronePositions);
        m_events.m_onRsa1024Claim.Invoke(relay.m_rsa1024Claim);
        m_events.m_onServerFrameTime.Invoke(relay.m_serverFrameTime);
        m_events.m_onTimeValue.Invoke(relay.m_timeValue);
        m_events.m_onProjectileCreation.Invoke(relay.m_projectileCreation);
        m_events.m_onDestructionEvent.Invoke(relay.m_destructionEvent);
        m_events.m_onDoubleGuidItemSpawn.Invoke(relay.m_doubleGuidItemSpawn);
        m_events.m_onDoubleGuidItemDestruction.Invoke(relay.m_doubleGuidItemDestruction);

    }

    public void PushIn(S_DroneSoccerBallGoals value)=> m_events.m_onBallGoals.Invoke(value);
    public void PushIn(S_DroneSoccerBallPosition value)=> m_events.m_onBallPosition.Invoke(value);
    public void PushIn(S_DroneSoccerIndexIntegerClaim value)=> m_events.m_onIndexIntegerClaim.Invoke(value);
    public void PushIn(S_DroneSoccerMatchState value)=> m_events.m_onMatchState.Invoke(value);
    public void PushIn(S_DroneSoccerMatchStaticInformation value)=> m_events.m_onMatchStaticInfo.Invoke(value);
    public void PushIn(S_DroneSoccerPositions value)=> m_events.m_onDronePositions.Invoke(value);
    public void PushIn(S_DroneSoccerPublicXmlRsaKey1024Claim value)=> m_events.m_onRsa1024Claim.Invoke(value);
    public void PushIn(S_NetworkGameFramePushTiming value)=> m_events.m_onServerFrameTime.Invoke(value);
    public void PushIn(S_DroneSoccerTimeValue value)=> m_events.m_onTimeValue.Invoke(value);
    public void PushIn(S_LinearProjectilePoolItemCreationEvent value)=> m_events.m_onProjectileCreation.Invoke(value);
    public void PushIn(S_PoolItemDestructionEvent value)=> m_events.m_onDestructionEvent.Invoke(value);
    public void PushIn(S_DoubleGuidItemSpawn value)=> m_events.m_onDoubleGuidItemSpawn.Invoke(value);
    public void PushIn(S_DoubleGuidItemDestruction value)=> m_events.m_onDoubleGuidItemDestruction.Invoke(value);


    public CPSGroup.Events m_events;
}
