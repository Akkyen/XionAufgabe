using System.Windows;
using XionAufgabe.Interfaces;
using XionAufgabe.Services;
using XionAufgabe.ViewModel;

namespace XionAufgabe.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PatientDialogService _patientDialogService;

        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _patientDialogService = new PatientDialogService();

            _viewModel = new MainWindowViewModel(_patientDialogService);

            DataContext = _viewModel;
        }
    }
}