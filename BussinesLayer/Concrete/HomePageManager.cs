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
    public class HomePageManager : IHomePageService
    {
        IHomePageDal _homepagedal;

        public HomePageManager(IHomePageDal homepagedal)
        {
            this._homepagedal = homepagedal;
        }

        public void TAdd(HomePage t)
        {
            _homepagedal.Insert(t);
        }

        public void TDelete(HomePage t)
        {
            _homepagedal.Delete(t);
        }

        public HomePage TGetByID(int id)
        {
            return _homepagedal.GetByID(id);
        }

        public List<HomePage> TGetList()
        {
                return _homepagedal.GetList();
        }

        public void TUpdate(HomePage t)
        {
            _homepagedal.Update(t);
        }
    }
}
