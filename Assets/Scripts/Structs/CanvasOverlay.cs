using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CanvasOverlay 
{

    #region Membre
    [SerializeField]
    public string m_OverlayID;

    [SerializeField]
    public Canvas m_OverlayCanva;

    public UICanva m_UICanva;

    #endregion

    #region Accessor

    public string GetOverlayID()
    {
        return m_OverlayID;
    }

    public Canvas GetOverlayCanva()
    {
        return m_OverlayCanva;
    }

    public UICanva GetUICanva()
    {
        return m_UICanva;
    }

    #endregion

    #region CanvasOverlay

    #endregion
}
