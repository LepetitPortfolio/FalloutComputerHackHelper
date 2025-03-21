using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;


public static class LibraryFunctions 
{
	#region Members
    #endregion
	

	#region Constructors
		
    #endregion

	
    #region Functions

    static public string UpCapsWord(string _Word)
    {
        string outWord = "";
        for(int charIndex = 0; charIndex < _Word.Length; charIndex++)
        {
            char c = _Word[charIndex];

            if ((c >= (0x41)) && (c <= (0x5A)))
            {
                outWord += c;
            }

            if ((c >= 0x61) && (c <= 0x7A))
            {
                c -= (char)0x20;
                outWord += c;
            }

        }

        return outWord;
    }

    public static void SaveData()
    {
        SaveLoadDataManager.m_Instance.SaveData(new AppData());
    }

    public static AppData LoadData()
    {
       return SaveLoadDataManager.m_Instance.LoadData();
    }

    #endregion


    #region Accessors
    #endregion
}