<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <p class="subtitle">Product Management</p>
        <div>
            <p>
            Code <asp:TextBox id="code" TextMode="SingleLine" Columns="38" runat="server" style="position: absolute"/>
            </p>
            <p>
                Name <asp:TextBox id="name" TextMode="SingleLine" Columns="40" runat="server" style="position: absolute"/>
            </p>
            <p>
                Amount <asp:TextBox ID ="amount" TextMode="SingleLine" Columns="20" runat="server" style="position: absolute"/>
            </p>
            <p>
                Category <asp:DropDownList id="category" runat="server" style="position: absolute" OnSelectedIndexChanged="category_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="computing">Computing</asp:ListItem>
                    <asp:ListItem Value="telephony">Telephony</asp:ListItem>
                    <asp:ListItem Value="gaming">Gaming</asp:ListItem>
                    <asp:ListItem Value="homeapps">Home appliances</asp:ListItem>
                    </asp:DropDownList>
            </p>
            <p>
                Price <asp:TextBox ID ="price" TextMode="SingleLine" Columns="16" runat="server" style="position: absolute"/>
            </p>
            <p>
                Creation Date <asp:TextBox ID ="date" TextMode="SingleLine" Columns="30" runat="server" style="position: absolute"/>
            </p>

            <div>
            <p> <!-- figure how to indent without spamming nbsp later-->
                <asp:Button id="create" Text="Create" runat="server" />
                &nbsp&nbsp&nbsp
                <asp:Button id="update" Text="Update" runat="server" />
                &nbsp&nbsp&nbsp
                <asp:Button id="delete" Text="Delete" runat="server" />
                &nbsp&nbsp&nbsp
                <asp:Button id="read" Text="Read" runat="server" />
                &nbsp&nbsp&nbsp
                <asp:Button id="readfirst" Text="Read First" runat="server" />
                &nbsp&nbsp&nbsp
                <asp:Button id="readprev" Text="Read Prev" runat="server" />
                &nbsp&nbsp&nbsp
                <asp:Button id="readnext" Text="Read Next" runat="server" />
            </p>
            </div>
        </div>
</asp:Content>
