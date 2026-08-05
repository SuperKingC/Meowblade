using System.Collections;
using Shift.Legion.ClientApi.Protocol;
using UI.GameActivity;

namespace Shift.Legion.Common.Managers;

public class Cache_CertificationRedDot : CacheBaseBehavior
{
	public const string ON_CERTIFICATION_RED_DOT_CHANGE = "ON_CERTIFICATION_RED_DOT_CHANGE";

	private bool _isUpdating = false;

	private bool _isShowRedDot = false;

	public bool IsShowRedDot
	{
		get
		{
			return _isShowRedDot;
		}
		set
		{
			if (value != _isShowRedDot)
			{
				_isShowRedDot = value;
				SharedMessenger.Broadcast("ON_CERTIFICATION_RED_DOT_CHANGE", this);
			}
		}
	}

	public override IEnumerator Init()
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 1f;
		yield return null;
	}

	public override void DeferredUpdate()
	{
		if (!_isUpdating)
		{
			_isUpdating = true;
			User value = GameController.Contexts.gameState.user.value;
			bool flag = (value.Verified == 0 || value.Verified == 3) && !FGUIManager.Instance.certificationTabChecked;
			bool flag2 = value.Verified == 1;
			IsShowRedDot = flag || flag2;
			IsUpdateEnabled = false;
			_isUpdating = false;
		}
	}

	public override void OnAllCachesInit()
	{
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUiClose);
	}

	private void OnUiClose(string uiName)
	{
		if (!(uiName != UI_ActivityPanel.Name))
		{
			IsUpdateEnabled = true;
			base.DelayUpdateFromNow = 0.5f;
		}
	}
}
