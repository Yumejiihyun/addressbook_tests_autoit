using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public GroupData()
        {
        }
        public GroupData(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public int CompareTo(GroupData other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(GroupData other)
        {
            return Name.Equals(other.Name);
        }
    }
}
