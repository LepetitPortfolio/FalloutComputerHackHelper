using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CharactertStatColor 
{

    #region Membre

    [SerializeField]
    private ECharacterStat m_LetterState;
    [SerializeField]
    private Color m_Color;
    #endregion

    #region Accessor

    public ECharacterStat GetCharacterStat()
    {
        return m_LetterState;
    }

    public Color GetColorStat()
    {
        return m_Color;
    }

    #endregion

    #region CharactertStateColor

    #endregion
}
