using System;

namespace PlumberPuzzle.Config {
    [Serializable]
    public enum PipeType {
        None = 0,
        Line = 1,
        Triple = 2,
        Angle = 3,
        Intersection = 4
    }
}