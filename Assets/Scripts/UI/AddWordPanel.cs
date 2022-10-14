using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddWordPanel : MonoBehaviour
{

    #region Membre
    [SerializeField]
    private TMPro.TMP_InputField m_WordTxtInput = null;

    [SerializeField]
    private ScrollRect m_WordsScroll = null;

    [SerializeField]
    private WordLine m_WordLinePrefab;

    private WordsManager m_WordsManager;

    #endregion

    #region Initialisation
    // Use this for initialization
    void Start()
    {
        m_WordsManager = GameObject.FindObjectOfType<WordsManager>();
    }
    #endregion

    #region Accessor

    #endregion

    #region Unity Action

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region AddWordPanel

    public void ResetPanel()
    {
        while (m_WordsScroll.content.childCount != 0)
        {
            DestroyImmediate(m_WordsScroll.content.GetChild(0));
        }

        m_WordTxtInput.text = "";
    }

    public void AddWord()
    {
        if (m_WordTxtInput && m_WordsScroll && m_WordLinePrefab)
        {
            string word = m_WordTxtInput.text;

            if (word.Length != 0)
            {
                word = LibraryFunctions.UpCapsWord(word);

                WordLine wordLine = Instantiate<WordLine>(m_WordLinePrefab, m_WordsScroll.content.transform);

                wordLine.SetWord(word);

                if (m_WordsManager)
                {
                    m_WordsManager.AddHackWord(word);
                }

                m_WordTxtInput.text = "";
            }
        }
    }
    #endregion
}
