
//Refresh every seconds
using System;

public class CPS_LinearProjectilePoolItemCreationEvent : I_CategoryBytesParsable<S_LinearProjectilePoolItemCreationEvent>
{
    public int m_size= 1 + 1 + 4 + 8 + 12 + 16 + 12 + 4 + 4;
    public void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public void Parse(byte category255, S_LinearProjectilePoolItemCreationEvent toParse, out byte[] bytes)
    {
        bytes = new byte[m_size];
        bytes[0] = category255;
        bytes[1] = toParse.m_poolId;
        BitConverter.GetBytes(toParse.m_poolItemIndex).CopyTo(bytes, 2);
        BitConverter.GetBytes(toParse.m_serverUtcNowTicks).CopyTo(bytes, 6);
        BitConverter.GetBytes(toParse.m_startPosition.x).CopyTo(bytes, 14);
        BitConverter.GetBytes(toParse.m_startPosition.y).CopyTo(bytes, 18);
        BitConverter.GetBytes(toParse.m_startPosition.z).CopyTo(bytes, 22);
        BitConverter.GetBytes(toParse.m_startRotation.x).CopyTo(bytes, 26);
        BitConverter.GetBytes(toParse.m_startRotation.y).CopyTo(bytes, 30);
        BitConverter.GetBytes(toParse.m_startRotation.z).CopyTo(bytes, 34);
        BitConverter.GetBytes(toParse.m_startRotation.w).CopyTo(bytes, 38);
        BitConverter.GetBytes(toParse.m_startDirection.x).CopyTo(bytes, 42);
        BitConverter.GetBytes(toParse.m_startDirection.y).CopyTo(bytes, 46);
        BitConverter.GetBytes(toParse.m_startDirection.z).CopyTo(bytes, 50);
        BitConverter.GetBytes(toParse.m_speedInMetersPerSecond).CopyTo(bytes, 54);
        BitConverter.GetBytes(toParse.m_colliderRadius).CopyTo(bytes, 58);

    }

    public bool TryParse(byte[] bytes, out byte category255, out S_LinearProjectilePoolItemCreationEvent fromBytes)
    {
        throw new NotImplementedException();
    }
}
