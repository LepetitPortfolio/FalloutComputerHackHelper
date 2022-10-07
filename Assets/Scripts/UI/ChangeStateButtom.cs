using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ChangeStateButtom : MonoBehaviour
{
    #region Members
    [SerializeField]
    protected EGameState m_NewGameSate;

    protected CanvasManager m_CanvasManager;

    #endregion


    #region Manipulators

    ///<summary>
    /// Use this for initialization
    ///</summary>
    protected void Start()
    {
        m_CanvasManager = FindObjectOfType<CanvasManager>();
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {

    }

    #endregion


    #region Functions
    virtual public void ChangeGameState()
    {
        if(m_CanvasManager)
        {
            m_CanvasManager.ChangeCurrentCanva(m_NewGameSate);
        }
    }
    #endregion


    #region Accessors
    #endregion
}