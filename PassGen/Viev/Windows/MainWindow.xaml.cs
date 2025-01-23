using PassGen.AppData;
using System.Windows;

namespace PassGen.Viev.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GenerationService _generationService;
        public MainWindow()
        {
            InitializeComponent();

            _generationService = new GenerationService();
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            int length = int.Parse(PasswordLengthTb.Text);
            PasswordsLb.ItemsSource = _generationService.Start(length);
        }
    }
}
