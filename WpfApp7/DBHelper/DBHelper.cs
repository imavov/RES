using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp7.DataBase;

namespace WpfApp7.DBHelper
{
    public static class DBHelper
    {
        private static User7Entities Context = new User7Entities();

        public static User7Entities GetContext()
        {
            return Context;
        }
    }
}
