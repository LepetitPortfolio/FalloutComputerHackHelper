using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HackUI : UICanva
{
    #region Members

    private WordsManager m_WordsManager;

    [SerializeField]
    private TMPro.TextMeshProUGUI m_TryInfoTxt;

    [SerializeField]
    private TMPro.TMP_InputField m_WordInput;
    [SerializeField]
    private TMPro.TMP_InputField m_CorrectCharInput;

    [SerializeField]
    private TMPro.TextMeshProUGUI m_WordSizeMax;

    [SerializeField]
    private LettersStateUI m_LettersStateUI;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    override protected void Start()
    {
        base.Start();

        m_WordsManager = FindObjectOfType<WordsManager>();

        m_TryInfoTxt.text = m_WordsManager.GetTry() + "/" + m_WordsManager.GetNumberOfTrials();

        m_WordSizeMax.text = "/" + m_WordsManager.GetWordsSize();
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    override protected void Update()
    {
        base.Update();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        if((m_TryInfoTxt) && (m_WordsManager))
        {
            m_TryInfoTxt.text = m_WordsManager.GetTry() + "/" + m_WordsManager.GetNumberOfTrials();
        }
        if ((m_WordSizeMax) && (m_WordsManager))
        {
            m_WordSizeMax.text = "/" + m_WordsManager.GetWordsSize();
        }

        if(m_LettersStateUI)
        {
            m_LettersStateUI.ResetStateOfCharacter();
        }

    }

    #endregion


    #region Functions

    public void LaunchCompute()
    {
        if (m_WordsManager)
        {
            if (m_WordsManager.GetTry() < m_WordsManager.GetNumberOfTrials())
            {
                if ((m_WordInput) && (m_CorrectCharInput))
                {
                    m_WordsManager.Compute(m_WordInput.text, int.Parse(m_CorrectCharInput.text), this);
                    m_WordsManager.IncreaseTry();
                    m_TryInfoTxt.text = m_WordsManager.GetTry() + "/" + m_WordsManager.GetNumberOfTrials();
                    m_WordInput.text = "";
                    m_CorrectCharInput.text = "";

                }
            }
        }
    }

    public void ChangeStateCharacter(char _Character, ECharacterState _CharacterState)
    {
        if(m_LettersStateUI)
        {
            m_LettersStateUI.ChangeStateCharacter(_Character, _CharacterState);
        }
    }

    #endregion


    #region Accessors
    #endregion
}