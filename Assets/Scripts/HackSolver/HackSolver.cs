using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackSolver : MonoBehaviour 
{

    #region Membre

    public static HackSolver m_Instance { get; private set; }

    private List<Try> m_Tries;

    [SerializeField]
    private List<CharactertStatColor> m_CodeColorByStat;

    private Color m_InterColor;

    private Dictionary<char, CharacterStat> m_CharacterStats;

    private List<string> m_WordHackList;

    private List<string> m_Sugests;


    private int m_TryNumberMax = 0;

    #endregion

    #region Initialisation

    //Awake is called when the script instance is being loaded.
    void Awake()
	{
        if (m_Instance != null)
        {
            Debug.LogError("Found more than one Hack Solver in this scene");
        }
        m_Instance = this;
    }
	
	// Use this for initialization
	void Start() 
	{

	}

    #endregion

    #region Accessor
    public int GetNumberOfTrials()
    {
        return m_TryNumberMax;
    }

    public int GetTries()
    {
        if(m_Tries == null)
        {
            m_Tries = new List<Try>();
        }

        return m_Tries.Count;
    }

    #endregion

    #region Unity Action

    // Update is called once per frame
    void Update()
	{

	}

    #endregion

    #region HackSolver

    public void InitializeNewSettingHack(int _TryNumberMax)
    {
        m_TryNumberMax = _TryNumberMax;
        m_Tries = new List<Try>();
        m_CharacterStats = new Dictionary<char, CharacterStat>();

        m_WordHackList = LibraryFunctions.GetWordsManager().GetWordHackList();

        CharactertStatColor usedState = FindCharactertStateColor(ECharacterStat.Used);
        CharactertStatColor usndeterminedState = FindCharactertStateColor(ECharacterStat.Undetermined);

        if((usedState != null) && (usndeterminedState != null))
        {
            Color difColor = usndeterminedState.GetColorStat() - usedState.GetColorStat();
            m_InterColor = difColor / m_TryNumberMax;
        }

    }

    public void Compute(string _Word, int _CharacterCorrect, HackUI _UI = null)
    {
        Try nTry = NewTry(_Word, _CharacterCorrect);
        m_Tries.Add(nTry);

        SolveTry(nTry, _UI);
        
        m_Sugests = new List<string>();

        if (m_WordHackList.Count > 0)
        {
            m_WordHackList.Remove(_Word);

            GenerateSugests(nTry);
        }

        if (_UI != null)
        {
            _UI.GiveSugests(m_Sugests);
        }

    }

    private Try NewTry(string _Word, int _CharacterCorrect)
    {
        Try newTry = new Try();

        newTry.m_Word = _Word;
        newTry.m_CharacterCorrect = _CharacterCorrect;

        newTry.m_CharacterList = new List<char>();

        for (int charIndex = 0; charIndex < _Word.Length; charIndex++)
        {
            char c = _Word[charIndex];

            if (!newTry.m_CharacterList.Contains(c))
            {
                newTry.m_CharacterList.Add(c);
            }
        }

        newTry.m_NumberOfCharacter = newTry.m_CharacterList.Count;

        return newTry;
    }

    private void SolveTry(Try _Try, HackUI _UI = null)
    {
        ECharacterStat characterState = ECharacterStat.Undetermined;

        if (_Try.m_CharacterCorrect == 0)
        {
            characterState = ECharacterStat.Unused;
        }
        else if(_Try.m_CharacterCorrect == _Try.m_NumberOfCharacter)
        {
            characterState = ECharacterStat.Used;
        }

        for (int charIndex = 0; charIndex < _Try.m_NumberOfCharacter; charIndex++)
        {
            CharacterStat characterStat = ChangeStateCharacter(_Try.m_CharacterList[charIndex], characterState);

            if(_UI != null)
            {
                UpdateUIColor(_UI, characterStat);
            }
        }
    }

    private void  UpdateUIColor(HackUI _UI, CharacterStat _CharacterStat)
    {
        CharactertStatColor charactertStatColor = FindCharactertStateColor(_CharacterStat.GetCharacterStat());
        if (charactertStatColor != null)
        {
            Color nColor = charactertStatColor.GetColorStat();

            if(_CharacterStat.GetCharacterStat() == ECharacterStat.Undetermined)
            {
                nColor -= m_InterColor * _CharacterStat.GetUndeterminedStatSeen();
            }

            _UI.ChangeCharacterColor(_CharacterStat.GetID(), nColor);
        }
    }

    private CharacterStat ChangeStateCharacter(char _Char, ECharacterStat _CharacterState)
    {
        if (m_CharacterStats.ContainsKey(_Char))
        {
            m_CharacterStats[_Char].UpdateCharacterStat(_CharacterState);

        }
        else
        {
            m_CharacterStats[_Char] = new CharacterStat(_Char, _CharacterState);
        }

        return m_CharacterStats[_Char];
    }

    private CharactertStatColor FindCharactertStateColor(ECharacterStat _Stat)
    {
        CharactertStatColor outCharactertStateColor = null;
        int statIndex = 0;

        while((outCharactertStateColor == null) && (statIndex < m_CodeColorByStat.Count))
        {
            CharactertStatColor charactertStatColor = m_CodeColorByStat[statIndex];
            if(charactertStatColor.GetCharacterStat() == _Stat)
            {
                outCharactertStateColor = charactertStatColor;
            }
            else
            {
                statIndex++;
            }
        }

        return outCharactertStateColor;
    }

    private void GenerateSugests(Try _Try)
    {

    }

    #endregion
}
