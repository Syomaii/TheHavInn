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
    public partial class frmHavinnFloorC : Form
    {
        private OleDbConnection connection;
        public frmHavinnFloorC()
        {
            InitializeComponent();
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TheHavInn.accdb");
        }



        public void RoomFullColor()
        {
            btnC1.BackColor = Color.Red;
            btnC2.BackColor = Color.Red;
            btnC3.BackColor = Color.Red;
            btnC4.BackColor = Color.Red;
            btnC5.BackColor = Color.Red;
            btnC6.BackColor = Color.Red;
            btnC1.Enabled = false;
            btnC2.Enabled = false;
            btnC3.Enabled = false;
            btnC4.Enabled = false;
            btnC5.Enabled = false;
            btnC6.Enabled = false;
        }

        private void frmHavinnFloorC_Load(object sender, EventArgs e)
        {
            UpdateFormStatus();
        }
        private void UpdateFormStatus()
        {
            try
            {
                connection.Open();

                string floorQuery = "SELECT [FloorStatus] FROM [HavInnFloors] WHERE [FloorNumber] = 'C'";
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
                            SetButtonColor("C1", btnC1);
                            SetButtonColor("C2", btnC2);
                            SetButtonColor("C3", btnC3);
                            SetButtonColor("C4", btnC4);
                            SetButtonColor("C5", btnC5);
                            SetButtonColor("C6", btnC6);
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
            string roomQuery = "SELECT [RoomStatus_C] FROM HavinnRooms_C WHERE [RoomNumber_C] = ?";
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

        private void frmHavinnFloorC_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            this.Hide();
            frmDashboard.ShowDialog();
            this.Dispose();
        }

        private void btnC1_Click(object sender, EventArgs e)
        {
            VIPRoomC vipRoom = new VIPRoomC("C1");
            vipRoom.ShowDialog();
        }

        private void btnC2_Click(object sender, EventArgs e)
        {
            VIPRoomC vipRoom = new VIPRoomC("C2");
            vipRoom.ShowDialog();
        }

        private void btnC3_Click(object sender, EventArgs e)
        {
            VIPRoomC vipRoom = new VIPRoomC("C3");
            vipRoom.ShowDialog();
        }

        private void btnC4_Click(object sender, EventArgs e)
        {
            ClassicRoomC classicRoom = new ClassicRoomC("C4");
            classicRoom.ShowDialog();
        }

        private void btnC5_Click(object sender, EventArgs e)
        {
            ClassicRoomC classicRoom = new ClassicRoomC("C5");
            classicRoom.ShowDialog();
        }

        private void btnC6_Click(object sender, EventArgs e)
        {
            ClassicRoomC classicRoom = new ClassicRoomC("C6");
            classicRoom.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFormStatus();
        }
    }
}
