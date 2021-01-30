using System.Windows.Input;

namespace OneFileManager.Commands
{
    public class OpenNewTabCommand
    {
        static OpenNewTabCommand()
        {
            var inputOpenNewTab = new InputGestureCollection();
            inputOpenNewTab.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            OpenNewTab = new RoutedUICommand("OpenNewTab", "OpenNewTab", typeof(OpenNewTabCommand), inputOpenNewTab);
        }
        public static RoutedUICommand OpenNewTab { get; }
    }
}