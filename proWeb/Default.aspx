<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <p class="subtitle">Product Management</p>
        <div>
            <!-- Código -->
            <p> 
            Code&nbsp; <asp:TextBox id="code" 
                        TextMode="SingleLine"
                        Columns="28"
                        MinLength="1"
                        MaxLength="16"
                        runat="server"
                        style="position: absolute"
                        OnTextChanged="code_TextChanged"/>
            </p>
            <!-- Nombre -->
            <p> 
                Name&nbsp; <asp:TextBox id="name"
                            TextMode="SingleLine"
                            Columns="29"
                            MaxLength="32"
                            runat="server"
                            style="position: absolute"
                            OnTextChanged="name_TextChanged"/>
            </p>
            <!-- Cantidad -->
            <p> 
                Amount&nbsp; 
                <asp:TextBox ID ="amount"
                            Columns="15"
                            MinLength="1"
                            MaxLength="4"
                            runat="server"
                            style="position: absolute"
                            OnTextChanged="amount_TextChanged"/>
                <!-- Validación de entrada, rango tiene que ser entre 0-9999 -->
                <asp:RangeValidator ID="amountRange"
                                    runat="server"
                                    ControlToValidate="amount"
                                    MinimumValue="0" 
                                    MaximumValue="9999"
                                    Type="Integer"
                                    ErrorMessage="Select 0-9999"
                                    ForeColor="Red"/>
                
            </p>

            <!-- Menu drop down -->
            <p>  
                Category&nbsp; 
                    <asp:DropDownList id="category" 
                                runat="server"
                                style="position: absolute"
                                OnSelectedIndexChanged="category_SelectedIndexChanged">
                        <asp:ListItem Value="computing">Computing</asp:ListItem>
                        <asp:ListItem Value="telephony">Telephony</asp:ListItem>
                        <asp:ListItem Value="gaming">Gaming</asp:ListItem>
                        <asp:ListItem Value="homeapps">Home appliances</asp:ListItem>
                    </asp:DropDownList>
            </p>
            <!-- Entrada del rango -->
            <p> 
                Price&nbsp; 
                <asp:TextBox ID="price"
                    TextMode="SingleLine"
                    Columns="15"
                    runat="server" 
                    style="position: absolute"
                    OnTextChanged="price_TextChanged"
                    minLength="1"
                    maxLength="7"
                    AutoPostBack="true" />
                <!-- Validar si el precio está en rango-->
                <asp:RangeValidator ID="priceRange"
                    runat="server"
                    ControlToValidate="price" 
                    MinimumValue="0.0" 
                    MaximumValue="9999.99" 
                    Type="Double" 
                    ErrorMessage="Select 0-9999" 
                    ForeColor="Red"
                    CultureInvariantValues="true" /> <!-- Para usar punto o coma -->
            </p>
            
            <p> <!-- maybe configure the format in the cs file? screw around with this later -->
                Creation Date&nbsp; 
                <asp:TextBox ID="date" 
                    TextMode="Date" 
                    Columns="19" 
                    AutoPostBack="true" 
                    runat="server" 
                    style="position: absolute" 
                    OnTextChanged="date_TextChanged"/>
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
