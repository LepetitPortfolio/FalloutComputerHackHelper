using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;


public class WordsManager : MonoBehaviour
{
    #region Members
    public static WordsManager m_Instance { get; private set; }

    private Dictionary<char, ECharacterStat> m_CharracterState = new Dictionary<char, ECharacterStat>();

    private List<string> m_WordList;

    private List<string> m_WordHackList;

    #endregion


    #region Manipulators

    private void Awake()
    {
        if (m_Instance != null)
        {
            Debug.LogError("Found more than one Words Manager in this scene");
        }
        m_Instance = this;

    }

    ///<summary>
    /// Use this for initialization
    ///</summary>
    void Start()
    {
        m_WordList = new List<string>();

        AppData loadData = LibraryFunctions.LoadData();
        if(loadData != null)
        {
            m_WordList = new List<string>(loadData.GetWordList());
        }

        m_WordHackList = new List<string>();
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
    }

    #endregion


    #region Functions

    public void AddHackWord(string _Word)
    {
        if (m_WordHackList == null)
        {
            m_WordHackList = new List<string>();
        }

        if (!m_WordHackList.Contains(_Word))
        {
            m_WordHackList.Add(_Word);
        }

        AddWord(_Word);

    }

    public bool ModifyHackWord(string _OldWord, string _NewWord)
    {        
        if (m_WordHackList == null)
        {
            AddHackWord(_NewWord);
            return true;
        }

        if (m_WordHackList.Contains(_NewWord))
        {
            return false;
        }

        if (m_WordHackList.Contains(_OldWord))
        {
            int wordIndex = m_WordHackList.IndexOf(_OldWord);

            m_WordHackList[wordIndex] = _NewWord;

        }
        else
        {
            AddHackWord(_NewWord);
        }
        return true;
    }

    public void RemoveHackWord(string _Word)
    {

        if (m_WordHackList.Contains(_Word))
        {
            m_WordHackList.Remove(_Word);
        }
        
    }

    public void CleanHackwords()
    {
        if (m_WordHackList == null)
        {
            m_WordHackList = new List<string>();
            return;
        }

        if(m_WordHackList.Count > 0)
        {
            m_WordHackList.Clear();
        }
    }

    public void AddWord(string _Word)
    { 
        
        if (m_WordList == null)
        {
            m_WordList = new List<string>();
        }

        if (!m_WordList.Contains(_Word))
        {
            m_WordList.Add(_Word);

            LibraryFunctions.SaveData();
        }
    }

    public bool ModifyWord(string _OldWord, string _NewWord)
    {       

        if (m_WordList == null)
        {
            AddWord(_NewWord);
            return true;
        }

        if (m_WordList.Contains(_NewWord))
        {
            return false;
        }

        if (m_WordList.Contains(_OldWord))
        {
            int wordIndex = m_WordList.IndexOf(_OldWord);

            m_WordList[wordIndex] = _NewWord;

            LibraryFunctions.SaveData();
        }
        else
        {
            AddWord(_NewWord);
        }

        return true;
    }

    public void RemoveWord(string _Word)
    {
        if (m_WordList == null)
        {
            m_WordList = new List<string>();
            return;
        }

        if (m_WordList.Contains(_Word))
        {
            m_WordList.Remove(_Word);

            LibraryFunctions.SaveData();
        }
    }

    #endregion


    #region Accessors

    public List<string> GetWordList()
    {
        if (m_WordList == null)
        {
            m_WordList = new List<string>();
        }
        return m_WordList;
    }

    public List<string> GetWordHackList()
    {
        if (m_WordHackList == null)
        {
            m_WordHackList = new List<string>();
        }
        return m_WordHackList;
    }

    #endregion
}