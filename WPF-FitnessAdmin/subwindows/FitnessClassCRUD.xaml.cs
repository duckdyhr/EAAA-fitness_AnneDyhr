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
            cmbInstructor.ItemsSource = service.GetAllInstructors();
            cmbGym.ItemsSource = service.GetAllGyms();
            lblGym.Content = "Sal (max " + fitnessClass.Gym.MaxCapacity + ")"; //binding skift farve?
        }
    }
}
