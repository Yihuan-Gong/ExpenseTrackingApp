using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 記帳
{
    internal class KeyValuePair
    {
        public String Key { get; set; }
        public String Value { get; set; }

        public KeyValuePair(string Key, string Value) { this.Key = Key; this.Value = Value; }
    }
}
