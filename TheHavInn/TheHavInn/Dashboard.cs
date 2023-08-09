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
    public partial class frmDashboard : Form
    {
        private OleDbConnection connection;
        public frmDashboard()
        {
            InitializeComponent();
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TheHavInn.accdb");
        }

        private void pbSecondFloor_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string roomStatus = "SELECT [FloorStatus] FROM [HavInnFloors] WHERE [FloorNumber] = 'B'";
                OleDbCommand command = new OleDbCommand(roomStatus, connection);
                OleDbDataReader roomReader = command.ExecuteReader();
                if (roomReader.Read())
                {
                    string floorStatus = roomReader.GetString(0);
                    if (floorStatus.Equals("FULL", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This Floor's rooms are full, try another floor", "Floor is Full", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = " The VIP rooms in this floor are \n Room B1, B2, B3. \n\n Classic Rooms are \n Room B4, B5, B6";
                        DialogResult dr = MessageBox.Show(message + "\n\n Do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            frmHavinnFloorB floorB = new frmHavinnFloorB();
                            this.Hide();
                            floorB.ShowDialog();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        private void pbThirdFloor_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string roomStatus = "SELECT [FloorStatus] FROM [HavInnFloors] WHERE [FloorNumber] = 'C'";
                OleDbCommand command = new OleDbCommand(roomStatus, connection);
                OleDbDataReader roomReader = command.ExecuteReader();
                if (roomReader.Read())
                {
                    string floorStatus = roomReader.GetString(0);
                    if (floorStatus.Equals("FULL", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This Floor's rooms are full, try another floor", "Floor is Full", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = " The VIP rooms in this floor are \n Room C1, C2, C3. \n\n Classic Rooms are \n Room C4, C5, C6";
                        DialogResult dr = MessageBox.Show(message + "\n\n Do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            frmHavinnFloorC floorC = new frmHavinnFloorC();
                            this.Hide();
                            floorC.ShowDialog();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        private void pbFirstFloor_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string roomStatus = "SELECT [FloorStatus] FROM [HavInnFloors] WHERE [FloorNumber] ='A'";
                OleDbCommand command = new OleDbCommand(roomStatus,connection);
                OleDbDataReader roomReader = command.ExecuteReader();
                if (roomReader.Read())
                {
                    string floorStatus = roomReader.GetString(0);
                    if (floorStatus.Equals("FULL", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This Floor's rooms are full, try another floor", "Floor is Full", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = " The VIP rooms in this floor are \n Room A1, A2, A3. \n\n Classic Rooms are \n Room A4, A5, A6";
                        DialogResult dr = MessageBox.Show(message + "\n\n Do you wish to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            frmHavinnFloorA floorA = new frmHavinnFloorA();
                            this.Hide();
                            floorA.ShowDialog();
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        
    }
}
