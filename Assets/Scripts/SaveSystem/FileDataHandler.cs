using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataHandler 
{

    #region Membre
    private string m_DataDirPath = "";
    private string m_DataFileName = "";
    #endregion

    #region Initialisation
    //Constructor
    public FileDataHandler (string _DataDirPath, string _DataFileName) 
	{
        m_DataDirPath = _DataDirPath;
        m_DataFileName = _DataFileName;

    }
    #endregion

    #region Accessor

    #endregion

    #region FileDataHandler
    public void SaveData(AppData _AppData)
    {
        string path = Path.Combine(m_DataDirPath, m_DataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string dataToStore = JsonUtility.ToJson(_AppData, true);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(stream))
                {
                    write.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error ocurred when trying to save data to file : " + path + "\n" + e);
        }
    }

    public AppData LoadData()
    {
        string path = Path.Combine(m_DataDirPath, m_DataFileName);
        AppData data = null;
        if (File.Exists(path))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                data = JsonUtility.FromJson<AppData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error ocurred when trying to load data from file : " + path + "\n" + e);
            }
        }

        return data;
    }
    #endregion
}
