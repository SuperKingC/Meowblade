using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;

namespace GvG2.Common.Models;

public class IslandProps
{
	public int Id;

	public string Name = "";

	public string MapId = "";

	public int CampId;

	public float X;

	public float Z;

	public string Sprite = "";

	public float S = 1f;

	public float S_Model = 1f;

	public float Ang_Model = 0f;

	public float S_ColX = 1f;

	public float S_ColZ = 1f;

	public List<int> Conn = new List<int>();

	public GDEGvGIslandMapConfigData _GDEData;

	public IslandType Type => (IslandType)GDEData.Type;

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
}
