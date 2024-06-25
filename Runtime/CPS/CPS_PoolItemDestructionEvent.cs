
//Refresh every seconds
using System;
[System.Serializable]

public class CPS_PoolItemDestructionEvent : AbstractCategoryBytesParsable<S_PoolItemDestructionEvent>
{
    public int m_size = 1 + 1 + 4 + 8;

    public override void GetCopy(S_PoolItemDestructionEvent source, out S_PoolItemDestructionEvent copy)
    {
        copy = new S_PoolItemDestructionEvent();
        copy.m_poolId = source.m_poolId;
        copy.m_poolItemIndex = source.m_poolItemIndex;
        copy.m_serverUtcNowTicks = source.m_serverUtcNowTicks;
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public override void Parse(byte category255, S_PoolItemDestructionEvent toParse, out byte[] bytes)
    {
        bytes = new byte[m_size];
        bytes[0] = category255;
        bytes[1] = toParse.m_poolId;
        BitConverter.GetBytes(toParse.m_poolItemIndex).CopyTo(bytes, 2);
        BitConverter.GetBytes(toParse.m_serverUtcNowTicks).CopyTo(bytes, 6);

    }

    public override void Randomize(S_PoolItemDestructionEvent source, out S_PoolItemDestructionEvent copy)
    {
        GetCopy(source, out copy);
        copy.m_poolId = (byte)UnityEngine.Random.Range(0, 256);
        copy.m_poolItemIndex = (uint)UnityEngine.Random.Range(0, int.MaxValue);
        copy.m_serverUtcNowTicks = (ulong)UnityEngine.Random.Range(0, int.MaxValue);
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_PoolItemDestructionEvent fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_PoolItemDestructionEvent();
        fromBytes.m_poolId = bytes[1];
        fromBytes.m_poolItemIndex = BitConverter.ToUInt32(bytes, 2);
        fromBytes.m_serverUtcNowTicks = BitConverter.ToUInt64(bytes, 6);
        return true;
    }
}