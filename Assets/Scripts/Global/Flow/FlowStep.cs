using System;
using System.Collections.Generic;

namespace Global.Flow {
    [Serializable]
    public class FlowStep {
        public FlowData[] Data;
        public List<string> Condition;
    }
}