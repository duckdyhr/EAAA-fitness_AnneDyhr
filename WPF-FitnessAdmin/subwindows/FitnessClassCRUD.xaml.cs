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
using System.Windows.Shapes;

namespace WPF_FitnessAdmin.subwindows
{
    /// <summary>
    /// Interaction logic for FitnessClassCRUD.xaml
    /// </summary>
    public partial class FitnessClassCRUD : Window
    {
        private FitnessClass fitnessClass;
        private Service.Service service;
        private WindowType type;
        public delegate void ChangesMadeEventHandler(FitnessClass fclass);
        public event ChangesMadeEventHandler ChangesMade;

        public FitnessClassCRUD(FitnessClass fc, WindowType type)
        {
            InitializeComponent();
            service = Service.Service.Instance;
            this.type = type;
            fitnessClass = fc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rootFitnessClass.DataContext = fitnessClass;
            cmbDisciplines.ItemsSource = service.GetAllDisciplines();
            cmbInstructor.ItemsSource = service.GetAllInstructors();
            cmbGym.ItemsSource = service.GetAllGyms();
            string content = "Sal ";
            if(fitnessClass.Gym != null)
            {
                content += "Sal (max " + fitnessClass.Gym.MaxCapacity + ")";
            }
            lblGym.Content = content; //binding skift farve?
            if (type == WindowType.NewEntity)
            {
                this.Title = "Ny Fitnesstime";
            }else
            {
                this.Title = "Rediger Fitnesstime";
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (type == WindowType.NewEntity)
            {
                //fitnessClass.Discipline = cmbDisciplines.SelectedItem as Discipline;
                //fitnessClass.Instructor = cmbInstructor.SelectedItem as Instructor;
                //fitnessClass.Gym = cmbGym.SelectedItem as Gym;
                fitnessClass = service.AddFitnessClass(fitnessClass);
            }else
            {
                fitnessClass = service.EditFitnessClass(fitnessClass);
            }
            this.Close();
            ChangesMade?.Invoke(fitnessClass);
        }
    }
}