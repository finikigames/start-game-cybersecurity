using System;
using System.Collections.Generic;

namespace Global.Flow {
    [Serializable]
    public class FlowStep {
        public string StepDescription;

        public bool MainSound;
        public string AudioId;
        public FlowData[] Data;
        public List<string> Condition;
    }
}