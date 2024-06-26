using System;

[System.Serializable]
public class PS_DronePositionCompressed : I_BytesParsable< S_DronePositionCompressed>, I_ItemCopyable<S_DronePositionCompressed>, I_ItemRandomizable<S_DronePositionCompressed>
{
    public int m_bytesSize => 9;
    public void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = 9;
    }


    public bool TryParse(byte[] bytes, out S_DronePositionCompressed fromBytes)
    {
        fromBytes = new S_DronePositionCompressed();
        fromBytes.m_localPositionXFromCenter = BitConverter.ToInt16(bytes, 0);
        fromBytes.m_localPositionYFromGround = BitConverter.ToUInt16(bytes, 2);
        fromBytes.m_localPositionZFromCenter = BitConverter.ToInt16(bytes, 4);
        fromBytes.m_eulerAngleX = bytes[6];
        fromBytes.m_eulerAngleY = bytes[7];
        fromBytes.m_eulerAngleZ = bytes[8];
        return true;
    }
    public void Parse(S_DronePositionCompressed toParse, out byte[] bytes)
    {

        bytes = new byte[m_bytesSize];
        BitConverter.GetBytes(toParse.m_localPositionXFromCenter).CopyTo(bytes, 0);
        BitConverter.GetBytes(toParse.m_localPositionYFromGround).CopyTo(bytes, 2);
        BitConverter.GetBytes(toParse.m_localPositionZFromCenter).CopyTo(bytes, 4);
        bytes[6] = toParse.m_eulerAngleX;
        bytes[7] = toParse.m_eulerAngleY;
        bytes[8] = toParse.m_eulerAngleZ;

    
    }

    public void GetCopy(S_DronePositionCompressed source, out S_DronePositionCompressed copy)
    {
        copy = new S_DronePositionCompressed();
        copy.m_localPositionXFromCenter = source.m_localPositionXFromCenter;
        copy.m_localPositionYFromGround = source.m_localPositionYFromGround;
        copy.m_localPositionZFromCenter = source.m_localPositionZFromCenter;
        copy.m_eulerAngleX = source.m_eulerAngleX;
        copy.m_eulerAngleY = source.m_eulerAngleY;
        copy.m_eulerAngleZ = source.m_eulerAngleZ;
    }

    public void Randomize(S_DronePositionCompressed source, out S_DronePositionCompressed copy)
    {
        GetCopy(source, out copy);
        copy.m_localPositionXFromCenter = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);
        copy.m_localPositionYFromGround = (ushort)UnityEngine.Random.Range(0, ushort.MaxValue);
        copy.m_localPositionZFromCenter = (short)UnityEngine.Random.Range(short.MinValue, short.MaxValue);
        copy.m_eulerAngleX = (byte)UnityEngine.Random.Range(byte.MinValue, byte.MaxValue);
        copy.m_eulerAngleY = (byte)UnityEngine.Random.Range(byte.MinValue, byte.MaxValue);
        copy.m_eulerAngleZ = (byte)UnityEngine.Random.Range(byte.MinValue, byte.MaxValue);

    }
}