using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AddWordPanel : MonoBehaviour
{

    #region Membre
    [SerializeField]
    private TMPro.TMP_InputField m_WordTxtInput = null;

    private List<WordLine> m_WordLineList;

    [SerializeField]
    private ScrollRect m_WordsScroll = null;

    [SerializeField]
    private WordLine m_WordLinePrefab;

    private WordsManager m_WordsManager;

    [SerializeField]
    private bool m_AddWordInHackWordList = false;

    #endregion

    #region Initialisation
    // Use this for initialization
    void Start()
    {
        m_WordsManager = GameObject.FindObjectOfType<WordsManager>();
        m_WordLineList = new List<WordLine>();
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

    public void InitializePanel()
    {
        m_WordTxtInput.text = "";
        if (m_WordsManager != null)
        {
            List<string> words = m_WordsManager.GetWordList();

            if(m_AddWordInHackWordList)
            {
                words = m_WordsManager.GetWordHackList();
            }

            for(int wordIndex = 0; wordIndex < words.Count; wordIndex++)
            {
                AddWordLineInWordsScroll(words[wordIndex], wordIndex);
            }
            
        }
    }    

    public void ResetPanel()
    {
        if (m_WordLineList != null)
        {
            while (m_WordLineList.Count != 0)
            {
                DestroyImmediate(m_WordLineList[0].gameObject);
                m_WordLineList.RemoveAt(0);
            }
        }

        m_WordTxtInput.text = "";
    }

    public void AddWord()
    {
        if (m_WordTxtInput)
        {
            string word = m_WordTxtInput.text;

            if (word.Length != 0)
            {
                word = LibraryFunctions.UpCapsWord(word);
                int wordCountRegisted = 0;

                if (m_WordsManager)
                {
                    if (m_AddWordInHackWordList)
                    {
                        wordCountRegisted = m_WordsManager.GetWordHackList().Count;
                        m_WordsManager.AddHackWord(word);
                    }
                    else
                    {
                        wordCountRegisted = m_WordsManager.GetWordList().Count;
                        m_WordsManager.AddWord(word);
                    }
                }

                AddWordLineInWordsScroll(word, wordCountRegisted);

                m_WordTxtInput.text = "";
            }
        }
    }

    public void AddWordLineInWordsScroll(string _Word, int _WordCount)
    {
        if (m_WordsScroll && m_WordLinePrefab)
        {
            WordLine wordLine = Instantiate<WordLine>(m_WordLinePrefab, m_WordsScroll.content.transform);

            Initialize(wordLine, _Word, _WordCount);
        }        
    }

    public void Initialize(WordLine _WordLine, string _Word, int _WordCount)
    {
        if(_WordLine)
        {
            m_WordLineList.Add(_WordLine);
            Vector3 wordLinePosition = new Vector3();
            wordLinePosition.y = (-_WordLine.GetRectTransform().rect.height / 2) - (_WordCount * _WordLine.GetRectTransform().rect.height);
            _WordLine.GetRectTransform().anchoredPosition = wordLinePosition;

            _WordLine.SetWord(_Word);
        }
    }

    #endregion
}
