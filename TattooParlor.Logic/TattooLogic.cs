using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooParlor.Models;
using TattooParlor.Repository;

namespace TattooParlor.Logic
{
    public class TattooLogic : ITattooLogic
    {
        ITattooRepository tattooRepo;
        public TattooLogic(ITattooRepository tattooRepo)
        {
            this.tattooRepo = tattooRepo;
        }

        #region CRUD methods
        //Create
        public void AddNewTattoo(Tattoo tattoo)
        {
            tattooRepo.AddNewTatto(tattoo);
        }

        //Read
        public Tattoo GetTattooById(int id)
        {
            if (id <= tattooRepo.GetAll().Count())
            {
                return tattooRepo.GetOne(id);
            }
            throw new IndexOutOfRangeException("Invalid ID");
        }
        //ReadAll
        public IEnumerable<Tattoo> GetAllTattoes()
        {
            return tattooRepo.GetAll();
        }

        
        //Update
        public void UpdateTattoo(Tattoo tattoo)
        {
            tattooRepo.UpdateTatto(tattoo);
        }
        public void ChangeFantasyName(int id, string newName)
        {
            tattooRepo.ChangeFantasyName(id, newName);
        }

        //Delete
        public void DeleteTatto(int id)
        {
            tattooRepo.DeleteTatto(id);
        }
        #endregion


    }
}
