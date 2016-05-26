using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for InstructorCRUD.xaml
    /// </summary>
    public partial class InstructorCRUD : Window
    {
        public delegate void ChangesMadeEventHandler();
        public event ChangesMadeEventHandler ChangesMade;

        private Instructor instructor;
        private Service.Service service;
        public Instructor Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        private WindowType type;
        //disciplines behøver ikke at være 2-way men blot en 1-way binding
        private List<Discipline> disciplines;
        public List<Discipline> Disciplines {
            get { return disciplines; }
            set { disciplines = value; }
        }

        public InstructorCRUD(Instructor i, WindowType type)
        {
            InitializeComponent();
            service = Service.Service.Instance;
            this.instructor = i;
            this.type = type;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            disciplines = service.GetAllDisciplines();
            rootInstructor.DataContext = instructor;
            if(type == WindowType.NewEntity)
            {
                this.Title = "Ny Instruktør";
            }else
            {
                this.Title = "Rediger Instruktør";
            }
            BindDisciplines();
        }

        private void BindDisciplines()
        {
            if(instructor == null)
            {
                cmbDisciplines.ItemsSource = disciplines;
            }else
            {
                cmbDisciplines.ItemsSource = disciplines.Where(d => !instructor.FitnessDiscipliner.Contains(d));
            }
            //Disciplines.Where(d => !instructor.FitnessDiscipliner.Contains(d));
            cmbDisciplines.SelectedIndex = 0;
        }

        private void btnGodkend_Click(object sender, RoutedEventArgs e)
        {
            if(type == WindowType.EditEntity)
            {
                service.UpdateInstuctor(instructor);
                this.Close();
            }else
            {
                service.AddInstructor(instructor);
                this.Close();
            }
            //Er der subscribers?
            ChangesMade?.Invoke();
        }

        private void btnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            Discipline selected = cmbDisciplines.SelectedItem as Discipline;
            if(selected != null)
            {
                instructor.FitnessDiscipliner.Add(selected);
                BindDisciplines();
            }
        }

        private void btnDeleteDisciplin_Click(object sender, RoutedEventArgs e)
        {
            Discipline selected = lboxDisciplines.SelectedItem as Discipline;
            if(selected != null)
            {
                var tobedeleted = instructor.FitnessDiscipliner.First(fc => fc.Id == selected.Id);
                instructor.FitnessDiscipliner.Remove(tobedeleted);
            }
        }
    }

    public enum WindowType
    {
        NewEntity, EditEntity
    }
}