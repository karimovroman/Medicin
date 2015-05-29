<%@ Page Title="Рабочее место врача" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true" CodeFile="workstop.aspx.cs" Inherits="workstop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p></p>
    <table>
        <tr>
            <td style="width:50%">
                 <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'" >
                    <h3>Мои пациенты</h3>
                    <p class="lead">Просмотр данных пациентов проходивших осмотр</p>
                    <p><a href="pacients.aspx" class="bgy" style="font-size:12px" >> Просмотр</a></p>
                </div>
            </td>
     <!--       <td style="width:50%">
    
       <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Осмотр</h3>
        <p class="lead">Осмотр пациента. Заполнение карты осмотра пациента</p>
        <p><a href="visits.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
        </tr>
        <p></p>
        <tr>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Метрики пациента</h3>
        <p class="lead">Заполнение метрик пациента</p>
        <p><a href="metrics.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Исследования</h3>
        <p class="lead">Просмотреть и внести данные исследований пациента</p>
        <p><a href="researchs.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
        </tr>
        <p></p>
        <tr>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Выписать рецепт</h3>
        <p class="lead">Просмотреть или выписать рацепт пациенту</p>
        <p><a href="recepts.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Лист нетрудоспособности</h3>
        <p class="lead">Просмотреть или выписать лист временной нетрудоспособности</p>
        <p><a href="lists.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
        </tr>         
           <p></p>
        <tr>  
    -->
        
            
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Сообщения</h3>
        <p class="lead">Отправить сообщение лечащему врачу</p>
        <p><a href="sms.aspx" class="bgy" style="font-size:12px" >> Переписка</a></p>
    </div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width:50%">
                 <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'" >
                    <h3>Записи</h3>
                    <p class="lead">Просмотр записей на прием</p>
                    <p><a href="visitslist.aspx" class="bgy" style="font-size:12px" >> Просмотр</a></p>
                </div>
            </td>
            <td id="Выравниватель"></td>
    </table>
   
    <p></p>
</asp:Content>