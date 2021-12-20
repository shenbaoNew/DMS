using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace DMS.Forms
{
    public partial class frmParityCode : DMS.Forms.BaseQueryForm
    {
        private BindingSource bin;

        public frmParityCode()
        {
            InitializeComponent();

            bin = new BindingSource();
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToFilter = true;
            this.dataGridViewX1.AllowUserToGroup = true;
            Type dgvType = this.dataGridViewX1.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dataGridViewX1, true, null);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("CCode",typeof(string)),
                new DataColumn("CName",typeof(string)),
                new DataColumn("CMemo",typeof(string))});

            DataRow dr = dt.NewRow();
            dr["CCode"] = "101";
            dr["CName"] = "张三";
            dr["CMemo"] = "11";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["CCode"] = "102";
            dr["CName"] = "李四";
            dr["CMemo"] = "11";
            dt.Rows.Add(dr);

            bin.DataSource = dt;
            this.dataGridViewX1.DataSource = dt;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim().Length != 17)
            {
                txtResult.Text = "输入必须为17位";
                txtParityCode.Text = "";
            }
            else
            {
                txtParityCode.Text = ParityCode(txtBarcode.Text.Trim());
                txtResult.Text = txtBarcode.Text.Trim() + txtParityCode.Text;
            }
        }

        public string ParityCode(string inputData)
        {
            try
            {
                int sum_even = 0;//偶数位之和
                int sum_odd = 0;//奇数位之和
                for (int i = 0; i < inputData.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum_odd += int.Parse(inputData[i].ToString());
                    }
                    else
                    {
                        sum_even += int.Parse(inputData[i].ToString());
                    }
                }
                int checkcode = (10 - (sum_even * 3 + sum_odd) % 10) % 10;//校验码
                return checkcode.ToString();
            }
            catch
            {
                return "出现错误";
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGet_Click(sender, e);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            /*
            string str = string.Empty;
            for (int i = 0; i < "孟_晓.阳-光".Length; i++)
            {
                str += this.GetOneIndex("孟_晓.阳-光".Substring(i, 1));
            }
            */
        }

        private string GetOneIndex(string OneIndexTxt)
        {
            if ((Convert.ToChar(OneIndexTxt) >= '\0') && (Convert.ToChar(OneIndexTxt) < 'Ā'))
            {
                return OneIndexTxt;
            }
            Encoding dstEncoding = Encoding.GetEncoding("gb2312");
            byte[] bytes = Encoding.Unicode.GetBytes(OneIndexTxt);
            byte[] buffer2 = Encoding.Convert(Encoding.Unicode, dstEncoding, bytes);
            string str = string.Format("{0:D2}", Convert.ToInt16(buffer2[0]) - 160);
            string str2 = string.Format("{0:D2}", Convert.ToInt16(buffer2[1]) - 160);
            str = str.Replace("-", "");
            str2 = str2.Replace("-", "");
            return this.GetX(Convert.ToInt32(str + str2));
        }

        private string GetX(int GBCode)
        {
            if ((GBCode >= 0x641) && (GBCode < 0x665))
            {
                return "A";
            }
            if ((GBCode >= 0x665) && (GBCode < 0x729))
            {
                return "B";
            }
            if ((GBCode >= 0x729) && (GBCode < 0x81e))
            {
                return "C";
            }
            if ((GBCode >= 0x81e) && (GBCode < 0x8e2))
            {
                return "D";
            }
            if ((GBCode >= 0x8e2) && (GBCode < 0x8fe))
            {
                return "E";
            }
            if ((GBCode >= 0x8fe) && (GBCode < 0x981))
            {
                return "F";
            }
            if ((GBCode >= 0x981) && (GBCode < 0xa22))
            {
                return "G";
            }
            if ((GBCode >= 0xa22) && (GBCode < 0xae3))
            {
                return "H";
            }
            if ((GBCode >= 0xae3) && (GBCode < 0xc22))
            {
                return "J";
            }
            if ((GBCode >= 0xc22) && (GBCode < 0xc8c))
            {
                return "K";
            }
            if ((GBCode >= 0xc8c) && (GBCode < 0xd90))
            {
                return "L";
            }
            if ((GBCode >= 0xd90) && (GBCode < 0xe33))
            {
                return "M";
            }
            if ((GBCode >= 0xe33) && (GBCode < 0xe8a))
            {
                return "N";
            }
            if ((GBCode >= 0xe8a) && (GBCode < 0xe92))
            {
                return "O";
            }
            if ((GBCode >= 0xe92) && (GBCode < 0xf12))
            {
                return "P";
            }
            if ((GBCode >= 0xf12) && (GBCode < 0xfbb))
            {
                return "Q";
            }
            if ((GBCode >= 0xfbb) && (GBCode < 0xff6))
            {
                return "R";
            }
            if ((GBCode >= 0xff6) && (GBCode < 0x1126))
            {
                return "S";
            }
            if ((GBCode >= 0x1126) && (GBCode < 0x11ce))
            {
                return "T";
            }
            if ((GBCode >= 0x11ce) && (GBCode < 0x124c))
            {
                return "W";
            }
            if ((GBCode >= 0x124c) && (GBCode < 0x133d))
            {
                return "X";
            }
            if ((GBCode >= 0x133d) && (GBCode < 0x1481))
            {
                return "Y";
            }
            if ((GBCode >= 0x1481) && (GBCode <= 0x15d5))
            {
                return "Z";
            }
            if ((GBCode >= 0x15e1) && (GBCode <= 0x225a))
            {
                string str = "cjwgnspgcenegypbtwxzdxykygtpjnmjqmbsgzscyjsyyfpggbzgydywjkgaljswkbjqhyjwpdzlsgmrybywwccgznkydgttngjeyekzydcjnmcylqlypyqbqrpzslwbdgkjfyxjwcltbncxjjjjcxdtqsqzycdxxhgckbphffsspybgmxjbbyglbhlssmzmpjhsojnghdzcdklgjhsgqzhxqgkezzwymcscjnyetxadzpmdssmzjjqjyzcjjfwqjbdzbjgdnzcbwhgxhqkmwfbpbqdtjjzkqhylcgxfptyjyyzpsjlfchmqshgmmxsxjpkdcmbbqbefsjwhwwgckpylqbgldlcctnmaeddksjngkcsgxlhzaybdbtsdkdylhgymylcxpycjndqjwxqxfyyfjlejbzrwccqhqcsbzkymgplbmcrqcflnymyqmsqtrbcjthztqfrxchxmcjcjlxqgjmshzkbswxemdlckfsydsglycjjssjnqbjctyhbftdcyjdgwyghqfrxwckqkxebpdjpxjqsrmebwgjlbjslyysmdxlclqkxlhtjrjjmbjhxhwywcbhtrxxglhjhfbmgykldyxzpplggpmtcbbajjzyljtyanjgbjflqgdzyqcaxbkclecjsznslyzhlxlzcghbxzhznytdsbcjkdlzayffydlabbgqszkggldndnyskjshdlxxbcghxyggdjmmzngmmccgwzszxsjbznmlzdthcqydbdllscddnlkjyhjsycjlkohqasdhnhcsgaehdaashtcplcpqybsdmpjlpcjaqlcdhjjasprchngjnlhlyyqyhwzpnccgwwmzffjqqqqxxaclbhkdjxdgmmydjxzllsygxgkjrywzwyclzmcsjzldbndcfcxyhlschycjqppqagmnyxpfrkssbjlyxyjjglnscmhcwwmnzjjlhmhchsyppttxrycsxbyhcsmxjsxnbwgpxxtaybgajcxlypdccwqocwkccsbnhcpdyznbcyytyckskybsqkkytqqxfcwchcwkelcqbsqyjqcclmthsywhmktlkjlychwheqjhtjhppqpqscfymmcmgbmhglgsllysdllljpchmjhwljcyhzjxhdxjlhxrswlwzjcbxmhzqxsdzpmgfcsglsdymjshxpjxomyqknmyblrthbcftpmgyxlchlhlzylxgsssscclsldclepbhshxyyfhbmgdfycnjqwlqhjjcywjztejjdhfblqxtqkwhdchqxagtlxljxmsljhdzkzjecxjcjnmbbjcsfywkbjzghysdcpqyrsljpclpwxsdwejbjcbcnaytmgmbapclyqbclzxcbnmsggfnzjjbzsfqyndxhpcqkzczwalsbccjxpozgwkybsgxfcfcdkhjbstlqfsgdslqwzkxtmhsbgzhjcrglyjbpmljsxlcjqqhzmjczydjwbmjklddpmjegxyhylxhlqyqhkycwcjmyhxnatjhyccxzpcqlbzwwwtwbqcmlbmynjcccxbbsnzzljpljxyztzlgcldcklyrzzgqtgjhhgjljaxfgfjzslcfdqzlclgjdjcsnclljpjqdcclcjxmyzftsxgcgsbrzxjqqcczhgyjdjqqlzxjyldlbcyamcstylbdjbyregklzdzhldszchznwczcllwjqjjjkdgjcolbbzppglghtgzcygezmycnqcycyhbhgxkamtxyxnbskyzzgjzlqjdfcjxdygjqjjpmgwgjjjpkjsbgbmmcjssclpqpdxcdyykypcjddyygywchjrtgcnyqldkljczzgzccjgdyksgpzmdlcphnjafyzdjcnmwescsglbtzcgmsdllyxqsxsbljsbbsgghfjlwpmzjnlyywdqshzxtyywhmcyhywdbxbtlmswyyfsbjcbdxxlhjhfpsxzqhfzmqcztqcxzxrdkdjhnnyzqqfnqdmmgnydxmjgdhcdycbffallztdltfkmxqzdngeqdbdczjdxbzgsqqddjcmbkxffxmkdmcsychzcmljdjynhprsjmkmpcklgdbqtfzswtfgglyplljzhgjjgypzltcsmcnbtjbhfkdhbyzgkpbbymtdlsxsbnpdkleycjnycdykzddhqgsdzsctarlltkzlgecllkjljjaqnbdggghfjtzqjsecshalqfmmgjnlyjbbtmlycxdcjpldlpcqdhsycbzsckbzmsljflhrbjsnbrgjhxpdgdjybzgdlgcsezgxlblgyxtwmabchecmwyjyzlljjshlgndjlslygkdzpzxjyyzlpcxszfgwyydlyhcljscmbjhblyjlycblydpdqysxktbytdkdxjypcnrjmfdjgklccjbctbjddbblblcdqrppxjcglzcshltoljnmdddlngkaqakgjgyhheznmshrphqqjchgmfprxcjgdychghlyrzqlcngjnzsqdkqjymszswlcfqjqxgbggxmdjwlmcrnfkkfsyyljbmqammmycctbshcptxxzzsmphfshmclmldjfyqxsdyjdjjzzhqpdszglssjbckbxyqzjsgpsxjzqznqtbdkwxjkhhgflbcsmdldgdzdblzkycqnncsybzbfglzzxswmsccmqnjqsbdqsjtxxmbldxcclzshzcxrqjgjylxzfjphymzqqydfqjjlcznzjcdgzygcdxmzysctlkphtxhtlbjxjlxscdqccbbqjfqzfsltjbtkqbsxjjljchczdbzjdczjccprnlqcgpfczlclcxzdmxmphgsgzgszzqjxlwtjpfsyaslcjbtckwcwmytcsjjljcqlwzmalbxyfbpnlschtgjwejjxxglljstgshjqlzfkcgnndszfdeqfhbsaqdgylbxmmygszldydjmjjrgbjgkgdhgkblgkbdmbylxwcxyttybkmrjjzxqjbhlmhmjjzmqasldcyxyqdlqcafywyxqhz";
                string str2 = GBCode.ToString();
                int num = ((Convert.ToInt16(str2.Substring(0, 2)) - 0x38) * 0x5e) + Convert.ToInt16(str2.Substring(str2.Length - 2, 2));
                return str.Substring(num - 1, 1);
            }
            return "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.dataGridViewX1.ShowGroupDialog();
            this.dataGridViewX1.ShowFilterDialog();
        }

    }
}
