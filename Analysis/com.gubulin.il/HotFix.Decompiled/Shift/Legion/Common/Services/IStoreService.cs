using System.Collections.Generic;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Services;

public interface IStoreService : IService
{
	List<StoreCategoryConfig> UpdateStoreCategoryConfigs();
}
