using GameDataEditor;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;

public class GvG3VideoMeta
{
	public string Id { get; private set; }

	public bool Enabled { get; }

	public string NextVideoId { get; private set; }

	public GvG3VideoMeta(GDEMissionData data)
	{
		Id = data.Key;
		Enabled = data.Enabled;
		NextVideoId = data.NextMission;
	}
}
