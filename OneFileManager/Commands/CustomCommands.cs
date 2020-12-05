using System.Windows.Input;

namespace OneFileManager.Commands
{
    internal class CustomCommands
    {
        static CustomCommands()
        {
            var inputOpenNewTab = new InputGestureCollection();
            inputOpenNewTab.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            OpenNewTab = new RoutedUICommand("OpenNewTab", "OpenNewTab", typeof(CustomCommands), inputOpenNewTab);
        }

        public static RoutedUICommand OpenNewTab { get; }
    }
}