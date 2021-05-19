using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Data;
using HandyControl.Tools;


namespace OneFileManager.CustomUserControl.Main
{
    /// <summary>
    /// NoUserContent.xaml 的交互逻辑
    /// </summary>
    public partial class NoUserContent:UserControl 
    {
      public NoUserContent()
        {
            InitializeComponent();
        }

      private void ButtonLangs_OnClick(object sender, RoutedEventArgs e)
      {
          if (e.OriginalSource is Button button && button.Tag is string langName)
          {
              PopupConfig.IsOpen = false;
              
          }
      }

      private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;

      private void ButtonSkins_OnClick(object sender, RoutedEventArgs e)
      {
          if (e.OriginalSource is Button button && button.Tag is SkinType tag)
          {
              PopupConfig.IsOpen = false;
            
          }
      }

      private void MenuAbout_OnClick(object sender, RoutedEventArgs e)
      {
  
      }
    }
}
