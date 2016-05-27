using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_FitnessAdmin.model;
using WPF_FitnessAdmin.subwindows;

namespace WPF_FitnessAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Service.Service service;
        private SessionViewModel model;

        //delegate onclose -> saveChanges/rollback?
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            service = Service.Service.Instance;
            model = service.GetFreshViewModel();
            root.DataContext = model;
        }

        private void btnAddInstructor_Click(object sender, RoutedEventArgs e)
        {
            var window = new InstructorCRUD(new Instructor(), WindowType.NewEntity);
            window.InstructorChangesMade += InstructorAdded;
            window.Show();
        }

        private void btnDeleteInstructor_Click(object sender, RoutedEventArgs e)
        {
            var selected = lboxInstructors.SelectedItem as Instructor;
            service.DeleteInstrutor(selected);
            model.Instructors.Remove(selected);
            //UpdateModel();
        }

        private void btnEditInstructor_Click(object sender, RoutedEventArgs e)
        {
            Instructor selected = lboxInstructors.SelectedItem as Instructor;
            var window = new InstructorCRUD(selected, WindowType.EditEntity);
            window.InstructorChangesMade += InstructorEdited;
            window.Show();
        }
        
        public void UpdateModel()
        {
            this.model = service.GetFreshViewModel();
        }

        public void InstructorAdded(Instructor instructor)
        {
            model.Instructors.Add(instructor);
        }

        public void InstructorEdited(Instructor instructor)
        {
            var oldValue = model.Instructors.First(i => i.InstructorId == instructor.InstructorId);
            model.Instructors.Remove(oldValue);
            model.Instructors.Add(instructor);
        }

        public void FitnessClassAdded(FitnessClass fclass)
        {
            model.Classes.Add(fclass);
        }
        public void FitnessClassEdited(FitnessClass fclass)
        {
            var oldValue = model.Classes.First(fc => fc.Id == fclass.Id);
            model.Classes.Remove(oldValue);
            model.Classes.Add(fclass);
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            FitnessClass fc = new FitnessClass();
            var window = new FitnessClassCRUD(fc, WindowType.NewEntity);
            window.ChangesMade += FitnessClassAdded;
            window.Show();
        }

        private void btnEditClass_Click(object sender, RoutedEventArgs e)
        {
            FitnessClass selected = dgrdClasses.SelectedItem as FitnessClass;
            var window = new FitnessClassCRUD(selected, WindowType.EditEntity);
            window.ChangesMade += FitnessClassEdited;
            window.Show();
        }

        private void btnDeleteClass_Click(object sender, RoutedEventArgs e)
        {
            FitnessClass selected = dgrdClasses.SelectedItem as FitnessClass;
            bool result = service.DeleteFitnessClass(selected);
            if (result)
            {
                model.Classes.Remove(selected);
            }
        }

        private void NotYetImplemented()
        {
            MessageBox.Show("Not yet implemented");
        }

        private void btnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            NotYetImplemented();
        }

        private void btnDeleteDiscpline_Click(object sender, RoutedEventArgs e)
        {
            NotYetImplemented();
        }
    }
}