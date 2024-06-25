using System;

[System.Serializable]
public struct S_DroneSoccerBallGoals {

    public float m_goalDistanceOfCenterMeter;
    public float m_goalCenterHeightMeter;
    public float m_goalWidthRadiusMeter;
    public float m_goalDepthMeter;
    public float m_ballRadius;

    public S_DroneSoccerBallGoals GetCopy() { 
    
        return new S_DroneSoccerBallGoals() {
        m_goalDistanceOfCenterMeter = m_goalDistanceOfCenterMeter,
        m_goalCenterHeightMeter = m_goalCenterHeightMeter,
        m_goalWidthRadiusMeter = m_goalWidthRadiusMeter,
        m_goalDepthMeter = m_goalDepthMeter,
        m_ballRadius = m_ballRadius
    };
    
    }
}
public struct PS_DroneSoccerBallGoals : I_CategoryBytesParsable<S_DroneSoccerBallGoals>
{
    public void Parse(byte category255, S_DroneSoccerBallGoals toParse, out byte[] bytes)
    {
        bytes = new byte[1 + 4 * 5];
        bytes[0] = 14;
        BitConverter.GetBytes(toParse.m_goalDepthMeter).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_goalDistanceOfCenterMeter).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_goalCenterHeightMeter).CopyTo(bytes, 9);
        BitConverter.GetBytes(toParse.m_goalWidthRadiusMeter).CopyTo(bytes, 13);
        BitConverter.GetBytes(toParse.m_ballRadius).CopyTo(bytes, 17);
    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerBallGoals fromBytes)
    {
        throw new System.NotImplementedException();
    }
}