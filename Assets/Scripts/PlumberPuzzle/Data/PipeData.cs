using System.Collections.Generic;
using PlumberPuzzle.Config;

namespace PlumberPuzzle.Data {
    public class PipeData {
        public List<int> ConnectedCells = new();
        public PipeType ConnectionType;
        public PipeRotationType Rotation;
    }
}