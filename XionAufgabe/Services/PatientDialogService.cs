using System.Windows;
using XionAufgabe.Interfaces;
using XionAufgabe.View.Dialogs;

namespace XionAufgabe.Services;

public class PatientDialogService : IDialogService
{
    public bool ShowDialog(object viewModel)
    {
        throw new NotImplementedException();
    }

    public bool ShowDialog(Enum type, object viewModel)
    {
        bool rValue = false;

        if (type is PatientDialogType dialogType)
        {
            Window dialog;

            switch (dialogType)
            {
                case PatientDialogType.CreatePatient:
                    dialog = new CreatePatientDialog();
                    break;
                case PatientDialogType.EditPatient:
                    dialog = new EditPatientDialog();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            dialog.DataContext = viewModel;

            rValue = dialog.ShowDialog() == true;
        }

        return rValue;
    }
}