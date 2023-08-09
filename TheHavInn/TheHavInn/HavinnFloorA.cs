using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace TheHavInn
{
    public partial class frmHavinnFloorA : Form
    {
        private OleDbConnection connection;

        public frmHavinnFloorA()
        {
            InitializeComponent();
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TheHavInn.accdb");
        }

        public void RoomFullColor()
        {
            btnA1.BackColor = Color.Red;
            btnA2.BackColor = Color.Red;
            btnA3.BackColor = Color.Red;
            btnA4.BackColor = Color.Red;
            btnA5.BackColor = Color.Red;
            btnA6.BackColor = Color.Red;
            btnA1.Enabled = false;
            btnA2.Enabled = false;
            btnA3.Enabled = false;
            btnA4.Enabled = false;
            btnA5.Enabled = false;
            btnA6.Enabled = false;
        }

        public void frmHavinnFloorA_Load(object sender, EventArgs e)
        {
            UpdateFormStatus();
        }

        
        private void UpdateFormStatus()
        {
            try
            {
                connection.Open();

                string floorQuery = "SELECT [FloorStatus] FROM [HavInnFloors] WHERE [FloorNumber] = 'A'";
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
                            SetButtonColor("A1", btnA1);
                            SetButtonColor("A2", btnA2);
                            SetButtonColor("A3", btnA3);
                            SetButtonColor("A4", btnA4);
                            SetButtonColor("A5", btnA5);
                            SetButtonColor("A6", btnA6);
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
            string roomQuery = "SELECT [RoomStatus_A] FROM HavinnRooms_A WHERE [RoomNumber_A] = ?";
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

        
        

        private void frmHavinnFloorA_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDashboard frmDashboard = new frmDashboard();
            this.Hide();
            frmDashboard.ShowDialog();
            this.Dispose();
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            VIPRoom vipRoom = new VIPRoom("A1");
            vipRoom.ShowDialog();
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            VIPRoom vipRoom = new VIPRoom("A2");
            vipRoom.ShowDialog();
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            VIPRoom vipRoom = new VIPRoom("A3");
            vipRoom.ShowDialog();
        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            ClassicRoom classicRoom = new ClassicRoom("A4");
            classicRoom.ShowDialog();
        }

        private void btnA5_Click(object sender, EventArgs e)
        {
            ClassicRoom classicRoom = new ClassicRoom("A5");
            classicRoom.ShowDialog();
        }

        private void btnA6_Click(object sender, EventArgs e)
        {
            ClassicRoom classicRoom = new ClassicRoom("A6");
            classicRoom.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFormStatus();
        }
    }
}
