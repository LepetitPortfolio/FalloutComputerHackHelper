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

    private RectTransform m_WordLineSize;

    [SerializeField]
    private bool m_AddWordInHackWordList = false;

    #endregion

    #region Initialisation
    // Use this for initialization
    void Start()
    {
        m_WordLineList = new List<WordLine>();
        m_WordLineSize = m_WordLinePrefab.GetComponent<RectTransform>(); 
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
        
        List<string> words = LibraryFunctions.GetWordsManager().GetWordList();

        if(m_AddWordInHackWordList)
        {
            words = LibraryFunctions.GetWordsManager().GetWordHackList();
        }

        for(int wordIndex = 0; wordIndex < words.Count; wordIndex++)
        {
            AddWordLineInWordsScroll(words[wordIndex], wordIndex);
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

                
                if (m_AddWordInHackWordList)
                {
                    wordCountRegisted = LibraryFunctions.GetWordsManager().GetWordHackList().Count;
                    LibraryFunctions.GetWordsManager().AddHackWord(word);
                }
                else
                {
                    wordCountRegisted = LibraryFunctions.GetWordsManager().GetWordList().Count;
                    LibraryFunctions.GetWordsManager().AddWord(word);
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

            Rect rect = m_WordLinePrefab.GetRectTransform().rect;

            Initialize(wordLine, _Word, _WordCount);
        }        
    }

    public void Initialize(WordLine _WordLine, string _Word, int _WordCount)
    {
        if(_WordLine)
        {
            m_WordLineList.Add(_WordLine);

            Vector3 wordLinePosition = new Vector3();
            wordLinePosition.y -= (_WordCount * m_WordLineSize.rect.height);
            _WordLine.GetRectTransform().localPosition += wordLinePosition;

            _WordLine.InitializeLine(_Word, this, m_AddWordInHackWordList);
        }
    }

    public void DeleteLine(string _WordLine)
    {
        WordLine wordLineFind = null;
        int wordLineIndex = 0;
        while ((wordLineFind == null) && (wordLineIndex < m_WordLineList.Count))
        {
            WordLine wordLine = m_WordLineList[wordLineIndex];

            if(wordLine.GetWord().text == _WordLine)
            {
                wordLineFind = wordLine;
            }
            else
            {
                wordLineIndex++;
            }
        }

        if(wordLineFind)
        {
            DeleteLine(wordLineFind);
        }
    }

    public void DeleteLine(WordLine _WordLine)
    {
        if(m_AddWordInHackWordList)
        {
            LibraryFunctions.GetWordsManager().RemoveHackWord(_WordLine.GetWord().text);
        }
        else
        {
            LibraryFunctions.GetWordsManager().RemoveWord(_WordLine.GetWord().text);
        }

        int wordLineIndex = m_WordLineList.IndexOf(_WordLine);
        float wordLineHeight = _WordLine.GetRectTransform().rect.height;
        m_WordLineList.Remove(_WordLine);

        for(; wordLineIndex < m_WordLineList.Count; wordLineIndex++)
        {
            WordLine wordLine= m_WordLineList[wordLineIndex];

            Vector3 wordLinePosition = new Vector3();
            wordLinePosition.y = m_WordLineSize.rect.height;
            wordLine.GetRectTransform().localPosition += wordLinePosition;
        }

        DestroyImmediate(_WordLine.gameObject);

    }

    #endregion
}
