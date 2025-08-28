using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcajaxddlcascading.Models
{
	public class StudentModel
	{
        public int studentid { get; set; }
        public string studentname { get; set; }
        public int studentage { get; set; }
        public int Country{ get; set; }
        public int State { get; set; }
        public int City { get; set; }

    }
}