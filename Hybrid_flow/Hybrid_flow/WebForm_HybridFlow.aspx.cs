using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


namespace Hybrid_flow
{
    public partial class WebForm_HybridFlow : System.Web.UI.Page
    {
        Connections cs = new Connections();
        Constants cc = new Constants();


        protected void Page_Load(object sender, EventArgs e)
        {
            string _rawuri = Hidden1.Value;

            if (_rawuri != "")
            {
                //Split the fragement
                string[] words = _rawuri.Split('&');


                //trim the caught parameters
                //print them in labels
                #region
                //part of the substring i want to exclude
                var rgxCd = new Regex("#code=");
                var rgxTk = new Regex("id_token=");
                var rgxSc = new Regex("scope=");
                var rgxSt = new Regex("state=");
                var rgxSeSt = new Regex("session_state=");

                //the excluding action
                var _code = rgxCd.Replace(words[0], "", 1);
                var _idtoken = rgxTk.Replace(words[1], "", 1);
                var _scope = rgxSc.Replace(words[2], "", 1);
                var _state = rgxSt.Replace(words[3], "", 1);
                var _sessionstate = rgxSeSt.Replace(words[4], "", 1);

                //show in labels
                lblCd.Text = _code;
                lblTk.Text = _idtoken;
                lblSc.Text = _scope;
                lblSt.Text = _state;
                lblSeSt.Text = _sessionstate;

                //Access ID retreived 
                lblAccTk.Text = cs.codeTokenH(_code);

                #endregion

            }
            else
            {
            }
        }

        //Login button
        protected void Login_Click(object sender, EventArgs e)
        {
            string[] _testarray = new string[] { TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text };
            cc.fieldVar(_testarray);

            var url = Constants.AuthorizeEndPoint + "client_id=" + Constants.ClientID + "&" + "redirect_uri=" + Constants.RedirectURI + "&" + "state=" + Constants.State + "&" + "nonce=" + Constants.Nonce + "&" + "scope=" + Constants.Scope + "&" + "response_type=" + Constants.Response_Type;
            Response.Redirect(url);
        }

    //textboxes
    #region
    protected void Hidden1_ValueChanged(object sender, EventArgs e)
        {
            //See the WebForm_HybridFlow.aspx (html code) how hiddenfield has been used
        }

        protected void btnAuth_Click(object sender, EventArgs e)
        {
            //code is in HybridWF.aspx (in the html code)

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
#endregion
    }
}