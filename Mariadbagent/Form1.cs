using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mariadbagent {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        string[] stockCodes = new string[] {
            "066303",
            "246246",
            "324986",
            "956798"
        };

        List<KshDb.ColumnInfo> stockColumnInfo = new List<KshDb.ColumnInfo> {
                new KshDb.ColumnInfo("date", KshDb.DataType.CHAR, 8, true),
                new KshDb.ColumnInfo("open", KshDb.DataType.MEDIUMINT),
                new KshDb.ColumnInfo("high", KshDb.DataType.MEDIUMINT),
                new KshDb.ColumnInfo("low", KshDb.DataType.MEDIUMINT),
                new KshDb.ColumnInfo("close", KshDb.DataType.MEDIUMINT),
                new KshDb.ColumnInfo("vol", KshDb.DataType.INT)
            };

        KshDb db;

        private void button1_Click(object sender, EventArgs e) {
            foreach (string code in stockCodes) {
                KshDb.TableInfo tInfo = new KshDb.TableInfo("A" + code);
                tInfo.columnList = stockColumnInfo;
                db.createTable(tInfo);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            db = new KshDb("test");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            db.destroy();
        }
    }
}
