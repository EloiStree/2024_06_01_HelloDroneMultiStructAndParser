using System;
using System.Text;

[System.Serializable]
public struct S_DroneSoccerPublicXmlRsaKey1024Claim
{
    public string m_redDrone0Stricker;
    public string m_redDrone1;
    public string m_redDrone2;
    public string m_redDrone3;
    public string m_redDrone4;
    public string m_redDrone5;
    public string m_blueDrone0Stricker;
    public string m_blueDrone1;
    public string m_blueDrone2;
    public string m_blueDrone3;
    public string m_blueDrone4;
    public string m_blueDrone5;

    public S_DroneSoccerPublicXmlRsaKey1024Claim GetCopy()
    {

        return new S_DroneSoccerPublicXmlRsaKey1024Claim()
        {
            m_redDrone0Stricker = m_redDrone0Stricker.ToString(),
            m_redDrone1 = m_redDrone1.ToString(),
            m_redDrone2 = m_redDrone2.ToString(),
            m_redDrone3 = m_redDrone3.ToString(),
            m_redDrone4 = m_redDrone4.ToString(),
            m_redDrone5 = m_redDrone5.ToString(),
            m_blueDrone0Stricker = m_blueDrone0Stricker.ToString(),
            m_blueDrone1 = m_blueDrone1.ToString(),
            m_blueDrone2 = m_blueDrone2.ToString(),
            m_blueDrone3 = m_blueDrone3.ToString(),
            m_blueDrone4 = m_blueDrone4.ToString(),
            m_blueDrone5 = m_blueDrone5.ToString()
        };
    }
}

//I_BytesParsable

public struct PS_DroneSoccerPublicXmlRsaKey1024Claim 
    
    :I_CategoryBytesParsable< S_DroneSoccerPublicXmlRsaKey1024Claim>,
    I_TextParsable<S_DroneSoccerPublicXmlRsaKey1024Claim>
{
    public bool IsValideForParsing(string text)
    {
        throw new System.NotImplementedException();
    }

    public void Parse(S_DroneSoccerPublicXmlRsaKey1024Claim toParse, out string text)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<xml>");
        sb.AppendLine(toParse.m_blueDrone0Stricker);
        sb.AppendLine(toParse.m_blueDrone1);
        sb.AppendLine(toParse.m_blueDrone2);
        sb.AppendLine(toParse.m_blueDrone3);
        sb.AppendLine(toParse.m_blueDrone4);
        sb.AppendLine(toParse.m_blueDrone5);
        sb.AppendLine(toParse.m_redDrone0Stricker);
        sb.AppendLine(toParse.m_redDrone1);
        sb.AppendLine(toParse.m_redDrone2);
        sb.AppendLine(toParse.m_redDrone3);
        sb.AppendLine(toParse.m_redDrone4);
        sb.AppendLine(toParse.m_redDrone5);
        sb.AppendLine("</xml>");
        text = sb.ToString();
    }

    public void Parse(byte category255, S_DroneSoccerPublicXmlRsaKey1024Claim toParse, out byte[] bytes)
    {
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_redDrone0Stricker, out byte[] redDrone0Stricker);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_redDrone1, out byte[] redDrone1);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_redDrone2, out byte[] redDrone2);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_redDrone3, out byte[] redDrone3);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_redDrone4, out byte[] redDrone4);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_redDrone5, out byte[] redDrone5);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_blueDrone0Stricker, out byte[] blueDrone0Stricker);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_blueDrone1, out byte[] blueDrone1);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_blueDrone2, out byte[] blueDrone2);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_blueDrone3, out byte[] blueDrone3);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_blueDrone4, out byte[] blueDrone4);
        ConvertPublicRsaToBytesUtility.ParsePublicRsaKeyToBytesWithoutModule(toParse.m_blueDrone5, out byte[] blueDrone5);
        byte[] drones = new byte[1 + (128 * 12)];
        drones[0] = category255;
        Buffer.BlockCopy(redDrone0Stricker, 0, drones, 1, 128);
        Buffer.BlockCopy(redDrone1, 0, drones, 1 + 128, 128);
        Buffer.BlockCopy(redDrone2, 0, drones, 1 + 256, 128);
        Buffer.BlockCopy(redDrone3, 0, drones, 1 + 384, 128);
        Buffer.BlockCopy(redDrone4, 0, drones, 1 + 512, 128);
        Buffer.BlockCopy(redDrone5, 0, drones, 1 + 640, 128);
        Buffer.BlockCopy(blueDrone0Stricker, 0, drones, 1 + 768, 128);
        Buffer.BlockCopy(blueDrone1, 0, drones, 1 + 896, 128);
        Buffer.BlockCopy(blueDrone2, 0, drones, 1 + 1024, 128);
        Buffer.BlockCopy(blueDrone3, 0, drones, 1 + 1152, 128);
        Buffer.BlockCopy(blueDrone4, 0, drones, 1 + 1280, 128);
        Buffer.BlockCopy(blueDrone5, 0, drones, 1 + 1408, 128);
    }

    public bool TryParse(string text, out S_DroneSoccerPublicXmlRsaKey1024Claim paresed)
    {
        throw new System.NotImplementedException();
    }

    public bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerPublicXmlRsaKey1024Claim fromBytes)
    {
        throw new System.NotImplementedException();
    }
}