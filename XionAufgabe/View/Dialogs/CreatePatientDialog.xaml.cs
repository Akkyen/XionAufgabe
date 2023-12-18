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
            //Falls Patienten mit leeren String erstellen werden können sollen, bitte if kommentieren und kommentierte Zeilen auskommentieren.

            if (TbName.Text != string.Empty && TbVorname.Text != string.Empty && TbWohnort.Text != string.Empty)
            {
                DialogResult = true;
                Close();
            }

            //DialogResult = true;

            //Close();
        }
    }
}
