using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushInNetworkAsBytesMono : MonoBehaviour
{

    public CPS_BytePerParsingTypeMono m_bytePerParsingType;
    public UnityEvent<byte[]> m_pushParseByte;


    public void PushIn( S_DroneSoccerBallPosition               value){
        CPS.CPS_DroneSoccerBallPosition.Parse(
            m_bytePerParsingType.m_data.m_byte_soccerBallPosition,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
        Debug.Log("PushIn( S_DroneSoccerBallPosition  )" + bytes.Length);
    }
    public void PushIn( S_DroneSoccerBallGoals                  value){
        CPS.CPS_DroneSoccerBallGoals.Parse(
            m_bytePerParsingType.m_data.m_byte_soccerBallGoals,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerIndexIntegerClaim          value){
        CPS.CPS_DroneSoccerIndexIntegerClaim.Parse(
            m_bytePerParsingType.m_data.m_byte_indexIntegerClaim,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerMatchState                 value){
        CPS.CPS_DroneSoccerMatchState.Parse(
            m_bytePerParsingType.m_data.m_byte_pointsState,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerMatchStaticInformation     value){
        CPS.CPS_DroneSoccerMatchStaticInformation.Parse(
            m_bytePerParsingType.m_data.m_byte_arenaStaticInformation,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerPositions                  value){
        CPS.CPS_DroneSoccerPositions.Parse(
            m_bytePerParsingType.m_data.m_byte_dronePositions,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_DroneSoccerPublicXmlRsaKey1024Claim   value){
        CPS.CPS_DroneSoccerPublicXmlRsaKey1024Claim.Parse(
            m_bytePerParsingType.m_data.m_byte_publicRsaKeyClaim,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);

    }
    public void PushIn( S_DroneSoccerTimeValue                  value){
        CPS .CPS_DroneSoccerTimeValue.Parse(
            m_bytePerParsingType.m_data.m_byte_matchTimeValue,
            value, out byte[] bytes);
            m_pushParseByte.Invoke(bytes);

    }
    public void PushIn( S_LinearProjectilePoolItemCreationEvent value){
        CPS.CPS_LinearProjectilePoolItemCreationEvent.Parse(
            m_bytePerParsingType.m_data.m_byte_projectileCreation,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_NetworkGameFramePushTiming            value){
        CPS.CPS_NetworkGameFramePushTiming.Parse(
            m_bytePerParsingType.m_data.m_byte_serverFrameTime,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
    public void PushIn( S_PoolItemDestructionEvent              value){
        CPS.CPS_PoolItemDestructionEvent.Parse(
            m_bytePerParsingType.m_data.m_byte_projectileDestruction,
            value, out byte[] bytes);
        m_pushParseByte.Invoke(bytes);
    }
}
