using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class WordsManager : MonoBehaviour
{
    #region Members
    private Dictionary<char, ECharacterState> m_CharracterState = new Dictionary<char, ECharacterState>();

    private List<Try> m_Tries = new List<Try>();

    private List<string> m_WordList;

    private List<string> m_WordHackList;

    private int m_WordsSize;

    private int m_NumberOfTrials;

    private int m_Try;



    #endregion


    #region Manipulators

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

    public void SetSettings(int _WordsSize, int _NumberOfTrials)
    {
        m_WordsSize = _WordsSize;
        m_NumberOfTrials = _NumberOfTrials;
    }

    public void Compute(string _Word, int _CharacterCorrect, HackUI _UI = null)
    {
        Try nTry = NewTry(_Word, _CharacterCorrect);
        m_Tries.Add(nTry);

        Resolve(nTry, _UI);
        int tryIndex = 0;

        while((m_Tries.Count > 1) && (tryIndex < m_Tries.Count))
        {
            if((Resolve(m_Tries[tryIndex], _UI)) && (tryIndex != 0))
            {
                tryIndex = 0;
            }
            else
            {
                tryIndex++;
            }
        }
    }

    private Try NewTry(string _Word, int _CharacterCorrect)
    {
        Try newTry = new Try();

        newTry.m_Word = _Word;
        newTry.m_CharacterCorrect = _CharacterCorrect;
        newTry.m_CharacterStateConfirmed = new List<char>();

        List<char> charList = new List<char>();

        for(int charIndex = 0; charIndex < _Word.Length; charIndex++)
        {
            char c = _Word[charIndex];
            if ((c >= 0x61) && (c <= 0x7A))
            {
                c -= (char)0x20;
            }

            if (!charList.Contains(c))
            {
                charList.Add(c);
            }
        }

        newTry.m_NumberOfCharacter = charList.Count;

        return newTry;
    }

    private bool Resolve(Try _Try, HackUI _UI = null)
    {
        bool newCharIdentify = false;
        if (_Try.m_CharacterStateConfirmed.Count < _Try.m_NumberOfCharacter)
        {

            if (_Try.m_CharacterCorrect == 0)
            {
                AllCharIsIdentifyInWord(_Try, ECharacterState.Unused, _UI);
                newCharIdentify = true;
            }
            else if (_Try.m_CharacterCorrect == m_WordsSize)
            {
                AllCharIsIdentifyInWord(_Try, ECharacterState.Used, _UI);
                newCharIdentify = true;
            }
            else
            {
                newCharIdentify = AllCharIsNotIdentifyInWord(_Try, _UI);
            }
        }
        return newCharIdentify;
    }

    private ECharacterState ChangeStateCharacter(char _Char, ECharacterState _CharacterState)
    {
        if (m_CharracterState.ContainsKey(_Char))
        {
            if ((m_CharracterState[_Char] == ECharacterState.Undetermined) && (_CharacterState != ECharacterState.Undetermined))
            {
                m_CharracterState[_Char] = _CharacterState;
            }
        }
        else
        {
            m_CharracterState[_Char] = _CharacterState;
        }

        return m_CharracterState[_Char];
    }

    private void AllCharIsIdentifyInWord(Try _Try, ECharacterState _CharacterState, HackUI _UI = null)
    {
        for (int charIndex = 0; charIndex < _Try.m_Word.Length; charIndex++)
        {
            char c = _Try.m_Word[charIndex];

            if((c >= 0x61) && (c <= 0x7A))
            {
                c -= (char)0x20;
            }

            if(_UI)
            {
                _UI.ChangeStateCharacter(c, ChangeStateCharacter(c, _CharacterState));
            }
            else
            {
                ChangeStateCharacter(c, _CharacterState);
            }

            if (!_Try.m_CharacterStateConfirmed.Contains(c))
            {
                _Try.m_CharacterStateConfirmed.Add(c);
            }
        }
    }

    private bool AllCharIsNotIdentifyInWord(Try _Try, HackUI _UI = null)
    {
        bool newCharIdentify = false;
        List<char> wrongCharacterKnow = new List<char>();
        List<char> goodCharacterKnow = new List<char>();
        for (int charIndex = 0; charIndex < _Try.m_Word.Length; charIndex++)
        {
            char c = _Try.m_Word[charIndex];

            if ((c >= 0x61) && (c <= 0x7A))
            {
                c -= (char)0x20;
            }

            ECharacterState cState = ChangeStateCharacter(c, ECharacterState.Undetermined);
            switch (cState)
            {
                case ECharacterState.Used:
                    goodCharacterKnow.Add(c);

                    if (!_Try.m_CharacterStateConfirmed.Contains(c))
                    {
                        _Try.m_CharacterStateConfirmed.Add(c);
                        if (_UI)
                        {
                            _UI.ChangeStateCharacter(c, ECharacterState.Unused);
                            if (_UI)
                            {
                                _UI.ChangeStateCharacter(c, ECharacterState.Used);
                            }
                        }
                    }

                    break;
                case ECharacterState.Unused:
                    wrongCharacterKnow.Add(c);

                    if (!_Try.m_CharacterStateConfirmed.Contains(c))
                    {
                        _Try.m_CharacterStateConfirmed.Add(c);

                        if(_UI)
                        {
                            _UI.ChangeStateCharacter(c, ECharacterState.Unused);
                        }
                    }

                    break;

                case ECharacterState.Undetermined:
                    if (_UI)
                    {
                        _UI.ChangeStateCharacter(c, ECharacterState.Undetermined);
                    }
                    break;
            }
        }

        if (goodCharacterKnow.Count == _Try.m_CharacterCorrect)
        {
            AllCharIsIdentifyInWord(_Try, ECharacterState.Unused);
            newCharIdentify = true;
        }
        else if (wrongCharacterKnow.Count == m_WordsSize - _Try.m_CharacterCorrect)
        {
            AllCharIsIdentifyInWord(_Try, ECharacterState.Used);
            newCharIdentify = true;
        }

        return newCharIdentify;
    }

    public void IncreaseTry()
    {
        m_Try++;

        if(m_Try > m_NumberOfTrials)
        {
            m_Try--;
        }
    }

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

    public void CleanHackwords()
    {
        if (m_WordHackList == null)
        {
            m_WordHackList = new List<string>();
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

    #endregion


    #region Accessors

    public int GetNumberOfTrials()
    {
        return m_NumberOfTrials;
    }

    public int GetWordsSize()
    {
        return m_WordsSize;
    }

    public int GetTry()
    {
        return m_Try;
    }

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