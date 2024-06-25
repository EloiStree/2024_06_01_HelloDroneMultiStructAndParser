using System;

[System.Serializable]
public class CPS_DroneSoccerBallGoals : AbstractCategoryBytesParsable<S_DroneSoccerBallGoals>
{
    public int m_size => 1 + 4 * 5;

    public override void GetCopy(S_DroneSoccerBallGoals source, out S_DroneSoccerBallGoals copy)
    {
        copy = new S_DroneSoccerBallGoals();
        copy.m_goalDepthMeter = source.m_goalDepthMeter;
        copy.m_goalDistanceOfCenterMeter = source.m_goalDistanceOfCenterMeter;
        copy.m_goalCenterHeightMeter = source.m_goalCenterHeightMeter;
        copy.m_goalWidthRadiusMeter = source.m_goalWidthRadiusMeter;
        copy.m_ballRadius = source.m_ballRadius;
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public override  void Parse(byte category255, S_DroneSoccerBallGoals toParse, out byte[] bytes)
    {
        bytes = new byte[m_size];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_goalDepthMeter).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_goalDistanceOfCenterMeter).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_goalCenterHeightMeter).CopyTo(bytes, 9);
        BitConverter.GetBytes(toParse.m_goalWidthRadiusMeter).CopyTo(bytes, 13);
        BitConverter.GetBytes(toParse.m_ballRadius).CopyTo(bytes, 17);
    }

    public override void Randomize(S_DroneSoccerBallGoals source, out S_DroneSoccerBallGoals copy)
    {
        GetCopy(source, out copy);
        copy.m_goalDepthMeter = UnityEngine.Random.Range(0.2f,0.3f);
        copy.m_goalDistanceOfCenterMeter = UnityEngine.Random.Range(2,3);
        copy.m_goalCenterHeightMeter = UnityEngine.Random.Range(2f,3f);
        copy.m_goalWidthRadiusMeter = UnityEngine.Random.Range(0.45f, 0.50f);
        copy.m_ballRadius = UnityEngine.Random.Range(0.2f, 0.4f);

    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerBallGoals fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DroneSoccerBallGoals();
        fromBytes.m_goalDepthMeter = BitConverter.ToSingle(bytes, 1);
        fromBytes.m_goalDistanceOfCenterMeter = BitConverter.ToSingle(bytes, 5);
        fromBytes.m_goalCenterHeightMeter = BitConverter.ToSingle(bytes, 9);
        fromBytes.m_goalWidthRadiusMeter = BitConverter.ToSingle(bytes, 13);
        fromBytes.m_ballRadius = BitConverter.ToSingle(bytes, 17);
        return true;
    }
}