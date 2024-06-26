using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CPS_BytePerParsingTypeMono : MonoBehaviour
{
    public CPS_BytePerType m_data;



}
[System.Serializable]
public class CPS_BytePerType
{
    public byte m_byteDronePositions           = 10;
    public byte m_byteMatchTimeValue           = 11;
    public byte m_byteSoccerBallPosition       = 15;
    public byte m_bytePointsState              = 20;
    public byte m_byteIndexIntegerClaim        = 60;
    public byte m_bytePublicRsaKeyClaim        = 61;
    public byte m_bytePublicEllipticCurveClaim = 62;
    public byte m_byteArenaStaticInformation         = 30;
    public byte m_byteSoccerBallGoals          = 35;
    public byte m_byteProjectileCreation     = 70;
    public byte m_byteProjectileDestruction  = 71;
    public byte m_byteServerFrameTime        =  9;
    public byte m_byteDoubleGuidItemSpawn     = 80;
    public byte m_byteDoubleGuidItemDestruction  = 81;  
}
