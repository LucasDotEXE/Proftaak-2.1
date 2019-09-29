using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace DocterAplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PaswordBox.PasswordChar = '*';
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            String name = nameBox.Text;
            String pasword = PaswordBox.Text;
            //Program.docterClient.sendLoginRequest($"L{name}|{pasword}");
            if (true)
            {
                Program.docterClient.isConnected = true;
                LoggedInStatus.Text = $"Logged in as: {name}";
            } else
            {
                Program.docterClient.isConnected = false;
                StatusStrip.Text = "Logged out";
            }
            Console.WriteLine("stuff");
        }

        private void StatuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshPage();
            FillTest();
        }

        private void FillTest()
        {
            for (int i = 0; i < 100; i++)
            {
                UserList.Items.Add($"Client {i+1}");
            }
        }

        private void updatePanel1()
        {
            this.BeginInvoke(new Action(() => {
                NameSelectionList.Nodes.Clear();
                CheckedItemCollection list = UserList.CheckedItems;
                foreach (string item in list)
                {
                    NameSelectionList.Nodes.Add(item);
                }
                NameSelectionList.TreeViewNodeSorter = new NodeSorter();
                NameSelectionList.Sort();
            }));
        }

        private void RefreshPage()
        {
            
        }

        private void UserList_ItemCheck(object sender, EventArgs e)
        {
            updatePanel1();
        }

        private void UserList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            updatePanel1();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void SpeedChart_Click(object sender, EventArgs e)
        {

        }

        private void NodeClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                ClientSelected.Text = $"Selected Client: {NameSelectionList.SelectedNode.Text}";
            }));

            SpeedChart.Series["Speed"].BorderWidth = 5;
            SpeedChart.Series["Speed"].Points.AddXY("", 90);
            
        }
    }
}
