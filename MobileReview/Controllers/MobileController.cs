using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileReview.Models;

namespace MobileReview.Controllers
{
    public class MobileController : Controller
    {
        string connectionstring = @"Data source=LAPTOP-1GLCSSF5\SAMANWAYSQL; Initial Catalog=MobileReview; Integrated Security=True";
        // GET: Mobile
        public ActionResult Index()
        {

            DataTable dataTable = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring)) //I'm using 'using' so that I don't have to close the connection every time
            {
                sqlcon.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter("Select * from Mobiles", sqlcon);
                sqlAdapter.Fill(dataTable);     // After Selecting all the details I'm showing that to the datatable i've created in the index page
            }
            return View(dataTable);

        }

      
        // GET: Mobile/Create
        public ActionResult Create()
        {
            return View(new MobileModel());
        }

        // POST: Mobile/Create
        [HttpPost]
        public ActionResult Create(MobileModel mobileModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "INSERT INTO Mobiles VALUES(@MobileName,@MobilePrice,@MobileBrand,@Rating)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@MobileName", mobileModel.MobileName);
                sqlcmd.Parameters.AddWithValue("@MobilePrice", mobileModel.MobilePrice);
                sqlcmd.Parameters.AddWithValue("@MobileBrand", mobileModel.MobileBrand);
                sqlcmd.Parameters.AddWithValue("@Rating", mobileModel.Rating);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");  //After inserting the records redirecting the page to Index
        }

        // GET: Mobile/Edit/5
        public ActionResult Edit(int id)
        {
            MobileModel mobileModel = new MobileModel();
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "SELECT * FROM Mobiles where MobileID=@MobileID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlcon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@MobileID", id);
                sqlDa.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)  //If there are records the only I'm updating those
            {
                mobileModel.MobileID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                mobileModel.MobileName = dataTable.Rows[0][1].ToString();
                mobileModel.MobilePrice = Convert.ToDecimal(dataTable.Rows[0][2].ToString());
                mobileModel.MobileBrand = dataTable.Rows[0][3].ToString();
                mobileModel.Rating = Convert.ToDecimal(dataTable.Rows[0][4].ToString());
                return View(mobileModel);
            }
            else
            {
                return RedirectToAction("Index");  // otherwise redirect to index
            }
        }

        // POST: Mobile/Edit/5
        [HttpPost]
        public ActionResult Edit(MobileModel mobileModel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "UPDATE Mobiles SET MobileName=@MobileName,MobilePrice=@MobilePrice,MobileBrand=@MobileBrand,Rating=@Rating where MobileID=@MobileID";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@MobileID", mobileModel.MobileID);
                sqlcmd.Parameters.AddWithValue("@MobileName", mobileModel.MobileName);
                sqlcmd.Parameters.AddWithValue("@MobilePrice", mobileModel.MobilePrice);
                sqlcmd.Parameters.AddWithValue("@MobileBrand", mobileModel.MobileBrand);
                sqlcmd.Parameters.AddWithValue("@Rating", mobileModel.Rating);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Mobile/Delete/5
        public ActionResult Delete(int id)   // I'm not creating any post method of delete as we're not returning anything after deleting
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "DELETE FROM Mobiles where MobileID=@MobileId";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@MobileID", id);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        
        
    }
}
