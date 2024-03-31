using System;
using System.Collections.Generic; 
namespace UniversalYogaMAUI
{
	public class YogaCourse
	{
        private string _key;
        private string day;
        private string time;
        private string capacityCourse;
        private string durationCourse;
        private string priceCourse;
        private string typeCourse;
        private string descriptionCourse;
        private string levelCourse;
        private string _id;

        public string Key { get => _key; set => _key = value; }
        public string dayOfWeek { get => day; set => day = value; }
        public string timeOfCourse { get => time; set => time = value; }
        public string capacity { get => capacityCourse; set => capacityCourse = value; }
        public string duration { get => durationCourse; set => durationCourse = value; }
        public string price{ get => priceCourse; set => priceCourse = value; }
        public string type { get => typeCourse; set => typeCourse = value; }
        public string description { get => descriptionCourse; set => descriptionCourse = value; }
        public string level{ get => levelCourse; set => levelCourse = value; }
        public string id { get => _id; set => _id = value; }
        
    }
}

