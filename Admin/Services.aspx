<%@ Page Title="Панель администрирования: Услуги" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Admin_services" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <script runat="server">
        
        void Page_Load(object sender, EventArgs e)
        {
            DBase.MSSQL mssql = new DBase.MSSQL();
            listerserv.Items.Clear();
            List<DBase.service> listservices = mssql.GetServices();
            List<DBase.service> listservice = listservices.OrderBy(o => o.Name).ToList();
            foreach (DBase.service m in listservice)
            {
                listerserv.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
            }
            if(!IsPostBack)
            {
                
                try
                {
                    

                    List<DBase.mo> listmos = mssql.GetMo();
                    List<DBase.mo> listmo = listmos.OrderBy(o => o.Name).ToList();
                   
                    foreach (DBase.mo m in listmo)
                    {
                        _molist.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
                    }

                   // List<DBase.service> listservices = mssql.GetServices();

                    
                } 
                finally
                {
                   
                }
                
            }
            
        
        }
        //записываем все в базу
        void Save(object sender, EventArgs e)
        {
            try { 
            DBase.service serv = new DBase.service();
            DBase.MSSQL mssql = new DBase.MSSQL();
                serv.Name = _name.Text;
                serv.About = _about.Text;
                serv.Cost = _cost.Text;
                serv.Id = 0;
                
                int r = mssql.InsertService(serv);
                if (r!=0)
                {
                    for (int i = 0; i< _molist.Items.Count; i++)
                    {
                        if (_molist.Items[i].Selected == true)
                        {
                            mssql.InsertMoServ(Convert.ToInt32(_molist.Items[i].Value), Convert.ToInt32(r));
                        }
                    }
                }
            }
            finally
            {

                DBase.MSSQL mssql = new DBase.MSSQL();
                _molist.Items.Clear();
                List<DBase.mo> listmos = mssql.GetMo();
                List<DBase.mo> listmo = listmos.OrderBy(o => o.Name).ToList();
                ;
                foreach (DBase.mo m in listmo)
                {
                    _molist.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
                }
            }
        }
    </script>

   
    <div style="text-align: center; width: 450px">
        <asp:Label Text="Добавить новую услугу:" runat="server"></asp:Label></div>
    <table style="width: 100%">
        <tr>
            <td style="width: 600px">
                <table>
                    <tr>
                        <td style="width: 150px">Название услуги:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                            ControlToValidate="_name"
                            ErrorMessage="Вы ввели не текст."
                            ValidationExpression="[а-яА-Я]{1,50}" />
                            <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                ControlToValidate="_name"
                                ErrorMessage="Вы не ввели название"> 
                            </asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 250px">
                            <asp:TextBox ID="_name" Width="250px" runat="server" MaxLength="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Описание:
                        </td>
                        <td>
                            <asp:TextBox ID="_about" Width="250px" runat="server" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Цена:<asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                            ControlToValidate="_cost"
                            ErrorMessage="Вы ввели не цену."
                            ValidationExpression="[1234567890]{1,5}" />
                            <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                ControlToValidate="_cost"
                                ErrorMessage="Вы не ввели цену"> 
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="_cost" Width="250px" runat="server" TextMode="Phone" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Мед. учреждения:
                        </td>
                        <td>
                            <asp:CheckBoxList ID="_molist" runat="server"></asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right; margin-right: 10px">
                            <asp:Button OnClick="Save" ID="save" runat="server" Text="Добавить" /></td>
                    </tr>
                </table>
            </td>

            <td style="vertical-align: top">
                <div >
                    <asp:RadioButtonList ID="listerserv" Width="300px" runat="server"></asp:RadioButtonList>
                    <asp:ImageButton ID="del" runat="server" OnClick="del_Click" ImageUrl="~/images/del.png" />Удалить выбранную запись
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

