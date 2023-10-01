namespace Global.Flow.Condition {
    public abstract class BaseCondition {
        public bool Ready { get; set; }
        
        public abstract void Check();
    }
}