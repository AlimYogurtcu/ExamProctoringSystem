using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProctoring.Models
{
    public class BackgroundProcess
    {

        public List<String> processes { get; set; }

        public void setProcesses(List<String> listName)
        {
            this.processes = listName;
        }

    }
}