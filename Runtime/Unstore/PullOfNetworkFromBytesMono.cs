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

        if (m_lastByteType == m_bytePerParsingType.m_data.m_byteServerFrameTime) { 
        
            CPS.CPS_NetworkGameFramePushTiming.TryParse(bytes, out _, out m_lastReceived.m_serverFrameTime);
            m_events.m_onServerFrameTime.Invoke(m_lastReceived.m_serverFrameTime);
            m_onReceivedObject.Invoke(m_lastReceived.m_serverFrameTime);
        }

        else if (m_lastByteType== m_bytePerParsingType.m_data.m_byteProjectileCreation){
            CPS.CPS_LinearProjectilePoolItemCreationEvent.TryParse(bytes, out _, out m_lastReceived.m_projectileCreation);
            m_events.m_onProjectileCreation.Invoke(m_lastReceived.m_projectileCreation);
            m_onReceivedObject.Invoke(m_lastReceived.m_projectileCreation);
        }
        else if (m_lastByteType == m_bytePerParsingType.m_data.m_byteProjectileDestruction) {
            CPS.CPS_PoolItemDestructionEvent.TryParse(bytes, out _, out m_lastReceived.m_destructionEvent);
            m_events.m_onDestructionEvent.Invoke(m_lastReceived.m_destructionEvent);
            m_onReceivedObject.Invoke(m_lastReceived.m_destructionEvent);
        }

        else if (bytesType == m_bytePerParsingType.m_data.m_byteDronePositions)
        {
            CPS.CPS_DroneSoccerPositions.TryParse(bytes, out _, out m_lastReceived.m_dronePositions);
            m_events.m_onDronePositions.Invoke(m_lastReceived.m_dronePositions);
            m_onReceivedObject.Invoke(m_lastReceived.m_dronePositions);
        }
        else if (bytesType == m_bytePerParsingType.m_data.m_byteSoccerBallPosition)
        {
            CPS.CPS_DroneSoccerBallPosition.TryParse(bytes, out _, out m_lastReceived.m_ballPosition);
            m_events.m_onBallPosition.Invoke(m_lastReceived.m_ballPosition);
            m_onReceivedObject.Invoke(m_lastReceived.m_ballPosition);
        }
        else if ( bytesType == m_bytePerParsingType.m_data.m_byteMatchTimeValue           ){
            CPS.CPS_DroneSoccerTimeValue.TryParse(bytes, out _, out m_lastReceived.m_timeValue);
            m_events.m_onTimeValue.Invoke(m_lastReceived.m_timeValue);
            m_onReceivedObject.Invoke(m_lastReceived.m_timeValue);

        }
        else if ( bytesType == m_bytePerParsingType.m_data.m_byteSoccerBallPosition               ){
            
            CPS.CPS_DroneSoccerBallPosition.TryParse(bytes, out _, out m_lastReceived.m_ballPosition);
            m_events.m_onBallPosition.Invoke(m_lastReceived.m_ballPosition);
            m_onReceivedObject.Invoke(m_lastReceived.m_ballPosition);
        }
        else if ( bytesType == m_bytePerParsingType.m_data.m_bytePointsState              ){
            CPS.CPS_DroneSoccerMatchState.TryParse(bytes, out _, out m_lastReceived.m_matchState);
            m_events.m_onMatchState.Invoke(m_lastReceived.m_matchState);
            m_onReceivedObject.Invoke(m_lastReceived.m_matchState);
        }
        else if ( bytesType == m_bytePerParsingType.m_data.m_byteIndexIntegerClaim        ){
            CPS.CPS_DroneSoccerIndexIntegerClaim.TryParse(bytes, out _, out m_lastReceived.m_indexIntegerClaim);
            m_events.m_onIndexIntegerClaim.Invoke(m_lastReceived.m_indexIntegerClaim);
            m_onReceivedObject.Invoke(m_lastReceived.m_indexIntegerClaim);
        }
        else if ( bytesType == m_bytePerParsingType.m_data.m_bytePublicRsaKeyClaim        ){
            CPS.CPS_DroneSoccerPublicXmlRsaKey1024Claim.TryParse(bytes, out _, out m_lastReceived.m_rsa1024Claim);
            m_events.m_onRsa1024Claim.Invoke(m_lastReceived.m_rsa1024Claim);
            m_onReceivedObject.Invoke(m_lastReceived.m_rsa1024Claim);
        }
        else if ( bytesType == m_bytePerParsingType.m_data.m_bytePublicEllipticCurveClaim ){

        }
        else if ( bytesType == m_bytePerParsingType.m_data.m_byteArenaStaticInformation         ){
            CPS.CPS_DroneSoccerMatchStaticInformation.TryParse(bytes, out _, out m_lastReceived.m_matchStaticInfo);
            m_events.m_onMatchStaticInfo.Invoke(m_lastReceived.m_matchStaticInfo);
            m_onReceivedObject.Invoke(m_lastReceived.m_matchStaticInfo);
        }
        else if (bytesType == m_bytePerParsingType.m_data.m_byteSoccerBallGoals)    {
            CPS.CPS_DroneSoccerBallGoals.TryParse(bytes, out _, out m_lastReceived.m_ballGoals);
            m_events.m_onBallGoals.Invoke(m_lastReceived.m_ballGoals);
            m_onReceivedObject.Invoke(m_lastReceived.m_ballGoals);
        }
        else if ( bytesType== m_bytePerParsingType.m_data.m_byteDoubleGuidItemSpawn){
            CPS.CPS_DoubleGuidItemSpawn.TryParse(bytes, out _, out m_lastReceived.m_doubleGuidItemSpawn);
            m_events.m_onDoubleGuidItemSpawn.Invoke(m_lastReceived.m_doubleGuidItemSpawn);
            m_onReceivedObject.Invoke(m_lastReceived.m_doubleGuidItemSpawn);
        }
        else if(bytesType== m_bytePerParsingType.m_data.m_byteDoubleGuidItemDestruction){
            CPS.CPS_DoubleGuidItemDestruction.TryParse(bytes, out _, out m_lastReceived.m_doubleGuidItemDestruction);
            m_events.m_onDoubleGuidItemDestruction.Invoke(m_lastReceived.m_doubleGuidItemDestruction);
            m_onReceivedObject.Invoke(m_lastReceived.m_doubleGuidItemDestruction);
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
        public UnityEvent<S_NetworkGameFramePushTiming> m_onServerFrameTime;
        public UnityEvent<S_DroneSoccerTimeValue> m_onTimeValue;

        [Header("Ball Info")]
        public UnityEvent<S_DroneSoccerBallPosition> m_onBallPosition;
        public UnityEvent<S_DroneSoccerBallGoals> m_onBallGoals;

        [Header("Soccer Info")]
        public UnityEvent<S_DroneSoccerPositions> m_onDronePositions;
        public UnityEvent<S_DroneSoccerMatchState> m_onMatchState;
        public UnityEvent<S_DroneSoccerMatchStaticInformation> m_onMatchStaticInfo;

        [Header("Claim Info")]
        public UnityEvent<S_DroneSoccerIndexIntegerClaim> m_onIndexIntegerClaim;
        public UnityEvent<S_DroneSoccerPublicXmlRsaKey1024Claim> m_onRsa1024Claim;

        [Header("Projectile Info")]
        public UnityEvent<S_LinearProjectilePoolItemCreationEvent> m_onProjectileCreation;
        public UnityEvent<S_PoolItemDestructionEvent> m_onDestructionEvent;

        [Header("GUID loading")]
        public UnityEvent<S_DoubleGuidItemSpawn> m_onDoubleGuidItemSpawn;
        public UnityEvent<S_DoubleGuidItemDestruction> m_onDoubleGuidItemDestruction;
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

        [Header("GUID loading")]
        public S_DoubleGuidItemSpawn m_doubleGuidItemSpawn;
        public S_DoubleGuidItemDestruction m_doubleGuidItemDestruction;
    }
}