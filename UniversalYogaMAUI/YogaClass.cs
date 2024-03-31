using System;
namespace UniversalYogaMAUI
{
	public class YogaClass
	{
        private string _key;
        private string teacherClass;
        private string dateClass;
        private string commentsClass;
        private string id_Course;


        public string Key { get => _key; set => _key = value; }
        public string teacher { get => teacherClass; set => teacherClass = value; }
        public string date { get => dateClass; set => dateClass = value; }
        public string comments { get => commentsClass; set => commentsClass = value; }
        public string id_course { get => id_Course; set => id_Course = value; }
    }
}

