﻿<%@ Page Title="Пациент" Language="C#" MasterPageFile="~/SitePatient.master" AutoEventWireup="true" CodeFile="patient.aspx.cs" Inherits="patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p></p>
    <table>
        <tr>
            <td style="width:50%">
                 <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'" >
                    <h3>Запись на прием к врачу</h3>
                    <p class="lead">Система предназначена для записи на прием к врачу</p>
                    <p><a href="recordmo.aspx" class="bgy" style="font-size:12px" >> Записаться</a></p>
                </div>
            </td>
            <td style="width:50%">
          
    <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Моя медицинская карта</h3>
        <p class="lead">Просмотр данных электронной медицинской карты</p>
        <p><a href="mycard.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
        </tr>
        <p></p>
        <tr>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Данные пациента</h3>
        <p class="lead">Внести или изменить данные пациента</p>
        <p><a href="myinformation.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Сообщения</h3>
        <p class="lead">Отправить сообщение лечащему врачу</p>
        <p><a href="sms.aspx" class="bgy" style="font-size:12px" >> Переписка</a></p>
    </div>
            </td>
        </tr>
    </table>
   
    <p></p>
    
</asp:Content>

