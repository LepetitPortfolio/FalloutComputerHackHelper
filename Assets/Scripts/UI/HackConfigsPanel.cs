using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackConfigsPanel : MonoBehaviour 
{

	#region Membre

	[SerializeField]
	private TMPro.TMP_InputField m_NumberOfTrialsTxt = null;

	#endregion

	#region Initialisation
	// Use this for initialization
	void Start () 
	{

	}
    #endregion

    #region Accessor

	public int GetNumberOfTrials()
    {
		return int.Parse(m_NumberOfTrialsTxt.text);
	}

	#endregion

	#region Unity Action

	// Update is called once per frame
	void Update()
	{

	}

    #endregion
	
	#region HackConfigsPanel

	public void ResetPanel()
    {

		if (m_NumberOfTrialsTxt)
		{
			m_NumberOfTrialsTxt.text = "";
		}
	}

	public bool ValideInputSetting()
	{

		if (!m_NumberOfTrialsTxt)
		{
			return false;
		}

		if ((m_NumberOfTrialsTxt.text == "") || (m_NumberOfTrialsTxt.text == "0"))
		{
			return false;
		}

		return true;
	}

	#endregion
}
