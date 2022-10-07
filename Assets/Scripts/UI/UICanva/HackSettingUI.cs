using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class HackSettingUI : UICanva
{
    #region Members

    private WordsManager m_WordsManager;

    [SerializeField]
    private TMPro.TMP_InputField m_WordSizeTxt = null;
    [SerializeField]
    private TMPro.TMP_InputField m_NumberOfTrialsTxt = null;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    override protected void Start()
    {
        m_WordsManager = FindObjectOfType<WordsManager>();
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    override protected void Update()
    {
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if(m_WordSizeTxt)
        {
            m_WordSizeTxt.text = "";
        }

        if (m_NumberOfTrialsTxt)
        {
            m_NumberOfTrialsTxt.text = "";
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    #endregion


    #region Functions

    public bool ValideInputSetting()
    {

        if((!m_NumberOfTrialsTxt) || (!m_WordSizeTxt))
        {
            return false;
        }

        if((m_WordSizeTxt.text == "") || (m_WordSizeTxt.text == "0"))
        {
            return false;
        }

        if ((m_NumberOfTrialsTxt.text == "") || (m_NumberOfTrialsTxt.text == "0"))
        {
            return false;
        }

        return true;
    }


    public bool ImporNewSetting()
    {
        if (ValideInputSetting())
        {
            m_WordsManager.SetSettings(int.Parse(m_WordSizeTxt.text), int.Parse(m_NumberOfTrialsTxt.text));
            return true;
        }

        return false;

    }

    #endregion


    #region Accessors
    #endregion
}