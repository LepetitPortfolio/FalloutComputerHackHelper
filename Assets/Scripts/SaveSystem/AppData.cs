using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AppData 
{

	#region Membre
		public List<string> m_WordList;
    #endregion

	#region Initialisation
	//Constructor
	public AppData () 
	{
		WordsManager wordsManager = GameObject.FindObjectOfType<WordsManager>();
		m_WordList = new List<string>(wordsManager.GetWordList());
	}
    #endregion

    #region Accessor

	public List<string> GetWordList()
    {
		return m_WordList;
    }

	#endregion

	#region Save

	#endregion
}
