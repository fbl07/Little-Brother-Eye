using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.DataAccess.DataAccessObjects
{
    public class BaseDataAccess : IDisposable
    {
        internal LittleBrotherEyeEntities Context;

        public BaseDataAccess()
        {
            Context = new LittleBrotherEyeEntities();
        }

        public void Dispose()
        {
            ((IDisposable)Context).Dispose();
        }
    }
}