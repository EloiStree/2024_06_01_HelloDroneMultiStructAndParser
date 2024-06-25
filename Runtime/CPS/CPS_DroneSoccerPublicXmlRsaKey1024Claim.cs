using System;
using System.Collections.Generic;
using System.Text;
//I_BytesParsable

[System.Serializable]
public class CPS_DroneSoccerPublicXmlRsaKey1024Claim 
    
    : AbstractCategoryBytesParsable< S_DroneSoccerPublicXmlRsaKey1024Claim>,
    I_TextParsable<S_DroneSoccerPublicXmlRsaKey1024Claim>
{
    public int m_bytesSize => 1 + (128 * 12);

    public override void GetCopy(S_DroneSoccerPublicXmlRsaKey1024Claim source, out S_DroneSoccerPublicXmlRsaKey1024Claim copy)
    {
        copy = new S_DroneSoccerPublicXmlRsaKey1024Claim();
        copy.m_redDrone0Stricker = source.m_redDrone0Stricker.ToString() ;
        copy.m_redDrone1 = source.m_redDrone1.ToString();
        copy.m_redDrone2 = source.m_redDrone2.ToString();
        copy.m_redDrone3 = source.m_redDrone3.ToString();
        copy.m_redDrone4 = source.m_redDrone4.ToString();
        copy.m_redDrone5 = source.m_redDrone5.ToString();
        copy.m_blueDrone0Stricker = source.m_blueDrone0Stricker.ToString();
        copy.m_blueDrone1 = source.m_blueDrone1.ToString();
        copy.m_blueDrone2 = source.m_blueDrone2.ToString();
        copy.m_blueDrone3 = source.m_blueDrone3.ToString();
        copy.m_blueDrone4 = source.m_blueDrone4.ToString();
        copy.m_blueDrone5 = source.m_blueDrone5.ToString();
    }

    public override void HasFixedSize(out bool hasFixedSize, out int bytesSize)
    {

        hasFixedSize = true;
        bytesSize = m_bytesSize;

    }

    public bool IsValideForParsing(string text)
    {
        return text.IndexOf("<PublicXml1024RSA>") >= 0;
    }

    public void Parse(S_DroneSoccerPublicXmlRsaKey1024Claim toParse, out string text)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<PublicXml1024RSA>");
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
        sb.AppendLine("</PublicXml1024RSA>");
        text = sb.ToString();
    }

    public override void Parse(byte category255, S_DroneSoccerPublicXmlRsaKey1024Claim toParse, out byte[] bytes)
    {
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_redDrone0Stricker, out byte[] redDrone0Stricker);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_redDrone1, out byte[] redDrone1);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_redDrone2, out byte[] redDrone2);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_redDrone3, out byte[] redDrone3);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_redDrone4, out byte[] redDrone4);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_redDrone5, out byte[] redDrone5);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_blueDrone0Stricker, out byte[] blueDrone0Stricker);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_blueDrone1, out byte[] blueDrone1);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_blueDrone2, out byte[] blueDrone2);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_blueDrone3, out byte[] blueDrone3);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_blueDrone4, out byte[] blueDrone4);
        ConvertPublicRsa1024XmlToBytesUtility.ParsePublicRsaToBytesWithoutModule(toParse.m_blueDrone5, out byte[] blueDrone5);
        bytes = new byte[m_bytesSize];
        bytes[0] = category255;
        Buffer.BlockCopy(redDrone0Stricker,     0, bytes, 1, 128);
        Buffer.BlockCopy(redDrone1,             0, bytes, 1 + 128, 128);
        Buffer.BlockCopy(redDrone2,             0, bytes, 1 + 256, 128);
        Buffer.BlockCopy(redDrone3,             0, bytes, 1 + 384, 128);
        Buffer.BlockCopy(redDrone4,             0, bytes, 1 + 512, 128);
        Buffer.BlockCopy(redDrone5,             0, bytes, 1 + 640, 128);
        Buffer.BlockCopy(blueDrone0Stricker,    0, bytes, 1 + 768, 128);
        Buffer.BlockCopy(blueDrone1,            0, bytes, 1 + 896, 128);
        Buffer.BlockCopy(blueDrone2,            0, bytes, 1 + 1024, 128);
        Buffer.BlockCopy(blueDrone3,            0, bytes, 1 + 1152, 128);
        Buffer.BlockCopy(blueDrone4,            0, bytes, 1 + 1280, 128);
        Buffer.BlockCopy(blueDrone5,            0, bytes, 1 + 1408, 128);
    }

    public override void Randomize(S_DroneSoccerPublicXmlRsaKey1024Claim source, out S_DroneSoccerPublicXmlRsaKey1024Claim copy)
    {
        copy = new S_DroneSoccerPublicXmlRsaKey1024Claim();
        copy.m_redDrone0Stricker = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_redDrone1 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_redDrone2 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_redDrone3 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_redDrone4 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_redDrone5 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_blueDrone0Stricker = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_blueDrone1 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_blueDrone2 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_blueDrone3 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_blueDrone4 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
        copy.m_blueDrone5 = ConvertPublicRsa1024XmlToBytesUtility.GetRandomPublicRsaKey();
    }

    public bool TryParse(string text, out S_DroneSoccerPublicXmlRsaKey1024Claim paresed)
    {
        paresed = new S_DroneSoccerPublicXmlRsaKey1024Claim();
        if (text.IndexOf("<PublicXml1024RSA>") < 0)
        {
            return false;
        }
        text.Replace("<PublicXml1024RSA>", "");
        text.Replace("</PublicXml1024RSA>", "");
        string[] lines = text.Split('\n');
        List<string> publicRsaKeys = new List<string>();
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length > 40)
            {
                publicRsaKeys.Add(lines[i]);
            }
        }
        if (publicRsaKeys.Count >= 1) {  paresed.m_redDrone0Stricker = publicRsaKeys[0]; }
        if (publicRsaKeys.Count >= 2) {  paresed.m_redDrone1 = publicRsaKeys[1]; }
        if (publicRsaKeys.Count >= 3) {  paresed.m_redDrone2 = publicRsaKeys[2]; }
        if (publicRsaKeys.Count >= 4) {  paresed.m_redDrone3 = publicRsaKeys[3]; }
        if (publicRsaKeys.Count >= 5) {  paresed.m_redDrone4 = publicRsaKeys[4]; }
        if (publicRsaKeys.Count >= 6) {  paresed.m_redDrone5 = publicRsaKeys[5]; }
        if (publicRsaKeys.Count >= 7) {  paresed.m_blueDrone0Stricker = publicRsaKeys[6]; }
        if (publicRsaKeys.Count >= 8) {  paresed.m_blueDrone1 = publicRsaKeys[7]; }
        if (publicRsaKeys.Count >= 9) {  paresed.m_blueDrone2 = publicRsaKeys[8]; }
        if (publicRsaKeys.Count >= 10) { paresed.m_blueDrone3 = publicRsaKeys[9]; }
        if (publicRsaKeys.Count >= 11) { paresed.m_blueDrone4 = publicRsaKeys[10]; }
        if (publicRsaKeys.Count >= 12) { paresed.m_blueDrone5 = publicRsaKeys[11]; }
        return true; 

    }

    public override bool TryParse(byte[] bytes, out byte category255, out S_DroneSoccerPublicXmlRsaKey1024Claim fromBytes)
    {
        fromBytes = new S_DroneSoccerPublicXmlRsaKey1024Claim();
        category255 = bytes[0];
        List<string> publicRsaKeys = new List<string>();
        for (int i = 1; i < bytes.Length; i += 128)
        {
            byte[] b128 = new byte[128];
            Buffer.BlockCopy(bytes, i, b128, 0, 128);
            ConvertPublicRsa1024XmlToBytesUtility.ParseBytesToPublicRsaKey(b128, out string publicRsaKey);
            publicRsaKeys.Add(publicRsaKey);
        }
        if (publicRsaKeys.Count >= 1) {  fromBytes.m_redDrone0Stricker = publicRsaKeys[0]; }
        if (publicRsaKeys.Count >= 2) {  fromBytes.m_redDrone1 = publicRsaKeys[1]; }
        if (publicRsaKeys.Count >= 3) {  fromBytes.m_redDrone2 = publicRsaKeys[2]; }
        if (publicRsaKeys.Count >= 4) {  fromBytes.m_redDrone3 = publicRsaKeys[3]; }
        if (publicRsaKeys.Count >= 5) {  fromBytes.m_redDrone4 = publicRsaKeys[4]; }
        if (publicRsaKeys.Count >= 6) {  fromBytes.m_redDrone5 = publicRsaKeys[5]; }
        if (publicRsaKeys.Count >= 7) {  fromBytes.m_blueDrone0Stricker = publicRsaKeys[6]; }
        if (publicRsaKeys.Count >= 8) {  fromBytes.m_blueDrone1 = publicRsaKeys[7]; }
        if (publicRsaKeys.Count >= 9) {  fromBytes.m_blueDrone2 = publicRsaKeys[8]; }
        if (publicRsaKeys.Count >= 10) { fromBytes.m_blueDrone3 = publicRsaKeys[9]; }
        if (publicRsaKeys.Count >= 11) { fromBytes.m_blueDrone4 = publicRsaKeys[10]; }
        if (publicRsaKeys.Count >= 12) { fromBytes.m_blueDrone5 = publicRsaKeys[11]; }

        return true; 

    }
}