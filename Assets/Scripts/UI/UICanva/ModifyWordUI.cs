using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyWordUI : UICanva
{

    #region Members

    [SerializeField]
    private TMPro.TMP_InputField m_WordTxtInput = null;

    private WordLine m_WordLine = null;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    override protected void Start()
    {
        base.Start();


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

        m_WordTxtInput.text = string.Empty;


    }

    protected override void OnEnable()
    {
        base.OnEnable();

        m_WordTxtInput.text = string.Empty;


    }

    #endregion


    #region Functions

    public void OnValidModif()
    {
        if(m_WordTxtInput.text == string.Empty)
        {
            return;
        }

        if (m_WordTxtInput.text != m_WordLine.GetWord().text)
        {
            LibraryFunctions.GetCanvasManager().DisplayValidActionOverlay(ExecuteModification);
        }
        else
        {
            OnCancelModif();
        }
    }

    public void OnCancelModif()
    {
        gameObject.SetActive(false);
    }

    private void ExecuteModification()
    {
        string newWord = LibraryFunctions.UpCapsWord(m_WordTxtInput.text);
        if(m_WordLine.GetIsHackWord())
        {
            LibraryFunctions.GetWordsManager().ModifyHackWord(m_WordLine.GetWord().text, newWord) ;
        }
        else
        {
            LibraryFunctions.GetWordsManager().ModifyWord(m_WordLine.GetWord().text, newWord); ;
        }

        m_WordLine.GetWord().text = newWord;
        OnCancelModif();
    }

    #endregion


    #region Accessors

    public void SetWordLine(WordLine _WordLine)
    {
        if (_WordLine != null)
        {
            m_WordLine = _WordLine;
            m_WordTxtInput.text = m_WordLine.GetWord().text;
        }
    }

    #endregion
}