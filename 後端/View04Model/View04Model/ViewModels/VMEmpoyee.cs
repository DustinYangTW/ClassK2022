using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using View04Model.Models;

namespace View04Model.ViewModels
{
    public class VMEmpoyee
    {
        public List<tDepartment> department { get; set; }
        public List<tEmployee> employee { get; set; }
    }
}