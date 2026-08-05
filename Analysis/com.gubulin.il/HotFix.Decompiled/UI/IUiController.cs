using System.Collections.Generic;

namespace UI;

public interface IUiController
{
	void RegisterUiEventListeners();

	void UnregisterUiEventListeners();

	void Init(Dictionary<string, object> parameters);

	void OnShow();

	void BeforeDestroy();

	void Destroy();
}
