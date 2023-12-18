using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using XionAufgabe.Model;
using XionAufgabe.ViewModel;

namespace XionAufgabe.View.Dialogs
{
    public partial class EditPatientDialog : Window
    {
        private PatientDialogViewModel PatientDialogViewModel = new PatientDialogViewModel();
        
        public EditPatientDialog()
        {
            DataContext = PatientDialogViewModel;
            
            InitializeComponent();

            DataObject.AddPastingHandler(TbName, OnPaste);
            DataObject.AddPastingHandler(TbVorname, OnPaste);
            DataObject.AddPastingHandler(TbWohnort, OnPaste);
        }
        
        public Patient Patient { get => PatientDialogViewModel.Patient; }

        private void UpdateTextBinding(object sender, KeyEventArgs keyEventArgs)
        {
            if (sender is TextBox textBox)
            { 
                BindingExpression binding = textBox.GetBindingExpression(TextBox.TextProperty);
                binding?.UpdateSource();
            }
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (sender is TextBox textBox && e.DataObject.GetDataPresent(typeof(string)))
            {
                BindingExpression binding = textBox.GetBindingExpression(TextBox.TextProperty);
                binding?.UpdateSource();
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
