using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";
    private bool useEncryption = false;
    private readonly string encryptionPassword = "SuksesSkripsi!";
    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load(string profileId)
    {
        string fullpath = Path.Combine(dataDirPath,profileId, dataFileName);

        GameData loadedData = null;

        if (File.Exists(fullpath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullpath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading data: " + fullpath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData data, string profileId)
    {
        string fullpath = Path.Combine(dataDirPath ,profileId, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

            string dataToStore = JsonUtility.ToJson(data, true);

            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving data: " + fullpath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles() 
    {
        Dictionary<string, GameData> profileDictionary = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();
        foreach ( DirectoryInfo dirInfo in dirInfos)
        {
            string profileId = dirInfo.Name;

            string fullpath = Path.Combine(dataDirPath, profileId, dataFileName);
            if (!File.Exists(fullpath))
            {
                Debug.LogWarning("No data file found for profile: " + profileId);
                continue;
            }
            
            GameData profileData = Load(profileId);

            if (profileData != null)
            {
                profileDictionary.Add(profileId, profileData);
            } 
            else
            {
                Debug.LogWarning("Tried to load data but something went wrong." + profileId);
            }
        }

        return profileDictionary;
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionPassword[(i % encryptionPassword.Length)]);
        }

        return modifiedData;
    }
}
