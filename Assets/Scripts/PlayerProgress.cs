using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Player Progress",
    menuName = "Quiz Game/Player Progress"
)]
public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int coin;
        public Dictionary<string, int> progressLevel;
    }
    public MainData progressData = new MainData();

    [SerializeField]
    private string _filename = "contoh.txt";

    public void SaveProgress()
    {
        // Data Sample
        progressData.coin = 200;
        if (progressData.progressLevel == null)
            progressData.progressLevel = new();
        progressData.progressLevel.Add("Level Pack 1", 3);
        progressData.progressLevel.Add("Level Pack 3", 5);

        // File Path
        var directory = Application.dataPath + "/Temporary";
        var path =  directory + "/" + _filename;

        // Create Temp Folder
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created: " + directory);
        }

        // Create new file
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File created: " + path);
        }

        var fileStream = File.Open(path, FileMode.Open);
        // var formatter = new BinaryFormatter();

        fileStream.Flush();
        // formatter.Serialize(fileStream, progressData);

        // Save data to file using binary writer
        var writer = new BinaryWriter(fileStream);

        writer.Write(progressData.coin);
        foreach(var i in progressData.progressLevel)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }

        // Close File
        writer.Dispose();
        fileStream.Dispose(); 

        Debug.Log($"{_filename} Berhasil Disimpan");
    }

    public bool LoadProgress()
    {
        // File Path
        var directory = Application.dataPath + "/Temporary";
        var path =  directory + "/" + _filename;

        var fileStream = File.Open(path, FileMode.OpenOrCreate);
        try
        {
            var reader = new BinaryReader(fileStream);
            try
            {
                progressData.coin = reader.ReadInt32();
                if (progressData.progressLevel == null)
                    progressData.progressLevel = new();
                while (reader.PeekChar() != -1)
                {
                    var levelPackName = reader.ReadString();
                    var levelIndex = reader.ReadInt32();
                    progressData.progressLevel.Add(levelPackName, levelIndex);
                    Debug.Log($"{levelPackName}:{levelIndex}");
                }
                reader.Dispose();
                fileStream.Dispose();
            }
            catch(System.Exception e)
            {
                Debug.Log($"ERROR: Terjadi kesalahan saat memuat progres binari. \n{e.Message}");
                reader.Dispose();
                fileStream.Dispose();
                return false;
            }

            Debug.Log($"{progressData.coin}; {progressData.progressLevel.Count}");
            return true;
        }
        catch (System.Exception e)
        {
            fileStream.Dispose();
            Debug.Log($"ERROR: Terjadi kesalahan saat load progress\n{e.Message}");
            return false;
        }
    }
}
