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
    public partial class VIPRoom : Form
    {
        private OleDbConnection connection;
        private string roomNumber;

        public VIPRoom(string roomNumber)
        {
            InitializeComponent();
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TheHavInn.accdb");
            this.roomNumber = roomNumber;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            string selectedDuration = "3 hours"; // Modify this based on the selected duration in your form
            string updatePaymentQuery = "UPDATE [VIPRoomRates] SET [ThreeHours] = [ThreeHours] + ? WHERE EXISTS(SELECT 1 FROM [VIPRoomRates])";
            string updateStatusQuery = "UPDATE [HavinnRooms_A] SET [RoomStatus_A] = 'OCCUPIED' WHERE [RoomNumber_A] = ?";

            try
            {
                connection.Open();

                // Update the record with the additional value
                OleDbCommand updatePaymentCommand = new OleDbCommand(updatePaymentQuery, connection);
                updatePaymentCommand.Parameters.AddWithValue("@AdditionalValue", 550.00); // Add the desired value to the existing value
                updatePaymentCommand.ExecuteNonQuery();

                OleDbCommand updateStatusCommand = new OleDbCommand(updateStatusQuery, connection);
                updateStatusCommand.Parameters.AddWithValue("@RoomNumber", roomNumber); // Update the parameter with the room number
                updateStatusCommand.ExecuteNonQuery();


                MessageBox.Show("This room is now rented, \nplease go to the counter");
                
                this.DialogResult = DialogResult.OK; // Set the dialog result to OK

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        
        private void btn7_Click(object sender, EventArgs e)
        {
            string updatePaymentQuery = "UPDATE [VIPRoomRates] SET [SevenHours] = [SevenHours] + ? WHERE EXISTS(SELECT 1 FROM [VIPRoomRates])";
            string updateStatusQuery = "UPDATE [HavinnRooms_A] SET [RoomStatus_A] = 'OCCUPIED' WHERE [RoomNumber_A] = ?";

            try
            {
                connection.Open();

                // Update the record with the additional value
                OleDbCommand updatePaymentCommand = new OleDbCommand(updatePaymentQuery, connection);
                updatePaymentCommand.Parameters.AddWithValue("@AdditionalValue", 1000.00); // Add the desired value to the existing value
                updatePaymentCommand.ExecuteNonQuery();

                OleDbCommand updateStatusCommand = new OleDbCommand(updateStatusQuery, connection);
                updateStatusCommand.Parameters.AddWithValue("@RoomNumber", roomNumber); // Update the parameter with the room number
                updateStatusCommand.ExecuteNonQuery();


                MessageBox.Show("This room is now rented by you, \nplease go to the counter");

                this.DialogResult = DialogResult.OK; // Set the dialog result to OK

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        private void btn24_Click(object sender, EventArgs e)
        {
            string updatePaymentQuery = "UPDATE [VIPRoomRates] SET [TwentyFourHours] = [TwentyFourHours] + ? WHERE EXISTS(SELECT 1 FROM [VIPRoomRates])";
            string updateStatusQuery = "UPDATE [HavinnRooms_A] SET [RoomStatus_A] = 'OCCUPIED' WHERE [RoomNumber_A] = ?";

            try
            {
                connection.Open();

                // Update the record with the additional value
                OleDbCommand updatePaymentCommand = new OleDbCommand(updatePaymentQuery, connection);
                updatePaymentCommand.Parameters.AddWithValue("@AdditionalValue", 2250.00); // Add the desired value to the existing value
                updatePaymentCommand.ExecuteNonQuery();

                OleDbCommand updateStatusCommand = new OleDbCommand(updateStatusQuery, connection);
                updateStatusCommand.Parameters.AddWithValue("@RoomNumber", roomNumber); // Update the parameter with the room number
                updateStatusCommand.ExecuteNonQuery();


                MessageBox.Show("This room is now rented by you, \nplease go to the counter");

                this.DialogResult = DialogResult.OK; // Set the dialog result to OK

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void VIPRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                // Close the current form if the OK button is clicked
                this.Dispose();
                this.Close();
            }
            else
            {
                // Show the frmDashboard form
                frmDashboard frmDashboard = new frmDashboard();
                this.Hide();
                frmDashboard.ShowDialog();
                this.Dispose();
            }
        }
    }
}
