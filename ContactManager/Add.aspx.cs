using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Add : System.Web.UI.Page
    {
        Func<string, bool> IsValidInput = s => (!String.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s));

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResetMsgs();

                //validate fields and save record
                if (IsValidInput(txtFirstName.Text) && IsValidInput(txtLastName.Text) && IsValidInput(txtPhoneNo.Text))
                {

                    ContactsDataContext db = new ContactsDataContext();

                    Contact addContact = new Contact();

                    addContact.FirstName = txtFirstName.Text;
                    addContact.LastName = txtLastName.Text;
                    addContact.PhoneNo = txtPhoneNo.Text;

                    db.Contacts.InsertOnSubmit(addContact);
                    db.SubmitChanges();
                    
                    ClearForm();
                    pnlSuccess.Visible = true;
                    ltlSuccess.Text = "Contact " + txtFirstName.Text.ToString() + " " + txtLastName.Text.ToString() + " saved";
                    
                }
                else
                {
                    //validation of text fields
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
            //clear form and reset panels
            ClearForm();
            ResetMsgs();
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