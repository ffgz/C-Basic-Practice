using System;

namespace Demo
{
    interface IPerson
    {
        string name{ get; set; }
        void showInfo(string name);
    }
    interface IStudent
    {
        string studentid{ get; set; }
        void showStuId(string studentid);
    }

    class Student: IPerson,IStudent
    {
        private string _name;
        public string name  // 实现IPerson的name
        {
            get => _name;
            set { _name = value; }
        }

        private string _studentid;
        public string studentid     // 实现IStudent的studentid
        {
            get{ return _studentid; }
            set{ _studentid = value; }
        }
        public Student(string stu_n,string stu_id){
            _name = stu_n;
            _studentid = stu_id;
        }

        void IPerson.showInfo(string name)
        {
            Console.WriteLine($"Name: {name}");
        }
        void IStudent.showStuId(string studentid)
        {
            Console.WriteLine($"StudentId: {studentid}");
        }
        public override string ToString()
        {
            
            return "name="+_name+",studentid="+_studentid;
        }
    }
}
