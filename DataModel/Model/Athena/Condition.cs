using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.DataModel.Model.Athena {
    public class Condition {
        private const String L_BRACKET = "(";
        private const String R_BRACKET = ")";
        private const String PATTERN_S = " {0} {1} '{2}' ";
        private const String PATTERN_N = " {0} {1} {2} ";
        private const String L_LIKE = " {0} LIKE '%{1}' ";
        private const String R_LIKE = " {0} LIKE '{1}%' ";
        private const String LIKE = " {0} LIKE '%{1}%' ";
        private const String NOT_LIKE = " {0} NOT LIKE '%{1}%' ";
        private const String BETWEEN_S = " {0} BETWEEN '{1}' AND '{2}' ";
        private const String BETWEEN_N = " {0} BETWEEN {1} AND {2} ";
        private const String RANGE = " {0} ";

        [JsonProperty("order")]
        private double order;
        [JsonProperty("bracket")]
        private String bracket;
        [JsonProperty("logic")]
        private String logic;
        [JsonProperty("search_field")]
        private String searchField;
        [JsonProperty("search_operator")]
        private String searchOperator;
        [JsonProperty("search_value")]
        private List<object> searchValue;

        public string Bracket {
            get { return this.bracket == null ? "" : this.bracket; }
        }

        public string Logic {
            get { return this.logic == null ? " AND " : this.logic; }
        }

        public Condition() {

        }

        public double GetOrder() {
            return order;
        }

        public void SetOrder(int order) {
            this.order = order;
        }

        public String GetBracket() {
            return bracket;
        }

        public void SetBracket(String bracket) {
            this.bracket = bracket;
        }

        public String GetLogic() {
            return logic;
        }

        public void SetLogic(String logic) {
            this.logic = logic;
        }

        public String GetSearchField() {
            return searchField;
        }

        public void SetSearchField(String searchField) {
            this.searchField = searchField;
        }

        public String GetSearchOperator() {
            return searchOperator;
        }

        public void SetSearchOperator(String searchOperator) {
            this.searchOperator = searchOperator;
        }

        public Object GetSearchValue() {
            return searchValue;
        }

        public void SetSearchValue(List<object> searchValue) {
            this.searchValue = searchValue;
        }

        public override String ToString() {
            StringBuilder conditions = new StringBuilder();
            String condition = BuildCondition();
            //左括号添加在条件的左边
            if (this.Bracket.Contains(L_BRACKET)) {
                condition = this.bracket + " " + condition;
            }
            //右括号添加在条件的右边
            if (this.bracket.Contains(R_BRACKET)) {
                condition = condition + " " + this.bracket;
            }
            conditions.Append(condition);
            //追加逻辑运算符
            conditions.Append(" " + this.logic + " ");
            return conditions.ToString();
        }

        private bool IsNumber() {
            try {
                int number = (int)this.searchValue[0];
                return true;
            } catch {
                return false;
            }
        }

        private String BuildCondition() {
            if (this.searchValue == null || this.searchValue.Count <= 0) {
                throw new Exception("searchValue 不允许为空!");
            }
            String condition = "";
            OperatorEnum oper = (OperatorEnum)Enum.Parse(typeof(OperatorEnum), this.searchOperator);
            switch (oper) {
                case OperatorEnum.equal:
                case OperatorEnum.greater:
                case OperatorEnum.greater_equal:
                case OperatorEnum.less:
                case OperatorEnum.less_equal:
                case OperatorEnum.not_equal:
                    //组织条件
                    String pattern = IsNumber() ? PATTERN_N : PATTERN_S;
                    condition = String.Format(pattern, this.searchField, Operator.OperatorValue(oper), this.searchValue[0]);
                    break;
                case OperatorEnum.l_like:
                    condition = String.Format(L_LIKE, this.searchField, this.searchValue[0]);
                    break;
                case OperatorEnum.like_r:
                    condition = String.Format(R_LIKE, this.searchField, this.searchValue[0]);
                    break;
                case OperatorEnum.like:
                    condition = String.Format(LIKE, this.searchField, this.searchValue[0]);
                    break;
                case OperatorEnum.not_like:
                    condition = String.Format(NOT_LIKE, this.searchField, this.searchValue[0]);
                    break;
                case OperatorEnum.between:
                    pattern = IsNumber() ? BETWEEN_N : BETWEEN_S;
                    condition = String.Format(pattern, this.searchField, this.searchValue[0], this.searchValue[1]);
                    break;
                case OperatorEnum.exist:
                case OperatorEnum.not_exist:
                    condition = String.Format(RANGE, this.searchField) + RangeValue(oper);
                    break;
            }
            return condition;
        }

        private String RangeValue(OperatorEnum oper) {
            StringBuilder con = new StringBuilder();
            if (oper == OperatorEnum.exist) {
                con.Append(" IN ( ");
            } else {
                con.Append(" NOT IN ( ");
            }
            bool isNumber = IsNumber();
            bool first = true;
            foreach (Object value in this.searchValue) {
                Object tmpValue = isNumber ? value : "'" + value + "'";
                if (first) {
                    con.Append(tmpValue);
                    first = false;
                } else {
                    con.Append("," + tmpValue);
                }
            }
            con.Append(" ) ");
            return con.ToString();
        }
    }
    public class Parameter {
        [JsonProperty("search_info")]
        private List<Condition> conditions = null;

        public List<Condition> Conditions {
            get { return conditions; }
        }
    }
}
