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
    public class MessageManager : IMessageService
    {
        IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            this._messagedal = messagedal;
        }

        public void TAdd(Message t)
        {
            _messagedal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messagedal.Delete(t);
        }

        public Message TGetByID(int id)
        {
           return _messagedal.GetByID(id);  
        }

        public List<Message> TGetList()
        {
            return _messagedal.GetList();
        }

        public void TUpdate(Message t)
        {
            _messagedal.Update(t);
        }
    }
}
