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
        }
       
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
        int maxdia = 0;
        foreach (MySqlLib.MySqlData.MySqlExecute.zabdiagnoz s in zd)
        {
            diaglist.Items.Add(new ListItem(s.name, Convert.ToString(s.id)));
            if (s.id > maxdia)
                maxdia = s.id;
        }
        iddiag.Text = Convert.ToString(maxdia + 1);

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
            if(s.id > maxl)
                maxl = s.id;
        }
        idlek.Text = Convert.ToString(maxl +1 );

        
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
        mysql.DeleteDoctor(Convert.ToInt32(speclist.SelectedValue));
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
        mysql.DeleteLek(Convert.ToInt32(leklist.SelectedValue));
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
        mysql.DeleteDiag(Convert.ToInt32(diaglist.SelectedValue));
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
        mysql.DeleteSimptom(Convert.ToInt32(simptlist.SelectedValue));
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
        mysql.DeleteStrah(Convert.ToInt32(strahlist.SelectedValue));
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
    protected void edit_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void edit2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void edit3_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void edit4_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void edit5_Click(object sender, ImageClickEventArgs e)
    {

    }
}