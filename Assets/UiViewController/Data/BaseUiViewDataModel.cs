namespace UiViewController
{
    public class BaseUiViewDataModel : IUiViewDataModel
    {
        public string ViewName { get; set; }
        public int Score { get; set; }
    }
}

/*
 * Help me create a System in unity for displaying Views in the game.
Use MVC pattern to create a view class, a controller for the view and a data model class.
Create base classes and have different inheritors from it for the views.
Apply solid principles to the code.
Use interfaces for making controller communicate with view and handle functionalities.
Implement interfaces in the views and have them implemented explicitly.
 */