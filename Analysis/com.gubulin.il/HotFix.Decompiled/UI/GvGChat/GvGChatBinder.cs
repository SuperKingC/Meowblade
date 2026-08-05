using FairyGUI;

namespace UI.GvGChat;

public class GvGChatBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapf0oi23", typeof(UI_com_ChannelLastMessage));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapjdtn15", typeof(UI_com_ChannelIcon));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapm9d724", typeof(UI_com_ChatPageBack));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j11", typeof(UI_main_GvG3ChatRedirectIsland));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j12", typeof(UI_com_ConfirmRedirectIsland));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j13", typeof(UI_com_Loading));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j9", typeof(UI_com_MessagePopUp));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jc", typeof(UI_com_ChatPages));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jd", typeof(UI_com_Chat));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0je", typeof(UI_com_Message_System));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jf", typeof(UI_btn_TabWorld));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jg", typeof(UI_btn_ClickGraph));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jh", typeof(UI_com_InputChatText));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0ji", typeof(UI_btn_SendMessage));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jk", typeof(UI_com_Message_User));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0js", typeof(UI_com_Message_My));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jt", typeof(UI_btn_TabCamp));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0ju", typeof(UI_btn_TabSystem));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jv", typeof(UI_main_GvG3ChatSendCost));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jw", typeof(UI_com_ConfirmSendCost));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jx", typeof(UI_btn_Confirm));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jz", typeof(UI_btn_Cancel));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapt0aw1u", typeof(UI_btn_Close));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapy77p1y", typeof(UI_btn_DialogIcon));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapyfd30", typeof(UI_main_GvG3Chat));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapyfd37", typeof(UI_btn_MessageBubble));
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapyfd38", typeof(UI_com_NewChannelMessage));
	}
}
