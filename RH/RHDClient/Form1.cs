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

      

        private void Login_Click(object sender, EventArgs e)
        {
            if (Program.docterClient.isConnected)
            {
                Program.docterClient.disconnect();
                LoggedInStatus.Text = "Not Logged In";
                    Login.Text = "Login";

                
            } else {
                String userName = nameBox.Text;
                String pasword = PaswordBox.Text;
                bool register = registerCheck.Checked;

                if (Program.docterClient.connect(userName, pasword, register)) //the true has to be the responce from the server
                {
                    LoggedInStatus.Text = $"Logged in as: {userName}";
                    Login.Text = "Logout";
                }
                else
                {
                    StatusStrip.Text = "Not Logged In";
                }
            }
                

            
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


        private void UserList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            updatePanel1();
        }

        private void NodeClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                ClientSelected.Text = $"Selected Client: {NameSelectionList.SelectedNode.Text}";
            }));

            //SpeedChart.Series["Speed"].BorderWidth = 5;
            //SpeedChart.Series["Speed"].Points.AddXY("", 90);
            
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (!Program.docterClient.isConnected)
                return;

                Program.docterClient.disconnect();
                StatusStrip.Text = "Not Logged In";
        }
    }
}
