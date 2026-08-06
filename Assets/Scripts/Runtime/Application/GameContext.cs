using System;
using System.IO;
using UnityEngine;

namespace Meowblade
{
    public interface IClock
    {
        long UtcNowUnixSeconds { get; }
    }

    public interface ISaveRepository
    {
        GameSaveData Load();
        void Save(GameSaveData data);
    }

    public sealed class SystemClock : IClock
    {
        public long UtcNowUnixSeconds
        {
            get { return DateTimeOffset.UtcNow.ToUnixTimeSeconds(); }
        }
    }

    public sealed class GameContext
    {
        public const string SaveFileName = "meowblade_demo_save.json";

        public GameSession Session { get; private set; }

        private GameContext(GameSession session)
        {
            Session = session;
        }

        public static GameContext CreateDefault()
        {
            return CreateForSavePath(Path.Combine(Application.persistentDataPath, SaveFileName));
        }

        public static GameContext CreateForSavePath(string savePath, IClock clock = null)
        {
            if (string.IsNullOrWhiteSpace(savePath))
            {
                throw new ArgumentException("A valid save path is required.", "savePath");
            }

            ISaveRepository repository = new JsonSaveRepository(savePath);
            GameSession session = new GameSession(repository, clock ?? new SystemClock());
            return new GameContext(session);
        }
    }
}
