using Caliburn.Micro;
using DesktopAdmin.Commands;
using DesktopAdmin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopAdmin.ViewModels
{
    class ShellViewModel: Screen
    {
        private string _studentFirstName;
        private string _studentLastName;
        private string _teahcerFirstName;
        private string _teacherLastName;
        private int _grade;
        private string _class;
        private int _classNumber;
        private string _subject;


        private readonly DelegateCommand saveStudentCommand;
        private readonly DelegateCommand saveTeacherCommand;

        private static readonly HttpClientHandler handler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        private static readonly HttpClient http = new HttpClient(handler);

        public ShellViewModel()
        {
            saveStudentCommand = new DelegateCommand(OnSaveStudentCommand);
            saveTeacherCommand = new DelegateCommand(OnSaveTeacherCommand);
        }


        public String StudentFirstName
        {
            get 
            { 
                return _studentFirstName; 
            }
            set 
            { 
                _studentFirstName = value;
                NotifyOfPropertyChange(() => StudentFirstName);    
            }
        }

        public String StudentLastName
        {
            get
            {
                return _studentLastName;
            }
            set
            {
                _studentLastName = value;
                NotifyOfPropertyChange(() => StudentLastName);
            }
        }

        public String TeacherFirstName 
        {
            get
            {
                return _teahcerFirstName;
            }
            set
            {
                _teahcerFirstName = value;
                NotifyOfPropertyChange(() => TeacherFirstName);
            }
        }

        public String TeacherLastName 
        {
            get
            {
                return _teacherLastName;
            }
            set
            {
                _teacherLastName = value;
                NotifyOfPropertyChange(() => TeacherLastName);
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

        public DelegateCommand SaveStudentCommand
        {
            get { return saveStudentCommand; }
        }
        public DelegateCommand SaveTeacherCommand 
        {
            get { return saveTeacherCommand; } 
        }
        private async void OnSaveStudentCommand(object commandParameter)
        {

            var values = new Dictionary<string, string>
            {
                {"FirstName", StudentFirstName},
                {"LastName", StudentLastName},
                {"Grade", Grade.ToString()},
                {"Class", Class},
                {"ClassNumber", ClassNumber.ToString()}

            };
            var content = JsonConvert.SerializeObject(values);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await http.PostAsync("https://localhost:5001/api/students", byteContent);

            //var responseString = await response.Content.ReadAsStringAsync();
            //MessageBox.Show(responseString);


            //string strJsonResult = JsonConvert.SerializeObject(
            //        new
            //        {
            //            FirstName = StudentFirstName,
            //            LastName = StudentLastName,
            //            Garde = Grade,
            //            Class = Class,
            //            ClassNumber = ClassNumber
            //        }
            //    );
            //File.WriteAllText("C:\\Users\\Metodi\\Desktop\\info.json", strJsonResult);
            //MessageBox.Show("Student file saved in JsonFomat");



            //MessageBox.Show(
            //    $"FirstName: { FirstName }\n " +
            //    $"LastName: { LastName }\n" +
            //    $"Grade: { Grade }\n" +
            //    $"Class: { Class }\n" +
            //    $"Class number: { ClassNumber }\n"
            //    );
        }
        private async void OnSaveTeacherCommand(object commandParameter)
        {

            var values = new Dictionary<string, string>
            {
                {"FirstName", TeacherFirstName},
                {"LastName", TeacherLastName},
                {"Subject", Subject}
            };
            var content = JsonConvert.SerializeObject(values);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await http.PostAsync("https://localhost:5001/api/teachers", byteContent);

            //var responseString = await response.Content.ReadAsStringAsync();
            //MessageBox.Show(responseString);

            //string strJsonResult = JsonConvert.SerializeObject(
            //        new
            //        {
            //            FirstName = TeacherFirstName,
            //            LastName = TeacherLastName,
            //            Subject = Subject    
            //        }
            //    );
            //File.WriteAllText("C:\\Users\\Metodi\\Desktop\\info2.json", strJsonResult);
            //MessageBox.Show("Teacher file saved in JsonFomat");
        }

    }
}
