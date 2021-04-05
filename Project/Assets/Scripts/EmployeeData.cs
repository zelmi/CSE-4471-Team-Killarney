using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets.Scripts
{
    //Class for representing an email inbox tab, serializable to persist across email sessions
    public class EmployeeData
    {
        //Message class for each individual message
        public class Employee
        {
            [XmlAttribute]
            public string name;
            [XmlAttribute]
            public string email;
            [XmlAttribute]
            public string role;

            //No argument constructor necessary for serialization
            public Employee()
            {
                name = "Doe, John";
                email = "doe.john@bmail.com";
                role = "CEO";
            }

            public Employee(string name, string email, string role)
            {
                this.name = name;
                this.email = email;
                this.role = role;
            }
        }

        //List of messages
        public List<Employee> employeeList;

        //Constructor
        public EmployeeData()
        {
            employeeList = new List<Employee>();
        }
    }
}
