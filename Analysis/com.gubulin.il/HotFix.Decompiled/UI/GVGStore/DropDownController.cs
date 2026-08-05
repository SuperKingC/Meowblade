using FairyGUI;

namespace UI.GVGStore;

public class DropDownController : IDropDownController
{
	private readonly Controller _controller;

	public DropDownControllerState ControllerState
	{
		get
		{
			return (DropDownControllerState)_controller.selectedIndex;
		}
		set
		{
			_controller.SetSelectedIndex((int)value);
		}
	}

	public DropDownController(Controller controller)
	{
		_controller = controller;
	}
}
