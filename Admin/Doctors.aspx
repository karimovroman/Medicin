<%@ Page Title="Панель администрирования: Расписание доктора" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Doctors.aspx.cs" Inherits="Admin_doctor" %>
<%@ Reference Control="~/Templates/time.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="doctorselect" runat="server">
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <h1>Выберите доктора</h1> <asp:Label id="doctorid" Visible="false" runat="server" Text="0" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="doctorsselect" OnSelectedIndexChanged="doctorsselect_SelectedIndexChanged"  OnTextChanged="doctorsselect_SelectedIndexChanged" runat="server" ></asp:DropDownList>
                        <asp:ImageButton ID="refresh" runat="server" ImageUrl="~/images/refresh-icon-1280x1024.jpg" OnClick="refresh_Click" Width="16px" Height="16px" />
                    </td>
                </tr>
               
            </table>

        
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
               <tr>
                    <td>
                        <asp:ImageButton ID="del" runat="server" Text="Очистить расписание для выбранного врача" OnClick="delete_Click" ImageUrl="~/images/del.png" />
                        <asp:LinkButton id="delete" text="Очистить расписание для выбранного врача" OnClick="delete_Click" runat="server"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="molist" runat="server" ></asp:DropDownList>
                    </td>
                </tr>

                <div id="timeselect">

                    <table style="width: 490px;visibility:collapse">
                        <tr>
                            <td style="width: 50%">
                                <asp:LinkButton ID="prev" Text="< предыдущая" OnClick="prev_Click" runat="server"></asp:LinkButton>
                            </td>
                            <td style="width: 50%; text-align: right">
                                <asp:LinkButton ID="next" Text="следущая >" OnClick="next_Click" runat="server"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>

                    <h1>
                        <asp:Label ID="month" runat="server"></asp:Label>
                        <asp:Label ID="daycontr" runat="server" Visible="false" Text="7"></asp:Label>
                    </h1>
                    <table>
                        <tr>
                            <td style="width: 70px">
                                <h1>ПН</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ВТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>СР</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ЧТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ПТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>СБ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ВС</h1>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h1>
                                    <asp:Label ID="ch1" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch2" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch3" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch4" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch5" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch6" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch7" runat="server"></asp:Label></h1>
                            </td>
                        </tr>

                        <tr style="text-align: center; vertical-align: top">
                            <td style="width: 70px">
                                <div runat="server">
                                        <asp:CheckBoxList ID="pn" runat="server"></asp:CheckBoxList>
                                    
                                </div>
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="vt" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="sr" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="ht" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="pt" runat="server"></asp:CheckBoxList>
                               
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="sb" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="vs" runat="server"></asp:CheckBoxList>
                               
                            </td>
                        </tr>
                        
                    </table>
                    <table>
                        <tr>
                            <td style="width: 70px">
                                <h1>ПН</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ВТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>СР</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ЧТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ПТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>СБ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ВС</h1>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h1>
                                    <asp:Label ID="ch11" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch22" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch33" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch44" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch55" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch66" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch77" runat="server"></asp:Label></h1>
                            </td>
                        </tr>

                        <tr style="text-align: center; vertical-align: top">
                            <td style="width: 70px">
                                <div runat="server">
                                        <asp:CheckBoxList ID="pn2" runat="server"></asp:CheckBoxList>
                                    
                                </div>
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="vt2" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="sr2" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="ht2" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="pt2" runat="server"></asp:CheckBoxList>
                               
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="sb2" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="vs2" runat="server"></asp:CheckBoxList>
                               
                            </td>
                        </tr>
                        
                        <table>
                        <tr>
                            <td style="width: 70px">
                                <h1>ПН</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ВТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>СР</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ЧТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ПТ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>СБ</h1>
                            </td>
                            <td style="width: 70px">
                                <h1>ВС</h1>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h1>
                                    <asp:Label ID="ch111" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch222" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch333" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch444" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch555" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch666" runat="server"></asp:Label></h1>
                            </td>
                            <td>
                                <h1>
                                    <asp:Label ID="ch777" runat="server"></asp:Label></h1>
                            </td>
                        </tr>

                        <tr style="text-align: center; vertical-align: top">
                            <td style="width: 70px">
                                <div runat="server">
                                        <asp:CheckBoxList ID="pn3" runat="server"></asp:CheckBoxList>
                                    
                                </div>
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="vt3" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="sr3" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="ht3" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="pt3" runat="server"></asp:CheckBoxList>
                               
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="sb3" runat="server"></asp:CheckBoxList>
                                
                            </td>
                            <td style="width: 70px">
                                    <asp:CheckBoxList ID="vs3" runat="server"></asp:CheckBoxList>
                               
                            </td>
                        </tr>
                        
                    </table>
                        <table style="width:490px" >
                     <tr>
                            <td colspan="7" style="text-align:right">
                                <asp:Button ID="savedesk" CssClass="mbg" runat="server" OnClick="savedesk_Click" Text="Сохранить расписание" />
                            </td>
                        </tr>
                </table>
                        </div>
            </table>
                    </table>
                    

        </asp:View>
        
    </asp:MultiView>
</asp:Content>

