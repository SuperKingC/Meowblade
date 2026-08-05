using FairyGUI;

namespace UI.Friends;

public class FriendsBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w30", typeof(UI_FriendsPanel));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w31", typeof(UI_FriendsDialog));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w32", typeof(UI_FriendItem));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w33", typeof(UI_InvitationIcon));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w34", typeof(UI_HeadPortrait));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w3e", typeof(UI_deleteBtn));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w3f", typeof(UI_ConfirmDialog));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w3h", typeof(UI_FriendRequestBtn));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cc3w3i", typeof(UI_SearchFriendPanel));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cewnakg", typeof(UI_startMessage));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6ck050r", typeof(UI_SendBtn));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cn9xk16", typeof(UI_InvitationCode));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr610", typeof(UI_FriendRequestPanel));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6s", typeof(UI_AddFriendDialog));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6u", typeof(UI_AddFriendPanel));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6v", typeof(UI_AddFriendBtn));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6w", typeof(UI_FriendItemConfirm));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6cqtr6y", typeof(UI_FriendRequestDialog));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6ct6gt14", typeof(UI_CancelBtn));
		UIObjectFactory.SetPackageItemExtension("ui://3rz8gv6ct6gt15", typeof(UI_ConfirmBtn));
	}
}
