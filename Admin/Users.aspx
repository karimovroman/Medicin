<%@ Page Title="Панель администрирования: Пользователи" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">



    <table style="width: 400px; text-align:center">
            <tr>
                <td style="text-align:right">
                <asp:Button ID="tab0" runat="server" OnClick="tab0_Click" Text="Сотрудники регистратуры" />
            </td>
            <td style="text-align:left">
                <asp:Button ID="tab1" runat="server" OnClick="tab1_Click" Text="Медицинский персонал" />
            </td>
           
        </tr>
    </table>
     <asp:Label ID="info" runat="server"></asp:Label>
    <asp:MultiView ID ="tabsi" runat="server">
        <asp:View ID="tabs0" runat="server">
             <table style="width: 100%">
        <tr>
            <td style="width: 600px">
                <table style="margin-left: 10px; margin-top: 15px; vertical-align: top">
                    <tr>
                        <td colspan="2" style="text-align: center">Добавить сотрудника регистратуры
                        </td>
                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="rfio" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Фамилия сотрудника*
                                <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="rfio"
                                    ErrorMessage="Вы ввели не фамилию."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="rfio" ValidationGroup="reg"
                                    ErrorMessage="Вы не ввели фамилию"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="rname" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Имя сотрудника*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="rname"
                                    ErrorMessage="Вы ввели не имя."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="rfio" ValidationGroup="reg"
                                    ErrorMessage="Вы не ввели имя"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="rotch" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Отчество сотрудника*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="rotch"
                                    ErrorMessage="Вы ввели не отчество."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="rotch" ValidationGroup="reg"
                                    ErrorMessage="Вы не ввели отчество"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="phone" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Номер телефона*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="phone"
                                    ErrorMessage="Вы ввели не номер. +7(xxx)xxx-xx-xx"
                                    ValidationExpression="^\+\d{1}\(\d{3}\)\d{3}-\d{2}-\d{2}$" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="phone" ValidationGroup="reg"
                                    ErrorMessage="Вы не ввели номер. +7(xxx)xxx-xx-xx"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="email" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Электронный адрес, пароль будет выслан по почте*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="email"
                                    ErrorMessage="Вы ввели не email."
                                    ValidationExpression="^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="email" ValidationGroup="reg"
                                    ErrorMessage="Вы не ввели email"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="comm" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Дополнительные данные (контактная информация)
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:DropDownList ID="mo" Width="300px" runat="server"></asp:DropDownList>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Медицинское учреждение*
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="savereg" runat="server" ValidationGroup="reg" Text="Сохранить" CssClass="company_name" OnClick="savereg_Click" />
                        </td>

                    </tr>

                </table>
                * обязательное поле
            </td>

            <td style="vertical-align: top">
                <div>
                    <asp:RadioButtonList ID="regilist" Width="300px" runat="server"></asp:RadioButtonList>
                    <asp:ImageButton ID="delr" runat="server" OnClick="delr_Click"  ImageUrl="~/images/del.png" />Удалить выбранную запись
                </div>
            </td>
        </tr>
    </table>

        </asp:View>
        <asp:View ID="tabs1" runat="server">
            <table style="width: 100%">
        <tr>
            <td style="width: 600px">
                <table style="margin-left: 10px; margin-top: 15px">
                    <tr>
                        <td colspan="2" style="text-align: center">Добавить сотрудника медицинского персонала
                        </td>
                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="Surname" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Фамилия сотрудника*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Surname"
                                    ErrorMessage="Вы ввели не фамилию."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Surname"
                                    ValidationGroup="med"
                                    ErrorMessage="Вы не ввели фамилию"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="Name" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Имя сотрудника*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Name"
                                    ErrorMessage="Вы ввели не имя."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Name" ValidationGroup="med"
                                    ErrorMessage="Вы не ввели имя"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="Midname" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Отчество сотрудника*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Midname"
                                    ErrorMessage="Вы ввели не отчество."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Midname" ValidationGroup="med"
                                    ErrorMessage="Вы не ввели отчество"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="Dolj" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Должность*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Dolj"
                                    ErrorMessage="Вы ввели не должность."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="Dolj" ValidationGroup="med"
                                    ErrorMessage="Вы не ввели должность"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>

                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="kabin" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Кабинет*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="kabin"
                                    ErrorMessage="Вы ввели не номер."
                                    ValidationExpression="[1234567890]{1,4}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="kabin" ValidationGroup="med"
                                    ErrorMessage="Вы не ввели номер"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:TextBox MaxLength="50" ID="demail" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Электронная почта*<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="demail"
                                    ErrorMessage="Вы ввели не email."
                                    ValidationExpression="^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="demail" ValidationGroup="med"
                                    ErrorMessage="Вы не ввели email"> 
                                </asp:RequiredFieldValidator>
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:DropDownList ID="Kvalif" Width="300px" runat="server">
                                <asp:ListItem Text="Высшая группа" Value="высшая"></asp:ListItem>
                                <asp:ListItem Text="Первая группа" Value="первая"></asp:ListItem>
                                <asp:ListItem Text="Вторая группа" Value="вторая" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Квалификация*
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:DropDownList ID="Specs" Width="300px" runat="server"></asp:DropDownList>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Специализация*
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td style="width: 300px; text-align: center">
                            <asp:DropDownList ID="mos" Width="300px" runat="server"></asp:DropDownList>
                        </td>
                        <td style="width: 300px">
                            <p>
                                Медицинское учреждение*
                            </p>
                        </td>

                    </tr>
                    <tr>

                        <td colspan="2" style="text-align: right">
                            <asp:Button ID="savedoc" runat="server" ValidationGroup="med" Text="Сохранить" CssClass="company_name" OnClick="savedoc_Click" />
                        </td>

                    </tr>

                </table>
                * обязательное поле
            </td>

            <td style="vertical-align: top">
                <div>
                    <asp:RadioButtonList ID="doctlist" Width="300px" runat="server"></asp:RadioButtonList>
                    <asp:ImageButton ID="deld" runat="server" OnClick="deld_Click" ImageUrl="~/images/del.png" />Удалить выбранную запись
                </div>
            </td>
        </tr>
    </table>
        </asp:View>

    </asp:MultiView>

   
   
    
</asp:Content>