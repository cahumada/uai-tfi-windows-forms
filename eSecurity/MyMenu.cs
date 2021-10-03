using eDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity
{
    public class MyMenu
    {
        public static DataTable GenerarMenu()
        {
            return MyMenu_DAL.GenerarMenu();
        }
    }
}
