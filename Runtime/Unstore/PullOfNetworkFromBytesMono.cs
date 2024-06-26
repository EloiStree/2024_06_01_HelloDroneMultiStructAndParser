using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PullOfNetworkFromBytesMono : MonoBehaviour
{
    public CPS_BytePerParsingTypeMono m_bytePerParsingType;

    public UnityEvent< byte[] > m_bytesReceived;
    public UnityEvent<object> m_onReceivedObject;
    public string m_lastReceivedString = "";
    public CPSGroup.Events m_events;
    public CPSGroup.Structs m_lastReceived;


    public byte m_lastByteType = 0;
    public bool m_copyTheBytes=true;
    public void PushInByte(byte[] bytes) { 
    
        if(m_copyTheBytes) {
            byte[] copy = new byte[bytes.Length];
            bytes.CopyTo(copy, 0);
            bytes = copy;
        }
        if( bytes==null || bytes.Length == 0) return;
        byte bytesType = bytes[0];
        m_lastByteType = bytesType;
        m_lastReceivedString = DateTime.Now.ToString("HH:mm:ss.fff") + " " + bytesType.ToString() + " " + bytes.Length.ToString() + " bytes";

        if (m_lastByteType == m_bytePerParsingType.m_data.m_byte_serverFrameTime) { 
        
            CPS.CPS_NetworkGameFramePushTiming.TryParse(bytes, out _, out m_lastReceived.m_serverFrameTime);
            m_events.m_serverFrameTime.Invoke(m_lastReceived.m_serverFrameTime);
            m_onReceivedObject.Invoke(m_lastReceived.m_serverFrameTime);
        }

        if(m_lastByteType== m_bytePerParsingType.m_data.m_byte_projectileCreation){
            CPS.CPS_LinearProjectilePoolItemCreationEvent.TryParse(bytes, out _, out m_lastReceived.m_projectileCreation);
            m_events.m_projectileCreation.Invoke(m_lastReceived.m_projectileCreation);
            m_onReceivedObject.Invoke(m_lastReceived.m_projectileCreation);
        }
        if (m_lastByteType == m_bytePerParsingType.m_data.m_byte_projectileDestruction) {
            CPS.CPS_PoolItemDestructionEvent.TryParse(bytes, out _, out m_lastReceived.m_destructionEvent);
            m_events.m_destructionEvent.Invoke(m_lastReceived.m_destructionEvent);
            m_onReceivedObject.Invoke(m_lastReceived.m_destructionEvent);
        }

        if (bytesType == m_bytePerParsingType.m_data.m_byte_dronePositions)
        {
            CPS.CPS_DroneSoccerPositions.TryParse(bytes, out _, out m_lastReceived.m_dronePositions);
            m_events.m_dronePositions.Invoke(m_lastReceived.m_dronePositions);
            m_onReceivedObject.Invoke(m_lastReceived.m_dronePositions);
        }
        if (bytesType == m_bytePerParsingType.m_data.m_byte_soccerBallPosition)
        {
            CPS.CPS_DroneSoccerBallPosition.TryParse(bytes, out _, out m_lastReceived.m_ballPosition);
            m_events.m_ballPosition.Invoke(m_lastReceived.m_ballPosition);
            m_onReceivedObject.Invoke(m_lastReceived.m_ballPosition);
        }
        if ( bytesType == m_bytePerParsingType.m_data.m_byte_matchTimeValue           ){
            CPS.CPS_DroneSoccerTimeValue.TryParse(bytes, out _, out m_lastReceived.m_timeValue);
            m_events.m_timeValue.Invoke(m_lastReceived.m_timeValue);
            m_onReceivedObject.Invoke(m_lastReceived.m_timeValue);

        }
        if( bytesType == m_bytePerParsingType.m_data.m_byte_soccerBallPosition               ){
            
            CPS.CPS_DroneSoccerBallPosition.TryParse(bytes, out _, out m_lastReceived.m_ballPosition);
            m_events.m_ballPosition.Invoke(m_lastReceived.m_ballPosition);
            m_onReceivedObject.Invoke(m_lastReceived.m_ballPosition);
        }
        if( bytesType == m_bytePerParsingType.m_data.m_byte_pointsState              ){
            CPS.CPS_DroneSoccerMatchState.TryParse(bytes, out _, out m_lastReceived.m_matchState);
            m_events.m_matchState.Invoke(m_lastReceived.m_matchState);
            m_onReceivedObject.Invoke(m_lastReceived.m_matchState);
        }
        if( bytesType == m_bytePerParsingType.m_data.m_byte_indexIntegerClaim        ){
            CPS.CPS_DroneSoccerIndexIntegerClaim.TryParse(bytes, out _, out m_lastReceived.m_indexIntegerClaim);
            m_events.m_indexIntegerClaim.Invoke(m_lastReceived.m_indexIntegerClaim);
            m_onReceivedObject.Invoke(m_lastReceived.m_indexIntegerClaim);
        }
        if( bytesType == m_bytePerParsingType.m_data.m_byte_publicRsaKeyClaim        ){
            CPS.CPS_DroneSoccerPublicXmlRsaKey1024Claim.TryParse(bytes, out _, out m_lastReceived.m_rsa1024Claim);
            m_events.m_rsa1024Claim.Invoke(m_lastReceived.m_rsa1024Claim);
            m_onReceivedObject.Invoke(m_lastReceived.m_rsa1024Claim);
        }
        if( bytesType == m_bytePerParsingType.m_data.m_byte_publicEllipticCurveClaim ){

        }
        if( bytesType == m_bytePerParsingType.m_data.m_byte_arenaStaticInformation         ){
            CPS.CPS_DroneSoccerMatchStaticInformation.TryParse(bytes, out _, out m_lastReceived.m_matchStaticInfo);
            m_events.m_matchStaticInfo.Invoke(m_lastReceived.m_matchStaticInfo);
            m_onReceivedObject.Invoke(m_lastReceived.m_matchStaticInfo);
        }
        if (bytesType == m_bytePerParsingType.m_data.m_byte_soccerBallGoals)    {
            CPS.CPS_DroneSoccerBallGoals.TryParse(bytes, out _, out m_lastReceived.m_ballGoals);
            m_events.m_ballGoals.Invoke(m_lastReceived.m_ballGoals);
            m_onReceivedObject.Invoke(m_lastReceived.m_ballGoals);
        }

        m_bytesReceived.Invoke(bytes);
    }

   
}





public class CPSGroup
{

    [System.Serializable]
    public class Events
    {
        [Header("Time Info")]
        public UnityEvent<S_NetworkGameFramePushTiming> m_serverFrameTime;
        public UnityEvent<S_DroneSoccerTimeValue> m_timeValue;


        [Header("Ball Info")]
        public UnityEvent<S_DroneSoccerBallPosition> m_ballPosition;
        public UnityEvent<S_DroneSoccerBallGoals> m_ballGoals;

        [Header("Soccer Info")]
        public UnityEvent<S_DroneSoccerPositions> m_dronePositions;
        public UnityEvent<S_DroneSoccerMatchState> m_matchState;
        public UnityEvent<S_DroneSoccerMatchStaticInformation> m_matchStaticInfo;

        [Header("Claim Info")]
        public UnityEvent<S_DroneSoccerIndexIntegerClaim> m_indexIntegerClaim;
        public UnityEvent<S_DroneSoccerPublicXmlRsaKey1024Claim> m_rsa1024Claim;

        [Header("Projectile Info")]
        public UnityEvent<S_LinearProjectilePoolItemCreationEvent> m_projectileCreation;
        public UnityEvent<S_PoolItemDestructionEvent> m_destructionEvent;
    }
    [System.Serializable]
    public class Structs
    {
        [Header("Time Info")]
        public S_NetworkGameFramePushTiming m_serverFrameTime;
        public S_DroneSoccerTimeValue m_timeValue;


        [Header("Ball Info")]
        public S_DroneSoccerBallPosition m_ballPosition;
        public S_DroneSoccerBallGoals m_ballGoals;

        [Header("Soccer Info")]
        public S_DroneSoccerPositions m_dronePositions;
        public S_DroneSoccerMatchState m_matchState;
        public S_DroneSoccerMatchStaticInformation m_matchStaticInfo;

        [Header("Claim Info")]
        public S_DroneSoccerIndexIntegerClaim m_indexIntegerClaim;
        public S_DroneSoccerPublicXmlRsaKey1024Claim m_rsa1024Claim;

        [Header("Projectile Info")]
        public S_LinearProjectilePoolItemCreationEvent m_projectileCreation;
        public S_PoolItemDestructionEvent m_destructionEvent;
    }
}