using System;

namespace HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;

public interface INestingGift
{
	string ItemId { get; }

	int Count { get; }

	string IconUrl { get; }

	string Name { get; }

	int GetUiState();

	void OnClick(Action onSuccess = null);
}
