using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HackUI : UICanva
{
    #region Members

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

        m_TryInfoTxt.text = LibraryFunctions.GetWordsManager().GetTry() + "/" + LibraryFunctions.GetWordsManager().GetNumberOfTrials();

        m_WordSizeMax.text = "/" + LibraryFunctions.GetWordsManager().GetWordsSize();
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

        if(m_TryInfoTxt)
        {
            m_TryInfoTxt.text = LibraryFunctions.GetWordsManager().GetTry() + "/" + LibraryFunctions.GetWordsManager().GetNumberOfTrials();
        }
        if (m_WordSizeMax)
        {
            m_WordSizeMax.text = "/" + LibraryFunctions.GetWordsManager().GetWordsSize();
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
        if (LibraryFunctions.GetWordsManager().GetTry() < LibraryFunctions.GetWordsManager().GetNumberOfTrials())
        {
            if ((m_WordInput) && (m_CorrectCharInput))
            {
                LibraryFunctions.GetWordsManager().Compute(m_WordInput.text, int.Parse(m_CorrectCharInput.text), this);
                LibraryFunctions.GetWordsManager().IncreaseTry();
                m_TryInfoTxt.text = LibraryFunctions.GetWordsManager().GetTry() + "/" + LibraryFunctions.GetWordsManager().GetNumberOfTrials();
                m_WordInput.text = "";
                m_CorrectCharInput.text = "";

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