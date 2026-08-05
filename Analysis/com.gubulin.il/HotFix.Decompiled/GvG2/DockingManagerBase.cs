using System;
using System.Collections.Generic;
using GvG2.Common.Models;

namespace GvG2;

public abstract class DockingManagerBase
{
	public const float ANIM_TIME = 0.6f;

	public Action OnChangeShips = delegate
	{
	};

	protected static Dictionary<int, string> CampSlotPrefab = new Dictionary<int, string>
	{
		{ 1, "slot_red" },
		{ 2, "slot_green" },
		{ 3, "slot_blue" },
		{ 4, "slot_yellow" }
	};

	protected static Dictionary<int, string> CampSlotCounterPrefab = new Dictionary<int, string>
	{
		{ 1, "slot_counter_red" },
		{ 2, "slot_counter_green" },
		{ 3, "slot_counter_blue" },
		{ 4, "slot_counter_yellow" }
	};

	public abstract void RenderSlots();

	public abstract void DockShip(Ship ship, bool isInit);

	public abstract void UndockShip(Ship ship);

	public abstract bool HasMyShip();

	public abstract List<Ship> GetDockingShips();
}
