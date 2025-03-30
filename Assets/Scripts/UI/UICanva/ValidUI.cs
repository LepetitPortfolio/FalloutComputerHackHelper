using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ActionValidate();

public class ValidUI : UICanva
{

    #region Members

    private ActionValidate m_ActionValidateHandler = null;

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

        m_ActionValidateHandler = null;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        

    }

    #endregion


    #region Functions

    public void OnValidateAction()
    {
        if (m_ActionValidateHandler != null)
        {
            m_ActionValidateHandler();
        }
        OnCancelAction(); 
    }

    public void OnCancelAction()
    {
        gameObject.SetActive(false);
    }

    #endregion


    #region Accessors

    public void SetActionValidateHandler(ActionValidate _Handler)
    {
        if (_Handler != null)
        {
            m_ActionValidateHandler = _Handler;  
        }
    }

    #endregion
}
