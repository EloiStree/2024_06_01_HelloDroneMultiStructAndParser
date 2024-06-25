using System;
using UnityEngine;
//Set Once at start of the match
[System.Serializable]
public struct S_DroneSoccerMatchStaticInformation {
    [Header("Match Info")]
    public float m_maxTimingOfSet;//300 seconds
    public float m_maxTimingOfMatch;//15 minutes
    public float m_numberOfSetsToWinMatch;//2 sets
    [Tooltip("If a team reach this points, the set is won")]
    public float m_numberOfPointsToForceWinSet;//99 points

    [Header("Dimension")]
    public float m_arenaWidthMeter;//around 7 meters
    public float m_arenaHeightMeter;//around 6 meters
    public float m_arenaDepthMeter;//around 14 meters
    public float m_goalDistanceOfCenterMeter;//4 meters+
    public float m_goalCenterHeightMeter;//3 meters
    public float m_goalInnerRadiusMeter;// 60cm+
    public float m_goalSizeRadiusMeter;///70cm+
    public float m_goalDepthMeter;//around 5-20 cm
    public float m_droneSphereRadiusMeter;//40cm 0.4 meter


    public S_DroneSoccerMatchStaticInformation GetCopy() {
        return new S_DroneSoccerMatchStaticInformation() {
            m_maxTimingOfSet = m_maxTimingOfSet,
            m_maxTimingOfMatch = m_maxTimingOfMatch,
            m_numberOfSetsToWinMatch = m_numberOfSetsToWinMatch,
            m_numberOfPointsToForceWinSet = m_numberOfPointsToForceWinSet,
            m_arenaWidthMeter = m_arenaWidthMeter,
            m_arenaHeightMeter = m_arenaHeightMeter,
            m_arenaDepthMeter = m_arenaDepthMeter,
            m_goalDistanceOfCenterMeter = m_goalDistanceOfCenterMeter,
            m_goalCenterHeightMeter = m_goalCenterHeightMeter,
            m_goalInnerRadiusMeter = m_goalInnerRadiusMeter,
            m_goalSizeRadiusMeter = m_goalSizeRadiusMeter,
            m_goalDepthMeter = m_goalDepthMeter,
            m_droneSphereRadiusMeter = m_droneSphereRadiusMeter
        };
    }
}

public struct PS_DroneSoccerMatchStaticInformation : I_CategoryBytesParsable<S_DroneSoccerMatchStaticInformation>
{
    public void Parse(byte category255, S_DroneSoccerMatchStaticInformation toParse, out byte[] bytes)
    {
        bytes = new byte[1 + 4 * 13];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_maxTimingOfSet).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_maxTimingOfMatch).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_numberOfSetsToWinMatch).CopyTo(bytes, 9);
        BitConverter.GetBytes(toParse.m_numberOfPointsToForceWinSet).CopyTo(bytes, 13);
        BitConverter.GetBytes(toParse.m_arenaWidthMeter).CopyTo(bytes, 17);
        BitConverter.GetBytes(toParse.m_arenaHeightMeter).CopyTo(bytes, 21);
        BitConverter.GetBytes(toParse.m_arenaDepthMeter).CopyTo(bytes, 25);
        BitConverter.GetBytes(toParse.m_goalDistanceOfCenterMeter).CopyTo(bytes, 29);
        BitConverter.GetBytes(toParse.m_goalCenterHeightMeter).CopyTo(bytes, 33);
        BitConverter.GetBytes(toParse.m_goalInnerRadiusMeter).CopyTo(bytes, 37);
        BitConverter.GetBytes(toParse.m_goalSizeRadiusMeter).CopyTo(bytes, 41);
        BitConverter.GetBytes(toParse.m_goalDepthMeter).CopyTo(bytes, 45);
        BitConverter.GetBytes(toParse.m_droneSphereRadiusMeter).CopyTo(bytes, 49);


    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerMatchStaticInformation fromBytes)
    {
        throw new System.NotImplementedException();
    }
}