using Caliburn.Micro;
using DesktopAdmin.Commands;
using DesktopAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopAdmin.ViewModels
{
    class ShellViewModel: Screen
    {
        private string _firstName;
        private string _lastName;
        private int _grade;
        private string _class;
        private int _classNumber;
        private string _subject;

        private StudentModel _student;
        private TeacherModel _teacher;

        private DelegateCommand saveCommand;

        public ShellViewModel()
        {
            saveCommand = new DelegateCommand(OnSaveCommand);
        }


        public String FirstName
        {
            get 
            { 
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);    
            }
        }

        public String LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public int Grade
        {
            get
            {
                return _grade;
            }
            set
            {
                _grade = value;
                NotifyOfPropertyChange(() => Grade);
            }
        }

        public String Class
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
                NotifyOfPropertyChange(() => Class);
            }
        }
        public int ClassNumber
        {
            get
            {
                return _classNumber;
            }
            set
            {
                _classNumber = value;
                NotifyOfPropertyChange(() => ClassNumber);
            }
        }

        public String Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
                NotifyOfPropertyChange(() => Subject);
            }
        }

        public StudentModel Student
        {
            get => _student;
            set
            {
                _student = value;
                NotifyOfPropertyChange(() => Student);
            }
        }

        //public TeacherModel Teacher 
        //{
        //    get => _teacher ?? new TeacherModel(); 
        //    set
        //    {
        //        _teacher = value;
        //        NotifyOfPropertyChange(() => Teacher);
        //    }
        //}

        public DelegateCommand SaveCommand
        {
            get { return saveCommand; }
        }

        private void OnSaveCommand(object commandParameter)
        {
            
            string strJsonResult = JsonConvert.SerializeObject(
                    new
                    {
                        FirstName = Student.FirstName,
                        LastName = LastName,
                        Garde = Grade,
                        Class = Class,
                        ClassNumber = ClassNumber
                    }
                );
            File.WriteAllText("C:\\Users\\Metodi\\Desktop\\info.json", strJsonResult);
            MessageBox.Show("Student file saved in JsonFomat");
            //MessageBox.Show(
            //    $"FirstName: { FirstName }\n " +
            //    $"LastName: { LastName }\n" +
            //    $"Grade: { Grade }\n" +
            //    $"Class: { Class }\n" +
            //    $"Class number: { ClassNumber }\n"
            //    );
        }

    }
}
