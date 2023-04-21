using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SeaBattle.Tools
{
    public class Navigation:BaseVM
    {
        private Navigation()
        {
        }

        static Navigation instance;

        public static Navigation GetInstance()
        { 
            if (instance == null)
                instance = new Navigation();
            return instance;
        }

        public Page CurrentPage { get; set; }
    }
}
