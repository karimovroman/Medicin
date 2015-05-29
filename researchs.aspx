<%@ Page Title="Исследование: Добавить новое" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true" CodeFile="researchs.aspx.cs" Inherits="researchs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
      
        void SaveMyInformation(Object sender, EventArgs e)
        {
            int r = 0;
            DBase.MSSQL mssql = new DBase.MSSQL();
            String file = "/Files/" ;
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
                 if(filesup.HasFile)
                    {
                        try
                        {
                            string filename = (filesup.FileName);
                            filesup.SaveAs(Server.MapPath(file) + filename);
                      
                            DBase.isledovanie isl = new DBase.isledovanie(0, Convert.ToInt32(pacid), name.Text, result.Text, comm.Text, DateTime.Now.ToShortDateString(),filename,"",0,Convert.ToInt32(docid));
                             r = mssql.InsertIsledovanie(isl);
                        
                        }
                        catch(Exception ex)
                        {
                            string ttt = ex.Message;
       
                        }
                    } 
                 else
                 {

                     DBase.isledovanie isl = new DBase.isledovanie(0, Convert.ToInt32(pacid), name.Text, result.Text, comm.Text, DateTime.Now.ToShortDateString(),"", "", 0, Convert.ToInt32(docid));
                      r = mssql.InsertIsledovanie(isl);
                 }
            
            
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
        <table runat="server" id="inform">
            <tr >
                <td colspan="2" style="text-align:center">
                    Заполните поля:
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Название исследования:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="300px" id="name" runat="server" ></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td>
                    <asp:Label runat="server" Text="Описание результатов:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="300px" TextMode="MultiLine" Height="50px"   id="result" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label runat="server" Text="Комментарии:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="300px" id="comm" TextMode="MultiLine" Height="50px"  runat="server"></asp:TextBox>
                </td>
            </tr>
            <div id="accordion">
             <tr>
                <td>
                    <asp:Label runat="server" Text="Добавление файлов"></asp:Label>

                </td>
                <td>
                    <asp:FileUpload ID="filesup"  runat="server"></asp:FileUpload>
                </td>
            </tr>
            </div>
            <tr>
                <td colspan="2" style="text-align:right">
                    <br /><asp:Button ID="save" runat="server" OnClick="SaveMyInformation" CssClass="logo" Text="Сохранить результаты" />
                </td>
            </tr>



        </table>

    </div>

    <script>
        $( "#accordion" ).accordion();
    </script>
</asp:Content>

