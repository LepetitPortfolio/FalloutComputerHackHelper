using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ValidHackSettingButtom : ChangeStateButtom
{
    #region Members
    [SerializeField]
    private HackSettingUI m_HackSetting;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    protected void Start()
    {
        base.Start();
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
    }

    #endregion


    #region Functions

    public override void ChangeGameState()
    {
        if ((m_HackSetting) && (m_HackSetting.ImporNewSetting()))
        {
            base.ChangeGameState();
        }
    }

    #endregion


    #region Accessors
    #endregion
}