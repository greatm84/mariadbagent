using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariadbagent {
    class KshDb {
        public enum DataType {
            INT = 0,
            MEDIUMINT,
            FLOAT,
            CHAR,
            TEXT,
        };

        public class ColumnInfo {
            public bool primaryKey = false;
            public DataType dataType;
            public string columnName;
            public int param;
            public ColumnInfo(string columnName, DataType dataType, int param = -1, bool primaryKey = false) {
                this.columnName = columnName;
                this.dataType = dataType;
                this.primaryKey = primaryKey;
                this.param = param;
            }
        }

        public class TableInfo {
            public string tableName;
            public List<ColumnInfo> columnList = new List<ColumnInfo>();

            public TableInfo(string tableName) {
                this.tableName = tableName;
            }
        }

        private MySqlConnection conn = null;

        public KshDb(string databaseFullPath) {
            conn = new MySqlConnection("Server = localhost; Port = 3306; Database = "+ databaseFullPath +"; Uid = root; Pwd = 1234;");
            conn.Open();
        }

        public void createTable(TableInfo tableInfo) {
            if (tableInfo.tableName == null || tableInfo.tableName.Length == 0 || tableInfo.columnList.Count == 0) {
                throw new ArgumentException("not enough tableInfo");
            }
            string sql = "create table if not exists " + tableInfo.tableName + " (";
            foreach (ColumnInfo info in tableInfo.columnList) {                
                sql += info.columnName + " " + info.dataType.ToString();

                if(info.param != -1) {
                    sql += "(" + info.param + ")";
                }

                if (info.primaryKey) {
                    sql += " primary key";
                }
                sql += ",";
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            new MySqlCommand(sql, conn).ExecuteNonQuery();
        }

        public void destroy() {
            conn.Close();
        }
    }
}
