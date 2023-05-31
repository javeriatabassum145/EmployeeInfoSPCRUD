using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data; 

namespace WebApplication
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        //Connection String
        string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewBind();
            }
        }

        //Create Operation
        protected void CreateNewEmployee(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertEmployeeSP", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", empName.Text);
                    cmd.Parameters.AddWithValue("@Age", empAge.Text);
                    cmd.Parameters.AddWithValue("@Gender", empGender.Text);

                    connection.Open();
                    int status = cmd.ExecuteNonQuery();

                    if (status != 0)
                    {
                        Label1.Text = "Record Inserted Succesfully into the Database";
                        Label1.ForeColor = System.Drawing.Color.CornflowerBlue;
                    }
                }
                GridViewBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong." + ex);
            }

        }

        /*
         //Read Operation
        protected void ReadEmployees(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                string query = "select * from [AdoNetDb].[dbo].[Employee]";
                SqlCommand sc = new SqlCommand(query, connection);
                // Opening connection  
                connection.Open();
                SqlDataReader reader = sc.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong." + ex);
            }
            finally
            {
                connection.Close();
            }
        }*/

        protected void GridViewBind()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetEmployeeSP", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }

                /*  else
                  {
                      ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                      GridView1.DataSource = ds;
                      GridView1.DataBind();
                      int columncount = GridView1.Rows[0].Cells.Count;
                      GridView1.Rows[0].Cells.Clear();
                      GridView1.Rows[0].Cells.Add(new TableCell());
                      GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                      GridView1.Rows[0].Cells[0].Text = "No Records Found";
                  }*/
            }
        }  

        // Update Operation
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridViewBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;

                int userid = Convert.ToInt32(id.Text);
                TextBox Name = GridView1.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
                TextBox Age = GridView1.Rows[e.RowIndex].FindControl("txt_Age") as TextBox;
                TextBox Gender = GridView1.Rows[e.RowIndex].FindControl("txt_Gender") as TextBox;

                String NameEmp = Name.Text;
                int AgeEmp = Convert.ToInt32(Age.Text);
                String GenderEmp = Gender.Text;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateEmployeeSP", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", userid);
                    cmd.Parameters.AddWithValue("@Name", NameEmp);
                    cmd.Parameters.AddWithValue("@Age", AgeEmp);
                    cmd.Parameters.AddWithValue("@Gender", GenderEmp);

                    connection.Open();
                    int status = cmd.ExecuteNonQuery();

                    if (status != 0)
                    {
                        Label1.Text = "Record Updated Succesfully";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                }
                GridView1.EditIndex = -1;
                GridViewBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong." + ex);
            }
        }
        
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridViewBind();
        }  

        //Delete Operation
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteEmployeeSP", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", userid);
                    connection.Open();
                    int status = cmd.ExecuteNonQuery();
                    if (status != 0)
                    {
                        Label1.Text = "Record Deleted Succesfully";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                GridViewBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong." + ex);
            }
        }
    }
}