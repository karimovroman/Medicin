using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_reference : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack) { 
            simptlist.Items.Clear();
            diaglist.Items.Clear();
            leklist.Items.Clear();
            speclist.Items.Clear();
            strahlist.Items.Clear();
            simptoms.Items.Clear();
            blokdiag.Items.Clear();
        }
        if(tabsi.ActiveViewIndex == 0)
        {
            tab0.BackColor = System.Drawing.Color.LightGray;
            tab1.BackColor = System.Drawing.Color.WhiteSmoke;
            tab2.BackColor = System.Drawing.Color.WhiteSmoke;
            tab3.BackColor = System.Drawing.Color.WhiteSmoke;
            tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        }
         if (tabsi.ActiveViewIndex == 1)
        {
            tab1.BackColor = System.Drawing.Color.LightGray;
            tab0.BackColor = System.Drawing.Color.WhiteSmoke;
            tab2.BackColor = System.Drawing.Color.WhiteSmoke;
            tab3.BackColor = System.Drawing.Color.WhiteSmoke;
            tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        if (tabsi.ActiveViewIndex == 2)
        {
            
            tab2.BackColor = System.Drawing.Color.LightGray;
            tab1.BackColor = System.Drawing.Color.WhiteSmoke;
            tab0.BackColor = System.Drawing.Color.WhiteSmoke;
            tab3.BackColor = System.Drawing.Color.WhiteSmoke;
            tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        if (tabsi.ActiveViewIndex == 3)
        {
            tab3.BackColor = System.Drawing.Color.LightGray;
            tab1.BackColor = System.Drawing.Color.WhiteSmoke;
            tab2.BackColor = System.Drawing.Color.WhiteSmoke;
            tab0.BackColor = System.Drawing.Color.WhiteSmoke;
            tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        }
        if (tabsi.ActiveViewIndex == 4)
        {
            tab4.BackColor = System.Drawing.Color.LightGray;
            tab1.BackColor = System.Drawing.Color.WhiteSmoke;
            tab2.BackColor = System.Drawing.Color.WhiteSmoke;
            tab3.BackColor = System.Drawing.Color.WhiteSmoke;
            tab0.BackColor = System.Drawing.Color.WhiteSmoke;
        } MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
       
        if (addsim.Text != "Сохранить изменения") { 
       List<MySqlLib.MySqlData.MySqlExecute.simptoms> simps = mysql.SelectSimptoms();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simp = simps.OrderBy(o => o.name).ToList();
        int maxsim = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in simp)
        {
            simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            simptoms.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxsim)
                maxsim = s.id;
        }
        idsimp.Text = Convert.ToString(maxsim + 1);
        }
        //перезапись таблиц
        //string res = MySqlLib.MySqlData.MySqlExecute.CreateTable();
        //res = res + "";
        if (adddiagnoz.Text != "Сохранить изменения")
        {

            List<MySqlLib.MySqlData.MySqlExecute.zabclas> zcs = mysql.SelectZabClass();
            List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zbs = mysql.SelectZabBlock();

            List<MySqlLib.MySqlData.MySqlExecute.zabclas> zc = zcs.OrderBy(o => o.name).ToList();
            List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zb = zbs.OrderBy(o => o.name).ToList();

            //foreach (MySqlLib.MySqlData.MySqlExecute.zabclas s in zc)
            //{
            //    classdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            //}
            foreach (MySqlLib.MySqlData.MySqlExecute.zabbloc s in zb)
            {
                blokdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            }
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();
            int maxdia = 0;
            foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
            {
                diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                if (s.id > maxdia)
                    maxdia = s.id;
            }
            iddiag.Text = Convert.ToString(maxdia + 1);
        }
        if (addstraxbut.Text != "Сохранить изменения")
        {

            List<MySqlLib.MySqlData.MySqlExecute.strahovay> strs = mysql.SelectStrah();
            List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = strs.OrderBy(o => o.name).ToList();
            foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in str)
            {
                strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            }
            idstrax.Text = Convert.ToString(str.Count);
        } 
        if (addspec.Text != "Сохранить изменения")
        {

            int maxs = 0;
            List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sps = mysql.SelectSpecDoctor();
            List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sp = sps.OrderBy(o => o.name).ToList();
            foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in sp)
            {
                speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                if (s.id > maxs)
                    maxs = s.id;
            }
            idspec.Text = Convert.ToString(maxs + 1);
        }
        if (addlekarstvo.Text != "Сохранить изменения")
        {

            List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
            List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
            int maxl = 0;
            foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
            {
                leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                if (s.id > maxl)
                    maxl = s.id;
            }
            idlek.Text = Convert.ToString(maxl + 1);
        }
        
    }
    protected void addspec_Click(object sender, EventArgs e)
    {
        
    }
    protected void tab0_Click(object sender, EventArgs e)
    {
        tabsi.ActiveViewIndex = 0;
        tab0.BackColor = System.Drawing.Color.LightGray;

        tab1.BackColor = System.Drawing.Color.WhiteSmoke;
        tab2.BackColor = System.Drawing.Color.WhiteSmoke;
        tab3.BackColor = System.Drawing.Color.WhiteSmoke;
        tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        simptlist.Items.Clear();
        diaglist.Items.Clear();
        leklist.Items.Clear();
        speclist.Items.Clear();
        strahlist.Items.Clear();
        simptoms.Items.Clear();
        blokdiag.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simps = mysql.SelectSimptoms();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simp = simps.OrderBy(o => o.name).ToList();
        int maxsim = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in simp)
        {
            simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            simptoms.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxsim)
                maxsim = s.id;
        }
        idsimp.Text = Convert.ToString(maxsim + 1);
        //перезапись таблиц
        //string res = MySqlLib.MySqlData.MySqlExecute.CreateTable();
        //res = res + "";
        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zcs = mysql.SelectZabClass();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zbs = mysql.SelectZabBlock();

        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zc = zcs.OrderBy(o => o.name).ToList();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zb = zbs.OrderBy(o => o.name).ToList();

        //foreach (MySqlLib.MySqlData.MySqlExecute.zabclas s in zc)
        //{
        //    classdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        //}
        foreach (MySqlLib.MySqlData.MySqlExecute.zabbloc s in zb)
        {
            blokdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();

        foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
        {
            diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        iddiag.Text = Convert.ToString(zd.Count);

        List<MySqlLib.MySqlData.MySqlExecute.strahovay> strs = mysql.SelectStrah();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = strs.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in str)
        {
            strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        idstrax.Text = Convert.ToString(str.Count);
        int maxs = 0;
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sps = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sp = sps.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in sp)
        {
            speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxs)
                maxs = s.id;
        }
        idspec.Text = Convert.ToString(maxs + 1);
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
        {
            leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idlek.Text = Convert.ToString(maxl + 1);
    }
    protected void tab1_Click(object sender, EventArgs e)
    {
        tabsi.ActiveViewIndex = 1;
        tab0.BackColor = System.Drawing.Color.WhiteSmoke;

        tab1.BackColor = System.Drawing.Color.LightGray;
        tab2.BackColor = System.Drawing.Color.WhiteSmoke;
        tab3.BackColor = System.Drawing.Color.WhiteSmoke;
        tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        simptlist.Items.Clear();
        diaglist.Items.Clear();
        leklist.Items.Clear();
        speclist.Items.Clear();
        strahlist.Items.Clear();
        simptoms.Items.Clear();
        blokdiag.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simps = mysql.SelectSimptoms();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simp = simps.OrderBy(o => o.name).ToList();
        int maxsim = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in simp)
        {
            simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            simptoms.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxsim)
                maxsim = s.id;
        }
        idsimp.Text = Convert.ToString(maxsim + 1);
        //перезапись таблиц
        //string res = MySqlLib.MySqlData.MySqlExecute.CreateTable();
        //res = res + "";
        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zcs = mysql.SelectZabClass();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zbs = mysql.SelectZabBlock();

        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zc = zcs.OrderBy(o => o.name).ToList();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zb = zbs.OrderBy(o => o.name).ToList();

        //foreach (MySqlLib.MySqlData.MySqlExecute.zabclas s in zc)
        //{
        //    classdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        //}
        foreach (MySqlLib.MySqlData.MySqlExecute.zabbloc s in zb)
        {
            blokdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();

        foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
        {
            diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        iddiag.Text = Convert.ToString(zd.Count);

        List<MySqlLib.MySqlData.MySqlExecute.strahovay> strs = mysql.SelectStrah();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = strs.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in str)
        {
            strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        idstrax.Text = Convert.ToString(str.Count);
        int maxs = 0;
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sps = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sp = sps.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in sp)
        {
            speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxs)
                maxs = s.id;
        }
        idspec.Text = Convert.ToString(maxs + 1);
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
        {
            leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idlek.Text = Convert.ToString(maxl + 1);
    }
    protected void tab2_Click(object sender, EventArgs e)
    {
        tabsi.ActiveViewIndex = 2;
        tab0.BackColor = System.Drawing.Color.WhiteSmoke;

        tab1.BackColor = System.Drawing.Color.WhiteSmoke;
        tab2.BackColor = System.Drawing.Color.LightGray;
        tab3.BackColor = System.Drawing.Color.WhiteSmoke;
        tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        simptlist.Items.Clear();
        diaglist.Items.Clear();
        leklist.Items.Clear();
        speclist.Items.Clear();
        strahlist.Items.Clear();
        simptoms.Items.Clear();
        blokdiag.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simps = mysql.SelectSimptoms();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simp = simps.OrderBy(o => o.name).ToList();
        int maxsim = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in simp)
        {
            simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            simptoms.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxsim)
                maxsim = s.id;
        }
        idsimp.Text = Convert.ToString(maxsim + 1);
        //перезапись таблиц
        //string res = MySqlLib.MySqlData.MySqlExecute.CreateTable();
        //res = res + "";
        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zcs = mysql.SelectZabClass();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zbs = mysql.SelectZabBlock();

        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zc = zcs.OrderBy(o => o.name).ToList();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zb = zbs.OrderBy(o => o.name).ToList();

        //foreach (MySqlLib.MySqlData.MySqlExecute.zabclas s in zc)
        //{
        //    classdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        //}
        foreach (MySqlLib.MySqlData.MySqlExecute.zabbloc s in zb)
        {
            blokdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();

        foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
        {
            diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        iddiag.Text = Convert.ToString(zd.Count);

        List<MySqlLib.MySqlData.MySqlExecute.strahovay> strs = mysql.SelectStrah();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = strs.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in str)
        {
            strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        idstrax.Text = Convert.ToString(str.Count);
        int maxs = 0;
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sps = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sp = sps.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in sp)
        {
            speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxs)
                maxs = s.id;
        }
        idspec.Text = Convert.ToString(maxs + 1);
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
        {
            leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idlek.Text = Convert.ToString(maxl + 1);
    }
    protected void tab3_Click(object sender, EventArgs e)
    {
        tabsi.ActiveViewIndex = 3;
        tab0.BackColor = System.Drawing.Color.WhiteSmoke;

        tab1.BackColor = System.Drawing.Color.WhiteSmoke;
        tab2.BackColor = System.Drawing.Color.WhiteSmoke;
        tab3.BackColor = System.Drawing.Color.LightGray;
        tab4.BackColor = System.Drawing.Color.WhiteSmoke;
        simptlist.Items.Clear();
        diaglist.Items.Clear();
        leklist.Items.Clear();
        speclist.Items.Clear();
        strahlist.Items.Clear();
        simptoms.Items.Clear();
        blokdiag.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simps = mysql.SelectSimptoms();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simp = simps.OrderBy(o => o.name).ToList();
        int maxsim = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in simp)
        {
            simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            simptoms.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxsim)
                maxsim = s.id;
        }
        idsimp.Text = Convert.ToString(maxsim + 1);
        //перезапись таблиц
        //string res = MySqlLib.MySqlData.MySqlExecute.CreateTable();
        //res = res + "";
        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zcs = mysql.SelectZabClass();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zbs = mysql.SelectZabBlock();

        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zc = zcs.OrderBy(o => o.name).ToList();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zb = zbs.OrderBy(o => o.name).ToList();

        //foreach (MySqlLib.MySqlData.MySqlExecute.zabclas s in zc)
        //{
        //    classdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        //}
        foreach (MySqlLib.MySqlData.MySqlExecute.zabbloc s in zb)
        {
            blokdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();

        foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
        {
            diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        iddiag.Text = Convert.ToString(zd.Count);

        List<MySqlLib.MySqlData.MySqlExecute.strahovay> strs = mysql.SelectStrah();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = strs.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in str)
        {
            strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        idstrax.Text = Convert.ToString(str.Count);
        int maxs = 0;
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sps = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sp = sps.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in sp)
        {
            speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxs)
                maxs = s.id;
        }
        idspec.Text = Convert.ToString(maxs + 1);
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
        {
            leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idlek.Text = Convert.ToString(maxl + 1);
    }
    protected void tab4_Click(object sender, EventArgs e)
    {
        tabsi.ActiveViewIndex = 4;
        tab0.BackColor = System.Drawing.Color.WhiteSmoke;

        tab1.BackColor = System.Drawing.Color.WhiteSmoke;
        tab2.BackColor = System.Drawing.Color.WhiteSmoke;
        tab3.BackColor = System.Drawing.Color.WhiteSmoke;
        tab4.BackColor = System.Drawing.Color.LightGray;
        simptlist.Items.Clear();
        diaglist.Items.Clear();
        leklist.Items.Clear();
        speclist.Items.Clear();
        strahlist.Items.Clear();
        simptoms.Items.Clear();
        blokdiag.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simps = mysql.SelectSimptoms();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> simp = simps.OrderBy(o => o.name).ToList();
        int maxsim = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in simp)
        {
            simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            simptoms.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxsim)
                maxsim = s.id;
        }
        idsimp.Text = Convert.ToString(maxsim + 1);
        //перезапись таблиц
        //string res = MySqlLib.MySqlData.MySqlExecute.CreateTable();
        //res = res + "";
        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zcs = mysql.SelectZabClass();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zbs = mysql.SelectZabBlock();

        List<MySqlLib.MySqlData.MySqlExecute.zabclas> zc = zcs.OrderBy(o => o.name).ToList();
        List<MySqlLib.MySqlData.MySqlExecute.zabbloc> zb = zbs.OrderBy(o => o.name).ToList();

        //foreach (MySqlLib.MySqlData.MySqlExecute.zabclas s in zc)
        //{
        //    classdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        //}
        foreach (MySqlLib.MySqlData.MySqlExecute.zabbloc s in zb)
        {
            blokdiag.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();

        foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
        {
            diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        iddiag.Text = Convert.ToString(zd.Count);

        List<MySqlLib.MySqlData.MySqlExecute.strahovay> strs = mysql.SelectStrah();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = strs.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in str)
        {
            strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
        }
        idstrax.Text = Convert.ToString(str.Count);
        int maxs = 0;
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sps = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> sp = sps.OrderBy(o => o.name).ToList();
        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in sp)
        {
            speclist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxs)
                maxs = s.id;
        }
        idspec.Text = Convert.ToString(maxs + 1);
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
        {
            leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idlek.Text = Convert.ToString(maxl + 1);
    }
    protected void del_Click(object sender, ImageClickEventArgs e)
    {
            
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            for (int i = 0; i < speclist.Items.Count; i++)
            {     
                if (speclist.Items[i].Selected == true)
                { 
                    mysql.DeleteDoctor(Convert.ToInt32(speclist.Items[i].Value));
                }
            }
            //Page_Load(new object(), new EventArgs());
            int maxl = 0;
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
    protected void del2_Click(object sender, ImageClickEventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        for (int i = 0; i < leklist.Items.Count; i++)
        {
            if (leklist.Items[i].Selected == true)
            {
                mysql.DeleteLek(Convert.ToInt32(leklist.Items[i].Value));
            }
        }
        //Page_Load(new object(), new EventArgs());
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lks = mysql.SelectLekarstvo();
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        leklist.Items.Clear();
        foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo s in lk)
        {
            leklist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idlek.Text = Convert.ToString(maxl + 1);
       
   
    }
    protected void del3_Click(object sender, ImageClickEventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        for (int i = 0; i < diaglist.Items.Count; i++)
        {
            if (diaglist.Items[i].Selected == true)
            {
                mysql.DeleteDiag(Convert.ToInt32(diaglist.Items[i].Value));
            }
        } 
       // Page_Load(new object(), new EventArgs());
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zds = mysql.SelectZabDiagnoz();
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> zd = zds.OrderBy(o => o.name).ToList();
        int maxd = 0;
        diaglist.Items.Clear();
        foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
        {
            diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxd)
                maxd = s.id;
        }
        iddiag.Text = Convert.ToString(zd.Count);
    }
    protected void del4_Click(object sender, ImageClickEventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        for (int i = 0; i < simptlist.Items.Count; i++)
        {
            if (simptlist.Items[i].Selected == true)
            {
                mysql.DeleteSimptom(Convert.ToInt32(simptlist.Items[i].Value));
            }
        } 
        //Page_Load(new object(), new EventArgs());
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> lks = mysql.SelectSimptoms();
        List<MySqlLib.MySqlData.MySqlExecute.simptoms> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        simptlist.Items.Clear();
        foreach (MySqlLib.MySqlData.MySqlExecute.simptoms s in lk)
        {
            simptlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idsimp.Text = Convert.ToString(maxl + 1);
    }
    protected void del5_Click(object sender, ImageClickEventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        for (int i = 0; i < strahlist.Items.Count; i++)
        {
            if (strahlist.Items[i].Selected == true)
            {
                mysql.DeleteStrah(Convert.ToInt32(strahlist.Items[i].Value));
            }
        } 
        //Page_Load(new object(), new EventArgs());
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> lks = mysql.SelectStrah();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> lk = lks.OrderBy(o => o.name).ToList();
        int maxl = 0;
        strahlist.Items.Clear();
        foreach (MySqlLib.MySqlData.MySqlExecute.strahovay s in lk)
        {
            strahlist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxl)
                maxl = s.id;
        }
        idstrax.Text = Convert.ToString(maxl + 1);
    }


    //Команды редактирования 

    protected void edit_Click(object sender, ImageClickEventArgs e)
    {
        int countselectitem = 0;
        for (int i = 0; i < speclist.Items.Count; i++)
        {
            if (speclist.Items[i].Selected == true)
            {
                countselectitem += 1;
            }
        }
        if (countselectitem != 0)
        {
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            MySqlLib.MySqlData.MySqlExecute.specdoctor strah = new MySqlLib.MySqlData.MySqlExecute.specdoctor();
            List<MySqlLib.MySqlData.MySqlExecute.specdoctor> strahs = new List<MySqlLib.MySqlData.MySqlExecute.specdoctor>();
            strahs = mysql.SelectSpecDoctor();
            for (int i = 0; i < speclist.Items.Count; i++)
            {
                if (speclist.Items[i].Selected == true)
                {
                    foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor str in strahs)
                        if (str.id == Convert.ToInt32(speclist.Items[i].Value))
                        {
                            strah = str;
                            break;
                        }
                }
                if (strah.id != 0)
                {
                    break;
                }
            }
            if (strah.id != 0)
            {
                idspec.Text = Convert.ToString(strah.id);
                namespec.Text = strah.name;
                
                addspec.Text = "Сохранить изменения";
            }
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
        }
        else
        {

        }

    }
    protected void edit3_Click(object sender, ImageClickEventArgs e)
    {
        int countselectitem = 0;
        for (int i = 0; i < diaglist.Items.Count; i++)
        {
            if (diaglist.Items[i].Selected == true)
            {
                countselectitem += 1;
            }
        }
        if (countselectitem != 0)
        {
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            MySqlLib.MySqlData.MySqlExecute.zabdiagnoz strah = new MySqlLib.MySqlData.MySqlExecute.zabdiagnoz();
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> strahs = new List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz>();
            strahs = mysql.SelectZabDiagnoz();
            for (int i = 0; i < diaglist.Items.Count; i++)
            {
                if (diaglist.Items[i].Selected == true)
                {
                    foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz str in strahs)
                        if (str.id == Convert.ToInt32(diaglist.Items[i].Value))
                        {
                            strah = str;
                            break;
                        }
                }
                if (strah.id != 0)
                {
                    break;
                }
            }
            if (strah.id != 0)
            {
                List<MySqlLib.MySqlData.MySqlExecute.zabbloc> lks = mysql.SelectZabBlock();
                List<MySqlLib.MySqlData.MySqlExecute.zabdsimptom> zds = mysql.SelectDSimptom(strah.id);
                foreach(MySqlLib.MySqlData.MySqlExecute.zabbloc zb in lks)
                {
                    if (zb.id == strah.idbloc)
                        for (int i = 0; i < blokdiag.Items.Count; i++)
                            if (blokdiag.Items[i].Value == Convert.ToString(zb.id))
                                blokdiag.Items[i].Selected = true;
                }
                foreach (MySqlLib.MySqlData.MySqlExecute.zabdsimptom zd in zds)
                {
                    if (zd.idd == strah.id)
                        for (int i = 0; i < simptoms.Items.Count; i++)
                            if (simptoms.Items[i].Value == Convert.ToString(zd.ids))
                                simptoms.Items[i].Selected = true;
                }
                iddiag.Text = Convert.ToString(strah.id);
                named.Text = strah.name;
                about.Text = strah.about;
                number.Text = strah.number;
                adddiagnoz.Text = "Сохранить изменения";
            }
            int maxl = 0;
            diaglist.Items.Clear();
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> lkes = mysql.SelectZabDiagnoz();
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> lk = lkes.OrderBy(o => o.name).ToList();
            foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in lk)
            {
                diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
                if (s.id > maxl)
                    maxl = s.id;
            }
        }
        else
        {

        }

    }
    protected void edit2_Click(object sender, ImageClickEventArgs e)
    {
        int countselectitem = 0;
        for (int i = 0; i < leklist.Items.Count; i++)
        {
            if (leklist.Items[i].Selected == true)
            {
                countselectitem += 1;
            }
        }
        if (countselectitem != 0)
        {
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            MySqlLib.MySqlData.MySqlExecute.lekarstvo strah = new MySqlLib.MySqlData.MySqlExecute.lekarstvo();
            List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> strahs = new List<MySqlLib.MySqlData.MySqlExecute.lekarstvo>();
            strahs = mysql.SelectLekarstvo();
            for (int i = 0; i < leklist.Items.Count; i++)
            {
                if (leklist.Items[i].Selected == true)
                {
                    foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo str in strahs)
                        if (str.id == Convert.ToInt32(leklist.Items[i].Value))
                        {
                            strah = str;
                            break;
                        }
                }
                if (strah.id != 0)
                {
                    break;
                }
            }
            if (strah.id != 0)
            {
                leklist.SelectedValue = strah.type;
                idlek.Text = Convert.ToString(strah.id);
                namelek.Text = strah.name;
                dozlek.Text = strah.doza;
                addlekarstvo.Text = "Сохранить изменения";
            }
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
        }
        else
        {

        }

    }
    protected void edit4_Click(object sender, ImageClickEventArgs e)
    {
        int countselectitem = 0;
        for (int i = 0; i < simptlist.Items.Count; i++)
        {
            if (simptlist.Items[i].Selected == true)
            {
                countselectitem += 1;
            }
        }
        if (countselectitem != 0)
        {
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            MySqlLib.MySqlData.MySqlExecute.simptoms strah = new MySqlLib.MySqlData.MySqlExecute.simptoms();
            List<MySqlLib.MySqlData.MySqlExecute.simptoms> strahs = new List<MySqlLib.MySqlData.MySqlExecute.simptoms>();
            strahs = mysql.SelectSimptoms();
            for (int i = 0; i < simptlist.Items.Count; i++)
            {
                if (simptlist.Items[i].Selected == true)
                {
                    foreach (MySqlLib.MySqlData.MySqlExecute.simptoms str in strahs)
                        if (str.id == Convert.ToInt32(simptlist.Items[i].Value))
                        {
                            strah = str;
                            break;
                        }
                }
                if (strah.id != 0)
                {
                    break;
                }
            }
            if (strah.id != 0)
            {
                idsimp.Text = Convert.ToString(strah.id);
                namesimp.Text = strah.name;
                aboutsimp.Text = strah.about;
                addsim.Text = "Сохранить изменения";
            }
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
        }
        else
        {

        }

    }
    protected void edit5_Click(object sender, ImageClickEventArgs e)
    {
        
        int countselectitem = 0;
        for (int i = 0; i < strahlist.Items.Count; i++)
        {
            if (strahlist.Items[i].Selected == true)
            {
                countselectitem += 1;
            }
        }
        if (countselectitem != 0)
        { 
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        MySqlLib.MySqlData.MySqlExecute.strahovay strah = new MySqlLib.MySqlData.MySqlExecute.strahovay();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> strahs = new List<MySqlLib.MySqlData.MySqlExecute.strahovay>();
        strahs = mysql.SelectStrah();
        for (int i = 0; i < strahlist.Items.Count; i++)
        {
            if (strahlist.Items[i].Selected == true)
            {
                foreach (MySqlLib.MySqlData.MySqlExecute.strahovay str in strahs)
                    if (str.id == Convert.ToInt32(strahlist.Items[i].Value))
                    {
                        strah = str;
                        break;
                    }
            }
            if (strah.id != 0)
            {
                break;
            }
        }
        if (strah.id != 0)
        {
            idstrax.Text = Convert.ToString(strah.id);
            namestrah.Text = strah.name;
            address.Text = strah.address;
            addstraxbut.Text = "Сохранить изменения";
        }
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
        }
        else
        {

        }

    }
}