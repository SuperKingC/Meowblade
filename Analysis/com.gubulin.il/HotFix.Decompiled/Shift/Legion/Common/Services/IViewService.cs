using UnityEngine;

namespace Shift.Legion.Common.Services;

public interface IViewService : IService, IAnyAssetListener
{
	bool InitView(GameEntity entity, GameObject gameObject);

	Transform GetViewRoot();
}
