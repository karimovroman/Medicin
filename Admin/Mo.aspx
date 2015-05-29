<%@ Page Title="Панель администрирования: Мед. учреждения" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Mo.aspx.cs" Inherits="Admin_Mo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <script runat="server">
        
        void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DBase.MSSQL mssql = new DBase.MSSQL();
                try
                {

                    listermo.Items.Clear();
                    List<DBase.mo> listmos = mssql.GetMo();
                    List<DBase.mo> listmo = listmos.OrderBy(o => o.Name).ToList();
                    foreach (DBase.mo m in listmo)
                    {
                        listermo.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
                    }
                } 
                finally
                {
                   
                }
                
            }
            
        
        }
        void Save(object sender, EventArgs e)
        {
            DBase.mo mo = new DBase.mo();
            DBase.MSSQL mssql = new DBase.MSSQL();
            try
            {
                mo.Id = 0;
                mo.Name = _name.Text;
                mo.Phone = _phone.Text;
                mo.Adres = _adres.Text;
                mo.Email = _email.Text;
                mo.Inn = _inn.Text;
                mo.Kpp = _kpp.Text;
                mo.Licenz = _licenz.Text + _datlic.Text;
                mo.Lico = _fio.Text + " " + _nam.Text + " " + _otch.Text;
                mo.Bik = _bik.Text;
                int r = mssql.InsertMo(mo);
                if (r!=0)
                {
                    List<DBase.mo> listmos = mssql.GetMo();
                    List<DBase.mo> listmo = listmos.OrderBy(o => o.Name).ToList();
                    
                    listermo.Items.FindByValue(Convert.ToString(r)).Text = "Я";
                }
            }
            catch
            {
                
            }
            finally
            {
                List<DBase.mo> listmos = mssql.GetMo();
                List<DBase.mo> listmo = listmos.OrderBy(o => o.Name).ToList();
                listermo.Items.Clear();
                foreach (DBase.mo m in listmo)
                {
                    listermo.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
                }
            }
           
        }
    </script>

    <div style="text-align:center;width:450px"><asp:Label Text ="Добавить новое учреждение:" runat="server"></asp:Label></div>
    <table style="width: 100%">
        <tr>
            <td style="width: 600px">
                <table>
                    <tr>
                        <td style="width: 150px">Название учреждения*:
                            <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_name"
                                ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не название."
                                    ValidationExpression="[а-яА-Я0-9\s*,-;:]{1,150}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_name"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели название"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="_name" Width="250px" runat="server" MaxLength="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Адрес*: <asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_adres"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не адрес."
                                    ValidationExpression="[а-яА-Я0-9\s*,-;:]{1,150}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_adres"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели адрес"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_adres" Width="250px" runat="server" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Телефон*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_phone"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не номер. "
                                    ValidationExpression="[1234567890]{6,12}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_phone"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели номер. 7xxxxxxxxxx"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_phone" Width="250px" runat="server" TextMode="Phone" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Электронная почта*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_email"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не email."
                                    ValidationExpression="^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_email"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели email"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_email" Width="250px" runat="server" TextMode="Email" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>БИК*:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_bik"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не цифры"
                                    ValidationExpression="[1234567890]{9}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_bik"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели БИК"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_bik" Width="250px" runat="server" MaxLength="9"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Фамилия заведующего:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_fio"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не фамилию."
                                    ValidationExpression="[а-яА-Яё]{1,150}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_fio"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели фамилию"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_fio" Width="250px" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Имя заведующего:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_nam"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не имя."
                                    ValidationExpression="[а-яА-Яё]{1,150}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_nam"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели имя"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_nam" Width="250px" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Отчество заведующего:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_otch"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не отчество."
                                    ValidationExpression="[а-яА-Яё]{1,150}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_otch"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели отчество"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_otch" Width="250px" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Лицензия:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_licenz"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не лицензию."
                                    ValidationExpression="[а-яА-Яё0-9-]{15}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_licenz"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели лицензию"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_licenz" Width="250px" runat="server"  MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>Дата выдачи:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_datlic"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не дату."
                                    ValidationExpression="^(((0[1-9]|[12]\d|3[01])\.(0[13578]|1[02])\.((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\.(0[13456789]|1[012])\.((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\.02\.((19|[2-9]\d)\d{2}))|(29\.02\.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))$" />
                   <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_datlic"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели дату"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_datlic" Width="250px" runat="server"  MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ИНН:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_inn"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не ИНН."
                                    ValidationExpression="[0-9]{10,12}" />
                   <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_inn"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели ИНН"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_inn" Width="250px" runat="server" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>КПП:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_kpp"  ValidationGroup="rr"
                                    ErrorMessage="Вы ввели не КПП."
                                    ValidationExpression="[0-9]{9}" />
                   <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="_kpp"  ValidationGroup="rr"
                                    ErrorMessage="Вы не ввели КПП"> 
                                </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_kpp" Width="250px" runat="server"  MaxLength="9"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right; margin-right: 10px">
                            <asp:Button OnClick="Save"   ValidationGroup="rr" ID="save" runat="server" Text="Добавить" /></td>
                    </tr>
                </table>
                * обязательное поле
            </td>

            <td style="vertical-align: top">
                <div>
                    <asp:RadioButtonList ID="listermo" Width="300px" runat="server"></asp:RadioButtonList>
                    <asp:ImageButton ID="del" runat="server" OnClick="del_Click" ImageUrl="~/images/del.png" />Удалить выбранную запись
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

