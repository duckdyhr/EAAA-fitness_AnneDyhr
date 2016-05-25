using EAAA_fitness_lib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_FitnessAdmin.model
{
    public class SessionViewModel
    {
        private ObservableCollection<Discipline> disciplines;
        private ObservableCollection<Instructor> instructors;
        private ObservableCollection<FitnessClass> classes;

        public ObservableCollection<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }

        public ObservableCollection<Instructor> Instructors
        {
            get { return instructors; }
            set { instructors = value; }
        }

        public ObservableCollection<FitnessClass> Classes
        {
            get { return classes; }
            set { classes = value; }
        }
    }
}
