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
    private TMPro.TextMeshProUGUI m_SuggestTxt;

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

        m_TryInfoTxt.text = LibraryFunctions.GetHackSolver().GetTries() + "/" + LibraryFunctions.GetHackSolver().GetNumberOfTrials();
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
            m_TryInfoTxt.text = LibraryFunctions.GetHackSolver().GetTries() + "/" + LibraryFunctions.GetHackSolver().GetNumberOfTrials();
        }

        if (m_SuggestTxt)
        {
            m_SuggestTxt.text = "";
        }

        if (m_LettersStateUI)
        {
            m_LettersStateUI.ResetStatOfCharacter();
        }

    }

    #endregion


    #region Functions

    public void GiveSugests(List<string> _Sugests)
    {
        if(m_SuggestTxt)
        {
            string sugests = "";
            for(int sugestIndex =0; sugestIndex < _Sugests.Count; sugestIndex++)
            {
                sugests += _Sugests[sugestIndex];
                if(sugestIndex+1 < _Sugests.Count)
                {
                    sugests += ", ";
                }
            }
            m_SuggestTxt.text = sugests;
        }
    }

    public void LaunchCompute()
    {
        if (LibraryFunctions.GetHackSolver().GetTries() < LibraryFunctions.GetHackSolver().GetNumberOfTrials())
        {
            if ((m_WordInput) && (m_CorrectCharInput))
            {
                string word = LibraryFunctions.UpCapsWord(m_WordInput.text);

                LibraryFunctions.GetHackSolver().Compute(word, int.Parse(m_CorrectCharInput.text), this);
                m_TryInfoTxt.text = LibraryFunctions.GetHackSolver().GetTries() + "/" + LibraryFunctions.GetHackSolver().GetNumberOfTrials();
                m_WordInput.text = "";
                m_CorrectCharInput.text = "";

            }
        }
        
    }

    public void ChangeCharacterColor(char _Character, Color _Color)
    {
        if(m_LettersStateUI)
        {
            m_LettersStateUI.ChangeCharacterColor(_Character, _Color);
        }
    }

    #endregion


    #region Accessors
    #endregion
}