using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class IslandProps
{
	public enum SizeType
	{
		Empty,
		Small,
		Medium,
		Large
	}

	public int Id;

	public string MapId = "";

	public int CampId;

	public float X;

	public float Z;

	public string SpriteGroup = "";

	public string DecoGroup = "";

	public float S = 1f;

	public float S_Model = 1f;

	public float Ang_Model = 0f;

	public float S_ColX = 1f;

	public float S_ColZ = 1f;

	public float FogAreaSize = 1f;

	public float CampAreaSize = 1f;

	public List<int> Conn = new List<int>();

	public GDEGvGIslandMapConfigData _GDEData;

	private SizeType _sizeType = SizeType.Empty;

	public eIslandType Type => (eIslandType)GDEData.Type;

	public GDEGvGIslandMapConfigData GDEData
	{
		get
		{
			if (_GDEData == null)
			{
				_GDEData = GDMgr.Get<GDEGvGIslandMapConfigData>(MapId);
			}
			return _GDEData;
		}
	}

	public SizeType GetSizeType()
	{
		if (_sizeType != SizeType.Empty)
		{
			return _sizeType;
		}
		if (SpriteGroup.Contains("small"))
		{
			_sizeType = SizeType.Small;
		}
		else if (SpriteGroup.Contains("middle"))
		{
			_sizeType = SizeType.Medium;
		}
		else if (SpriteGroup.Contains("boss") || SpriteGroup.Contains("big"))
		{
			_sizeType = SizeType.Large;
		}
		else
		{
			_sizeType = SizeType.Small;
		}
		return _sizeType;
	}
}
