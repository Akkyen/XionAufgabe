using System.Windows;
using XionAufgabe.Model;
using XionAufgabe.ViewModel;

namespace XionAufgabe.View.Dialogs
{
    public partial class CreatePatientDialog : Window
    {
        private PatientDialogViewModel PatientDialogViewModel = new();
        
        public CreatePatientDialog()
        {
            DataContext = PatientDialogViewModel;
            
            InitializeComponent();
        }
        
        public Patient Patient { get => PatientDialogViewModel.Patient; }

        private void BtnConfirm_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            Close();
        }
    }
}
