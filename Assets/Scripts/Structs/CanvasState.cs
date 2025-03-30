using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct CanvasState 
{

    #region Membre
    [SerializeField]
    public EGameState m_GameState;

    [SerializeField]
    public Canvas m_CanvaState;
    #endregion

    #region Accessor

    public EGameState GetGameState()
    {
        return m_GameState;
    }

    
    public Canvas GetCanvaState()
    {
        return m_CanvaState;
    }

    #endregion

    #region CanvasState
    #endregion
}
