namespace DMS.DataModel.Model.Athena {
    public class Operator {
        public const string equal = "=";
        public const string greater = ">";
        public const string greater_equal = ">=";
        public const string l_like = "";
        public const string like = "";
        public const string less = "<";
        public const string less_equal = "<=";
        public const string like_r = "";
        public const string not_like = "";
        public const string not_equal = "<>";
        public const string between = "";
        public const string exist = "";
        public const string not_exist = "";

        public static string OperatorValue(OperatorEnum operValue) {
            switch (operValue) {
                case OperatorEnum.equal:
                    return equal;
                case OperatorEnum.greater:
                    return greater;
                case OperatorEnum.greater_equal:
                    return greater_equal;
                case OperatorEnum.less:
                    return less;
                case OperatorEnum.less_equal:
                    return less_equal;
                case OperatorEnum.not_equal:
                    return not_equal;
            }
            return "";
        }
    }

    public enum OperatorEnum {
        equal,
        greater,
        greater_equal,
        l_like,
        like,
        less,
        less_equal,
        like_r,
        not_like,
        not_equal,
        between,
        exist,
        not_exist
    }
}