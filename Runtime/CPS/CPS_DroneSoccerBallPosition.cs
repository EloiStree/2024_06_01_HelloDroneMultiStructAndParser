using System;
using UnityEngine;

[System.Serializable]
public class CPS_DroneSoccerBallPosition : AbstractCategoryBytesParsable<S_DroneSoccerBallPosition>
{
    public int m_size => 1 + 8 + 3 * 2 + 3 ;
    public override void Parse(byte category255, S_DroneSoccerBallPosition toParse, out byte[] bytes)
    {
        ulong serverTickTime = toParse.m_dateTimeUtcTick;
        Vector3 e = toParse.m_rotation.eulerAngles;
        byte eulerX = (byte)((e.x % 360f / 360f) * 255f);
        byte eulerY = (byte)((e.y % 360f / 360f) * 255f);
        byte eulerZ = (byte)((e.z % 360f / 360f) * 255f);


        bytes = new byte[m_size];
        bytes[0] = category255;
        BitConverter.GetBytes(serverTickTime).CopyTo(bytes, 1);
        BitConverter.GetBytes(ClampShort(toParse.m_position.x)).CopyTo(bytes, 9);
        BitConverter.GetBytes(ClampShort(toParse.m_position.y)).CopyTo(bytes, 11);
        BitConverter.GetBytes(ClampShort(toParse.m_position.z)).CopyTo(bytes, 13);
        bytes[15] = eulerX;
        bytes[16] = eulerY;
        bytes[17] = eulerZ;
    }
    private static short ClampShort(float value)
    {
        return (short)Mathf.Clamp(value, short.MinValue, short.MaxValue);
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerBallPosition fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DroneSoccerBallPosition();
        fromBytes.m_dateTimeUtcTick = BitConverter.ToUInt64(bytes, 1);
        fromBytes.m_position.x = BitConverter.ToInt16(bytes, 9);
        fromBytes.m_position.y = BitConverter.ToInt16(bytes, 11);
        fromBytes.m_position.z = BitConverter.ToInt16(bytes, 13);
        fromBytes.m_rotation = Quaternion.Euler(
            (bytes[15] / 255f) * 360f,
            (bytes[16] / 255f) * 360f,
            (bytes[17] / 255f) * 360f
        );
        return true;
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public override void Randomize(S_DroneSoccerBallPosition source, out S_DroneSoccerBallPosition copy)
    {
        GetCopy(source, out copy);
        copy.m_dateTimeUtcTick = (ulong)UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        copy.m_position = new Vector3(UnityEngine.Random.Range(short.MinValue, short.MaxValue), UnityEngine.Random.Range(short.MinValue, short.MaxValue), UnityEngine.Random.Range(short.MinValue, short.MaxValue));
        copy.m_rotation = Quaternion.Euler(UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f), UnityEngine.Random.Range(0, 360f));
           
    }

    public override void GetCopy(S_DroneSoccerBallPosition source, out S_DroneSoccerBallPosition copy)
    {
        copy = new S_DroneSoccerBallPosition();
        copy.m_dateTimeUtcTick = source.m_dateTimeUtcTick;
        copy.m_position = source.m_position;
        copy.m_rotation = source.m_rotation;
    }
}
