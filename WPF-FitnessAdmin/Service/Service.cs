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
            model.Disciplines = new ObservableCollection<Discipline>(_db.Disciplines.ToList());
            model.Instructors = new ObservableCollection<Instructor>(_db.Instructors.ToList());
            model.Classes = new ObservableCollection<FitnessClass>(_db.Classes.ToList());
            return model;
        }
        
    }
}