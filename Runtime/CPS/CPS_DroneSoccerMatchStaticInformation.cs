using System;

[System.Serializable]
public class CPS_DroneSoccerMatchStaticInformation : AbstractCategoryBytesParsable<S_DroneSoccerMatchStaticInformation>
{
    public int m_bytesSize => 1 + 4 * 13;

    public override void GetCopy(S_DroneSoccerMatchStaticInformation source, out S_DroneSoccerMatchStaticInformation copy)
    {
        copy = new S_DroneSoccerMatchStaticInformation();
        copy.m_maxTimingOfSetInSeconds = source.m_maxTimingOfSetInSeconds;
        copy.m_maxTimingOfMatchInSeconds = source.m_maxTimingOfMatchInSeconds;
        copy.m_numberOfSetsToWinMatch = source.m_numberOfSetsToWinMatch;
        copy.m_numberOfPointsToForceWinSet = source.m_numberOfPointsToForceWinSet;
        copy.m_arenaWidthMeter = source.m_arenaWidthMeter;
        copy.m_arenaHeightMeter = source.m_arenaHeightMeter;
        copy.m_arenaDepthMeter = source.m_arenaDepthMeter;
        copy.m_goalDistanceOfCenterMeter = source.m_goalDistanceOfCenterMeter;
        copy.m_goalCenterHeightMeter = source.m_goalCenterHeightMeter;
        copy.m_goalInnerRadiusMeter = source.m_goalInnerRadiusMeter;
        copy.m_goalOuterRadiusMeter = source.m_goalOuterRadiusMeter;
        copy.m_goalDepthMeter = source.m_goalDepthMeter;
        copy.m_droneSphereRadiusMeter = source.m_droneSphereRadiusMeter;
            

    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_bytesSize;
    }

    public override void Parse(byte category255, S_DroneSoccerMatchStaticInformation toParse, out byte[] bytes)
    {
        bytes = new byte[m_bytesSize];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_maxTimingOfSetInSeconds).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_maxTimingOfMatchInSeconds).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_numberOfSetsToWinMatch).CopyTo(bytes, 9);
        BitConverter.GetBytes(toParse.m_numberOfPointsToForceWinSet).CopyTo(bytes, 13);
        BitConverter.GetBytes(toParse.m_arenaWidthMeter).CopyTo(bytes, 17);
        BitConverter.GetBytes(toParse.m_arenaHeightMeter).CopyTo(bytes, 21);
        BitConverter.GetBytes(toParse.m_arenaDepthMeter).CopyTo(bytes, 25);
        BitConverter.GetBytes(toParse.m_goalDistanceOfCenterMeter).CopyTo(bytes, 29);
        BitConverter.GetBytes(toParse.m_goalCenterHeightMeter).CopyTo(bytes, 33);
        BitConverter.GetBytes(toParse.m_goalInnerRadiusMeter).CopyTo(bytes, 37);
        BitConverter.GetBytes(toParse.m_goalOuterRadiusMeter).CopyTo(bytes, 41);
        BitConverter.GetBytes(toParse.m_goalDepthMeter).CopyTo(bytes, 45);
        BitConverter.GetBytes(toParse.m_droneSphereRadiusMeter).CopyTo(bytes, 49);


    }

    public override void Randomize(S_DroneSoccerMatchStaticInformation source, out S_DroneSoccerMatchStaticInformation copy)
    {
        GetCopy(source, out copy);
        copy.m_maxTimingOfSetInSeconds = UnityEngine.Random.Range(10f, 100f);
        copy.m_maxTimingOfMatchInSeconds = UnityEngine.Random.Range(10f, 100f);
        copy.m_numberOfSetsToWinMatch = UnityEngine.Random.Range(3f, 10f);
        copy.m_numberOfPointsToForceWinSet = UnityEngine.Random.Range(3f, 10f);
        copy.m_arenaWidthMeter = UnityEngine.Random.Range(5f, 10f);
        copy.m_arenaHeightMeter = UnityEngine.Random.Range(5f, 10f);
        copy.m_arenaDepthMeter = UnityEngine.Random.Range(5f, 10f);
        copy.m_goalDistanceOfCenterMeter = UnityEngine.Random.Range(1f, 3f);
        copy.m_goalCenterHeightMeter = UnityEngine.Random.Range(1f, 3f);
        copy.m_goalInnerRadiusMeter = UnityEngine.Random.Range(0.4f, 0.5f);
        copy.m_goalOuterRadiusMeter = UnityEngine.Random.Range(0.5f, 0.65f);
        copy.m_goalDepthMeter = UnityEngine.Random.Range(0.1f,0.2f);
        copy.m_droneSphereRadiusMeter = UnityEngine.Random.Range(0.2f, 0.4f);


    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerMatchStaticInformation fromBytes)
    {
        category255= bytes[0];
        fromBytes = new S_DroneSoccerMatchStaticInformation();
        fromBytes.m_maxTimingOfSetInSeconds = BitConverter.ToSingle(bytes, 1);
        fromBytes.m_maxTimingOfMatchInSeconds = BitConverter.ToSingle(bytes, 5);
        fromBytes.m_numberOfSetsToWinMatch = BitConverter.ToSingle(bytes, 9);
        fromBytes.m_numberOfPointsToForceWinSet = BitConverter.ToSingle(bytes, 13);
        fromBytes.m_arenaWidthMeter = BitConverter.ToSingle(bytes, 17);
        fromBytes.m_arenaHeightMeter = BitConverter.ToSingle(bytes, 21);
        fromBytes.m_arenaDepthMeter = BitConverter.ToSingle(bytes, 25);
        fromBytes.m_goalDistanceOfCenterMeter = BitConverter.ToSingle(bytes, 29);
        fromBytes.m_goalCenterHeightMeter = BitConverter.ToSingle(bytes, 33);
        fromBytes.m_goalInnerRadiusMeter = BitConverter.ToSingle(bytes, 37);
        fromBytes.m_goalOuterRadiusMeter = BitConverter.ToSingle(bytes, 41);
        fromBytes.m_goalDepthMeter = BitConverter.ToSingle(bytes, 45);
        fromBytes.m_droneSphereRadiusMeter = BitConverter.ToSingle(bytes, 49);
        return true;

    }
}