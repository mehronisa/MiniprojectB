using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "INSERT INTO Student (FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES('" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + txtContact.Text + "', '" + txtEmail.Text + "', '" + txtRegNumber.Text + "', '" + comboBox1.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Inserted Successfully!");
            //txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtRegNumber.Text = "";
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM Student";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
           // txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtRegNumber.Text = "";
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "UPDATE Student SET FirstName = '" + txtFirstName.Text + "', LastName = '" + txtLastName.Text + "', Contact = '" + txtContact.Text + "', Email = '" + txtEmail.Text + "', RegistrationNumber = '" + txtRegNumber.Text + "', Status = '" + comboBox1.Text + "' WHERE Id=" + id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Updated Successfully!");
            //txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtRegNumber.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*int selectrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);*/
            //txtId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtContact.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtRegNumber.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet5.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet5.Assessment);
            // TODO: This line of code loads data into the 'projectBDataSet4.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter1.Fill(this.projectBDataSet4.Rubric);
            // TODO: This line of code loads data into the 'projectBDataSet3.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet3.Rubric);
            // TODO: This line of code loads data into the 'projectBDataSet2.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet2.Clo);
            // TODO: This line of code loads data into the 'projectBDataSet1.RubricLevel' table. You can move, or remove it, as needed.
            this.rubricLevelTableAdapter.Fill(this.projectBDataSet1.RubricLevel);
            /*try
            {
                string combo = "SELECT LookupId FROM Lookup WHERE LookupId = 5 OR LookupId = 6";
                SqlDataAdapter da = new SqlDataAdapter(combo, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Lookup");
                comboBox1.DisplayMember = "LookupId";
                comboBox1.ValueMember = "LookupId";
                comboBox1.DataSource = ds.Tables["Lookup"];
                conn.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!");
            }*/
            /*SqlDataAdapter sda = new SqlDataAdapter("SELECT isnull(max(cast(Id as int)),0)+1 from Student", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtId.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = txtFirstName;*/
            //disp();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "DELETE FROM Student WHERE Id=" + id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Deleted!!");
            //txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtRegNumber.Text = "";
            comboBox1.Text = "";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            DateTime dc = DateTime.Now;
            string query = "INSERT INTO Clo(Name, DateCreated, DateUpdated) VALUES ('" + txtClo.Text + "', '" + dc + "', '" + dc + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("CLO's added!");
            txtClo.Text = "";
        }

        private void btnviewClo_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM Clo";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
            txtClo.Text = "";
        }

        private void btnupdClo_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "UPDATE Clo SET Name = '" + txtClo.Text + "' WHERE Id=" +id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Selected CLO updated successfully!");
            txtClo.Text = "";
        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtClo.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            //dateTimePicker1.Value.ToShortDateString() = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btndelClo_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "DELETE FROM Clo WHERE Id=" + id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Deleted!");
            txtClo.Text = "";
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            conn.Open();
            int Id = 0;
            string query1 = "SELECT count(*) FROM Rubric";
            SqlDataReader Reader;
           SqlCommand cmd = new SqlCommand(query1,conn);
           Reader = cmd.ExecuteReader();
            while(Reader.Read())     
            {
                Id = Convert.ToInt32(Reader[0]) + 1;
            }
            conn.Close();
            conn.Open();
            string query = "INSERT INTO Rubric (Id,Details, CloId) VALUES ('" + Id + "','" + richTextBox1.Text + "', '" + comboBox2.Text + "')";
            //string query1 = "INSERT INTO Rubric(Details, CloId)  SELECT Id, Name FROM Clo WHERE Id = CloId " VALUES ('" + richTextBox1.Text + "', '" + query + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Rubrics added!");
            richTextBox1.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM Rubric";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox1.Text = dataGridView3[1, e.RowIndex].Value.ToString();
            comboBox2.Text = dataGridView3[2, e.RowIndex].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            DateTime dc = DateTime.Now;
            string query = "INSERT INTO Assessment(Title, DateCreated, TotalMarks, TotalWeightage) VALUES ('" + textBox1.Text + "', '"+dc+"', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data added!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sc = new SqlCommand("Select Id, CloId from Rubric", conn);
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("CloId", typeof(string));
            dt.Load(reader);
            comboBox1.DisplayMember = "CloId";
            comboBox1.ValueMember = "Id"; comboBox1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            int Id = 0;
            string query1 = "SELECT count(*) FROM Rubric";
            SqlDataReader Reader;
            SqlCommand cmd = new SqlCommand(query1, conn);
            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Id = Convert.ToInt32(Reader[0]) + 1;
            }
            conn.Close();
            conn.Open();
            string query = "DELETE FROM Rubric WHERE Id = " +Id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Deleted!");
            comboBox2.Text = "";
            richTextBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView4.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "UPDATE Assessment SET Tiltle = '" + textBox1.Text + "', TotalMarks = '" + textBox2.Text + "', TotalWeightage = '" + textBox3.Text + "' WHERE Id = " + id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data updated successfully!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            int index = dataGridView3.CurrentCell.RowIndex;
            DataGridViewRow r = dataGridView3.Rows[index];
            int id = Convert.ToInt32(r.Cells[0].Value);
            string query = "UPDATE Rubric SET CloId = '"+comboBox2.Text+"', Details = '" + richTextBox1.Text + "' WHERE Id = " +id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data updated successfully!");
            comboBox2.Text = "";
            richTextBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView4.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "DELETE FROM Assessment WHERE Id=" + id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Deleted!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM Assessment";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView4.DataSource = dt;
            conn.Close();
        }

        /*private void dataGridView4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
            string jobId = selectedRow.Cells[0].Value.ToString();
         /*  textBox1.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
          /*  textBox2.Text = dataGridView4.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString();    } */

        private void button9_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "INSERT INTO RubricLevel(RubricId, Details, MeasurementLevel) VALUES ('"+comboBox3.Text+"', '"+textBox5.Text+"', '"+textBox6.Text+"')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data added!");
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView5.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView5.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "UPDATE RubricLevel SET RubricId = '"+comboBox3.Text+"', Details = '" + textBox5.Text + "', MeasurementLevel = '" + textBox6.Text + "' WHERE Id = " + id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data updated successfully!");
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView5.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView5.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "DELETE FROM RubricLevel WHERE Id=" + id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Deleted!");
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            comboBox3.Text = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();
            textBox5.Text = dataGridView5.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = dataGridView5.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            /*  textBox2.Text = dataGridView4.SelectedRows[0].Cells[3].Value.ToString();
              textBox3.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString(); */

        }

        private void dataGridView4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             /*textBox1.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
             textBox2.Text = dataGridView4.SelectedRows[0].Cells[3].Value.ToString();
             textBox3.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString();*/ 
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*richTextBox1.Text = dataGridView3[e ].Value.ToString();
            comboBox2.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();*/
        }

        private void button16_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM AssessmentComponent";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView6.DataSource = dt;
            conn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            /*conn.Open();
            string query = "INSERT INTO AssessmentComponent(Name, RubricId, TotalMarks, DateCreated, DateUpdated, AssessmentId) VALUES ('"+textBox4.Text+"', '"+comboBox4.Text+"', '"+textBox7.Text+"', convert(date, '"+dateTimePicker1+"'), convert(date, '"+dateTimePicker2+"'), '"+comboBox5.Text+"')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data added!");
            textBox4.Text = "";
            textBox7.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";*/
            conn.Open();
            DateTime dc = DateTime.Now;
            string query = "INSERT INTO AssessmentComponent(Name, RubricId, TotalMarks, DateCreated, DateUpdated, AssessmentId) VALUES ('"+textBox4.Text+"', '"+comboBox4.Text+"', '"+textBox7.Text+"', '"+dc+"', '"+dc+"', '"+comboBox5.Text+"')";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data added!");
            textBox4.Text = "";
            textBox7.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "SELECT * FROM RubricLevel";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView5.DataSource = dt;
            conn.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            /*conn.Open();
            int selectrowindex = dataGridView6.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView6.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "UPDATE AssessmentComponent SET Name = '" + textBox4.Text + "', RubricId = '" + comboBox4.Text + "', TotalMarks = '" + textBox7.Text + "', DateCreated = '" + dateTimePicker1 + "', DateUpdated = '" + dateTimePicker2 + "', AssessmentId = '"+comboBox5.Text+"' WHERE Id=" +id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data updated successfully!");
            textBox4.Text = "";
            textBox7.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";*/
            conn.Open();
            int selectrowindex = dataGridView6.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView6.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "UPDATE AssessmentComponent SET Name = '" + textBox4.Text + "', RubricId = '" + comboBox4.Text + "', TotalMarks = '" + textBox7.Text + "', AssessmentId = '"+comboBox5.Text+"' WHERE Id=" +id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data updated successfully!");
            textBox4.Text = "";
            textBox7.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            conn.Open();
            int selectrowindex = dataGridView6.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView6.Rows[selectrowindex];
            string id = Convert.ToString(selectedRow.Cells["Id"].Value);
            string query = "DELETE FROM AssessmentComponent WHERE Id="+id;
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            sda.SelectCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Deleted!");
            textBox4.Text = "";
            textBox7.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";
        }

        private void dataGridView6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = dataGridView6.SelectedRows[0].Cells[1].Value.ToString();
            comboBox4.Text = dataGridView6.SelectedRows[0].Cells[2].Value.ToString();
            textBox7.Text = dataGridView6.SelectedRows[0].Cells[3].Value.ToString();
            comboBox5.Text = dataGridView6.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtClo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView4[1, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView4[3, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridView4[4, e.RowIndex].Value.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand SqlCommand;
            SqlDataAdapter adapter = new SqlDataAdapter();
            //string showdata = "SELECT Clo.Name AS CLO ,Rubric.Details AS Rubric, AssessmentComponent.TotalMarks AS Component_Marks, RubricLevel.MeasurementLevel AS Student_Rubric_Level ,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) AS ObtainedMarks from (((Clo inner join Rubric on Clo.Id=Rubric.CloId) inner join AssessmentComponent on Rubric.Id=AssessmentComponent.RubricId)inner join RubricLevel on  Rubric.Id=RubricLevel.RubricId)"; 
            string showdata = "SELECT Assessment.Title, Student.RegistrationNumber as RegNo, AssessmentComponent.Name as Component, Rubric.Details as Rubric, AssessmentComponent.TotalMarks, RubricLevel.MeasurementLevel FROM Assessment INNER JOIN AssessmentComponent ON Assessment.Id = AssessmentComponent.AssessmentId INNER JOIN Rubric ON AssessmentComponent.RubricId = Rubric.Id INNER JOIN StudentResult ON AssessmentComponent.Id = StudentResult.AssessmentComponentId INNER JOIN RubricLevel ON StudentResult.RubricMeasurementId = RubricLevel.Id INNER JOIN Student ON Student.Id = StudentResult.StudentId";
            SqlCommand = new SqlCommand(showdata, conn);
            adapter.SelectCommand = new SqlCommand(showdata, conn);
            DataTable dbdataset = new DataTable();
            adapter.Fill(dbdataset);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbdataset;
            dataGridView7.DataSource = bsource;
            DataGridViewTextBoxColumn ObtainedMarks = new DataGridViewTextBoxColumn();
            ObtainedMarks.HeaderText = "ObtainedMarks";
            dataGridView7.Columns.Add(ObtainedMarks);
            /*string query = "SELECT Clo.Name AS CLO ,Rubric.Details AS Rubric, AssessmentComponent.TotalMarks AS Component_Marks, RubricLevel.MeasurementLevel AS Student_Rubric_Level ,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) AS ObtainedMarks from (((Clo inner join Rubric on Clo.Id=Rubric.CloId) inner join AssessmentComponent on Rubric.Id=AssessmentComponent.RubricId)inner join RubricLevel on  Rubric.Id=RubricLevel.RubricId)"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView7.DataSource = dt;
            conn.Close();*/
        }
    }
}
