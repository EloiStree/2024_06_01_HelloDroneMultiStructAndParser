using System;

[System.Serializable]
public class CPS_DroneSoccerIndexIntegerClaim : AbstractCategoryBytesParsable<S_DroneSoccerIndexIntegerClaim>
{
    public int m_size=>1 + 4 * 12;

    public override void GetCopy(S_DroneSoccerIndexIntegerClaim source, out S_DroneSoccerIndexIntegerClaim copy)
    {
        copy = new S_DroneSoccerIndexIntegerClaim()
        {
            m_redDrone0Stricker = source.m_redDrone0Stricker,
            m_redDrone1 = source.m_redDrone1,
            m_redDrone2 = source.m_redDrone2,
            m_redDrone3 = source.m_redDrone3,
            m_redDrone4 = source.m_redDrone4,
            m_redDrone5 = source.m_redDrone5,
            m_blueDrone0Stricker = source.m_blueDrone0Stricker,
            m_blueDrone1 = source.m_blueDrone1,
            m_blueDrone2 = source.m_blueDrone2,
            m_blueDrone3 = source.m_blueDrone3,
            m_blueDrone4 = source.m_blueDrone4,
            m_blueDrone5 = source.m_blueDrone5
        };
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {
        hasFixedSize = true;
        bytesSize = m_size;
    }

    public override void Parse(byte category255, S_DroneSoccerIndexIntegerClaim toParse, out byte[] bytes)
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

    public override void Randomize(S_DroneSoccerIndexIntegerClaim source, out S_DroneSoccerIndexIntegerClaim copy)
    {
        GetCopy(source, out copy);

            copy.m_redDrone0Stricker = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_redDrone1 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_redDrone2 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_redDrone3 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_redDrone4 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_redDrone5 = UnityEngine.Random.Range(int.MinValue, int.MaxValue); 
            copy.m_blueDrone0Stricker = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_blueDrone1 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_blueDrone2 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_blueDrone3 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_blueDrone4 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
            copy.m_blueDrone5 = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        
    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerIndexIntegerClaim fromBytes)
    {
        category255 = bytes[0];
        fromBytes = new S_DroneSoccerIndexIntegerClaim()
        {
            m_redDrone0Stricker = BitConverter.ToInt32(bytes, 1),
            m_redDrone1 = BitConverter.ToInt32(bytes, 5),
            m_redDrone2 = BitConverter.ToInt32(bytes, 9),
            m_redDrone3 = BitConverter.ToInt32(bytes, 13),
            m_redDrone4 = BitConverter.ToInt32(bytes, 17),
            m_redDrone5 = BitConverter.ToInt32(bytes, 21),
            m_blueDrone0Stricker = BitConverter.ToInt32(bytes, 25),
            m_blueDrone1 = BitConverter.ToInt32(bytes, 29),
            m_blueDrone2 = BitConverter.ToInt32(bytes, 33),
            m_blueDrone3 = BitConverter.ToInt32(bytes, 37),
            m_blueDrone4 = BitConverter.ToInt32(bytes, 41),
            m_blueDrone5 = BitConverter.ToInt32(bytes, 45)
        };
        return true;
    }
}