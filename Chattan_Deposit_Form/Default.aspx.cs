using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Xml;

namespace Chattan_Deposit_Form
{
    public partial class _Default : Page
    {
        public void ExploreRootFolder()
        {
            // Create a request using a URL that can receive a post. 
            //WebRequest request = WebRequest.Create("https://server.xpressdox.com/Cloud/IntegrationServices/ThirdPartyService.svc/ExploreFolder?authenticationTicket={authenticationTicket}&folderIdentifier= ");
            string URI = "https://server.xpressdox.com/Cloud/IntegrationServices/ThirdPartyService.svc/ExploreFolder?authenticationTicket=ecaa3551-79a1-4810-98c0-d4ce3a4d01ea&folderIdentifier=";
            string Out = String.Empty;
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            try
            {
                System.Net.WebResponse resp = req.GetResponse();
                using (System.IO.Stream stream = resp.GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(stream))
                    {
                        Out = sr.ReadToEnd();
                        sr.Close();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Out = string.Format("HTTP_ERROR :: The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close' :: {0}", ex.Message);
            }
            catch (WebException ex)
            {
                Out = string.Format("HTTP_ERROR :: WebException raised! :: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Out = string.Format("HTTP_ERROR :: Exception raised! :: {0}", ex.Message);
            }
            //Display the output
            //lblOutput.Text = Out;
            txtXML_Input.Text = Out;
        }



        //     public string CreateInterviewXML()
        //{
        //    XElement xml = new XElement("ChattanDepositConfirmationv22015",
        //        new XElement("Deposit_Software_Owner",
        //            name),
        //        new XElement("Deposit_Beneficiary_Contact",
        //            age),
        //        new XElement("Deposit_Account_Number",
        //            city),
        //        new XElement("Deposit_Software_Date",
        //            country),
        //        new XElement("Deposit_Software_Method",
        //            country),
        //        new XElement("Deposit_Description",
        //            country)


        //    );

        //}


        public void FillTemplateUsingTemplateIdentifier(string Software_Owner, string Benficiary_Contact, string Deposit_Account_Number, string Deposit_Date, string Deposit_Method, string Software_Description)
        {
            //Below is the XML string in the format for the specific interview, change the child nodes to match the interview DataElements 
            string xml = "<ChattanDepositConfirmationv22015><Deposit_Software_Owner>" + Software_Owner + "</Deposit_Software_Owner><Deposit_Beneficiary_Contact>" + txtDeposit_Beneficiary + "</Deposit_Beneficiary_Contact><Deposit_Account_Number>" + Deposit_Account_Number + "</Deposit_Account_Number><Deposit_Software_Date>" + Deposit_Date + "</Deposit_Software_Date><Deposit_Software_Method>" + Deposit_Method + "</Deposit_Software_Method><Deposit_Description>" + Software_Description + "</Deposit_Description></ChattanDepositConfirmationv22015>";
            //Below is the URL for the XpressDox API function that allows you to fill a template with data using taken from the webpage form
            string url = "https://server.xpressdox.com/Cloud/IntegrationServices/ThirdPartyService.svc/FillTemplateByTemplateID?authenticationTicket=ecaa3551-79a1-4810-98c0-d4ce3a4d01ea&templateIdentifier=7faa0c5e-bd32-433d-b410-839fd2d7e55a";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(xml);
            req.Method = "POST";
            req.ContentType = "text/xml;charset=utf-8";
            req.ContentLength = requestBytes.Length;
            Stream requestStream = req.GetRequestStream();
            requestStream.Write(requestBytes, 0, requestBytes.Length);
            requestStream.Close();

            //Code block below is to retrieve the response from the XpressDox API and get the download link for the assembled document
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.Default);
            string backstr = sr.ReadToEnd();
            // txtXML_Input.Text = backstr;
            sr.Close();
            res.Close();


            //Code to convert the string response to XML so we can find the download link using XML functions
            //Code below just loads the response string to XML var then we just search for the DowloadLink node then BOOM its there (*_*)
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(backstr);
            XmlNodeList nodeList = xmldoc.GetElementsByTagName("DownloadLink");
            string Short_Fall = string.Empty;
            foreach (XmlNode node in nodeList)
            {
                Short_Fall = node.InnerText;
                txtXML_Input.Text = Short_Fall;
                Response.Redirect(Short_Fall);
            }
        }
           


        protected void Page_Load(object sender, EventArgs e)
        {
           // XMLCreator();
        }

        protected void btnAssemble_Click(object sender, EventArgs e)
        {
            FillTemplateUsingTemplateIdentifier(txtSoftware_Owner.Text, txtDeposit_Beneficiary.Text, txtDeposit_Account_Number.Text, cldrDeposit_Date.SelectedDate.ToString(), dplDeposit_Method.SelectedValue.ToString(), txtSoftware_Description.Text);
            //ExploreRootFolder();
        }
    }
}