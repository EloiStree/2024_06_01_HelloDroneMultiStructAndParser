using System;

[System.Serializable]
public struct S_DroneSoccerIndexIntegerClaim
{
    public int m_redDrone0Stricker;
    public int m_redDrone1;
    public int m_redDrone2;
    public int m_redDrone3;
    public int m_redDrone4;
    public int m_redDrone5;
    public int m_blueDrone0Stricker;
    public int m_blueDrone1;
    public int m_blueDrone2;
    public int m_blueDrone3;
    public int m_blueDrone4;
    public int m_blueDrone5;

    public S_DroneSoccerIndexIntegerClaim GetCopy()
    {
        return new S_DroneSoccerIndexIntegerClaim()
        {
            m_redDrone0Stricker =(int) m_redDrone0Stricker,
            m_redDrone1 =(int) m_redDrone1,
            m_redDrone2 =(int) m_redDrone2,
            m_redDrone3 =(int) m_redDrone3,
            m_redDrone4 =(int) m_redDrone4,
            m_redDrone5 = (int)m_redDrone5,
            m_blueDrone0Stricker = (int)m_blueDrone0Stricker,
            m_blueDrone1 =(int) m_blueDrone1,
            m_blueDrone2 =(int) m_blueDrone2,
            m_blueDrone3 =(int) m_blueDrone3,
            m_blueDrone4 =(int) m_blueDrone4,
            m_blueDrone5 = (int)m_blueDrone5
        };

    }
}
public struct PS_DroneSoccerIndexIntegerClaim : I_CategoryBytesParsable<S_DroneSoccerIndexIntegerClaim>
{
    public void Parse(byte category255, S_DroneSoccerIndexIntegerClaim toParse, out byte[] bytes)
    {
         bytes = new byte[1 + 4 * 12];
        bytes[0] = category255;
        BitConverter.GetBytes(toParse.m_redDrone0Stricker).CopyTo(bytes, 1);
        BitConverter.GetBytes(toParse.m_redDrone1).CopyTo(bytes, 5);
        BitConverter.GetBytes(toParse.m_redDrone2).CopyTo(bytes, 9);
        BitConverter.GetBytes(toParse.m_redDrone3).CopyTo(bytes, 13);
        BitConverter.GetBytes(toParse.m_redDrone4).CopyTo(bytes, 17);
        BitConverter.GetBytes(toParse.m_redDrone5).CopyTo(bytes, 21);
        BitConverter.GetBytes(toParse.m_blueDrone0Stricker).CopyTo(bytes, 25);
        BitConverter.GetBytes(toParse.m_blueDrone1).CopyTo(bytes, 29);
        BitConverter.GetBytes(toParse.m_blueDrone2).CopyTo(bytes, 33);
        BitConverter.GetBytes(toParse.m_blueDrone3).CopyTo(bytes, 37);
        BitConverter.GetBytes(toParse.m_blueDrone4).CopyTo(bytes, 41);
        BitConverter.GetBytes(toParse.m_blueDrone5).CopyTo(bytes, 45);
    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerIndexIntegerClaim fromBytes)
    {
        throw new System.NotImplementedException();
    }
}