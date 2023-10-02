using System.Collections.Generic;
using PlumberPuzzle.Config;

namespace PlumberPuzzle.Data {
    public class PipeData {
        public HashSet<int> ConnectedCells = new();
        public PipeType ConnectionType;
        public PipeRotationType Rotation;
    }
}