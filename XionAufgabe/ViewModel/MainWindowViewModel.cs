using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using XionAufgabe.Interfaces;
using XionAufgabe.Model;
using XionAufgabe.View.Dialogs;

namespace XionAufgabe.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService _patientDialogService;

        private ObservableCollection<Patient> _patients = new();

        #region RelayCommands

        public RelayCommand CreatePatientCommand { get; }
        public RelayCommand<Patient> EditPatientCommand { get; }
        public RelayCommand<Patient> DeletePatientCommand { get; }

        #endregion

        public MainWindowViewModel(IDialogService patientDialogService)
        {
            _patientDialogService = patientDialogService;

            CreatePatientCommand = new RelayCommand(CreatePatient);
            EditPatientCommand = new RelayCommand<Patient>(EditPatient);
            DeletePatientCommand = new RelayCommand<Patient>(DeletePatient);
        }
        

        private void CreatePatient()
        {
            PatientDialogViewModel patientDialogViewModel = new PatientDialogViewModel();
            
            if(_patientDialogService.ShowDialog(PatientDialogType.CreatePatient, patientDialogViewModel))
                Patients.Add(patientDialogViewModel.Patient);
        }

        private void EditPatient(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException("Parameter patient shouldn't be null!");

            PatientDialogViewModel patientDialogViewModel = new PatientDialogViewModel(patient);

            _patientDialogService.ShowDialog(PatientDialogType.EditPatient, patientDialogViewModel);
        }

        private void DeletePatient(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException("Parameter patient shouldn't be null!");

            Patients.Remove(patient);
        }


        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                if (Equals(value, _patients)) return;
                _patients = value ?? throw new ArgumentNullException(nameof(value));
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
}
