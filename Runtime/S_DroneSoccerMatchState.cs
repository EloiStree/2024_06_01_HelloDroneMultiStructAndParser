
//Refresh with event
using System;

[System.Serializable]
public struct S_DroneSoccerMatchState
{   
    public int m_bluePoints;
    public int m_redPoints;
    public int m_blueSets;
    public int m_redSets;
    public long m_utcTickInSecondsWhenMatchStarted;
    public long m_utcTickInSecondsWhenMatchFinished;

    public S_DroneSoccerMatchState GetCopy() { 
    return new S_DroneSoccerMatchState() {
        m_bluePoints = m_bluePoints,
        m_redPoints = m_redPoints,
        m_blueSets = m_blueSets,
        m_redSets = m_redSets,
        m_utcTickInSecondsWhenMatchStarted = m_utcTickInSecondsWhenMatchStarted,
        m_utcTickInSecondsWhenMatchFinished = m_utcTickInSecondsWhenMatchFinished
    };
    
    
    }
}

public struct PS_DroneSoccerMatchState : I_CategoryBytesParsable<S_DroneSoccerMatchState>
{
    public void Parse(byte category255, S_DroneSoccerMatchState toParse, out byte[] bytes)
    {
         bytes = new byte[1 + 4 * 4 + 2 * 8];
        bytes[0] = 3;
        BitConverter.GetBytes(toParse.m_redPoints).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_bluePoints).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_redSets).CopyTo(bytes, 9);
        BitConverter.GetBytes(toParse.m_blueSets).CopyTo(bytes, 13);
        BitConverter.GetBytes(toParse.m_utcTickInSecondsWhenMatchStarted).CopyTo(bytes, 17);
        BitConverter.GetBytes(toParse.m_utcTickInSecondsWhenMatchFinished).CopyTo(bytes, 25);

    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerMatchState fromBytes)
    {
        throw new System.NotImplementedException();
    }
}