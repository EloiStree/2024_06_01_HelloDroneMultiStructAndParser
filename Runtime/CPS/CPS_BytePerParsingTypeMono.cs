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
    public byte m_byte_dronePositions           = 10;
    public byte m_byte_matchTimeValue           = 11;
    public byte m_byte_soccerBallPosition       = 15;
    public byte m_byte_pointsState              = 20;
    public byte m_byte_indexIntegerClaim        = 60;
    public byte m_byte_publicRsaKeyClaim        = 61;
    public byte m_byte_publicEllipticCurveClaim = 62;
    public byte m_byte_arenaStaticInformation         = 30;
    public byte m_byte_soccerBallGoals          = 35;
    public byte m_byte_projectileCreation     = 70;
    public byte m_byte_projectileDestruction  = 71;
    public byte m_byte_serverFrameTime        =  9;
}
