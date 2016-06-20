using UnityEngine;

[System.Serializable]
public class VNDialog 
{
    public string m_Speaker;
    public string m_Lines;

    public VNDialog(string a_speaker, string a_lines)
    {
        m_Speaker = a_speaker;
        m_Lines = a_lines;
    }
    public VNDialog() { }
}
