using System.Threading.Tasks;
using GameMaths;
using RSG;

namespace Shift.Legion.Common.Services;

public interface IViewInstantiator
{
	object Initialize(string viewName, Vector3 pos, int poolSize = 5);

	Task<object> InstantiateAsync(string viewName, Vector3 pos);

	Promise<object> InitializeAsync(string viewName, Vector3 pos, int poolSize = 5);
}
