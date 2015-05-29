/*using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;

namespace turist.App_Code
{
    /* Классы для работы с word и excel c использованием шаблонов документов.
     * Добавить возможности поиска и замены текста в документе doc.
    *
    public class Wordwork
    {/* Класс для работы с шаблонами word*
        Word._Application application;
        Word._Document document;
        //Обьектные переменные для функций word
        Object missingObj = System.Reflection.Missing.Value;
        Object trueObj = true;
        Object falseObj = false;
        // определяет поведение в случае ошибки при поиске и замене строки, по умолчанию открытый документ и приложенеи Word закрываются
        public bool CloseIFReplaceFailed = true;
        //Код для открытия шаблона с диска
        public Wordwork(string Path)
        {
            //создаем обьект приложения word
            application = new Word.Application();
            // создаем путь к файлу 
            Object templatePathObj = AppDomain.CurrentDomain.BaseDirectory + Path; 
            // если вылетим не этом этапе, приложение останется открытым
            try
            {
                document = application.Documents.Open(ref  templatePathObj,
                    ref missingObj, ref trueObj, ref missingObj, ref missingObj,
                     ref missingObj, ref missingObj, ref missingObj, ref missingObj,
                      ref missingObj, ref missingObj, ref missingObj, ref missingObj,
                       ref missingObj, ref missingObj, ref missingObj);
            }
            catch (Exception error)
            {
                application.Quit(ref missingObj, ref  missingObj, ref missingObj);
                document = null;
                application = null;
                throw error;
            }
            //application.Visible = true;
        }
        // если документ уже закрыт, true
	    private bool documentClosed()
	    {
	        if (application == null || document == null) { return true; }
	        else { return false; }
	    }
        //Сохранение документа в папку
        public bool SaveDoc(string PathToSave)
        {
            try
            {
                //Сохраняем и true обратно, в противном случае false
                Object pathToSaveObj = PathToSave;
                document.Save();
                
                /*
                  document.SaveAs(ref pathToSaveObj, Word.WdSaveFormat.wdFormatDocument, ref missingObj, 
                    ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, 
                    ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, ref missingObj, 
                    ref missingObj);
                *//*
                 return true;
            }
            catch
            {
                return false;
            }
        }
        //Закрытие открытого документа
        public void Closeword()
        {
                //Если документ открыт
                try
                {
                    document.Close(ref trueObj, ref  missingObj, ref missingObj);
                    application.Quit(ref missingObj, ref  missingObj, ref missingObj);
                    document = null;
                    application = null;
                }
                //Вдруг лишний раз вызвали
                catch (Exception error)
                {
                    throw error;
                }
        }
        //Работа с закладками в тексте документа
        public void ReplaceTextByBookmark(string BookmarkName, string ReplaceText)
        {
            Object bookmarkNameObj = BookmarkName;
    	    Word.Range bookmarkRange = null;
    	    try
    	    {
    	        bookmarkRange = document.Bookmarks.get_Item(ref bookmarkNameObj).Range;
    	    }
    	    catch (Exception error)
    	    {
    	        throw new Exception("Ошибка при поиске закладки " + BookmarkName + " в документе Word. Сообщение от Word: " + error.Message);
    	 
    	    }
            bookmarkRange.Font.Size = 12;
            bookmarkRange.Text = ReplaceText;
            bookmarkRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            }
    }
    public class Excelwork
    {/* Класс для работы с шаблонами excel*/
/*
    }

}
*/