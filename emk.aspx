<%@ Page Title="ЭМК" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true" CodeFile="emk.aspx.cs" Inherits="emk_doc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script runat="server">
      
        void SaveMyInformation(Object sender, EventArgs e)
        {
            int r = 0;
            DBase.MSSQL mssql = new DBase.MSSQL();

            HttpCookie cookie = Request.Cookies["patient"];
            if (cookie != null)
            {
                pacid = cookie["idpatient"];
            }
            else
                Response.Redirect("pacients.aspx");
            HttpCookie cookiee = Request.Cookies["user"];
            if (cookiee != null)
            {
                if (cookiee["typeuser"] == "doctor")
                    docid = cookiee["iduser"];
            }
            else
                Response.Redirect("pacients.aspx");
            DBase.emk emk = new DBase.emk();

            //Заполняем поля данными
            emk.Grupkrov = grupa.Text;
            emk.Rezus = rezus.Text;
            emk.Kategreben = rebenok.Text;
            emk.Kategsocial = katyceta.Text;
            emk.Grupzdorov = zdorgrupa.Text;
            emk.Kyrenie = kyren.Text;
            emk.Alcogol = alkog.Text;
            emk.Narkot = narkom.Text;
            emk.Alerg = allerg.Text;
            emk.Neperen = neperen.Text;
            emk.Haract = xarak.Text;
            emk.Anamnez = semanam.Text;
            emk.Invalid = inval.Text;
            emk.Otklon = otkl.Text;
            emk.Psihomotor = psihmot.Text;
            emk.Intelect = intel.Text;
            emk.Medrab = Convert.ToInt32(docid);
            emk.Idp = Convert.ToInt32(pacid);
            emk.Id = 0;

            emk.Time = DateTime.Now.ToShortDateString();

            r = mssql.InsertEmk(emk);
            if (r != 0)
                info.Text = "Запись произведена";
            else
                info.Text = "Запись не произведена";
        }
    </script>


    <style type="text/css">
        .cardFile.profile {
            margin: 0 0 5px 0;
        }

        .cardFile {
            min-height: 50px;
            border: 1px solid #FFF;
            position: relative;
            margin: 15px 0;
        }

        .tContent {
            -webkit-background-clip: border-box;
            -webkit-background-origin: padding-box;
            -webkit-background-size: auto;
            -webkit-box-shadow: rgba(0, 0, 0, 0.298039) -3px 2px 4px 0px;
            background-attachment: scroll;
            background-clip: border-box;
            background-color: rgba(0, 0, 0, 0);
            background-image: url(https://doctor30.ru/design/common/img/cardContentbox.jpg);
            background-origin: padding-box;
            background-size: auto;
            border-bottom-color: rgb(236, 236, 236);
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
            border-bottom-style: solid;
            border-bottom-width: 1px;
            border-image-outset: 0px;
            border-image-repeat: stretch;
            border-image-slice: 100%;
            border-image-source: none;
            border-image-width: 1;
            border-left-color: rgb(236, 236, 236);
            border-left-style: solid;
            border-left-width: 1px;
            border-right-color: rgb(236, 236, 236);
            border-right-style: solid;
            border-right-width: 1px;
            border-top-color: rgb(236, 236, 236);
            border-top-left-radius: 10px;
            border-top-right-radius: 10px;
            border-top-style: solid;
            border-top-width: 1px;
            box-shadow: rgba(0, 0, 0, 0.298039) -3px 2px 4px 0px;
            clear: both;
            color: rgb(0, 0, 238);
            cursor: auto;
            display: block;
            font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;
            height: 30px;
            margin-bottom: 5px;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
            outline-color: rgb(0, 0, 238);
            outline-style: none;
            outline-width: 0px;
            padding-bottom: 5px;
            padding-left: 10px;
            padding-right: 10px;
            padding-top: 0px;
            text-decoration: none;
            width: 331px;
        }
    </style>



    <div>
        <div id="inform" style="width: 100%"></div>
        <table runat="server">
            <tr>
                <td>



                    <table id="emk-t" width="100%" style="margin-left: 100px">
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Label ID="info" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">Заполните поля:
                            </td>

                        </tr>

                        <tr align="left">
                            <td width="250px">Группа крови:
                
                    
                            </td>
                            <td width="250px">
                                <asp:DropDownList ID="grupa" Width="250px" runat="server">
                                    <asp:ListItem Value="Нет данных" Text="Нет данных" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="α и β: первая" Text="α и β: первая"></asp:ListItem>
                                    <asp:ListItem Value="A и β: вторая" Text="A и β: вторая"></asp:ListItem>
                                    <asp:ListItem Value="α и B: третья" Text="α и B: третья"></asp:ListItem>
                                    <asp:ListItem Value="A и B: четвёртая" Text="A и B: четвёртая"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Резус фактур:</td>
                            <td width="250px">
                                <asp:DropDownList ID="rezus" Width="250px" runat="server">
                                    <asp:ListItem Value="Нет данных" Text="Нет данных" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="Rh+ положительный" Text="Rh+ положительный"></asp:ListItem>
                                    <asp:ListItem Value="Rh- отрицательный" Text="Rh- отрицательный"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Категория ребенка:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="rebenok"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[а-яА-Я\s*,-;:]{1,50}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="rebenok" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Категория учета в трудной ситуации:</td>
                            <td width="250px">
                                <asp:DropDownList ID="katyceta" Width="250px" runat="server">
                                    <asp:ListItem Value="Нет данных" Text="Нет данных" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="дети-инвалиды" Text="дети-инвалиды"></asp:ListItem>
                                    <asp:ListItem Value="дети, оставшиеся без попечения родителей" Text="дети, оставшиеся без попечения родителей"></asp:ListItem>
                                    <asp:ListItem Value="дети с ограниченными возможностями здоровья" Text="дети с ограниченными возможностями здоровья"></asp:ListItem>
                                    <asp:ListItem Value="дети - жертвы насилия" Text="дети - жертвы насилия"></asp:ListItem>
                                    <asp:ListItem Value="дети с отклонениями в поведении" Text="дети с отклонениями в поведении"></asp:ListItem>
                                    <asp:ListItem Value="дети, проживающие в малоимущих семьях" Text="дети, проживающие в малоимущих семьях"></asp:ListItem>


                                </asp:DropDownList></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Группа здоровья:</td>
                            <td width="250px">
                                <asp:DropDownList ID="zdorgrupa" Width="250px" runat="server">
                                    <asp:ListItem Value="Нет данных" Text="Нет данных" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="I группа" Text="I группа"></asp:ListItem>
                                    <asp:ListItem Value="II-A группа" Text="II-A группа"></asp:ListItem>
                                    <asp:ListItem Value="II-Б группа" Text="II-Б группа"></asp:ListItem>
                                    <asp:ListItem Value="III группа" Text="III группа"></asp:ListItem>
                                    <asp:ListItem Value="IV группа" Text="IV группа"></asp:ListItem>
                                    <asp:ListItem Value="V группа" Text="V группа"></asp:ListItem>

                                </asp:DropDownList></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">
                                <p>Вредные привычки пациента</p>
                                Курение:</td>
                            <td width="250px" style="vertical-align: bottom">
                                <asp:DropDownList ID="kyren" Width="250px" runat="server">
                                    <asp:ListItem Value="Да" Text="Да"></asp:ListItem>
                                    <asp:ListItem Value="Нет" Text="Нет" Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Алкоголизм:</td>
                            <td width="250px">
                                <asp:DropDownList ID="alkog" Width="250px" runat="server">
                                    <asp:ListItem Value="Да" Text="Да"></asp:ListItem>
                                    <asp:ListItem Value="Нет" Text="Нет" Selected="True"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Наркомания:</td>
                            <td width="250px">
                                <asp:DropDownList ID="narkom" Width="250px" runat="server">
                                    <asp:ListItem Value="Да" Text="Да"></asp:ListItem>
                                    <asp:ListItem Value="Нет" Text="Нет" Selected="True"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Аллергический анамнез:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="allerg"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="allerg" TextMode="MultiLine" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Непереносимость препаратов:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="neperen"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="neperen" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Характерные особенности:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="xarak"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="xarak" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Семейный анамнез:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="semanam"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="semanam" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Инвалидность:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="inval"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="inval" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Отклонения развития:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="otkl"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="otkl" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Психомоторные функции:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="psihmot"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="psihmot" Width="250px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr align="left">
                            <td width="250px">Интелект:<asp:RegularExpressionValidator ValidationGroup="emk" ForeColor="#ff3300" runat="server"
                                ControlToValidate="intel"
                                ErrorMessage="Вы ввели не текст."
                                ValidationExpression="[[а-яА-Я\s*0-9,-;:]{1,150}" /></td>
                            <td width="250px">
                                <asp:TextBox ID="intel" Width="250px" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td colspan="2" style="text-align: right">
                                <br />
                                <asp:Button ID="save" runat="server" OnClick="SaveMyInformation" ValidationGroup="emk" CssClass="logo" Text="Сохранить результаты" />
                            </td>
                        </tr>
                    </table>




                </td>
            </tr>

        </table>

    </div>

    <script>
        $("#accordion").accordion();
    </script>


</asp:Content>

