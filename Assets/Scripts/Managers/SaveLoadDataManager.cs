using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

public class SaveLoadDataManager : MonoBehaviour
{

    #region Membre

    [SerializeField]
    private string m_FileName;

    private FileDataHandler m_DataHandler;

    public static SaveLoadDataManager m_Instance { get; private set; }

    #endregion

    #region Manipulators

    private void Awake()
    {
        if(m_Instance != null)
        {
            Debug.LogError("Found more than one Save Load Data Manager in this scene");
        }
        m_Instance = this;
        m_DataHandler = new FileDataHandler(Application.persistentDataPath, m_FileName);
    }

    ///<summary>
    /// Use this for initialization
    ///</summary>
    void Start()
    {
    }


    ///<summary>
    /// Update is called once per frame
    ///</summary>
    void Update()
    {
    }

    #endregion

    #region Functions

    public void SaveData(AppData _AppData)
    {
        m_DataHandler.SaveData(_AppData);
    }

    public AppData LoadData()
    {
        return m_DataHandler.LoadData();
    }

    #endregion

    #region Accessors

    #endregion
}

