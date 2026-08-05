using System.Collections.Generic;

public class QuickPlayReplayKeyFrame
{
	public enum eKeyFrameType
	{
		CreateUnit,
		MoveMap,
		RefreshUI,
		RefreshHP,
		UnitScaleChange,
		PvpEffect
	}

	public readonly int KeyFrame;

	public bool has_played = false;

	public List<int> Types;

	public List<object> data = new List<object>();

	public QuickPlayReplayKeyFrame(int _val)
	{
		KeyFrame = _val;
		Types = new List<int>();
		has_played = false;
	}
}
