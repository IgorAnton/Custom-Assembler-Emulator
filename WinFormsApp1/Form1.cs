namespace WinFormsApp1
{
    using System.CodeDom.Compiler;
    using System.Text.RegularExpressions;

    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            richTextBox3.Font = richTextBox2.Font;
            richTextBox2.Select();
            AddLineNumbers();
            Memory.initOPCODES();
            Memory.initMACHINESTATE();
            
        }
        

        private static void makeLabel(ref String[] code,int i)
        {
            String[] s = code[i].Split(':', 2);
            s[0] = s[0].Trim().ToUpper();
            s[1] = s[1].Trim();
            Config.labels[s[0]] = i;
            code[i] = s[1];
        }

        public void parse(String[] code)
        {
            int n = code.Length;

            for(int i = 0; i < n; i++)
            {
                if (code[i] == null)
                    continue;

                if (code[i].Contains(':'))
                {
                    makeLabel(ref code, i);
                }
            }

            while(Config.RUNNIGN)
            {
                if (code[Config.codeIndex] == null)
                    continue;

                String[] s = code[Config.codeIndex].Split(' ',2);

                NAMES op_code = KMOPR.reslove(s[0]);

                KMOPR.execute(op_code, code[Config.codeIndex]);
                Config.PC += 4;
                Config.codeIndex++;
            }
        }
        private void run()
        {
            int n = richTextBox2.Lines.Count();

            if(n == 0)
            {
                return;
            }

            String[] code = new String[n];
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                string s = richTextBox2.Lines[i].ToString().ToUpper().Trim();

                if (s == "")
                    continue;

                code[j] = s;
                j++;

            }
            parse(code);
        }

        public  void compile(String[] code)
        {
            

            int n = code.Length;

            for (int i = 0; i < n; i++)
            {
                if (code[i] == null)
                    continue;

                if (code[i].Contains(':'))
                {
                    makeLabel(ref code, i);
                }
            }

            int ind = 0;

            int PC = 0x1000;

            for(; ind < n; ind++)
            {
                if (code[ind] == "" || code[ind] == null)
                    continue;
                
                String[] s = new string[2];
                s[0] = "";
                s[1] = "";

                s = code[ind].Split(' ', 2);
                String[] ops = new string[1];
                if (s.Length > 1 && s[1] != "")
                {
                     ops = s[1].Split(',');

                    trimOps(ref ops);
                }

                

                if (Config.isBranch(s[0]))
                {

                    Config.instrucitonsInBinary[PC] = Memory.formBranch(s[0], Convert.ToString(Config.labels[s[1]]*4 + 0x1000 ,2));

                }
                else
                {
                    Config.instrucitonsInBinary[PC] = Memory.formMemory(s[0], ops);
                }

                PC += 4;
            }
            



        }

        public  void buildCode()
        {
            int n = richTextBox2.Lines.Count();


            String[] code = new String[n];
            int j = 0;
            for (int i = 0; i < n; i++)
            {
                string s = richTextBox2.Lines[i].ToString().ToUpper().Trim();

                if (s == "")
                    continue;

                code[j] = s;
                j++;

            }


            compile(code);

        }



        private void button5_Click(object sender, EventArgs e)
        {
            Config.resetConfig();
            textBox2.Clear();

            buildCode();

            run();
            
            textBox2.AppendText(Config.HALT_MSG);
            textBox2.AppendText(Environment.NewLine);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTextBox1    
            int First_Index = richTextBox2.GetCharIndexFromPosition(pt);
            int First_Line = richTextBox2.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTextBox1    
            int Last_Index = richTextBox2.GetCharIndexFromPosition(pt);
            int Last_Line = richTextBox2.GetLineFromCharIndex(Last_Index);
            
            // set Center alignment to LineNumberTextBox    
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumberTextBox text to null & width to getWidth() function value    
            richTextBox3.Text = "";
            richTextBox3.Width = this.getWidth();
            richTextBox3.Font = new Font("Courier New", 14, FontStyle.Bold);
            // now add each line number to LineNumberTextBox upto last line    
            for (int i = First_Line + 1; i < Last_Line + 2 ; i++) // 2
            {
                richTextBox3.Text += i  + "\n";
            }
        }
        public int getWidth()
        {
            int w = 25;
            // get total lines of richTextBox1    
            int line = richTextBox2.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTextBox2.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTextBox2.Font.Size;
            }
            else
            {
                w = 50 + (int)richTextBox2.Font.Size ;
            }

            return w;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "")
            {
                AddLineNumbers();
            }
            //syntax highlighting
            int start = 0, end = 0;
            try
            {
                for (start = richTextBox2.SelectionStart - 1; start > 0; start--)
                {
                    if (richTextBox2.Text[start] == '\n' || richTextBox2.Text[start-1] == ':')
                    {
                        start++;
                        break;
                    }
                }

                for (end = richTextBox2.SelectionStart; end < richTextBox2.Text.Length; end++)
                {
                    if (richTextBox2.Text[end] == '\n'  ) break;
                }
                String line = richTextBox2.Text.Substring(start, end - start);

                int selectionStart = richTextBox2.SelectionStart;
                int selectionLength = richTextBox2.SelectionLength;
                Regex r = new Regex("([ \\t{};:])");
                string[] tokens = r.Split(line);

                for (int i = 0; i < tokens.Length; i++)
                {
                    tokens[i] = tokens[i].ToUpper().Trim();
                }

                int index = start;

                foreach (string token in tokens)
                {
                    richTextBox2.SelectionStart = index;
                    richTextBox2.SelectionLength = token.Length;
                    richTextBox2.SelectionColor = Color.Black;
                    richTextBox2.SelectionFont = new Font("Courier New", 14, FontStyle.Regular);
                    String[] keywords = {"qwe", "ADD", "MOV", "SUB", "DIV" ,"MUL","CMP" ,"HALT", "MOD","JSR","RTS", "JUMP","LD","ST","PUSH", "CLR" ,"POP" ,"INC", "DEC", "BEQ" ,"BNEQ" ,"BLSS" , "BGT","BGE","BLEQ", "AND", "OR" , "XOR" ,"LSH", "RSH"}; //dodati jos

                    for (int i = 0; i < keywords.Length; i++)
                    {
                        if (keywords[i] == token)
                        {
                            richTextBox2.SelectionColor = Color.Blue;
                            richTextBox2.SelectionFont = new Font("Courier New", 14, FontStyle.Bold);
                            break;
                        }
                        

                        index += token.Length;
                    }


                }

                richTextBox2.SelectionStart = selectionStart;
                richTextBox2.SelectionLength = selectionLength;
            }catch(Exception )
            {

            }

        }


        private void richTextBox2_VScroll_1(object sender, EventArgs e)
        {
            richTextBox3.Text = "";
            AddLineNumbers();
            richTextBox3.Invalidate();
        }

        private void richTextBox2_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = richTextBox2.GetPositionFromCharIndex(richTextBox2.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void richTextBox2_FontChanged(object sender, EventArgs e)
        {
            richTextBox3.Font = richTextBox2.Font;
            richTextBox2.Select();
            AddLineNumbers();
        }

        private void richTextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox2.Select();
            richTextBox3.DeselectAll();
        }

        private void richTextBox2_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string s = File.ReadAllText(ofd.FileName);
                richTextBox2.Text = s;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fname = saveFileDialog1.FileName;
            File.WriteAllText(fname, richTextBox2.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            
            
        }

        private static void trimOps(ref String[] ops)
        {
            for (int i = 0; i < ops.Length; i++)
            {
                ops[i] = ops[i].Trim();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buildCode();
        }
    }
}