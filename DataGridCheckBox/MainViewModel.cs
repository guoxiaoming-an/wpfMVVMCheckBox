using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace DataGridCheckBox
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            DataGridBaseInfo = AddDataGridInfo();
        }
        private List<MainModel> dataGridBaseInfo;

        public List<MainModel> DataGridBaseInfo
        {
            get { return dataGridBaseInfo; }
            set
            {
                dataGridBaseInfo = value;
                RaisePropertyChanged("DataGridBaseInfo");
            }
        }

        private RelayCommand buttonCommand;

        public RelayCommand ButtonCommand
        {
            get
            {
                return buttonCommand ?? (buttonCommand = new RelayCommand(
                    () =>
                    {
                        int count = DataGridBaseInfo.ToList().FindAll(p => p.IsSelected == true).Count;
                        for (int i = 0; i < count; i++)
                            MessageBox.Show(DataGridBaseInfo.ToList().FindAll(p=>p.IsSelected==true)[i].Name + "," + DataGridBaseInfo.ToList().FindAll(p=>p.IsSelected==true)[i].Age);
                    }));
            }            
        }

        public List<MainModel> AddDataGridInfo()
        {
            MainModel model;
            List<MainModel> list = new List<MainModel>();
            for (int i = 0; i < 5; i++)
            {
                model = new MainModel();
                model.Xh = i;
                model.Name = "李雷" + i;
                model.Age = 20 + i;
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 选中
        /// </summary>
        private RelayCommand selectCommand;

        public RelayCommand SelectCommand
        {
            get
            {
                return selectCommand ?? (selectCommand = new RelayCommand(
                    () =>
                    {
                        int selectCount = DataGridBaseInfo.ToList().Count(p => p.IsSelected == false);
                        if (selectCount.Equals(0))
                        {
                            IsSelectAll = true;
                        }
                    }));
            }
        }
        /// <summary>
        /// 取消选中
        /// </summary>
        private RelayCommand unSelectCommand;

        public RelayCommand UnSelectCommand
        {
            get
            {
                return unSelectCommand ?? (unSelectCommand = new RelayCommand(
                    () =>
                    {
                        IsSelectAll = false;
                    }));
            }
        }

        private bool isSelectAll = false;

        public bool IsSelectAll
        {
            get { return isSelectAll; }
            set
            {
                isSelectAll = value;
                RaisePropertyChanged("IsSelectAll");
            }
        }

        /// <summary>
        /// 选中全部
        /// </summary>
        private RelayCommand selectAllCommand;

        public RelayCommand SelectAllCommand
        {
            get
            {
                return selectAllCommand ?? (selectAllCommand = new RelayCommand(ExecuteSelectAllCommand, CanExecuteSelectAllCommand));
            }
        }

        private void ExecuteSelectAllCommand()
        {
            if (DataGridBaseInfo.Count < 1) return;
            DataGridBaseInfo.ToList().FindAll(p => p.IsSelected = true);
        }

        private bool CanExecuteSelectAllCommand()
        {
            if (DataGridBaseInfo != null)
            {
                return DataGridBaseInfo.Count > 0;
            }
            else
                return false;
        }

        /// <summary>
        /// 取消全部选中
        /// </summary>
        private RelayCommand unSelectAllCommand;

        public RelayCommand UnSelectAllCommand
        {
            get { return unSelectAllCommand ?? (unSelectAllCommand = new RelayCommand(ExecuteUnSelectAllCommand, CanExecuteUnSelectAllCommand)); }
        }

        private void ExecuteUnSelectAllCommand()
        {
            if (DataGridBaseInfo.Count < 1)
                return;
            if (DataGridBaseInfo.ToList().FindAll(p => p.IsSelected == false).Count != 0)
                IsSelectAll = false;
            else
                DataGridBaseInfo.ToList().FindAll(p => p.IsSelected = false);
        }

        private bool CanExecuteUnSelectAllCommand()
        {
            if (DataGridBaseInfo != null)
            {
                return DataGridBaseInfo.Count > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
