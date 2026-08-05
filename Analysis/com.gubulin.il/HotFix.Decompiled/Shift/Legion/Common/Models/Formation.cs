using System.Collections.Generic;
using GameDataEditor;
using GameMaths;

namespace Shift.Legion.Common.Models;

public class Formation
{
	public string Id;

	public GDEFormationData Data;

	public readonly Dictionary<int, Vector2> SlotPosition;

	public readonly Dictionary<int, Vector2> SlotSize;

	public readonly Dictionary<int, float> SlotVision;

	public readonly bool PlayerUsable;

	public readonly bool UnlockedAtBegin;

	public string Name;

	public string Desc;

	public string Icon;

	public Formation(GDEFormationData formationData)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		Id = formationData.Key;
		Data = formationData;
		PlayerUsable = Data.PlayerUsable;
		UnlockedAtBegin = Data.UnlockedAtBegin;
		Name = Data.Name;
		Desc = Data.Description;
		Icon = Data.Icon;
		SlotPosition = new Dictionary<int, Vector2>
		{
			{ 0, formationData.Slot1 },
			{ 1, formationData.Slot2 },
			{ 2, formationData.Slot3 },
			{ 3, formationData.Slot4 },
			{ 4, formationData.Slot5 },
			{ 5, formationData.Slot6 },
			{ 6, formationData.Slot7 },
			{ 7, formationData.Slot8 },
			{ 8, formationData.Slot9 },
			{ 9, formationData.Slot10 },
			{ 10, formationData.Slot11 },
			{ 11, formationData.Slot12 }
		};
		SlotSize = new Dictionary<int, Vector2>
		{
			{ 0, formationData.Size1 },
			{ 1, formationData.Size2 },
			{ 2, formationData.Size3 },
			{ 3, formationData.Size4 },
			{ 4, formationData.Size5 },
			{ 5, formationData.Size6 },
			{ 6, formationData.Size7 },
			{ 7, formationData.Size8 },
			{ 8, formationData.Size9 },
			{ 9, formationData.Size10 },
			{ 10, formationData.Size11 },
			{ 11, formationData.Size12 }
		};
		SlotVision = new Dictionary<int, float>
		{
			{ 0, formationData.VisionRadius1 },
			{ 1, formationData.VisionRadius2 },
			{ 2, formationData.VisionRadius3 },
			{ 3, formationData.VisionRadius4 },
			{ 4, formationData.VisionRadius5 },
			{ 5, formationData.VisionRadius6 },
			{ 6, formationData.VisionRadius7 },
			{ 7, formationData.VisionRadius8 },
			{ 8, formationData.VisionRadius9 },
			{ 9, formationData.VisionRadius10 },
			{ 10, formationData.VisionRadius11 },
			{ 11, formationData.VisionRadius12 }
		};
	}
}
