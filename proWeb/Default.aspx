<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formContent" runat="server">
    <p class="subtitle">Product Management</p>
        <div>
            <!-- Código -->
            <p> 
            Code&nbsp; <asp:TextBox id="codeInput" 
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
                Name&nbsp; <asp:TextBox id="nameInput"
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
                <asp:TextBox ID ="amountInput"
                            Columns="15"
                            MinLength="1"
                            MaxLength="4"
                            runat="server"
                            style="position: absolute"
                            OnTextChanged="amount_TextChanged"/>
                <!-- Validación de entrada, rango tiene que ser entre 0-9999 -->
                <asp:RangeValidator ID="amountRange"
                                    runat="server"
                                    ControlToValidate="amountInput"
                                    MinimumValue="0" 
                                    MaximumValue="9999"
                                    Type="Integer"
                                    ErrorMessage="Select 0-9999"
                                    ForeColor="Red"/>
                
            </p>

            <!-- Menu drop down -->
            <p>  
                Category&nbsp; 
                    <asp:DropDownList id="categoryInput" 
                                runat="server"
                                style="position: absolute"
                                OnSelectedIndexChanged="category_SelectedIndexChanged">
                        <asp:ListItem Value="1">Computing</asp:ListItem>
                        <asp:ListItem Value="2">Telephony</asp:ListItem>
                        <asp:ListItem Value="3">Gaming</asp:ListItem>
                        <asp:ListItem Value="4">Home appliances</asp:ListItem>
                    </asp:DropDownList>
            </p>
            <!-- Entrada del rango -->
            <p> 
                Price&nbsp; 
                <asp:TextBox ID="priceInput"
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
                    ControlToValidate="priceInput" 
                    MinimumValue="0.0" 
                    MaximumValue="9999.99" 
                    ErrorMessage="Select 0-9999" 
                    ForeColor="Red"
                    CultureInvariantValues="true" /> <!-- Para usar punto o coma -->
            </p>
            
            <p> 
                Creation Date&nbsp; 
                <asp:TextBox ID="dateInput" 
                    TextMode="DateTime" 
                    Columns="19" 
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

                <asp:Label ID="statusLabel" runat="server" ForeColor="Green" Font-Bold="true" />

            </p>
            </div>
        </div>
        <div style="margin-top:20px;">
        <asp:GridView ID="productGrid" runat="server" AutoGenerateColumns="False"
            CssClass="product-table" Visible="false">
            <Columns>
                <asp:BoundField DataField="Code" HeaderText="Code" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:F2}" />
                <asp:TemplateField HeaderText="Category">
                    <ItemTemplate>
                        <%# GetCategoryName(Convert.ToInt32(Eval("Category"))) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreationDate" HeaderText="Created" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
