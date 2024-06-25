
//Refresh every seconds
using System;
//I_BytesParsable

[System.Serializable]
public class CPS_DroneSoccerTimeValue : AbstractCategoryBytesParsable<S_DroneSoccerTimeValue>
{
    public int m_size=>1 + 4 + 4 + 8;

    public override void GetCopy(S_DroneSoccerTimeValue source, out S_DroneSoccerTimeValue copy)
    {
        copy = new S_DroneSoccerTimeValue()
        {
            m_secondsSinceMatchStarted = source.m_secondsSinceMatchStarted,
            m_secondsSinceSetStarted = source.m_secondsSinceSetStarted,
            m_timeOfServerDateTimeUtcNowTicks = source.m_timeOfServerDateTimeUtcNowTicks
        };
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public override void Parse(byte category255, S_DroneSoccerTimeValue toParse, out byte[] bytes)
    {
         bytes = new byte[1 + 4 + 4 + 8];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_secondsSinceMatchStarted).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_secondsSinceSetStarted).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_timeOfServerDateTimeUtcNowTicks).CopyTo(bytes, 9);

    }

    public override void Randomize(S_DroneSoccerTimeValue source, out S_DroneSoccerTimeValue copy)
    {
        GetCopy(source, out copy);
        copy.m_secondsSinceMatchStarted = UnityEngine.Random.Range(0f, 100f);
        copy.m_secondsSinceSetStarted = UnityEngine.Random.Range(0f, 100f);
        copy.m_timeOfServerDateTimeUtcNowTicks = (ulong)UnityEngine.Random.Range(0, int.MaxValue);
    
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerTimeValue fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DroneSoccerTimeValue()
        {
            m_secondsSinceMatchStarted = BitConverter.ToSingle(bytes, 1),
            m_secondsSinceSetStarted = BitConverter.ToSingle(bytes, 5),
            m_timeOfServerDateTimeUtcNowTicks = BitConverter.ToUInt64(bytes, 9)
        };
        return true;
    }
}
