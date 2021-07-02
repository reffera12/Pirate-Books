﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PIrateBook
{
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO users.Table " +
                    "(first_name,surname,email,date_of_birth,country,user_id,password,confirm_password,account_status)" +
                    "values(@first_name,@surname,@email,@date_of_birth,@country,@user_id,@password,@confirm_password,@account_status)", con);
                cmd.Parameters.AddWithValue("@first_name", Name.Text.Trim());
                cmd.Parameters.AddWithValue("@surname", Surname.Text.Trim());
                cmd.Parameters.AddWithValue("@email", Email.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", DoB.Text.Trim());
                cmd.Parameters.AddWithValue("@country", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@user_id", Uname.Text.Trim());
                cmd.Parameters.AddWithValue("@confirm_password", Pswrd.Text.Trim());
                cmd.Parameters.AddWithValue("@password", CPswrd.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login and log :)');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}