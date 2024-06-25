
//12 time per second refresh
using System;
//I_BytesParsable
public class PS_NetworkGameFramePushTiming : I_CategoryBytesParsable<S_NetworkGameFramePushTiming>
{
    public int m_bytesSize = 1 + 8 + 8;
    public void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_bytesSize;
    }

    public void Parse(byte category255, S_NetworkGameFramePushTiming toParse, out byte[] bytes)
    {
        bytes = new byte[m_bytesSize];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_utcNowTickServer).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_gameNetworkFrame).CopyTo(bytes, 9);
    }

    public bool TryParse(byte[] bytes, out byte category255, out S_NetworkGameFramePushTiming fromBytes)
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
