
//Refresh every seconds
using UnityEngine;

[System.Serializable]
public struct S_LinearProjectilePoolItemCreationEvent
{
    public byte m_poolId;
    public uint m_poolItemIndex;
    public ulong m_serverUtcNowTicks;
    public Vector3 m_startPosition;
    public Quaternion m_startRotation;
    public Vector3 m_startDirection;
    public float m_speedInMetersPerSecond;
    public float m_colliderRadius;
}
