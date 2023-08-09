using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHavInn
{
    public partial class frmHavinnFloorB : Form
    {
        private OleDbConnection connection;
        public frmHavinnFloorB()
        {
            InitializeComponent();
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TheHavInn.accdb");

        }

        public void RoomFullColor()
        {
            btnB1.BackColor = Color.Red;
            btnB2.BackColor = Color.Red;
            btnB3.BackColor = Color.Red;
            btnB4.BackColor = Color.Red;
            btnB5.BackColor = Color.Red;
            btnB6.BackColor = Color.Red;
            btnB1.Enabled = false;
            btnB2.Enabled = false;
            btnB3.Enabled = false;
            btnB4.Enabled = false;
            btnB5.Enabled = false;
            btnB6.Enabled = false;
        }
        private void frmHavinnFloorB_Load(object sender, EventArgs e)
        {
            UpdateFormStatus();
        }

        private void UpdateFormStatus()
        {
            try
            {
                connection.Open();

                string floorQuery = "SELECT [FloorStatus] FROM [HavInnFloors] WHERE [FloorNumber] = 'B'";
                OleDbCommand floorCommand = new OleDbCommand(floorQuery, connection);

                using (OleDbDataReader floorReader = floorCommand.ExecuteReader())
                {
                    if (floorReader.Read())
                    {
                        string floorStatus = floorReader.GetString(0);

                        if (floorStatus.Equals("FULL", StringComparison.OrdinalIgnoreCase))
                        {
                            RoomFullColor();
                        }
                        else if (floorStatus.Equals("VACANT", StringComparison.OrdinalIgnoreCase))
                        {
                            SetButtonColor("B1", btnB1);
                            SetButtonColor("B2", btnB2);
                            SetButtonColor("B3", btnB3);
                            SetButtonColor("B4", btnB4);
                            SetButtonColor("B5", btnB5);
                            SetButtonColor("B6", btnB6);
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is an error fetching data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SetButtonColor(string roomNumber, Button button)
        {
            string roomQuery = "SELECT [RoomStatus_B] FROM HavinnRooms_B WHERE [RoomNumber_B] = ?";
            OleDbCommand roomCommand = new OleDbCommand(roomQuery, connection);
            roomCommand.Parameters.AddWithValue("?", roomNumber);

            using (OleDbDataReader roomReader = roomCommand.ExecuteReader())
            {
                if (roomReader.Read())
                {
                    string roomStatus = roomReader.GetString(0);
                    if (roomStatus.Equals("VACANT", StringComparison.OrdinalIgnoreCase))
                    {
                        button.BackColor = Color.Green;
                        button.Enabled = true;
                    }
                    else
                    {
                        button.BackColor = Color.Red;
                        button.Enabled = false;
                    }
                }
            }
        }

        private void frmHavinnFloorB_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            this.Hide();
            frmDashboard.ShowDialog();
            this.Dispose();
        }

        private void btnB5_Click(object sender, EventArgs e)
        {
            ClassicRoomB classicRoom = new ClassicRoomB("B5");
            classicRoom.ShowDialog();
        }

        private void btnB2_Click(object sender, EventArgs e)
        {
            VIPRoomB vipRoom = new VIPRoomB("B2");
            vipRoom.ShowDialog();
        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            VIPRoomB vipRoom = new VIPRoomB("B3");
            vipRoom.ShowDialog();
        }

        private void btnB4_Click(object sender, EventArgs e)
        {
            ClassicRoomB classicRoom = new ClassicRoomB("B4");
            classicRoom.ShowDialog();
        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            VIPRoomB vipRoom = new VIPRoomB("B1");
            vipRoom.ShowDialog();
        }

        private void btnB6_Click(object sender, EventArgs e)
        {
            ClassicRoomB classicRoom = new ClassicRoomB("B6");
            classicRoom.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFormStatus();
        }
    }
}
