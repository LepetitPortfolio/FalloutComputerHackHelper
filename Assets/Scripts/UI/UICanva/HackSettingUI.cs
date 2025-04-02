using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class HackSettingUI : UICanva
{
    #region Members

    [SerializeField]
    private HackConfigsPanel m_HackConfigsPanel = null;

    [SerializeField]
    private AddWordPanel m_AddWordPanel = null;

    private WordsManager m_WordsManager;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    override protected void Start()
    {
        m_AddWordPanel.gameObject.SetActive(false);
        m_HackConfigsPanel.gameObject.SetActive(true);
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

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (m_WordsManager)
        {
            m_WordsManager.CleanHackwords();
        }

        m_AddWordPanel.gameObject.SetActive(false);
        m_AddWordPanel.ResetPanel();

        m_HackConfigsPanel.gameObject.SetActive(true);
        m_HackConfigsPanel.ResetPanel();
    }

    #endregion


    #region Functions

    public bool ImporNewSetting()
    {
        if (m_HackConfigsPanel.ValideInputSetting())
        {
            LibraryFunctions.GetHackSolver().InitializeNewSettingHack(m_HackConfigsPanel.GetNumberOfTrials());
            return true;
        }

        return false;

    }

    public void ShowAddWordPanel()
    {
        if(m_AddWordPanel && m_HackConfigsPanel)
        {
            if(m_AddWordPanel.isActiveAndEnabled)
            {
                m_AddWordPanel.gameObject.SetActive(false);
                m_HackConfigsPanel.gameObject.SetActive(true);
            }
            else
            {
                m_AddWordPanel.gameObject.SetActive(true);
                m_HackConfigsPanel.gameObject.SetActive(false);
            }
        }
    }

    #endregion


    #region Accessors
    #endregion
}