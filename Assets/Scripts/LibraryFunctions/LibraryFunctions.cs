using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


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
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Data.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        AppData data = new AppData();

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static AppData LoadData()
    {
        string path = Application.persistentDataPath + "/Data.sav";
        AppData data = null;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            data =  formatter.Deserialize(stream) as AppData;

            stream.Close();
        }

        return data;
    }

    #endregion


    #region Accessors
    #endregion
}