using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushInNetworkAsBytesMono : MonoBehaviour
{

    public CPS_BytePerParsingTypeMono m_bytePerParsingType;
    public UnityEvent<byte[]> m_pushParseByte;


    public void PushInAllAsGroup(CPSGroup.Structs all) {

        PushIn(all.m_ballPosition);
        PushIn(all.m_ballGoals);
        PushIn(all.m_dronePositions);
        PushIn(all.m_indexIntegerClaim);
        PushIn(all.m_rsa1024Claim);
        PushIn(all.m_matchState);
        PushIn(all.m_matchStaticInfo);
        PushIn(all.m_projectileCreation);
        PushIn(all.m_destructionEvent);
        PushIn(all.m_serverFrameTime);
        PushIn(all.m_timeValue);
        PushIn(all.m_doubleGuidItemSpawn);
        PushIn(all.m_doubleGuidItemDestruction);



    }

    public void PushIn( S_DroneSoccerBallPosition               value){
        CPS.CPS_DroneSoccerBallPosition.Parse(
            m_bytePerParsingType.m_data.m_byteSoccerBallPosition,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerBallGoals                  value){
        CPS.CPS_DroneSoccerBallGoals.Parse(
            m_bytePerParsingType.m_data.m_byteSoccerBallGoals,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerIndexIntegerClaim          value){
        CPS.CPS_DroneSoccerIndexIntegerClaim.Parse(
            m_bytePerParsingType.m_data.m_byteIndexIntegerClaim,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerMatchState                 value){
        CPS.CPS_DroneSoccerMatchState.Parse(
            m_bytePerParsingType.m_data.m_bytePointsState,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerMatchStaticInformation     value){
        CPS.CPS_DroneSoccerMatchStaticInformation.Parse(
            m_bytePerParsingType.m_data.m_byteArenaStaticInformation,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerPositions                  value){
        CPS.CPS_DroneSoccerPositions.Parse(
            m_bytePerParsingType.m_data.m_byteDronePositions,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerPublicXmlRsaKey1024Claim   value){
        CPS.CPS_DroneSoccerPublicXmlRsaKey1024Claim.Parse(
            m_bytePerParsingType.m_data.m_bytePublicRsaKeyClaim,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);

    }
    public void PushIn( S_DroneSoccerTimeValue                  value){
        CPS .CPS_DroneSoccerTimeValue.Parse(
            m_bytePerParsingType.m_data.m_byteMatchTimeValue,
            value, out byte[] bytes);
            m_pushParseByte.Invoke(bytes);

    }
    public void PushIn( S_LinearProjectilePoolItemCreationEvent value){
        CPS.CPS_LinearProjectilePoolItemCreationEvent.Parse(
            m_bytePerParsingType.m_data.m_byteProjectileCreation,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_NetworkGameFramePushTiming            value){
        CPS.CPS_NetworkGameFramePushTiming.Parse(
            m_bytePerParsingType.m_data.m_byteServerFrameTime,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_PoolItemDestructionEvent              value){
        CPS.CPS_PoolItemDestructionEvent.Parse(
            m_bytePerParsingType.m_data.m_byteProjectileDestruction,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DoubleGuidItemSpawn              value){
        CPS.CPS_DoubleGuidItemSpawn.Parse(
            m_bytePerParsingType.m_data.m_byteDoubleGuidItemSpawn,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn(S_DoubleGuidItemDestruction value){
        CPS.CPS_DoubleGuidItemDestruction.Parse(
            m_bytePerParsingType.m_data.m_byteDoubleGuidItemDestruction,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
}
