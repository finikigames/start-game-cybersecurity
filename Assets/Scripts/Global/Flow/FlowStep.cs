using System;
using System.Collections.Generic;

namespace Global.Flow {
    [Serializable]
    public class FlowStep {
        public string StepDescription;

        public bool MainSound;
        public string AudioId;
        public bool NotLoop;
        public FlowData[] Data;
        public List<string> Condition;
    }
}