using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Player;

public class JsonSaver : IDataSaver
{
    private const string FileName = "SaveData";
    private const string SaveFileExtensions = ".json";

    private PlayerData _playerData;

    public JsonSaver()
    {
        _playerData = (PlayerData) Load();
    }

    private string SavePath => Application.persistentDataPath;
    private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtensions}");

    public void Save()
    {
        var json = JsonConvert.SerializeObject(_playerData);

        using (var fileStream = new StreamWriter(FullPath))
        {
            fileStream.Write(json);
        }
    }

    public object TryLoad()
    {
        if (DataAlreadyExist())
            return false;

        return JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
    }

    public object Load()
    {
        if (TryLoad() == null)
            _playerData = new PlayerData();

        return _playerData;
    }

    private bool DataAlreadyExist() => File.Exists(FullPath);
}

