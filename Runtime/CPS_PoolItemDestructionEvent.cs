
//Refresh every seconds
using System;

public class CPS_PoolItemDestructionEvent : I_CategoryBytesParsable<S_PoolItemDestructionEvent>
{
    public int m_size = 1 + 1 + 4 + 8;
    public void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public void Parse(byte category255, S_PoolItemDestructionEvent toParse, out byte[] bytes)
    {
        bytes = new byte[m_size];
        bytes[0] = category255;
        bytes[1] = toParse.m_poolId;
        BitConverter.GetBytes(toParse.m_poolItemIndex).CopyTo(bytes, 2);
        BitConverter.GetBytes(toParse.m_serverUtcNowTicks).CopyTo(bytes, 6);

    }

    public bool TryParse(byte[] bytes, out byte category255, out S_PoolItemDestructionEvent fromBytes)
    {
        throw new NotImplementedException();
    }
}