using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;

public interface IIslandCard
{
	void Render(IslandStateModel islandState);

	void Update(IslandStateModel islandState);

	void OnClose(IslandStateModel islandState);

	void OnLoad(IslandStateModel islandState);
}
