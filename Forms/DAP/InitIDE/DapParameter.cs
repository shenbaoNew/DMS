using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Forms.DAP.InitIDE {
    class DapParameter {
        public string Name { get; set; }
        public string Value { get; set; }

        public bool IsPlatform { get; set; }

        public string Pattern {
            get {
                return "(" + Name + "=.*?)\r\n";
            }
        }

        public override string ToString() {
            return Name + "=" + Value;
        }
    }
}
