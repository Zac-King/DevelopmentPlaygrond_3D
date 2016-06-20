using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class VNManager : MonoBehaviour
{
    [Header("Diplay Objects")]
    [SerializeField] private UnityEngine.UI.Text m_writing;
    [SerializeField] private UnityEngine.UI.Text m_Speaker;
    //[SerializeField] private float m_dialogDelay = 2;
    [Header("Dialog Sequence")]
    [SerializeField] private List<string> asdf;
    [SerializeField] private List<VNDialog> m_dialog;



    //IEnumerator ChatBubbleTest()
    //{
    //    int i = 0;
    //    while (i < m_dialog.Count)
    //    {
    //        m_dialog[i].SetActive(true);
    //        float t = 0;
    //        while (t < m_dialogDelay)
    //        {
    //            t += Time.deltaTime;
    //            yield return null;
    //        }
    //        m_dialog[i].SetActive(false);
    //        i++;
    //    }
    //    Debug.Log("End Dialog");
    //}

    //[ContextMenu("Begin")]
    //public void Begin()
    //{
    //    StartCoroutine(ChatBubbleTest());
    //}

    void Awake()
    {
        ReadDialog(@"C:\Users\zac.king\Desktop\VisualNovel\Assets\Resource\Test.txt");
        StartCoroutine(TraverseDialog());
    }

    [ContextMenu("Begin Read")]
    public void ReadDialog(string a_DialogPath)
    {
        System.IO.StreamReader file = new System.IO.StreamReader(a_DialogPath);

        string line;
        string pSpeaker = null;
        string pDialog = null;
        while((line = file.ReadLine()) != null)
        {
            if(line.Contains(">>"))
            {
                string n = line.Replace(">>", "");
                pSpeaker = n;
                pDialog = null;
            }
            if(line.Contains("<<"))
            {
                string n = line.Replace("<<", "");
                pDialog = n;
            }

            if(pDialog != null && pSpeaker != null)
            {
                VNDialog t = new VNDialog(pSpeaker, pDialog);

                m_dialog.Add(t);

                pSpeaker = null;
                pDialog = null;
            }
        }

        file.Close();
    }

    IEnumerator TraverseDialog()
    {
        int i = 0;
        while (m_dialog.Count > i)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                m_Speaker.text = m_dialog[i].m_Speaker;
                m_writing.text = m_dialog[i].m_Lines;
                i++;
            }
            yield return null;
        } 
    }

    private string GrabInsertedValue(string body, string leftDenote, string rightDenote)
    {
        int pfrom = body.IndexOf(leftDenote) + leftDenote.Length;
        int pTo = body.IndexOf(rightDenote);

        return body.Substring(pfrom, pTo);
    }
}
