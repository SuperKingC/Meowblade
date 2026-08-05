using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;

public class ViewUiPositionHelper
{
	private readonly Vector2 _damageOffset = new Vector2(-10f, 115f);

	private readonly Vector2 _islandOffsetY = new Vector2(0f, -20f);

	private readonly Vector2 _islandOffsetX = new Vector2(20f, 0f);

	private readonly Vector2 _battleFieldSoldierCostOffsetX = new Vector2(90f, 0f);

	private readonly Vector2 _battleField机械降神IncreaseOffsetX = new Vector2(-90f, 0f);

	private readonly Vector2 _battleFieldOffsetY = new Vector2(0f, -80f);

	private readonly Vector2 _battleScoreChangeOffset = new Vector2(90f, 0f);

	public Vector2 DamageUiOffset(eMapViewLevel level)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return (level == eMapViewLevel.Island) ? Vector2.zero : _damageOffset;
	}

	public Vector2 SoldierCostOffset(eMapViewLevel level)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return (level == eMapViewLevel.Island) ? (_islandOffsetY + _islandOffsetX) : (_battleFieldOffsetY + _battleFieldSoldierCostOffsetX);
	}

	public Vector2 机械降神IncreaseOffset(eMapViewLevel level)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return (level == eMapViewLevel.Island) ? (_islandOffsetY - _islandOffsetX) : (_battleFieldOffsetY + _battleField机械降神IncreaseOffsetX);
	}

	public Vector2 BrawlEventScoreChangedOffset(eMapViewLevel level)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		return (level == eMapViewLevel.Island) ? (_islandOffsetY + _islandOffsetX) : (_battleFieldOffsetY + _battleScoreChangeOffset);
	}
}
