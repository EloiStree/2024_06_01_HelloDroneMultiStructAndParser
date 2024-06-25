
//12 time per second refresh
using System;
//I_BytesParsable
[System.Serializable]
public class CPS_NetworkGameFramePushTiming : AbstractCategoryBytesParsable<S_NetworkGameFramePushTiming>
{
    public int m_bytesSize => 1 + 8 + 8;

    public override void GetCopy(S_NetworkGameFramePushTiming source, out S_NetworkGameFramePushTiming copy)
    {
        copy = new S_NetworkGameFramePushTiming()
        {
            m_utcNowTickServer = source.m_utcNowTickServer,
            m_gameNetworkFrame = source.m_gameNetworkFrame
        };
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_bytesSize;
    }

    public override void Parse(byte category255, S_NetworkGameFramePushTiming toParse, out byte[] bytes)
    {
        bytes = new byte[m_bytesSize];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_utcNowTickServer).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_gameNetworkFrame).CopyTo(bytes, 9);
    }

    public override void Randomize(S_NetworkGameFramePushTiming source, out S_NetworkGameFramePushTiming copy)
    {
        GetCopy(source, out copy);
        copy.m_utcNowTickServer = (ulong)UnityEngine.Random.Range(uint.MinValue, int.MaxValue);
        copy.m_gameNetworkFrame = (ulong)UnityEngine.Random.Range(uint.MinValue, int.MaxValue);
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_NetworkGameFramePushTiming fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_NetworkGameFramePushTiming()
        {
            m_utcNowTickServer = BitConverter.ToUInt64(bytes, 1),
            m_gameNetworkFrame = BitConverter.ToUInt64(bytes, 9)
        };
        return true;
    }
}
