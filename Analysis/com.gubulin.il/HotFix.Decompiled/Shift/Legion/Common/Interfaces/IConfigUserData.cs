using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Interfaces;

public interface IConfigUserData
{
	void SetOriginalValue(string value);

	void SetUserData(UserData userData);
}
