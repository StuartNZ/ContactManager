using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Edit : System.Web.UI.Page
    {
        Func<string, bool> IsValidInput = s => (!String.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s));

        Int32 cidInt;

        protected void Page_Load(object sender, EventArgs e)
        {
            //grab the contact id from the querystring
            var cid = Page.Request.QueryString["contactid"];

            if (cid != null)
            {
                try
                {
                    cidInt = Convert.ToInt32(cid);
                }
                catch (Exception ex)
                {
                    pnlError.Visible = true;
                    ltlError.Text = ex.Message;
                }
            }

            if (!(Page.IsPostBack))
            {

                if (cid != null)
                {
                    try
                    {
                        //retrieve the contact details and populate the form fields
                        ContactsDataContext db = new ContactsDataContext();

                        var query = (from c in db.Contacts
                                     where c.ContactID == cidInt
                                     select c).FirstOrDefault();

                        txtFirstName.Text = query.FirstName;
                        txtLastName.Text = query.LastName;
                        txtPhoneNo.Text = query.PhoneNo;
                    }
                    catch (Exception ex)
                    {
                        pnlError.Visible = true;
                        ltlError.Text = ex.Message;
                    }
                }
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResetMsgs();

                if (IsValidInput(txtFirstName.Text) && IsValidInput(txtLastName.Text) && IsValidInput(txtPhoneNo.Text))
                {
                    ContactsDataContext db = new ContactsDataContext();

                    // Query the database for the row to be updated.
                    var editContact = from c in db.Contacts
                                where c.ContactID == cidInt
                                       select c;

                    foreach (Contact c in editContact)
                    {
                        c.FirstName = txtFirstName.Text;
                        c.LastName = txtLastName.Text;
                        c.PhoneNo = txtPhoneNo.Text;
                        // Insert any additional changes to column values.
                    }
                   
                    // Submit the changes to the database.
                    try
                    {
                        db.SubmitChanges();
                        pnlSuccess.Visible = true;
                        ltlSuccess.Text = "Record updated.";
                    }
                    catch (Exception ex)
                    {
                        pnlError.Visible = true;
                        ltlError.Text = ex.Message;
                    }

                }
                else
                {
                    //validate form fields
                    if (!(IsValidInput(txtFirstName.Text)))
                    {
                        divFirstName.Attributes["class"] = "clearfix error";
                        txtFirstName.CssClass = "error";
                        helpFirstName.Visible = true;
                    }
                    if (!(IsValidInput(txtLastName.Text)))
                    {
                        divLastName.Attributes["class"] = "clearfix error";
                        txtLastName.CssClass = "error";
                        helpLastName.Visible = true;
                    }
                    if (!(IsValidInput(txtPhoneNo.Text)))
                    {
                        divPhoneNo.Attributes["class"] = "clearfix error";
                        txtPhoneNo.CssClass = "error";
                        helpPhoneNo.Visible = true;
                    }
                    pnlError.Visible = true;
                    ltlError.Text = "Please correct the errors below";


                }
            }
            catch (Exception ex)
            {
                pnlError.Visible = true;
                ltlError.Text = ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //return to grid page
            Response.Redirect("~/Default.aspx");
        }

        private void ClearForm()
        {
            //clear the text fields
            txtFirstName.Text = txtLastName.Text = txtPhoneNo.Text = "";
        }

        private void ResetMsgs()
        {
            //reset fields and panels
            divFirstName.Attributes["class"] = divLastName.Attributes["class"] = divPhoneNo.Attributes["class"] = "clearfix";
            txtFirstName.CssClass = txtLastName.CssClass = txtPhoneNo.CssClass = "";
            helpFirstName.Visible = helpLastName.Visible = helpPhoneNo.Visible = false;
            pnlError.Visible = pnlSuccess.Visible = false;
        }
    }
}