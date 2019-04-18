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

        List<KshDb.ColumnInfo> stockInfoColumnInfoList = new List<KshDb.ColumnInfo> {
            new KshDb.ColumnInfo("quater", KshDb.DataType.CHAR, 7, true),
            new KshDb.ColumnInfo("mechul", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("bspr", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("bspro", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("tbbpro", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("quaterpro", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("quaterprom", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("quaterpronm", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("quaterpro", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("blcto", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("minusto", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("moneyto", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("moneytom", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("moneytonm", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("seedmoney", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("busmflow", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("inveflow", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("jaemooflow", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("CAPEX", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("FCF", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("libminus", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("bsprpct", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("realprpct", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("roe", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("roa", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("minuspct", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("capretratio", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("eps", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("per", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("bps", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("pbr", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("dps", KshDb.DataType.CHAR, 15),
            new KshDb.ColumnInfo("cashbpropct", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("paybackpct", KshDb.DataType.CHAR, 10),
            new KshDb.ColumnInfo("stockcount", KshDb.DataType.CHAR, 15)
        };

        KshDb db;

        private void button1_Click(object sender, EventArgs e) {
            foreach (string code in stockCodes) {
                KshDb.TableInfo tInfo = new KshDb.TableInfo("A" + code) {
                    columnList = stockColumnInfo
                };
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
