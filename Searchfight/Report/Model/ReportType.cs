namespace Searchfight {
    class ReportType<T> {
        public ReportType(T value) {
            Value = value;
        }
        public T Value { get; }

        public override string ToString() {
            return Value.ToString();
        }
    }
}