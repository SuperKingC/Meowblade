namespace Shift.Legion.Common.Services;

public interface IGameDataService : IService
{
	void StartLoadGameData();

	bool LoadGameData(byte[] data, bool encrypted = false);

	void StartLoadUserArchive(int userId);

	void LoadGameDataSucess(byte[] hadnler);
}
