using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_TaskList
{
    internal class TaskInfo
    {
        string taskName;
        DateTime taskDate;
        DateTime taskTime;
        string taskAmPm;

        //Getting the data

        public void NewName(string newName)
        {
            if (newName.Length > 1)
            {
                taskName = newName;
                //Debug.Assert(newName.Length == 0);
            }
            else
            {
                taskName = "No Name"; //to prevent crashing as cant return null
            }
        }

        public void NewDate(DateTime newDate)
        {
            taskDate = newDate;
        }

        public void NewTime(DateTime newTime)
        {
            taskTime = newTime;
        }

        public void NewAmPm(string newAmPm)
        {
            taskAmPm = newAmPm;
        }

        //Returning the data

        public string GetName()
        {
            return taskName;
        }

        public DateTime GetDate()
        {
            return taskDate;
        }

        public DateTime GetTime()
        {
            return taskTime;
        }

        public string GetAmPm()
        {
            return taskAmPm;
        }

        public override string ToString()
        {
            return taskName;
        }
    }
}
