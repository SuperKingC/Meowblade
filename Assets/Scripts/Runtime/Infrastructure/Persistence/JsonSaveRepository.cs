using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace Meowblade
{
    public sealed class JsonSaveRepository : ISaveRepository
    {
        private readonly string _savePath;
        private readonly string _backupPath;
        private readonly string _temporaryPath;

        public JsonSaveRepository(string savePath)
        {
            if (string.IsNullOrWhiteSpace(savePath))
            {
                throw new ArgumentException("A valid save path is required.", "savePath");
            }

            _savePath = Path.GetFullPath(savePath);
            _backupPath = _savePath + ".bak";
            _temporaryPath = _savePath + ".tmp";
        }

        public GameSaveData Load()
        {
            return TryLoad(_savePath) ?? TryLoad(_backupPath);
        }

        public void Save(GameSaveData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            string directory = Path.GetDirectoryName(_savePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(_temporaryPath, json, new UTF8Encoding(false));

            if (File.Exists(_savePath))
            {
                File.Copy(_savePath, _backupPath, true);
                File.Delete(_savePath);
            }

            File.Move(_temporaryPath, _savePath);
        }

        private static GameSaveData TryLoad(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            try
            {
                string json = File.ReadAllText(path, Encoding.UTF8);
                return JsonUtility.FromJson<GameSaveData>(json);
            }
            catch (Exception exception)
            {
                Debug.LogWarning("Game save load failed at " + path + ": " + exception.Message);
                return null;
            }
        }
    }
}
