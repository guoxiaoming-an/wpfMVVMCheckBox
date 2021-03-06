﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataGridCheckBox
{
    public class MainModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void INotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int xh;

        public int Xh
        {
            get { return xh; }
            set { xh = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
            INotifyPropertyChanged("Name");
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value;
            INotifyPropertyChanged("Age");
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;
            INotifyPropertyChanged("IsSelected");
            }
        }
    }
}
