using System;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public interface IStoryActionHandler
{
	string ActionId();

	Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger);
}
