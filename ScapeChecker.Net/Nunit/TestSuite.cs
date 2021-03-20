using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ScapeChecker.Net.Models
{
    [XmlRoot("testsuite")]
    public class TestSuite
    {
        [XmlAttribute("tests")]
        public int Count { get; set; }

        [XmlElement("testcase")]
        public List<TestCase> TestCases = new List<TestCase>();
    }

    public class TestCase
    {
        [XmlAttribute("name")]
        public string Name = "";

        [XmlAttribute("classname")]
        public string ClassName = "SpaceChecker_Net";

        [XmlAttribute("time")]
        public int Time = 0;

        [XmlElement("error")]
        public NunitError NunitError { get; set; }

        [XmlElement("system-out")]
        public string SystemOut { get; set; }

        [XmlElement("system-err")]
        public string SystemErr { get; set; }
    }

    public class NunitError
    {
        [XmlAttribute("message")]
        public string Message { get; set; }

        [XmlText]
        public string Content { get; set; }
    }
}