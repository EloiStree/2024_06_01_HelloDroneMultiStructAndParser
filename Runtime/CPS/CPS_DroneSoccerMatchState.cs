
//Refresh with event
using System;

[System.Serializable]
public class CPS_DroneSoccerMatchState : AbstractCategoryBytesParsable<S_DroneSoccerMatchState>
{
    public int m_bytesSize => 1 + 4 * 4 + 2 * 8;

    public override void GetCopy(S_DroneSoccerMatchState source, out S_DroneSoccerMatchState copy)
    {
        copy = new S_DroneSoccerMatchState();
        copy.m_redPoints = source.m_redPoints;
        copy.m_bluePoints = source.m_bluePoints;
        copy.m_redSets = source.m_redSets;
        copy.m_blueSets = source.m_blueSets;
        copy.m_utcTickInSecondsWhenMatchStarted = source.m_utcTickInSecondsWhenMatchStarted;
        copy.m_utcTickInSecondsWhenMatchFinished = source.m_utcTickInSecondsWhenMatchFinished;
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_bytesSize;
    }

    public override void Parse(byte category255, S_DroneSoccerMatchState toParse, out byte[] bytes)
    {
         bytes = new byte[m_bytesSize];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_redPoints).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_bluePoints).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_redSets).CopyTo(bytes, 9);
        BitConverter.GetBytes(toParse.m_blueSets).CopyTo(bytes, 13);
        BitConverter.GetBytes(toParse.m_utcTickInSecondsWhenMatchStarted).CopyTo(bytes, 17);
        BitConverter.GetBytes(toParse.m_utcTickInSecondsWhenMatchFinished).CopyTo(bytes, 25);

    }

    public override void Randomize(S_DroneSoccerMatchState source, out S_DroneSoccerMatchState copy)
    {
        GetCopy(source, out copy);
        copy.m_redPoints =(uint) UnityEngine.Random.Range(uint.MinValue, 99);
        copy.m_bluePoints = (uint)UnityEngine.Random.Range(uint.MinValue, 99);
        copy.m_redSets = (uint)UnityEngine.Random.Range(uint.MinValue, 99);
        copy.m_blueSets = (uint)UnityEngine.Random.Range(uint.MinValue, 99);

       
        copy.m_utcTickInSecondsWhenMatchStarted = (ulong)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        copy.m_utcTickInSecondsWhenMatchFinished = (ulong)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerMatchState fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DroneSoccerMatchState();
        fromBytes.m_redPoints = BitConverter.ToUInt32(bytes, 1);
        fromBytes.m_bluePoints = BitConverter.ToUInt32(bytes, 5);
        fromBytes.m_redSets = BitConverter.ToUInt32(bytes, 9);
        fromBytes.m_blueSets = BitConverter.ToUInt32(bytes, 13);
        fromBytes.m_utcTickInSecondsWhenMatchStarted = BitConverter.ToUInt64(bytes, 17);
        fromBytes.m_utcTickInSecondsWhenMatchFinished = BitConverter.ToUInt64(bytes, 25);
        return true;
    }
}