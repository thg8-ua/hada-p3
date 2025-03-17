<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <p class="subtitle">Product Management</p>
        <div>
            <p> <!-- Code is restricted to a range of 1-16 characters -->
            Code&nbsp; <asp:TextBox id="code" TextMode="SingleLine" Columns="28" MinLength="1" MaxLength="16" runat="server" style="position: absolute" OnTextChanged="code_TextChanged"/>
            </p>
            <p> <!-- Name cannot exceed 32 characters -->
                Name&nbsp; <asp:TextBox id="name" TextMode="SingleLine" Columns="29" MaxLength="32" runat="server" style="position: absolute" OnTextChanged="name_TextChanged"/>
            </p>
            <p> <!-- Figure out how to restrict range from 0-9999 -->
                Amount&nbsp; <asp:TextBox ID ="amount" Columns="15" MinLength="1" MaxLength="4" runat="server" style="position: absolute" OnTextChanged="amount_TextChanged"/>
                <asp:RangeValidator ID="rv1" runat="server" ControlToValidate="amount" MinimumValue="0" MaximumValue="9999" Type="Integer" ErrorMessage="Select 0-9999" ForeColor="Red">
                </asp:RangeValidator>

            </p>
            <p>  <!-- Show a drop down menu, said menu has only 4 items -->
                Category&nbsp; <asp:DropDownList id="category" runat="server" style="position: absolute" OnSelectedIndexChanged="category_SelectedIndexChanged">
                    <asp:ListItem Value="computing">Computing</asp:ListItem>
                    <asp:ListItem Value="telephony">Telephony</asp:ListItem>
                    <asp:ListItem Value="gaming">Gaming</asp:ListItem>
                    <asp:ListItem Value="homeapps">Home appliances</asp:ListItem>
                    </asp:DropDownList>
            </p>
            <p> <!-- same issue as amount, but for floats -->
                Price&nbsp; <asp:TextBox ID ="price" TextMode="SingleLine" Columns="15" runat="server" style="position: absolute" OnTextChanged="price_TextChanged"/>

            </p>
            <p> <!-- maybe configure the format in the cs file? screw around with this later -->
                Creation Date&nbsp; <asp:TextBox ID ="date" TextMode="SingleLine" Columns="19" runat="server" style="position: absolute" OnTextChanged="date_TextChanged"/>
            </p>

            <div>
            <p> 
                <asp:Button id="create" Text="Create" runat="server" OnClick="create_Click" />
                &nbsp
                <asp:Button id="update" Text="Update" runat="server" OnClick="update_Click" />
                &nbsp
                <asp:Button id="delete" Text="Delete" runat="server" OnClick="delete_Click" />
                &nbsp
                <asp:Button id="read" Text="Read" runat="server" OnClick="read_Click" />
                &nbsp
                <asp:Button id="readfirst" Text="Read First" runat="server" OnClick="readfirst_Click" />
                &nbsp
                <asp:Button id="readprev" Text="Read Prev" runat="server" OnClick="readprev_Click" />
                &nbsp
                <asp:Button id="readnext" Text="Read Next" runat="server" OnClick="readnext_Click" />
            </p>
            </div>
        </div>
</asp:Content>
