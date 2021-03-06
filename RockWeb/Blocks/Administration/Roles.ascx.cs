﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Web.UI;

namespace RockWeb.Blocks.Administration
{
    public partial class Roles : Rock.Web.UI.Block
    {
        private string _action = string.Empty;
        private string _roleName = string.Empty;

        protected void Page_Init( object sender, EventArgs e )
        {
            _action = PageParameter( "action" ).ToLower();
            switch ( _action )
            {
                case "":
                case "list":
                    DisplayList();
                    break;
                case "add":
                    _roleName = string.Empty;
                    DisplayEdit( _roleName );
                    break;
                case "edit":
                    if ( !String.IsNullOrEmpty( PageParameter( "RoleName" )))
                        DisplayEdit( _roleName );
                    else
                        throw new System.Exception( "Missing RoleName" );
                    break;
            }
        }

        protected void Page_Load( object sender, EventArgs e )
        {
        }

        private void DisplayList()
        {
            phList.Visible = true;
            phDetails.Visible = false;
            phRoles.Controls.Clear();

            foreach ( string roleName in System.Web.Security.Roles.GetAllRoles() )
            {
                System.Web.UI.HtmlControls.HtmlAnchor a = new System.Web.UI.HtmlControls.HtmlAnchor();
                a.HRef = "Role/Edit/" + roleName;
                a.InnerText = roleName;
                phRoles.Controls.Add( a );
                phRoles.Controls.Add( new LiteralControl( "<br/>" ) );
            }
        }

        private void DisplayEdit( string roleName )
        {
            phList.Visible = false;
            phDetails.Visible = true;

            tbName.Text = roleName;
        }

        protected void lbSave_Click( object sender, EventArgs e )
        {
            if ( !System.Web.Security.Roles.RoleExists( tbName.Text ) )
                System.Web.Security.Roles.CreateRole( tbName.Text );

            Response.Redirect( "~/site/list" );
        }
    }
}