using System;
using UnityEngine;

[System.Serializable]
public struct S_DroneSoccerBallState
{
    public long m_dateTimeUtcTick;
    public Vector3 m_position;
    public Quaternion m_rotation;

    public S_DroneSoccerBallState GetCopy() {
        return new S_DroneSoccerBallState() {
            m_dateTimeUtcTick = m_dateTimeUtcTick,
            m_position = m_position,
            m_rotation = m_rotation
        };
    }
}



public struct PS_DroneSoccerBallState : I_CategoryBytesParsable<S_DroneSoccerBallState>
{
    public void Parse(byte category255, S_DroneSoccerBallState toParse, out byte[] bytes)
    {
        long serverTickTime = toParse.m_dateTimeUtcTick;
        Vector3 e = toParse.m_rotation.eulerAngles;
        byte eulerX = (byte)((e.x % 360f / 360f) * 255f);
        byte eulerY = (byte)((e.y % 360f / 360f) * 255f);
        byte eulerZ = (byte)((e.z % 360f / 360f) * 255f);


        bytes = new byte[1 + 4 * 3 + 2 * 3];
        bytes[0] = 8;
        BitConverter.GetBytes(serverTickTime).CopyTo(bytes, 1);
        BitConverter.GetBytes(ClampShort(toParse.m_position.x)).CopyTo(bytes, 9);
        BitConverter.GetBytes(ClampShort(toParse.m_position.y)).CopyTo(bytes, 11);
        BitConverter.GetBytes(ClampShort(toParse.m_position.z)).CopyTo(bytes, 13);
        bytes[15] = eulerX;
        bytes[16] = eulerY;
        bytes[17] = eulerZ;
    }
    private static ushort ClampShort(float value)
    {
        return (ushort)Mathf.Clamp(value, short.MinValue, short.MaxValue);
    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerBallState fromBytes)
    {
        throw new System.NotImplementedException();
    }
}
