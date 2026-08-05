using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Services;

public class CameraFollowUnitSystem : BaseExecuteSystem
{
	private IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	private IGroup<GameEntity> Group => _group ?? (_group = _contexts.Service<ReplayPlayerService>().GetGroupOfReplayContexts(GameMatcher.AiObject));

	public CameraFollowUnitSystem(Contexts contexts)
		: base(contexts)
	{
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		if (!_contexts.gameState.isCameraFollowingUnit || !_contexts.gameState.hasCameraFollowTeam || Group == null)
		{
			return;
		}
		Team value = _contexts.gameState.cameraFollowTeam.value;
		float num = ((value == Team.Blue) ? 10000f : (-10000f));
		switch (value)
		{
		case Team.Red:
			if (!PlayFrameService.GetInstance().HasRedTeamTargetX())
			{
				return;
			}
			num = PlayFrameService.GetInstance().GetRedTeamTargetX();
			break;
		case Team.Blue:
			if (!PlayFrameService.GetInstance().HasBlueTeamTargetX())
			{
				return;
			}
			num = PlayFrameService.GetInstance().GetBlueTeamTargetX();
			break;
		}
		if (num != -10000f && num != 10000f)
		{
			ICameraService cameraService = _contexts.Service<ICameraService>();
			Vector3 position = cameraService.Position;
			Vector3 val = Vector3.SmoothStep(position, new Vector3(num, position.y, position.z), 10f * _contexts.input.fixedDeltaTime.value);
			float num2 = cameraService.ScreenWidth / cameraService.ScreenHeight / 1.7777778f;
			Vector3 position2 = _contexts.gameState.cameraMoveLimit.position;
			float size = cameraService.Size;
			float num3 = ((num2 > 1f) ? (size * cameraService.Aspect * num2) : (size * cameraService.Aspect));
			Vector3 val2 = _contexts.gameState.cameraMoveLimit.size - new Vector3((num2 > 1f) ? (num3 - 0.8f) : num3, 0f, size);
			float num4 = position2.x - val2.x;
			float num5 = position2.x + val2.x;
			if (_contexts.gameState.battleFieldLevel?.value?.ChapterId == "C10000" || _contexts.gameState.battleFieldLevel?.value?.ChapterId == "C10001")
			{
				num5 = 0f;
			}
			float num6 = position2.z - val2.z;
			float num7 = position2.z + val2.z;
			if (val.x < num4)
			{
				val.x = num4;
			}
			if (val.x > num5)
			{
				val.x = num5;
			}
			if (val.z < num6)
			{
				val.z = num6;
			}
			if (val.z > num7)
			{
				val.z = num7;
			}
			cameraService.SetPosition(val);
		}
	}
}
