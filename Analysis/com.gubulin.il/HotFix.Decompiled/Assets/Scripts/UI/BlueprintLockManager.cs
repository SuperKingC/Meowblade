using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;

namespace Assets.Scripts.UI;

public class BlueprintLockManager
{
	private HashSet<string> _bpLocks = new HashSet<string>();

	public Action<Blueprint> EBPLockStateChange;

	public void Init()
	{
		_bpLocks = new HashSet<string>();
		Task<LegendItemBlueprintGetResponse> task = GameController.Contexts.Service<INetworkService>().LegendItemBlueprintGet();
		task.GetAwaiter().OnCompleted(delegate
		{
			LegendItemBlueprintGetResponse result = task.Result;
			if (result.LockedBlueprints == null)
			{
				return;
			}
			foreach (string lockedBlueprint in result.LockedBlueprints)
			{
				_bpLocks.Add(lockedBlueprint);
			}
		});
	}

	public bool GetIsLocked(Blueprint bp)
	{
		if (bp == null)
		{
			return false;
		}
		return _bpLocks.Contains(bp.Id);
	}

	public void SetIsLocked(Blueprint bpId, bool isLocked, Action<bool> onComplete)
	{
		Task<LockLegendItemBlueprintResponse> task = GameController.Contexts.Service<INetworkService>().SetLockLegendItemBlueprint(bpId.Id, isLocked);
		task.GetAwaiter().OnCompleted(delegate
		{
			LockLegendItemBlueprintResponse result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				_bpLocks.Clear();
				foreach (string item in result.LockedBlueprint)
				{
					_bpLocks.Add(item);
				}
				EBPLockStateChange?.Invoke(bpId);
				onComplete?.Invoke(isLocked);
			}
		});
	}
}
