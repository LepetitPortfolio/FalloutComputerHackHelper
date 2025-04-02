using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterStat 
{

    #region Membre
    private char m_ID;
    private ECharacterStat m_CharacterState;
    private int m_UndeterminedStatSeen;
    #endregion

    #region Initialisation
    //Constructor
    public CharacterStat (char _ID, ECharacterStat _CharacterState = ECharacterStat.Unused) 
	{
        m_ID = _ID;
        m_CharacterState = _CharacterState;
        m_UndeterminedStatSeen = 0;
    }
    #endregion

    #region Accessor
    public char GetID()
    {
        return m_ID;
    }

    public ECharacterStat GetCharacterStat()
    {
        return m_CharacterState;
    }

    public int GetUndeterminedStatSeen()
    {
        return m_UndeterminedStatSeen;
    }

    #endregion

    #region CharacterStat
    public void UpdateCharacterStat(ECharacterStat _CharacterState)
    {
        if ((m_CharacterState == ECharacterStat.Unused) || (m_CharacterState == ECharacterStat.Unused))
        {
            return;
        }

        if ((m_CharacterState == _CharacterState) && (_CharacterState == ECharacterStat.Undetermined))
        {
            m_UndeterminedStatSeen++;
        }
        else
        {
            m_CharacterState = _CharacterState;
        }
    }
    #endregion
}
