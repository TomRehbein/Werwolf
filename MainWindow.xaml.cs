using System.Windows;

namespace Werwolf
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void MainViewControl_Loaded(object sender, RoutedEventArgs e)
      {
         Werwolf.ViewModel.GameSetUpViewModel MainViewModelObject =
            new Werwolf.ViewModel.GameSetUpViewModel();

         MainViewControl.DataContext = MainViewModelObject;
      }
   }
}
