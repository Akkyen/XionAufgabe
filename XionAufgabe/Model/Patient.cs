using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XionAufgabe.Model;

public class Patient : INotifyPropertyChanged
{
    private string _name = string.Empty;
    private string _vorname = string.Empty;

    private string _wohnort = string.Empty;

    public Patient()
    {
    }

    public Patient(string vorname, string name, string wohnort)
    {
        _vorname = vorname;
        _name = name;
        _wohnort = wohnort;
    }

    public string Name
    {
        get => _name;
        set
        {
            if (value == _name) return;
            _name = value ?? throw new ArgumentNullException(nameof(value) + " shouldn't be null!");
            OnPropertyChanged();
        }
    }

    public string Vorname
    {
        get => _vorname;
        set
        {
            if (value == _vorname) return;
            _vorname = value ?? throw new ArgumentNullException(nameof(value) + " shouldn't be null!");
            OnPropertyChanged();
        }
    }

    public string Wohnort
    {
        get => _wohnort;
        set
        {
            if (value == _wohnort) return;
            _wohnort = value ?? throw new ArgumentNullException(nameof(value) + " shouldn't be null!");
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