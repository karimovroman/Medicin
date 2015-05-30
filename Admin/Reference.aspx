<%@ Page Title="Панель администрирования: Справочники" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Reference.aspx.cs" Inherits="Admin_reference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script runat="server">
        void addspeccom(Object sender, EventArgs e)
        {
             MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();

             if (addspec.Text == "Добавить")
            { 
                int maxl = 0;
                int r = mysql.InsertSpecDoctor(Convert.ToInt32(idspec.Text), namespec.Text);
                speclist.Items.Clear();
                List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sps = mysql.SelectSpecDoctor();
                List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sp = sps.OrderBy(o => o.name).ToList();
        
                foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in sp)
                {
                    speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                    if (s.id > maxl)
                        maxl = s.id;
                }
                idspec.Text = Convert.ToString(maxl + 1);
                }
            if (addspec.Text == "Сохранить изменения")
            {
                mysql.UpdateSpecDoctor(Convert.ToInt32(idspec.Text), namespec.Text);
                int maxl = 0;
                speclist.Items.Clear();
                List<MySqlLib.MySqlData.MySqlExecute.specdoctor> lks = mysql.SelectSpecDoctor();
                List<MySqlLib.MySqlData.MySqlExecute.specdoctor> lk = lks.OrderBy(o => o.name).ToList();
                foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in lk)
                {
                    speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                    if (s.id > maxl)
                        maxl = s.id;
                }
                idspec.Text = Convert.ToString(maxl + 1);
                namespec.Text = "";
                
                addspec.Text = "Добавить";
            }
        }
        void adddiag(Object sender, EventArgs e)
        {
             MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();

             if (adddiagnoz.Text == "Добавить")
            { 
            int f = 0; int maxl = 0;
            int r = mysql.InsertDiagnoz(Convert.ToInt32(iddiag.Text), named.Text, number.Text, about.Text, Convert.ToInt32(blokdiag.SelectedValue));
            if (r != 0)
            {
                for (int i = 0; i < simptoms.Items.Count; i++)
                {
                    if (simptoms.Items[i].Selected == true)
                        f = mysql.InsertDSimptom(r, Convert.ToInt32(simptoms.Items[i].Value));
                }
            }
            diaglist.Items.Clear();
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
            int maxd = 0;
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();
            foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
            {
                diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                if (s.id > maxd)
                    maxd = s.id;
            }
            iddiag.Text = Convert.ToString(zd.Count);
            }
             if (adddiagnoz.Text == "Сохранить изменения")
             {
                 mysql.UpdateDiagnoz(Convert.ToInt32(iddiag.Text), named.Text, number.Text, about.Text, Convert.ToInt32(blokdiag.SelectedValue));
                 int maxl = 0;
                 diaglist.Items.Clear();
                 List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> lks = mysql.SelectZabDiagnoz();
                 List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> lk = lks.OrderBy(o => o.name).ToList();
                 foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in lk)
                 {
                     diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                     if (s.id > maxl)
                         maxl = s.id;
                 }
                 iddiag.Text = Convert.ToString(maxl + 1);
                 named.Text = "";
                 number.Text = "";
                 about.Text = "";
                 adddiagnoz.Text = "Добавить";
             }
        }
        void addlek(Object sender, EventArgs e)
        {  MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();

             if (addlekarstvo.Text == "Добавить")
            {
            leklist.Items.Clear();
            int r = mysql.InsertLek(Convert.ToInt32(idlek.Text), namelek.Text, dozlek.Text, typelek.Text);
            List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
            int maxl = 0;
            List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
            leklist.Items.Clear();
            foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
            {
                leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                if (s.id > maxl)
                    maxl = s.id;
            }
            idlek.Text = Convert.ToString(maxl + 1);
            }
             if (addlekarstvo.Text == "Сохранить изменения")
             {
                 mysql.UpdateLek(Convert.ToInt32(idlek.Text), namelek.Text, dozlek.Text, typelek.Text);
                 int maxl = 0;
                 leklist.Items.Clear();
                 List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
                 List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
                 foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
                 {
                     leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                     if (s.id > maxl)
                         maxl = s.id;
                 }
                 idlek.Text = Convert.ToString(maxl + 1);
                 namelek.Text = "";
                 dozlek.Text = "";
                 for (int i = 0; i < leklist.Items.Count;i++ )
                 {
                     leklist.Items[i].Selected = false;
                 }
                     addlekarstvo.Text = "Добавить";
             }
        }
        void addstrax(Object sender, EventArgs e)
        {
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
               
            if(addstraxbut.Text == "Добавить")
            { 
                int r = mysql.InsertStrax(Convert.ToInt32(idstrax.Text), namestrah.Text, address.Text);
                List<MySqlLib.MySqlData.MySqlExecute.strahovay> lks = mysql.SelectStrah();
                int maxl = 0;
                strahlist.Items.Clear();
                List<MySqlLib.MySqlData.MySqlExecute.strahovay> lk = lks.OrderBy(o => o.name).ToList();
                foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in lk)
                {
                    strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                    if (s.id > maxl)
                        maxl = s.id;
                }
                idstrax.Text = Convert.ToString(maxl + 1);
            }
            if (addstraxbut.Text == "Сохранить изменения")
            {
                mysql.UpdateStrax(Convert.ToInt32(idstrax.Text), namestrah.Text, address.Text);
                int maxl = 0;
                strahlist.Items.Clear();
                List<MySqlLib.MySqlData.MySqlExecute.strahovay> lks = mysql.SelectStrah();
                List<MySqlLib.MySqlData.MySqlExecute.strahovay> lk = lks.OrderBy(o => o.name).ToList();
                foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in lk)
                {
                    strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                    if (s.id > maxl)
                        maxl = s.id;
                }
                idstrax.Text = Convert.ToString(maxl + 1);
                namestrah.Text = "";
                address.Text = "";
                addstraxbut.Text = "Добавить";
            }

        }
        void addsimptom(Object sender, EventArgs e)
        { 
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
               
            if(addsim.Text == "Добавить")
            { 
            int maxl = 0;
            int r = mysql.InsertSimptoms(Convert.ToInt32(idsimp.Text), namesimp.Text, aboutsimp.Text);
            
             List<MySqlLib.MySqlData.MySqlExecute.simptoms> lks = mysql.SelectSimptoms();
            List<MySqlLib.MySqlData.MySqlExecute.simptoms> lk = lks.OrderBy(o => o.name).ToList();
            simptlist.Items.Clear();
            foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in lk)
            {
                simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                if (s.id > maxl)
                    maxl = s.id;
            }
            idsimp.Text = Convert.ToString(maxl + 1);
            }
            if (addsim.Text == "Сохранить изменения")
            {
                mysql.UpdateSimptoms(Convert.ToInt32(idsimp.Text), namesimp.Text, aboutsimp.Text);
                int maxl = 0;
                simptlist.Items.Clear();
                List<MySqlLib.MySqlData.MySqlExecute.simptoms> lks = mysql.SelectSimptoms();
                List<MySqlLib.MySqlData.MySqlExecute.simptoms> lk = lks.OrderBy(o => o.name).ToList();
                foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in lk)
                {
                    simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                    if (s.id > maxl)
                        maxl = s.id;
                }
                idsimp.Text = Convert.ToString(maxl + 1);
                namesimp.Text = "";
                aboutsimp.Text = "";
                addsim.Text = "Добавить";
            }
           
            
            

        }
    </script>
    <table style="width: 400px">
        <tr>
            <td>
                <asp:Button ID="tab0" runat="server" OnClick="tab0_Click" Text="Специализация врача" />
            </td>
            <td>
                <asp:Button ID="tab1" runat="server" OnClick="tab1_Click" Text="Лекарство" />
            </td>
            <td>
                <asp:Button ID="tab3" runat="server" OnClick="tab3_Click" Text="Симптомы" />
            </td>
            <td>
                <asp:Button ID="tab2" runat="server" OnClick="tab2_Click" Text="Диагнозы" />
            </td>

            <td>
                <asp:Button ID="tab4" runat="server" OnClick="tab4_Click" Text="Страховые компании" />
            </td>
        </tr>
    </table>
    <asp:MultiView ID="tabsi" runat="server" ActiveViewIndex="0">

        <asp:View ID="specdoctor" runat="server">
            <table style="width: 100%">
                <tr>
                    <td style="width: 50%; vertical-align:top">
                        <table style="vertical-align:top">
                            <tr>
                                <td colspan="4">Добавить специализацию врача
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 40px; text-align: center">
                                    Наименование<asp:TextBox ID="idspec" Width="40px" Visible="false" TextMode="Number" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 300px; text-align: center">
                                    <asp:TextBox ID="namespec" ToolTip="Наименование спец." Width="300px" runat="server"></asp:TextBox>
                                </td>
                                <td style="text-align: right">
                                    <asp:Button ID="addspec" runat="server" Text="Добавить" OnClick="addspeccom" />
                                </td>

                            </tr>
                        </table>
                    </td>
                    <td style="width: 50%">
                        
                                <asp:CheckBoxList ID="speclist" runat="server"></asp:CheckBoxList><br />
                                <asp:ImageButton ToolTip="Удалить" ID="del" runat="server" ImageUrl="~/images/del.png"  OnClick="del_Click" /><a style="margin-left:10px"></a>
                                <asp:ImageButton ToolTip="Редактировать" ID="edit" runat="server" ImageUrl="~/images/edit.png"  OnClick="edit_Click" /></td>
                       

                </tr>

            </table>
        </asp:View>
        <asp:View ID="lekarstva" runat="server">

            <table style="width: 100%">
                <tr>
                    <td style="width: 50%;vertical-align:top">
                        <table style="text-align:left">
                            <tr>
                                <td colspan="3" style="border-bottom: inset"></td>
                            </tr>
                            <tr>
                                <td colspan="3">Добавить лекарственное средство<asp:TextBox ID="idlek" Width="40px" TextMode="Number" Visible="false" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px;">
                                    Название лекарства
                                </td>

                                <td style="width: 300px; ">
                                    <asp:TextBox ID="namelek" Width="300px" MaxLength="100" ToolTip="Название лекарства" runat="server"></asp:TextBox>
                                </td>
                                </tr>
                                <tr>
                                    <td style="width: 300px; ">Описание дозировки
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="dozlek" ToolTip="Доза лекарства" MaxLength="100" Width="300px" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            <tr>
                                <td style="text-align: left;">Тип лекарства
                                </td>
                                <td style="width: 300px; ">
                                    <asp:DropDownList ID="typelek" ToolTip="Тип лекарства" MaxLength="100" Width="300px" runat="server">
                                         <asp:ListItem Text="Капли" Value="Капли" Selected="True" ></asp:ListItem>
                                        <asp:ListItem Text="Микстуры" Value="Микстуры" ></asp:ListItem>
                                        <asp:ListItem Text="Растворы" Value="Растворы" ></asp:ListItem>
                                        <asp:ListItem Text="Сиропы" Value="Сиропы" ></asp:ListItem>
                                         <asp:ListItem Text="Капсулы" Value="Капсулы" ></asp:ListItem>
                                        <asp:ListItem Text="Мази" Value="Мази" ></asp:ListItem>
                                       <asp:ListItem Text="Настои" Value="Настои" ></asp:ListItem>
                                      <asp:ListItem Text="Пастилки" Value="Пастилки" ></asp:ListItem>
                                        <asp:ListItem Text="Пилюли" Value="Пилюли" ></asp:ListItem>
                                         <asp:ListItem Text="Пластыри" Value="Пластыри" ></asp:ListItem>
                                        <asp:ListItem Text="Сборы" Value="Сборы" ></asp:ListItem>
                                           <asp:ListItem Text="Таблетки" Value="Таблетки" ></asp:ListItem>
                                        
                                       
                                        
                                       
                                         </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td  style="text-align: right">
                                    <asp:Button ID="addlekarstvo" runat="server" Text="Добавить" OnClick="addlek" />
                                </td>

                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align:top;margin-left:30px">
                        <asp:CheckBoxList ID="leklist" runat="server"></asp:CheckBoxList><br /><asp:ImageButton ID="del2" runat="server" ImageUrl="~/images/del.png" OnClick="del2_Click" /><a style="margin-left:10px"></a>
                                <asp:ImageButton ToolTip="Редактировать" ID="edit2" runat="server" ImageUrl="~/images/edit.png"  OnClick="edit2_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="diagnosi" runat="server">
            <table style="width: 100%; text-align: left; vertical-align: top">
                <tr>
                    <td style="width: 50%">

                        <table>
                            <tr>
                                <td colspan="2" style="border-bottom: inset"></td>
                            </tr>
                            <tr>
                                <td colspan="2">Добавить диагноз <!--<a href="http://mkb-10.com/" style="margin-left: 20px">Информация</a>-->
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 300px;">
                                    <asp:TextBox ID="iddiag" Width="10px" Visible="false" runat="server"></asp:TextBox>Название
                                </td>
                                <td style="width: 300px; text-align: center">
                                    <asp:TextBox ID="named" ToolTip="Название диагноза" Width="300px" runat="server"></asp:TextBox>
                                </td>
                                <caption>
                                    <br />
                                </caption>
                            </tr>
                            <tr>
                                <td style="width: 100px;">Описание
                                </td>
                                <td style="width: 300px; text-align: center">
                                    <asp:TextBox ID="about" ToolTip="Описание" TextMode="MultiLine" Width="300px" runat="server"></asp:TextBox>
                                </td>
                                <caption>
                                    <br />
                                </caption>

                            </tr>
                            <tr>

                                <td style="width: 100px;">Номер по МКБ-10</td>
                                <td style="width: 300px; text-align: center; vertical-align: top">
                                    <asp:TextBox ID="number" ToolTip="" Width="300px" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 300px; text-align: center">&nbsp;</td>



                            </tr>
                            <tr>
                                <td colspan="2" style="width: 300px; text-align: center; margin-top: 30px">
                                    <div style="height: 200px; overflow-y: auto">
                                        Симптомы<asp:CheckBoxList ID="simptoms" runat="server" Height="50px">
                                        </asp:CheckBoxList>
                                    </div>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="2" style="width: 300px; text-align: center">Блок заболевания (МКБ-10)
                        <div style="height: 200px; overflow-y: auto; text-align: left">

                            <asp:RadioButtonList ID="blokdiag" runat="server"></asp:RadioButtonList>
                        </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: bottom">
                                    <asp:Button ID="adddiagnoz" runat="server" Text="Добавить" OnClick="adddiag" />
                                </td>

                            </tr>
                        </table>
                    </td>
                    <td style="width: 50%;vertical-align:top">
                        <asp:CheckBoxList ID="diaglist" runat="server"></asp:CheckBoxList><br />
                        <asp:ImageButton ID="del3" runat="server" ImageUrl="~/images/del.png" OnClick="del3_Click" />
                        <a style="margin-left:10px"></a>
                                <asp:ImageButton ToolTip="Редактировать" ID="edit3" runat="server" ImageUrl="~/images/edit.png"  OnClick="edit3_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="simptomi" runat="server">
            <table>
                <tr>
                    <td style="vertical-align:top">
                        <table style="width: 400px;vertical-align:top">
                            <tr>
                                <td colspan="2" style="border-bottom: inset"></td>
                            </tr>

                            <tr>

                                <td>Добавить симптом
                               
                                    <asp:TextBox ID="idsimp" Visible="false" Width="40px" TextMode="Number" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>

                                <td>Название
                                </td>
                                <td style="width: 300px; text-align: center">
                                    <asp:TextBox ID="namesimp" Width="300px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Описание
                                </td>
                                <td style="width: 300px; text-align: center">
                                    <asp:TextBox ID="aboutsimp" Width="300px" MaxLength="250" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: right">
                                    <asp:Button ID="addsim" runat="server" Text="Добавить" OnClick="addsimptom" />


                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align:top">
                        <asp:CheckBoxList ID="simptlist" runat="server">
                        </asp:CheckBoxList><br /><asp:ImageButton ID="del4" runat="server" ImageUrl="~/images/del.png" OnClick="del4_Click" />
                   <a style="margin-left:10px"></a>
                                <asp:ImageButton ToolTip="Редактировать" ID="edit4" runat="server" ImageUrl="~/images/edit.png"  OnClick="edit4_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="strahovie" runat="server">
            <table>
                <tr>
                    <td>

            <table style="width: 400px">
                <tr>
                    <td colspan="2" style="border-bottom: inset"></td>
                </tr>
               
                <tr>
                    <td colspan="2">Добавить страховую компанию
                    </td>
                    <td style="width: 40px; text-align: center">
                        <asp:TextBox ID="idstrax" Visible="false" Width="40px" TextMode="Number" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Название
                    </td>
                    <td style="width: 300px; text-align: center">
                        <asp:TextBox ID="namestrah" Width="300px" MaxLength="80" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Адрес
                    </td>
                    <td style="width: 300px; text-align: center">
                        <asp:TextBox ID="address" Width="300px" MaxLength="200" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right" colspan="2">
                        <asp:Button ID="addstraxbut" runat="server" Text="Добавить" OnClick="addstrax" />
                    </td>
                </tr>
            </table>
                        </td>
                    <td>    
                         <asp:CheckBoxList ID="strahlist" runat="server">
                        </asp:CheckBoxList><br /><asp:ImageButton ID="del5" runat="server" ImageUrl="~/images/del.png" OnClick="del5_Click" />
                   <a style="margin-left:10px"></a>
                                <asp:ImageButton ToolTip="Редактировать" ID="edit5" runat="server" ImageUrl="~/images/edit.png"  OnClick="edit5_Click" /></td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

