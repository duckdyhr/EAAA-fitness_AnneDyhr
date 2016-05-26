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
            ShowInstructorWindow(new Instructor(), WindowType.NewEntity);
        }

        private void btnDeleteInstructor_Click(object sender, RoutedEventArgs e)
        {
            var selected = lboxInstructors.SelectedItem as Instructor;
            service.DeleteInstrutor(selected);
            UpdateModel();
        }
        private void btnEditInstructor_Click(object sender, RoutedEventArgs e)
        {
            Instructor selected = lboxInstructors.SelectedItem as Instructor;
            ShowInstructorWindow(selected, WindowType.EditEntity);
        }

        private void btnEditClass_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowInstructorWindow(Instructor instructor, WindowType type)
        {
            var window = new InstructorCRUD(instructor, type);
            window.ChangesMade += UpdateModel;
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
    }
}
