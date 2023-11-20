using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal adminDal)
        {
            this._admindal = adminDal;
        }

        public void TAdd(Admin t)
        {
            _admindal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            _admindal.Delete(t);
        }

        public Admin TGetByID(int id)
        {
            return _admindal.GetByID(id);
        }

        public List<Admin> TGetList()
        {
            return _admindal.GetList();

        }

        public void TUpdate(Admin t)
        {
            _admindal.Update(t);
        }
    }
}