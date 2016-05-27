using EAAA_fitness_lib.Model;
using EAAA_fitness_lib.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        public List<Discipline> GetAllDisciplines()
        {
            return _db.Disciplines.ToList();
        }

        public List<Instructor> GetAllInstructors()
        {
            return _db.Instructors.ToList();
        }
        public Instructor AddInstructor(Instructor instructor)
        {
            var result =_db.Instructors.Add(instructor);
            _db.SaveChanges();
            return result;
        }
        public void DeleteInstrutor(Instructor instructor)
        {
            _db.Instructors.Remove(instructor);
            _db.SaveChanges();
        }
        //Burde update istedet for delete og inserte...
        public Instructor UpdateInstuctor(Instructor instructor)
        {
            Instructor result = null;
            if(instructor != null)
            {
                var oldvalue = _db.Instructors.First(i => i.InstructorId == instructor.InstructorId);
                _db.Instructors.Remove(oldvalue);
                _db.Entry(oldvalue).State = EntityState.Deleted;
                try {
                    result = _db.Instructors.Add(instructor);
                    _db.Entry(instructor).State = EntityState.Added;
                    _db.SaveChanges();

                }
                catch (Exception e)
                {
                    //gør noget meaningsfuldt...
                }
            }
            return result;
        }

        public FitnessClass AddFitnessClass(FitnessClass fclass)
        {
            FitnessClass result = null;
            if(fclass != null)
            {
                result = _db.Classes.Add(fclass);
                _db.Entry(fclass).State = EntityState.Added;
                _db.SaveChanges();
            }
            return result;
        }

        public FitnessClass EditFitnessClass(FitnessClass fclass)
        {
            FitnessClass result = null;
            if(fclass != null)
            {
                var oldValue = _db.Classes.First(fc => fc.Id == fclass.Id);
                _db.Classes.Remove(oldValue);
                result = _db.Classes.Add(fclass);
                _db.Entry(result).State = EntityState.Added;
            }
            return result;
        }

        public bool DeleteFitnessClass(FitnessClass fclass)
        {
            var tobedeleted = _db.Classes.Find(fclass.Id);
            _db.Classes.Remove(tobedeleted);
            return tobedeleted!=null;
        }
        public List<Gym> GetAllGyms()
        {
            return _db.Gyms.ToList();
        }
    }
}