using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryUI : UICanva
{

    #region Membre
    [SerializeField]
    private AddWordPanel m_AddWordPanel = null;
    #endregion

    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    override protected void Start()
    {
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
        m_AddWordPanel.ResetPanel();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        m_AddWordPanel.InitializePanel();
    }

    #endregion


    #region Functions

    #endregion


    #region Accessors
    #endregion
}
