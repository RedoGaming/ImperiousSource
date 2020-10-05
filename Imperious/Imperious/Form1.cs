using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;

namespace Imperious
{
    public partial class Imperious : Form
    {
        EasyExploits.Module module = new EasyExploits.Module();
        Point lastPoint;
        public Imperious()
        {
            InitializeComponent();
        }

        private void createTab()
        {
            ScintillaNET.Scintilla wc = new ScintillaNET.Scintilla();
            TabPage tp = new TabPage("Untitled");
            tp.Controls.Add(wc);
            wc.Dock = DockStyle.Fill; scintilla1.Margins[0].Width = 16;
            wc.Styles[Style.Default].Font = "Consolas";
            wc.Styles[Style.Default].Size = 10;
            wc.Styles[Style.Default].ForeColor = Color.White;
            wc.Styles[Style.Default].BackColor = Color.FromArgb(30, 30, 30);
            wc.Margins[1].BackColor = Color.FromArgb(30, 30, 30);
            wc.StyleClearAll();
            wc.Styles[Style.Default].ForeColor = Color.FromArgb(204, 204, 204);
            wc.Styles[Style.Lua.Default].ForeColor = Color.FromArgb(204, 204, 204);
            wc.Styles[Style.Lua.Comment].ForeColor = Color.FromArgb(102, 102, 102);
            wc.Styles[Style.Lua.CommentLine].ForeColor = Color.FromArgb(102, 102, 102);
            wc.Styles[Style.Lua.Number].ForeColor = Color.FromArgb(255, 198, 0);
            wc.Styles[Style.Lua.Word].ForeColor = Color.FromArgb(248, 109, 124);
            wc.Styles[Style.Lua.Word2].ForeColor = Color.FromArgb(132, 214, 247);
            wc.Styles[Style.Lua.Word3].ForeColor = Color.FromArgb(132, 214, 247);
            wc.Styles[Style.Lua.Word4].ForeColor = Color.FromArgb(91, 16, 204);
            wc.Styles[Style.Lua.String].ForeColor = Color.FromArgb(173, 241, 149);
            wc.Styles[Style.Lua.Character].ForeColor = Color.FromArgb(173, 241, 149);
            wc.Styles[Style.Lua.LiteralString].ForeColor = Color.FromArgb(173, 241, 149);
            wc.Styles[Style.Lua.StringEol].BackColor = Color.Pink;
            wc.Styles[Style.Lua.Operator].ForeColor = Color.FromArgb(204, 204, 204);
            wc.Styles[Style.Lua.Preprocessor].ForeColor = Color.FromArgb(102, 255, 204);
            wc.Styles[Style.LineNumber].BackColor = Color.FromArgb(25, 25, 25);
            wc.Styles[Style.LineNumber].ForeColor = Color.White;
            wc.Styles[Style.LineNumber].BackColor = Color.FromArgb(25, 25, 25);
            wc.Styles[Style.LineNumber].ForeColor = Color.White;
            wc.Lexer = Lexer.Lua;
            wc.ScrollWidth = 1;
            wc.ScrollWidthTracking = true; // the default
            wc.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while" + " false true" + " goto");
            wc.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug" + " getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            wc.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan" + " string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult" + " bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift" + " utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            wc.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname" + " coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath" + " require package.cpath package.loaded package.loadlib package.path package.preload");
            wc.SetProperty("fold", "1");
            wc.SetProperty("fold.compact", "1");
            wc.Margins[1].Type = MarginType.ForeColor;
            wc.Margins[1].Mask = Marker.MaskFolders;
            wc.Margins[1].Sensitive = true;
            wc.Margins[1].Width = 9;
            wc.SetFoldMarginColor(true, Color.FromArgb(25, 25, 25));
            wc.SetFoldMarginHighlightColor(true, Color.FromArgb(25, 25, 25));
            for (int i = 25; i <= 31; i++)
            {
                wc.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                wc.Markers[i].SetBackColor(SystemColors.ControlLightLight);
            }
            wc.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            wc.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            wc.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            wc.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            wc.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            wc.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            wc.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            wc.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
            visualStudioTabControl1.TabPages.Add(tp);
            visualStudioTabControl1.SelectedTab = tp;
        }

        private ScintillaNET.Scintilla GetTextBox()
        {

            ScintillaNET.Scintilla fst = null;
            TabPage tp = visualStudioTabControl1.SelectedTab;
            if (tp != null)
            {
                fst = tp.Controls[0] as ScintillaNET.Scintilla;
            }
            return fst;
        }

        private void Imperious_Load(object sender, EventArgs e)
        {
            
            this.TopMost = false;
            var alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numericChars = "0123456789";
            var accentedChars = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
            scintilla1.Margins[0].Width = 16;
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.Styles[Style.Default].ForeColor = Color.White;
            scintilla1.Styles[Style.Default].BackColor = Color.FromArgb(30, 30, 30);
            scintilla1.Margins[1].BackColor = Color.FromArgb(30, 30, 30);
            scintilla1.StyleClearAll();
            scintilla1.Styles[Style.Default].ForeColor = Color.FromArgb(204, 204, 204);
            scintilla1.Styles[Style.Lua.Default].ForeColor = Color.FromArgb(204, 204, 204);
            scintilla1.Styles[Style.Lua.Comment].ForeColor = Color.FromArgb(102, 102, 102);
            scintilla1.Styles[Style.Lua.CommentLine].ForeColor = Color.FromArgb(102, 102, 102);
            scintilla1.Styles[Style.Lua.Number].ForeColor = Color.FromArgb(255, 198, 0);
            scintilla1.Styles[Style.Lua.Word].ForeColor = Color.FromArgb(248, 109, 124);
            scintilla1.Styles[Style.Lua.Word2].ForeColor = Color.FromArgb(132, 214, 247);
            scintilla1.Styles[Style.Lua.Word3].ForeColor = Color.FromArgb(132, 214, 247);
            scintilla1.Styles[Style.Lua.Word4].ForeColor = Color.FromArgb(91, 16, 204);
            scintilla1.Styles[Style.Lua.String].ForeColor = Color.FromArgb(173, 241, 149);
            scintilla1.Styles[Style.Lua.Character].ForeColor = Color.FromArgb(173, 241, 149);
            scintilla1.Styles[Style.Lua.LiteralString].ForeColor = Color.FromArgb(173, 241, 149);
            scintilla1.Styles[Style.Lua.StringEol].BackColor = Color.Pink;
            scintilla1.Styles[Style.Lua.Operator].ForeColor = Color.FromArgb(204, 204, 204);
            scintilla1.Styles[Style.Lua.Preprocessor].ForeColor = Color.FromArgb(102, 255, 204);
            scintilla1.Styles[Style.LineNumber].BackColor = Color.FromArgb(25, 25, 25);
            scintilla1.Styles[Style.LineNumber].ForeColor = Color.White;
            scintilla1.Styles[Style.LineNumber].BackColor = Color.FromArgb(25, 25, 25);
            scintilla1.Styles[Style.LineNumber].ForeColor = Color.White;
            scintilla1.Lexer = Lexer.Lua;
            scintilla1.WordChars = alphaChars + numericChars + accentedChars;
            scintilla1.ScrollWidth = 1;
            scintilla1.ScrollWidthTracking = true; // the default
            scintilla1.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while" + " false true" + " goto");
            scintilla1.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug" + " getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            scintilla1.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan" + " string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult" + " bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift" + " utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            scintilla1.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname" + " coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath" + " require package.cpath package.loaded package.loadlib package.path package.preload");
            scintilla1.SetProperty("fold", "1");
            scintilla1.SetProperty("fold.compact", "1");
            scintilla1.Margins[1].Type = MarginType.ForeColor;
            scintilla1.Margins[1].Mask = Marker.MaskFolders;
            scintilla1.Margins[1].Sensitive = true;
            scintilla1.Margins[1].Width = 9;
            scintilla1.SetFoldMarginColor(true, Color.FromArgb(25, 25, 25));
            scintilla1.SetFoldMarginHighlightColor(true, Color.FromArgb(25, 25, 25));
            for (int i = 25; i <= 31; i++)
            {
                scintilla1.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla1.Markers[i].SetBackColor(SystemColors.ControlLightLight);
            }
            scintilla1.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla1.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla1.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla1.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void yes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            module.ExecuteScript(GetTextBox().Text);
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            module.LaunchExploit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            GetTextBox().Text = "";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                GetTextBox().Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(GetTextBox().Text);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            scintilla1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coding and UI done by Redo Gaming. \n\nAdditional Credits to Pardella Exploits for help with some parts of Imperious.", "Credits -");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            ScriptHub openform = new ScriptHub();
            openform.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Next update!");
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void scintilla1_Click(object sender, EventArgs e)
        {
            var alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numericChars = "0123456789";
            var accentedChars = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
            scintilla1.Margins[0].Width = 16;
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.Styles[Style.Default].ForeColor = Color.White;
            scintilla1.Styles[Style.Default].BackColor = Color.FromArgb(30, 30, 30);
            scintilla1.Margins[1].BackColor = Color.FromArgb(30, 30, 30);
            scintilla1.StyleClearAll();
            scintilla1.Styles[Style.Default].ForeColor = Color.FromArgb(204, 204, 204);
            scintilla1.Styles[Style.Lua.Default].ForeColor = Color.FromArgb(204, 204, 204);
            scintilla1.Styles[Style.Lua.Comment].ForeColor = Color.FromArgb(102, 102, 102);
            scintilla1.Styles[Style.Lua.CommentLine].ForeColor = Color.FromArgb(102, 102, 102);
            scintilla1.Styles[Style.Lua.Number].ForeColor = Color.FromArgb(255, 198, 0);
            scintilla1.Styles[Style.Lua.Word].ForeColor = Color.FromArgb(248, 109, 124);
            scintilla1.Styles[Style.Lua.Word2].ForeColor = Color.FromArgb(132, 214, 247);
            scintilla1.Styles[Style.Lua.Word3].ForeColor = Color.FromArgb(132, 214, 247);
            scintilla1.Styles[Style.Lua.Word4].ForeColor = Color.FromArgb(91, 16, 204);
            scintilla1.Styles[Style.Lua.String].ForeColor = Color.FromArgb(173, 241, 149);
            scintilla1.Styles[Style.Lua.Character].ForeColor = Color.FromArgb(173, 241, 149);
            scintilla1.Styles[Style.Lua.LiteralString].ForeColor = Color.FromArgb(173, 241, 149);
            scintilla1.Styles[Style.Lua.StringEol].BackColor = Color.Pink;
            scintilla1.Styles[Style.Lua.Operator].ForeColor = Color.FromArgb(204, 204, 204);
            scintilla1.Styles[Style.Lua.Preprocessor].ForeColor = Color.FromArgb(102, 255, 204);
            scintilla1.Styles[Style.LineNumber].BackColor = Color.FromArgb(25, 25, 25);
            scintilla1.Styles[Style.LineNumber].ForeColor = Color.White;
            scintilla1.Styles[Style.LineNumber].BackColor = Color.FromArgb(25, 25, 25);
            scintilla1.Styles[Style.LineNumber].ForeColor = Color.White;
            scintilla1.Lexer = Lexer.Lua;
            scintilla1.WordChars = alphaChars + numericChars + accentedChars;
            scintilla1.ScrollWidth = 1;
            scintilla1.ScrollWidthTracking = true; // the default
            scintilla1.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while" + " false true" + " goto");
            scintilla1.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug" + " getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            scintilla1.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan" + " string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult" + " bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift" + " utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            scintilla1.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname" + " coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath" + " require package.cpath package.loaded package.loadlib package.path package.preload");
            scintilla1.SetProperty("fold", "1");
            scintilla1.SetProperty("fold.compact", "1");
            scintilla1.Margins[1].Type = MarginType.ForeColor;
            scintilla1.Margins[1].Mask = Marker.MaskFolders;
            scintilla1.Margins[1].Sensitive = true;
            scintilla1.Margins[1].Width = 9;
            scintilla1.SetFoldMarginColor(true, Color.FromArgb(25, 25, 25));
            scintilla1.SetFoldMarginHighlightColor(true, Color.FromArgb(25, 25, 25));
            for (int i = 25; i <= 31; i++)
            {
                scintilla1.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla1.Markers[i].SetBackColor(SystemColors.ControlLightLight);
            }
            scintilla1.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla1.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla1.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla1.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            scintilla1.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Imperious is made by Redo Gaming.\n\n Thanks to Pardella Exploits for the insight on how to make a good looking script hub, and help with making tabs.\n\n Small thanks to Coco Technologies / Bobby The Cat for the ScintillaNET text box code.", "Credits");
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            createTab();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (visualStudioTabControl1.TabCount < 2)
            {
                MessageBox.Show("Please always leave 1 tab open!");
            }
            else
            {
                TabPage tp = new TabPage("Untitled");
                visualStudioTabControl1.TabPages.Remove(visualStudioTabControl1.SelectedTab);
            }

        }
    }
}
