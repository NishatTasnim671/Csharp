using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList
{
    /// <summary>
    /// emun of relation
    /// </summary>
    public enum RelationType
    {
        FRIEND, FAMILY, BUSINESS
    }

    /// <summary>
    /// this is the structure of input
    /// </summary>
    public struct structure
    {
        public string name, phone, address;
        public RelationType relation;

    }
}