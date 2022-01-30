using System.Windows;
using Showcase.WPF.DragDrop.ViewModels;

namespace DragDropDemo.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {

            InitializeComponent();

            DataContext = new StructureManagerViewModel();

        }
    }
}
