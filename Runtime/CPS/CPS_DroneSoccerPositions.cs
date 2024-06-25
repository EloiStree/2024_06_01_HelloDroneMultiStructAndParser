
//12 time per second refresh
using PlasticGui.WorkspaceWindow;
using System;
//I_BytesParsable
[System.Serializable]
public class CPS_DroneSoccerPositions : AbstractCategoryBytesParsable<S_DroneSoccerPositions>
{
    public int m_bytesSize => 1 + 16 + (9 * 12);
    public override void Parse(byte category255, S_DroneSoccerPositions toParse, out byte[] bytes)
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

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerPositions fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DroneSoccerPositions();
        fromBytes.m_dateTimeUtcTick = BitConverter.ToUInt64(bytes, 1);
        fromBytes.m_framePushed = BitConverter.ToUInt64(bytes, 9);
        int index = 17;
        ParseD(index, ref bytes,    out fromBytes.m_redDrone0Stricker);
        ParseD(index+9, ref bytes,  out fromBytes.m_redDrone1);
        ParseD(index+18, ref bytes, out fromBytes.m_redDrone2);
        ParseD(index+27, ref bytes, out fromBytes.m_redDrone3);
        ParseD(index+36, ref bytes, out fromBytes.m_redDrone4);
        ParseD(index+45, ref bytes, out fromBytes.m_redDrone5);
        ParseD(index+54, ref bytes, out fromBytes.m_blueDrone0Stricker);
        ParseD(index+63, ref bytes, out fromBytes.m_blueDrone1);
        ParseD(index+72, ref bytes, out fromBytes.m_blueDrone2);
        ParseD(index+81, ref bytes, out fromBytes.m_blueDrone3);
        ParseD(index+90, ref bytes, out fromBytes.m_blueDrone4);
        ParseD(index+99, ref bytes, out fromBytes.m_blueDrone5);
            
            



        return true;
        
    }

    private void ParseD(int index, ref byte[] bytes, out S_DronePositionCompressed m_blueDrone0Stricker)
    {


        m_blueDrone0Stricker = new S_DronePositionCompressed();
        m_blueDrone0Stricker.m_localPositionX = BitConverter.ToInt16(bytes, index);
        m_blueDrone0Stricker.m_localPositionY = BitConverter.ToInt16(bytes, index + 2);
        m_blueDrone0Stricker.m_localPositionZ = BitConverter.ToInt16(bytes, index + 4);
        m_blueDrone0Stricker.m_eulerAngleX = bytes[index + 6];
        m_blueDrone0Stricker.m_eulerAngleY = bytes[index + 7];
        m_blueDrone0Stricker.m_eulerAngleZ = bytes[index + 8];
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_bytesSize;
    }

    CPS_DronePositionCompressed p = new CPS_DronePositionCompressed();
    public override void Randomize(S_DroneSoccerPositions source, out S_DroneSoccerPositions copy)
    {
        GetCopy(source, out copy);
        copy.m_dateTimeUtcTick = (ulong)UnityEngine.Random.Range(0, int.MaxValue);
        copy.m_framePushed = (ulong)UnityEngine.Random.Range(0, int.MaxValue);

        p.Randomize(source.m_redDrone0Stricker, out copy.m_redDrone0Stricker);
        p.Randomize(source.m_redDrone1, out copy.m_redDrone1);
        p.Randomize(source.m_redDrone2, out copy.m_redDrone2);
        p.Randomize(source.m_redDrone3, out copy.m_redDrone3);
        p.Randomize(source.m_redDrone4, out copy.m_redDrone4);
        p.Randomize(source.m_redDrone5, out copy.m_redDrone5);
        p.Randomize(source.m_blueDrone0Stricker, out copy.m_blueDrone0Stricker);
        p.Randomize(source.m_blueDrone1, out copy.m_blueDrone1);
        p.Randomize(source.m_blueDrone2, out copy.m_blueDrone2);
        p.Randomize(source.m_blueDrone3, out copy.m_blueDrone3);
        p.Randomize(source.m_blueDrone4, out copy.m_blueDrone4);
        p.Randomize(source.m_blueDrone5, out copy.m_blueDrone5);

    }

    public override void GetCopy(S_DroneSoccerPositions source, out S_DroneSoccerPositions copy)
    {
        copy = new S_DroneSoccerPositions();
        copy.m_dateTimeUtcTick = source.m_dateTimeUtcTick;
        copy.m_framePushed = source.m_framePushed;
        p.GetCopy(source.m_redDrone0Stricker, out copy.m_redDrone0Stricker);
        p.GetCopy(source.m_redDrone1, out copy.m_redDrone1);
        p.GetCopy(source.m_redDrone2, out copy.m_redDrone2);
        p.GetCopy(source.m_redDrone3, out copy.m_redDrone3);
        p.GetCopy(source.m_redDrone4, out copy.m_redDrone4);
        p.GetCopy(source.m_redDrone5, out copy.m_redDrone5);
        p.GetCopy(source.m_blueDrone0Stricker, out copy.m_blueDrone0Stricker);
        p.GetCopy(source.m_blueDrone1, out copy.m_blueDrone1);
        p.GetCopy(source.m_blueDrone2, out copy.m_blueDrone2);
        p.GetCopy(source.m_blueDrone3, out copy.m_blueDrone3);
        p.GetCopy(source.m_blueDrone4, out copy.m_blueDrone4);
        p.GetCopy(source.m_blueDrone5, out copy.m_blueDrone5);
     

    }
}