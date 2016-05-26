using EAAA_fitness_lib.Model;
using EAAA_fitness_lib.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_FitnessAdmin.model;

namespace WPF_FitnessAdmin.Service
{
    public class Service
    {
        //readonly elementer er knyttet på Class objektet og derfor kun en instans af hver
        private static readonly Service _instance = new Service();
        private FitnessContext _db;

        private Service()
        {
            _db = new FitnessContext();
        }

        public static Service Instance
        {
            get
            {
                return _instance;
            }
        }
        public IEnumerable<FitnessClass> GetAllFitnessClasses()
        {
            var result = _db.Classes.ToList();
            return result;
        }
        public SessionViewModel GetFreshViewModel()
        {
            var model = new SessionViewModel();
            //model.Disciplines = _db.Disciplines.Local;
            //model.Instructors = _db.Instructors.Local;
            //model.Classes = _db.Classes.Local;
            model.Disciplines = new ObservableCollection<Discipline>(_db.Disciplines.ToList());
            model.Instructors = new ObservableCollection<Instructor>(_db.Instructors.ToList());
            model.Classes = new ObservableCollection<FitnessClass>(_db.Classes.ToList());
            return model;
        }

        public SessionViewModel UpdateViewModel(SessionViewModel model)
        {
            model.Disciplines = new ObservableCollection<Discipline>(_db.Disciplines.ToList());
            //model.Instructors = new ObservableCollection<Instructor>(_db.Instructors.ToList());
            model.Instructors.Clear();
            _db.Instructors.ToList().ForEach(i => model.Instructors.Add(i)); //Aktiverer 2-way binding.. forhåbentligt...

            model.Classes = new ObservableCollection<FitnessClass>(_db.Classes.ToList());
            return model;
        }

        public List<Discipline> GetAllDisciplines()
        {
            return _db.Disciplines.ToList();
        }
        public void AddInstructor(Instructor instructor)
        {
            _db.Instructors.Add(instructor);
            _db.SaveChanges();
        }

        public List<Instructor> GetAllInstructors()
        {
            return _db.Instructors.ToList();
        }
        public void DeleteInstrutor(Instructor instructor)
        {
            _db.Instructors.Remove(instructor);
            _db.SaveChanges();
        }
        //Burde update istedet for delete og inserte...
        public bool UpdateInstuctor(Instructor instructor)
        {
            if(instructor != null)
            {
                var oldvalue = _db.Instructors.First(i => i.InstructorId == instructor.InstructorId);
                _db.Instructors.Remove(oldvalue);
                try {
                    _db.Instructors.Add(instructor);
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    //gør noget meaningsfuldt...
                    return false;
                }
            }
            return false;
        }

        public List<Gym> GetAllGyms()
        {
            return _db.Gyms.ToList();
        }
    }
}