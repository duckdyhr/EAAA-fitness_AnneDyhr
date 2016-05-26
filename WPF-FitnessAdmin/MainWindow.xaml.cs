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

        //delegate onclose -> saveChanges/rollback
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            service = Service.Service.Instance;
            model = service.GetFreshViewModel();
            test.Content = "instructors.count: " + model.Instructors.Count;
            root.DataContext = model;
        }

        private void btnAddInstructor_Click(object sender, RoutedEventArgs e)
        {
            var window = new InstructorCRUD(new Instructor(), WindowType.NewEntity);
            window.ChangesMade += InstructorAdded;
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
            window.ChangesMade += InstructorChanged;
            window.Show();
        }

        private void ShowFitnessClassWindow(FitnessClass fc, WindowType type)
        {
            var window = new FitnessClassCRUD(fc, type);
            window.Show();
        }

        public void UpdateModel()
        {
            this.model = service.GetFreshViewModel();
            test.Content = "instructors.count: " + model.Instructors.Count;
        }

        public void InstructorAdded(Instructor instructor)
        {
            model.Instructors.Add(instructor);
        }

        public void InstructorChanged(Instructor instructor)
        {
            var oldValue = model.Instructors.First(i => i.InstructorId == instructor.InstructorId);
            model.Instructors.Remove(oldValue);
            model.Instructors.Add(instructor);
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            FitnessClass fc = new FitnessClass();
            ShowFitnessClassWindow(fc, WindowType.NewEntity);
        }
        private void btnEditClass_Click(object sender, RoutedEventArgs e)
        {
            FitnessClass selected = dgrdClasses.SelectedItem as FitnessClass;
            ShowFitnessClassWindow(selected, WindowType.EditEntity);
        }

        private void btnDeleteClass_Click(object sender, RoutedEventArgs e)
        {
            NotYetImplemented();
        }
        private void NotYetImplemented()
        {
            MessageBox.Show("Not yet implemented");
        }
    }
}