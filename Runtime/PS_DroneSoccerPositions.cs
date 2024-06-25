
//12 time per second refresh
using System;
//I_BytesParsable
public class PS_DroneSoccerPositions : I_CategoryBytesParsable<S_DroneSoccerPositions>
{
    public int m_bytesSize =  1 + 16 + (9 * 12);
    public void Parse(byte category255, S_DroneSoccerPositions toParse, out byte[] bytes)
    {
        int dronePositionByteLength = m_bytesSize;
        bytes = new byte[dronePositionByteLength];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_dateTimeUtcTick).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_framePushed).CopyTo(bytes, 9);
        GetByteAt(bytes, 17, ref toParse.m_redDrone0Stricker);
        GetByteAt(bytes, 17 + 9, ref toParse.m_redDrone1);
        GetByteAt(bytes, 17 + 18, ref toParse.m_redDrone2);
        GetByteAt(bytes, 17 + 27, ref toParse.m_redDrone3);
        GetByteAt(bytes, 17 + 36, ref toParse.m_redDrone4);
        GetByteAt(bytes, 17 + 45, ref toParse.m_redDrone5);
        GetByteAt(bytes, 17 + 54, ref toParse.m_blueDrone0Stricker);
        GetByteAt(bytes, 17 + 63, ref toParse.m_blueDrone1);
        GetByteAt(bytes, 17 + 72, ref toParse.m_blueDrone2);
        GetByteAt(bytes, 17 + 81, ref toParse.m_blueDrone3);
        GetByteAt(bytes, 17 + 90, ref toParse.m_blueDrone4);
        GetByteAt(bytes, 17 + 99, ref toParse.m_blueDrone5);
    }
    private void GetByteAt(byte[] b, int index, ref S_DronePositionCompressed drone)
    {

        BitConverter.GetBytes(drone.m_localPositionX).CopyTo(b, index);
        BitConverter.GetBytes(drone.m_localPositionY).CopyTo(b, index + 2);
        BitConverter.GetBytes(drone.m_localPositionZ).CopyTo(b, index + 4);
        b[index + 6] = drone.m_eulerAngleX;
        b[index + 7] = drone.m_eulerAngleY;
        b[index + 8] = drone.m_eulerAngleZ;
    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerPositions fromBytes)
    {
        throw new System.NotImplementedException();
    }

    public void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        throw new NotImplementedException();
    }
}