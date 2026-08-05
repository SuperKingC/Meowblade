using System.Collections.Generic;

namespace Shift.Legion.ClientApi.RPC.Api;

public class UserLoginCredentialsResult
{
	public int ErrorCode;

	public int CurrentUserId;

	public string Zone;

	public List<UserLoginCredentialsProto> Infos;
}
