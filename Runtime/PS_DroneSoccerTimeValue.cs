
//Refresh every seconds
using System;
//I_BytesParsable

public class PS_DroneSoccerTimeValue : I_CategoryBytesParsable<S_DroneSoccerTimeValue>
{
    public int m_size= 1 + 4 + 4 + 8;
    public void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public void Parse(byte category255, S_DroneSoccerTimeValue toParse, out byte[] bytes)
    {
         bytes = new byte[1 + 4 + 4 + 8];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_secondsSinceMatchStarted).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_secondsSinceSetStarted).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_timeOfServerDateTimeUtcNowTicks).CopyTo(bytes, 9);

    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerTimeValue fromBytes)
    {
        throw new System.NotImplementedException();
    }
}
