
//Refresh every seconds
using System;

[System.Serializable]
public class CPS_LinearProjectilePoolItemCreationEvent : AbstractCategoryBytesParsable<S_LinearProjectilePoolItemCreationEvent>
{
    public int m_size=> 1 + 1 + 4 + 8 + 12 + 16 + 12 + 4 + 4;

    public override void GetCopy(S_LinearProjectilePoolItemCreationEvent source, out S_LinearProjectilePoolItemCreationEvent copy)
    {
        copy = new S_LinearProjectilePoolItemCreationEvent()
        {
            m_poolId = source.m_poolId,
            m_poolItemIndex = source.m_poolItemIndex,
            m_serverUtcNowTicks = source.m_serverUtcNowTicks,
            m_startPosition = source.m_startPosition,
            m_startRotation = source.m_startRotation,
            m_startDirection = source.m_startDirection,
            m_speedInMetersPerSecond = source.m_speedInMetersPerSecond,
            m_colliderRadius = source.m_colliderRadius
        };
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public override void Parse(byte category255, S_LinearProjectilePoolItemCreationEvent toParse, out byte[] bytes)
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

    public override void Randomize(S_LinearProjectilePoolItemCreationEvent source, out S_LinearProjectilePoolItemCreationEvent copy)
    {
        GetCopy(source, out copy);
        copy.m_poolId = (byte)UnityEngine.Random.Range(0, 255);
        copy.m_poolItemIndex = (uint)UnityEngine.Random.Range(0, int.MaxValue);
        copy.m_serverUtcNowTicks = (ulong)UnityEngine.Random.Range(0, int.MaxValue);
        copy.m_startPosition = new UnityEngine.Vector3(
            UnityEngine.Random.Range(-100f, 100f),
            UnityEngine.Random.Range(-100f, 100f),
            UnityEngine.Random.Range(-100f, 100f)
        );
        copy.m_startRotation = new UnityEngine.Quaternion(
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f)
        );
        copy.m_startDirection = new UnityEngine.Vector3(
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(-1f, 1f)
        );
        copy.m_speedInMetersPerSecond = UnityEngine.Random.Range(0.1f, 1f);
        copy.m_colliderRadius = UnityEngine.Random.Range(0.1f, 2f);
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_LinearProjectilePoolItemCreationEvent fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_LinearProjectilePoolItemCreationEvent()
        {
            m_poolId = bytes[1],
            m_poolItemIndex = BitConverter.ToUInt32(bytes, 2),
            m_serverUtcNowTicks = BitConverter.ToUInt64(bytes, 6),
            m_startPosition = new UnityEngine.Vector3(
                BitConverter.ToSingle(bytes, 14),
                BitConverter.ToSingle(bytes, 18),
                BitConverter.ToSingle(bytes, 22)
            ),
            m_startRotation = new UnityEngine.Quaternion(
                BitConverter.ToSingle(bytes, 26),
                BitConverter.ToSingle(bytes, 30),
                BitConverter.ToSingle(bytes, 34),
                BitConverter.ToSingle(bytes, 38)
            ),
            m_startDirection = new UnityEngine.Vector3(
                BitConverter.ToSingle(bytes, 42),
                BitConverter.ToSingle(bytes, 46),
                BitConverter.ToSingle(bytes, 50)
            ),
            m_speedInMetersPerSecond = BitConverter.ToSingle(bytes, 54),
            m_colliderRadius = BitConverter.ToSingle(bytes, 58)
        };
        return true; 
    }
}
