using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nokia
{
    public class TestCase
    {
        public string Owner { get; set; }
        public enum TestStatus { NULL = 0, Failed = 1, Exception = 2, Passed = 4 };
        public TestStatus Status { get; set; }
        public string Jira { get; set; }
        public string Defect { get; set; }
        public string Priority { get; set; }

        public TestCase(string owner, string status, string jira, string defect, string priority)
        {
            Owner = owner;
            Status = TestStatus.NULL; //redo This
            Jira = jira;
            Defect = defect;
            Priority = priority;
        }
    }
}
