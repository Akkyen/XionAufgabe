using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using XionAufgabe.Model;

namespace XionAufgabe.ViewModel;

public class PatientDialogViewModel : INotifyPropertyChanged
{
    private Patient _patient = new Patient();

    public PatientDialogViewModel()
    {
    }

    public PatientDialogViewModel(Patient patient)
    {
        Patient = patient;
    }

    public Patient Patient
    {
        get => _patient;
        set
        {
            if (Equals(value, _patient)) return;
            _patient = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}