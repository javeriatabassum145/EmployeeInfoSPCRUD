<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="WebApplication.EmployeeForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 226px;
        }
        .auto-style2 {
            width: 182px;
        }
        .auto-style5 {
            width: 784px;
        }
        .auto-style6 {
            width: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Employee Form</h3></div>
        <table style="width: 99%; height: 189px;">
            <tr>
                <td class="auto-style1">Employee Name</td>
                <td class="auto-style5">
                    <asp:TextBox ID="empName" runat="server" Height="25px" Width="338px"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Employee Age</td>
                <td class="auto-style5">
                    <asp:TextBox ID="empAge" runat="server" Height="25px" Width="338px"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Employee Gender</td>
                <td class="auto-style5">
                    <asp:TextBox ID="empGender" runat="server" Height="25px" Width="338px"></asp:TextBox>
                </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>
            <table style="width: 100%; height: 50px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="Button1" OnClick="CreateNewEmployee" runat="server" Height="27px" Text="Add Employee" Width="137px" BackColor="White" ForeColor="Black" />
                    </td>
                </tr>
            </table>
        <asp:Label ID="Label1" runat="server"></asp:Label> 
        <h2>Employee Data</h2>
 

        <p>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" Width="853px">
                 <Columns>  
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                        <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" />  

                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Name">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Age">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Age" runat="server" Text='<%#Eval("Age") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Age" runat="server" Text='<%#Eval("Age") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                                     <asp:TemplateField HeaderText="Gender">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Gender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Gender" runat="server" Text='<%#Eval("Gender") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
            </Columns>  
            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/> 
            </asp:GridView>
        </p>
 

    </form>

    
</body>
</html>
