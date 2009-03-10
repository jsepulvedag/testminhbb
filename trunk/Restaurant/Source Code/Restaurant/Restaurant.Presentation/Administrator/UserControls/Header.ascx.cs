using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.WebControls;
using System.Xml;
using Restaurant.Presentation.Library;

namespace Restaurant.Presentation.Administrator.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMenu();
            }
        }
        private void LoadMenu()
        {
            XmlDocument itemDoc = new XmlDocument();
            itemDoc.Load(Server.MapPath(PageConstant.ADMIN_XML_FILE_CONFIG));
            if (itemDoc.ChildNodes.Count > 0)
            {
                XmlNode pageConfigNode = (itemDoc.GetElementsByTagName("PageConfig"))[0];
                foreach (XmlNode rootNode in pageConfigNode.ChildNodes)
                {
                    Boolean visibile = rootNode.Attributes["visible"] != null ? Convert.ToBoolean(rootNode.Attributes["visible"].Value) : false;

                    if (visibile)
                    {
                        RadMenuItem menuItem = new RadMenuItem();
                        menuItem.Text = rootNode.Attributes["title"].Value;
                        menuItem.Value = rootNode.Attributes["key"].Value;
                        if (rootNode.Attributes["value"].Value != "#")
                        {
                            menuItem.NavigateUrl = PageConstant.ADMIN_URL + "?ctrl=" + rootNode.Attributes["key"].Value;
                        }
                        LoadChildItems(menuItem, rootNode);
                        radAdminMenu.Items.Add(menuItem);
                    }
                }
            }
        }
        private void LoadChildItems(RadMenuItem rootItem, XmlNode rootNode)
        {
            if (rootNode.ChildNodes.Count > 0)
            {
                foreach (XmlNode childNode in rootNode.ChildNodes)
                {
                    Boolean visibile = childNode.Attributes["visible"] != null ? Convert.ToBoolean(childNode.Attributes["visible"].Value) : true;

                    if (visibile)
                    {
                        RadMenuItem childItem = new RadMenuItem();
                        childItem.Text = childNode.Attributes["title"].Value;
                        childItem.Value = childNode.Attributes["key"].Value;
                        if (childNode.Attributes["value"].Value != "#")
                        {
                            childItem.NavigateUrl = PageConstant.ADMIN_URL + "?ctrl=" + childNode.Attributes["key"].Value;
                        }
                        rootItem.Items.Add(childItem);
                        LoadChildItems(childItem, childNode);
                    }
                }
            }
        }
    }
}