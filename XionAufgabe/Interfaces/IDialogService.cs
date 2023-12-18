namespace XionAufgabe.Interfaces;

public interface IDialogService
{
    bool ShowDialog(object viewModel);

    bool ShowDialog(Enum dialogTyp, object viewModel);
}