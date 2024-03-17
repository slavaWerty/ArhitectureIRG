using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DataLocalProvider : IDataProvider
{
    private const string FileName = "SaveData";
    private const string SaveFileExtensions = ".json";

    private IPersistantData _persistantData;

    public DataLocalProvider(IPersistantData persistantData) => _persistantData = persistantData;

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtensions}");

    public void Save()
    {
        File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistantData.PlayerData, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }));
    }

    public bool TryLoad()
    {
        if (DataAlreadyExist())
            return false;

        Save();
        _persistantData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
        return true;
    }

    private bool DataAlreadyExist() => File.Exists(FullPath);
}

