using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;

namespace ScarLanguage_Version1._1
{
    public partial class Form1 : Form
    {
        Hashtable varType = new Hashtable();
        Hashtable varData = new Hashtable();
        string datatype;
        string Key;
        string NewTech = null,NewTech1=null;
        string Cmpline = null;
        string stringType = null;
        bool flag = true;
        DataTable dt = new DataTable();
        string otherformdata = null;
        public Form1()
        {

            InitializeComponent();
        }
        public Form1(string data)
        {
            otherformdata = data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richtxtInputCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dt.Clear();
            richtxtResult.Text = string.Empty;
            rtxtDatatype.Text = string.Empty;
            varData.Clear();
            varType.Clear();
            string[] lines = richtxtInputCode.Lines;
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].EndsWith(";"))//flad true
                {
                    foreach (var item in lines[i].Trim().Split(';'))
                    {
                        if (item != "")
                        {
                            if (item.Trim().Split(' ')[0].Equals("INT") || item.Trim().Split(' ')[0].Equals("FLOAT") || item.Trim().Split(' ')[0].Equals("CHAR"))
                            {
                                #region START WITH INT
                                if (new Regex("[ |\t]*INT[ |\t]*@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    VarDeclaration(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*FLOAT[ |\t]*@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    VarDeclaration(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*CHAR[ |\t]*@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    VarDeclaration(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*INT[ |\t]*@{1}[A-Z]+[ |\t]*=[ |\t]*\\d{1,9}[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    VarInsertData(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*FLOAT[ |\t]*@{1}[A-Z]+[ |\t]*=[ |\t]*\\d{1,9}\\.\\d{1,9}f|\\d{1,9}f[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    VarInsertData(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*CHAR[ |\t]*@{1}[A-Z]+[ |\t]*=[ |\t]*[A-Z][ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    VarInsertData(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*INT[ |\t]*@{1}[A-Z]+[ |\t]*[\\,[ |\t@{1}[A-Z]+]*@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    insertVariables(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*FLOAT[ |\t]*@{1}[A-Z]+[ |\t]*[\\,[ |\t@{1}[A-Z]+]*@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    insertVariables(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*CHAR[ |\t]*@{1}[A-Z]+[ |\t]*[\\,[ |\t@{1}[A-Z]+]*@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    insertVariables(Cmpline, i);
                                }
                                else
                                {
                                    //ERRORS AREA
                                    foreach (var item3 in item.Trim().Split(' '))
                                    {
                                        if (item3 != "")
                                        {
                                            if (item3.Trim().Contains("INT") || item3.Trim().Contains("FLOAT") || item3.Trim().Contains("CHAR"))
                                            {
                                                NewTech = item3 + " ";
                                            }
                                            else
                                            {
                                                NewTech += item3;
                                            }
                                        }
                                    }
                                    if (NewTech.EndsWith(";") == false)
                                    {
                                        richtxtResult.Text += " Missing ; At Line " + i.ToString() + "\n";
                                    }
                                    else if (NewTech.Trim().Split(' ')[0].Equals("INT") && !NewTech.Trim().Split(' ')[1].StartsWith("@"))
                                    {
                                        richtxtResult.Text += " Variable Declaration  Error" + NewTech.Trim().Split(' ')[1].First() + " At Line " + i.ToString() + "\n";
                                    }
                                    else if (NewTech.Trim().Split(' ')[0].Equals("INT") && NewTech.Trim().Split('=')[1].Contains("."))
                                    {
                                        richtxtResult.Text += " Value Assigning Error" + NewTech.Trim().Split('=')[1] + " At Line " + i.ToString() + "\n";
                                    }
                                    else if (NewTech.Trim().Split(' ')[0].Equals("FLOAT") && !NewTech.Trim().Split('=')[1].EndsWith("f"))
                                    {
                                        richtxtResult.Text += " Value Assigning Error Missing 'f' " + NewTech.Trim().Split('=')[1] + " At Line " + i.ToString() + "\n";
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "  Error 120 " + item + " At Line " + i.ToString() + "\n";
                                    }

                                    NewTech = null;
                                }
                                #endregion
                            }
                            else if (item.Trim().Split(' ')[0].StartsWith("CIN"))
                            {
                                #region CIN
                                if (new Regex("[ |\t]*CIN>>@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {

                                    foreach (var item3 in item.Trim().Split(' '))
                                    {
                                        if (item3 != "")
                                        {
                                            if (item3.Trim().Contains("INT") || item3.Trim().Contains("FLOAT") || item3.Trim().Contains("CHAR"))
                                            {
                                                NewTech = item3 + " ";
                                            }
                                            else
                                            {
                                                NewTech += item3;
                                            }
                                        }
                                    }
                                    Cmpline = NewTech.Split(';')[0];
                                    takingInPutAction(Cmpline, i);
                                    //NewTech = Cmpline.Trim().Split('>')[2];
                                    NewTech = null;
                                }
                                else
                                {
                                    // if Check first Cin the  >> block
                                    //Error Varaible or not declared or Cin>> command Error
                                    if (item.EndsWith(";") == false)
                                    {
                                        richtxtResult.Text += " Missing ; At Line " + i.ToString() + "\n";
                                    }
                                    else if (lines[i].Contains(">>"))
                                    {
                                        if (!lines[i].Trim().Split('>')[2].StartsWith("@"))
                                        {
                                            richtxtResult.Text += "  Error Missing '@' Of Varaible " + lines[i].Split('>')[2] + " At Line " + i.ToString() + "\n";
                                        }
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "  Error  '>>'  -> " + lines[i] + " At Line " + i.ToString() + "\n";
                                    }
                                }
                                #endregion
                            }
                            else if (item.Trim().Split(' ')[0].StartsWith("COUT"))
                            {
                                #region COUT
                                if (new Regex("[ |\t]*COUT<<@{1}[A-Z]+[ |\t]*;").IsMatch(lines[i]))
                                {

                                    foreach (var item3 in item.Trim().Split(' '))
                                    {
                                        if (item3 != "")
                                        {
                                            if (item3.Trim().Contains("INT") || item3.Trim().Contains("FLOAT") || item3.Trim().Contains("CHAR"))
                                            {
                                                NewTech = item3 + " ";
                                            }
                                            else
                                            {
                                                NewTech += item3;
                                            }
                                        }
                                    }
                                    Cmpline = NewTech.Split(';')[0];
                                    outputAction(Cmpline, i);
                                    //NewTech = Cmpline.Trim().Split('>')[2];
                                    NewTech = null;
                                }
                                else
                                {
                                    // if Check first Cin the  >> block
                                    //Error Varaible or not declared or Cin>> command Error
                                    if (item.EndsWith(";") == false)
                                    {
                                        richtxtResult.Text += " Missing ; At Line " + i.ToString() + "\n";
                                    }
                                    else if (lines[i].Contains("<<"))
                                    {
                                        if (!lines[i].Trim().Split('<')[2].StartsWith("@"))
                                        {
                                            richtxtResult.Text += "  Error Missing '@' Of Varaible " + lines[i].Split('<')[2] + " At Line " + i.ToString() + "\n";
                                        }
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "  Error  '<<'  -> " + lines[i] + " At Line " + i.ToString() + "\n";
                                    }
                                }
                                #endregion
                            }
                            else if (!item.Trim().Split(' ')[0].Equals("INT") || !item.Trim().Split(' ')[0].Equals("FLOAT") || !item.Trim().Split(' ')[0].Equals("CHAR"))
                            {
                                #region WITHOUT START INT
                                 if (new Regex("[ |\t]*@[A-Z]+[ |\t]*=[ |\t]*(@{1}[A-Z]+|\\d{1,9}\\.\\d{1,9}f|\\d{1,9})[ |\t]*([ |\t]*[*+/-]{1}[ |\t]*(@{1}[A-Z]+|\\d{1,9}\\.\\d{1,9}f|\\d{1,9}[ |\t]*))*[ |\t]*;").IsMatch(lines[i]))//DMAS RULES
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    DMASRule(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*@[A-Z]+[ |\t]*=[ |\t]*@[A-Z][ |\t]*;").IsMatch(lines[i]))//@A=@A
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    AssignAlreadyDecVariables(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*@[A-Z]+[ |\t]*=[ |\t]*\\d{1,9}[ |\t]*;").IsMatch(lines[i]))//@A=325
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    AssignAlreadyDecVariables(Cmpline, i);
                                }
                                else if (new Regex("[ |\t]*@[A-Z]+[ |\t]*=[ |\t]*\\d{1,9}\\.\\d{1,9}f|\\d{1,9}f|[a-zA-Z][ |\t]*;").IsMatch(lines[i]))//@A=@A|3.3f|222
                                {
                                    Cmpline = lines[i].Split(';')[0];
                                    AssignAlreadyDecVariables(Cmpline, i);
                                }
                                
                                else
                                {
                                    if (item.EndsWith(";") == false)
                                    {
                                        richtxtResult.Text += " Missing ; At Line " + i.ToString() + "\n";
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "  Error 121 " + item + " At Line " + i.ToString() + "\n";
                                    }
                                }
                                #endregion
                            }
                        }
                        //else
                        //{
                        //    //NOTHING TO DO//
                        //    MessageBox.Show("Error"); 
                        //}
                    }
                }
                else
                {
                    
                    richtxtResult.Text += "Error ';' at Line"+i+"\n";
                   // NewTech1 += lines[i];
                }

                //no line end with ';'

                //  }
                //else
                //{
                //    richtxtResult.Text += " Missing ; At Line " + i.ToString() + "\n";
                //}


            }
            foreach (var item in varType.Keys)
            {
                rtxtDatatype.Text += "Key " + item + " Type " + varType[item] + "\n";
            }
            foreach (var item2 in varData.Keys)
            {
                rtxtDatatype.Text += "Key " + item2 + " Value " + varData[item2] + "\n";
            }
        }

        private void outputAction(string cmpline, int i)
        {
            string cin = cmpline.Split('<')[1];
            string variable = cmpline.Split('<')[2];
            if (varType.ContainsKey(variable))
            {
                richtxtResult.Text += "Ouput => " + varData[variable].ToString() + "\n";
            }
            else
            {
                richtxtResult.Text += "Varaible Are Not Declared " + variable + " At Line " + i.ToString() + " \n";
            }
        }

        private void takingInPutAction(string cmpline, int i)
        {
            string cin = cmpline.Split('>')[1];
            string variable = cmpline.Split('>')[2];
            if (varType.ContainsKey(variable))
            {
                try
                {

                    if (varType[variable].Equals("INT"))
                    {
                        InputTakingForm itf = new InputTakingForm();
                        itf.ShowDialog();
                        string s = InputTakingForm.datatype;
                        if (new Regex("[ |\t]*\\d{1,9}[ |\t]*").IsMatch(s.Trim()))
                        {
                            varData[variable] = Convert.ToInt32(s.Trim());
                        }
                        else
                        {
                            if (s.Contains("."))
                            {
                                richtxtResult.Text += "Error Int Can't Take Decimal Point Value " + s.Trim() + " At Line " + i.ToString() + " \n";
                            }
                            else
                            {
                                richtxtResult.Text += "Parsing Error 221 " + s.Trim() + " At Line " + i.ToString() + " \n";
                            }
                        }
                    }
                    else if (varType[variable].Equals("FLOAT"))
                    {
                        InputTakingForm itf = new InputTakingForm();
                        itf.ShowDialog();
                        string s = InputTakingForm.datatype;
                        if (new Regex("[ |\t]*\\d{1,9}\\.\\d{1,9}f|\\d{1,9}f[ |\t]*").IsMatch(s.Trim()))
                        {
                            varData[variable] = float.Parse(s.Trim().Split('f')[0]) + "f";
                        }
                        else
                        {
                            if (!s.Trim().EndsWith("f"))
                            {
                                richtxtResult.Text += "Error Missing 'f' " + s.Trim() + " At Line " + i.ToString() + " \n";
                            }
                            else if (s.Contains(".").ToString().Count() > 1)
                            {
                                richtxtResult.Text += "Error Float Can't Take More Than 1 Decimal Point Value " + s.Trim() + " At Line " + i.ToString() + " \n";
                            }
                            else
                            {
                                richtxtResult.Text += "Parsing Error 222 " + s.Trim() + " At Line " + i.ToString() + " \n";
                            }
                        }
                    }
                    else if (varType[variable].Equals("CHAR"))
                    {
                        InputTakingForm itf = new InputTakingForm();
                        itf.ShowDialog();
                        string s = InputTakingForm.datatype;
                        if (new Regex("[ |\t]*[A-Z][ |\t]*").IsMatch(s.Trim()))
                        {
                            varData[variable] = char.Parse(s.Trim());
                        }
                        else
                        {
                            if (s.Trim().Length > 1)
                            {
                                richtxtResult.Text += "Char Length Greater than 1 " + s + " At Line " + i.ToString() + " \n";
                            }
                            else
                            {
                                richtxtResult.Text += "Error 223 " + s.Trim() + " At Line " + i.ToString() + " \n";
                            }
                        }
                    }
                    else
                    {
                        richtxtResult.Text += "This DataType Does Not Used In Language " + variable + " At Line " + i.ToString() + " \n";
                    }
                }
                catch (Exception ex)
                {
                    richtxtResult.Text += "Parsing Error 224 " + ex + " At Line " + i.ToString() + " \n";
                }
            }
            else
            {
                richtxtResult.Text += " Variable Are Not Declared " + variable + " At Line " + i.ToString() + "\n";
            }
        }

        private void DMASRule(string cmpline, int i)
        {
            NewTech = null;
            string res = null;
            //string variables = v.Trim().Split(' ')[1];
            foreach (var item in cmpline.Trim().Split(' '))
            {
                if (item != "")
                {
                    foreach (var item1 in item.Trim().Split(' '))
                    {
                        if (item1 != "")
                            NewTech += item1;
                    }
                }

            }
            string LHS = NewTech.Trim().Split('=')[0];
            string RHS = NewTech.Trim().Split('=')[1];
            NewTech = null;
            if (varType.ContainsKey(LHS))
            {
                datatype = varType[LHS].ToString();
                char[] EVAL = RHS.ToCharArray();
                foreach (var zs in EVAL)
                {
                    if (zs != ' ')
                    {
                        if (zs.Equals('@'))
                        {
                            NewTech += zs;
                        }
                        else if (zs.Equals('A') || zs.Equals('B') || zs.Equals('C') || zs.Equals('D') ||
                                                            zs.Equals('E') || zs.Equals('F') || zs.Equals('G') || zs.Equals('H') ||
                                                            zs.Equals('I') || zs.Equals('J') || zs.Equals('K') || zs.Equals('L') ||
                                                            zs.Equals('M') || zs.Equals('N') || zs.Equals('O') || zs.Equals('P') ||
                                                            zs.Equals('Q') || zs.Equals('R') || zs.Equals('S') || zs.Equals('T') ||
                                                            zs.Equals('U') || zs.Equals('V') || zs.Equals('W') || zs.Equals('X') ||
                                                            zs.Equals('Y') || zs.Equals('Z'))
                        {
                            NewTech += zs;
                        }
                        else if (zs.Equals('0') || zs.Equals('1') || zs.Equals('2') || zs.Equals('3') || zs.Equals('4') ||
                           zs.Equals('5') || zs.Equals('6') || zs.Equals('7') || zs.Equals('8') || zs.Equals('9') || zs.Equals('.')/*|| zs.Equals('f')*/)
                        {
                            res += zs;
                        }
                        else
                        {

                            if (zs.Equals('+'))
                            {
                                #region Addition
                                if (/*!NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") &&*/ NewTech==null )
                                {
                                    res += "+";
                                }
                                else if (NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech != "")
                                {
                                    if (varType.ContainsKey(NewTech) && varData.ContainsKey(NewTech))
                                    {
                                        try
                                        {
                                            if (varType[NewTech].Equals("INT"))
                                            {
                                                res += Convert.ToInt32(varData[NewTech]) + "+";

                                            }
                                            else if (varType[NewTech].Equals("FLOAT"))
                                            {
                                                res += float.Parse(varData[NewTech].ToString().Trim().Split('f')[0]) + "+";
                                            }
                                            else if (varType[NewTech].Equals("CHAR"))
                                            {
                                                res += Convert.ToUInt32(varData[NewTech.ToLower()]) + "+";
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            richtxtResult.Text += ex + "" + "Lines " + i + " \n";
                                            flag = false;
                                        }
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "Varaible Are Not Declared" + NewTech + "" + "Lines " + i + " \n";
                                        flag = false;
                                    }
                                    NewTech = "";
                                }
                                
                                else
                                {
                                    richtxtResult.Text += "Variable Declaration Error" + NewTech + "" + "Lines " + i + " \n";
                                    flag = false;
                                }
                                #endregion

                            }
                            else if (zs.Equals('-'))
                            {
                                #region Subtraction
                                if (NewTech == null)//
                                {
                                    res += "-";
                                }
                                else if (NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech != "")
                                {
                                    if (varType.ContainsKey(NewTech) && varData.ContainsKey(NewTech))
                                    {
                                        try
                                        {
                                            if (varType[NewTech].Equals("INT"))
                                            {
                                                res += Convert.ToInt32(varData[NewTech.ToLower()]) + "-";

                                            }
                                            else if (varType[NewTech].Equals("FLOAT"))
                                            {
                                                res += float.Parse(varData[NewTech].ToString().Trim().Split('f')[0]) + "-";
                                            }
                                            else if (varType[NewTech].Equals("CHAR"))
                                            {
                                                res += Convert.ToUInt32(varData[NewTech.ToLower()]) + "-";
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            richtxtResult.Text += ex + "" + "Lines " + i + " \n";
                                            flag = false;
                                        }
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "Varaible Are Not Declared" + NewTech + "" + "Lines " + i + " \n";
                                        flag = false;
                                    }
                                    NewTech = "";
                                }
                                //else if (!NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech == null)
                                //{
                                //    res += "-";
                                //}
                                else
                                {
                                    richtxtResult.Text += "Variable Declaration Error" + NewTech + "" + "Lines " + i + " \n";
                                    flag = false;
                                }
                                #endregion

                            }
                            else if (zs.Equals('*'))
                            {
                                #region Multiplication
                                if (/*!NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") ||*/ NewTech == null)//
                                {
                                    res += "*";
                                }
                                else if (NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech != "")
                                {
                                    if (varType.ContainsKey(NewTech) && varData.ContainsKey(NewTech))
                                    {
                                        try
                                        {
                                            if (varType[NewTech].Equals("INT"))
                                            {
                                                res += Convert.ToInt32(varData[NewTech.ToLower()]) + "*";

                                            }
                                            else if (varType[NewTech].Equals("FLOAT"))
                                            {
                                                res += float.Parse(varData[NewTech].ToString().Trim().Split('f')[0]) + "*";
                                            }
                                            else if (varType[NewTech].Equals("CHAR"))
                                            {
                                                res += Convert.ToUInt32(varData[NewTech.ToLower()]) + "*";
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            richtxtResult.Text += ex + "" + "Lines " + i + " \n";
                                            flag = false;
                                        }
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "Varaible Are Not Declared" + NewTech + "" + "Lines " + i + " \n";
                                        flag = false;
                                    }
                                    NewTech = "";
                                }
                                //else if (!NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech == null)
                                //{
                                //    res += "*";
                                //}
                                else
                                {
                                    richtxtResult.Text += "Variable Declaration Error" + NewTech + "" + "Lines " + i + " \n";
                                    flag = false;
                                }
                                #endregion

                            }
                            else if (zs.Equals('/'))
                            {
                                #region Division
                                if (/*!NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") ||*/ NewTech == null)//
                                {
                                    res += "/";
                                }
                                else if (NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech != "")
                                {
                                    if (varType.ContainsKey(NewTech) && varData.ContainsKey(NewTech))
                                    {
                                        try
                                        {
                                            if (varType[NewTech].Equals("INT"))
                                            {
                                                res += Convert.ToInt32(varData[NewTech.ToLower()]) + "/";

                                            }
                                            else if (varType[NewTech].Equals("FLOAT"))
                                            {
                                                res += float.Parse(varData[NewTech].ToString().Trim().Split('f')[0]) + "/";
                                            }
                                            else if (varType[NewTech].Equals("CHAR"))
                                            {
                                                res += Convert.ToUInt32(varData[NewTech.ToLower()]) + "/";
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            richtxtResult.Text += ex + "" + "Lines " + i + " \n";
                                            flag = false;
                                        }
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "Varaible Are Not Declared" + NewTech + "" + "Lines " + i + " \n";
                                        flag = false;
                                    }
                                    NewTech = "";
                                }
                                //else if (!NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech == null)
                                //{
                                //    res += "/";
                                //}
                                else
                                {
                                    richtxtResult.Text += "Variable Declaration Error" + NewTech + "" + "Lines " + i + " \n";
                                    flag = false;
                                }
                                #endregion

                            }

                        }
                    }
                }
                if (true)
                {

                }
                else if (NewTech.Trim().StartsWith("@") && !NewTech.Trim().EndsWith("@") || NewTech != null)//
                {
                    if (varType.ContainsKey(NewTech) && varData.ContainsKey(NewTech))
                    {
                        try
                        {
                            if (varType[NewTech].Equals("INT"))
                            {
                                res += Convert.ToInt32(varData[NewTech]);

                            }
                            else if (varType[NewTech].Equals("FLOAT"))
                            {
                                res += float.Parse(varData[NewTech].ToString().Trim().Split('f')[0]);
                            }
                            else if (varType[NewTech].Equals("CHAR"))
                            {
                                res += Convert.ToUInt32(varData[NewTech]);
                            }
                        }
                        catch (Exception ex)
                        {
                            richtxtResult.Text += ex + "" + "Lines " + i + " \n";
                            flag = false;
                        }
                    }
                    else
                    {
                        richtxtResult.Text += "Variable Are Not Declared" + NewTech + " " + "Lines " + i + " \n";
                        flag = false;
                    }
                    NewTech = "";
                }
                try
                {

                    if (!res.Contains(".") && varType[LHS].Equals("INT"))
                    {
                        string result = res;
                        Char[] madsrule = res.ToCharArray();
                        double plus = 0;
                        double mul = 0;
                        double div = 0;
                        double sub = 0;
                        foreach (var item in madsrule)
                        {

                        }
                        string asn = dt.Compute(res, null).ToString();
                        varData[LHS] = asn;
                        res = null;
                    }
                    else if (res.Contains(".") && varType[LHS].Equals("FLOAT"))
                    {
                        string result = res;
                        string asn = dt.Compute(res, null).ToString();
                        varData[LHS] = asn + "f";
                        res = null;
                    }
                    else
                    {
                        richtxtResult.Text += " Can't be parse 412 " + "" + "Lines " + i + " \n";
                        flag = false;
                    }


                }
                catch (Exception)
                {
                    richtxtResult.Text += " Can't be parse " + "" + "Lines " + i + " \n";
                    flag = false;
                }
            }
            else
            {
                richtxtResult.Text += "varaible Are Not Declared " + LHS + " At Line " + i + "\n";
            }
        }

        private void insertVariables(string cmpline, int i)
        {
            stringType = null;
            //string datatype = cmpline.Trim().Split(' ')[0];
            foreach (var item3 in cmpline.Trim().Split(' '))
            {
                if (item3 != "")
                {
                    if (item3.Trim().Contains("INT") || item3.Trim().Contains("FLOAT") || item3.Trim().Contains("CHAR"))
                    {
                        stringType = item3 + " ";
                    }
                    else
                    {
                        stringType += item3;
                    }
                }
            }
            foreach (var item in stringType.Trim().Split(' '))
            {
                if (item != "")
                {
                    foreach (var item2 in item.Trim().Split(','))
                    {
                        if (item2 != ",")
                        {
                            if (item2.Equals("INT") || item2.Equals("FLOAT") || item2.Equals("CHAR"))
                            {
                                datatype = item2;
                            }
                            else
                            {
                                if (varType.ContainsKey(item2.ToString()) == false)//does not contain hashtable key then add
                                {
                                    if (datatype.Equals("INT"))
                                    {
                                        varType.Add(item2, datatype);
                                        varData.Add(item2, 0);
                                    }
                                    else if (datatype.Equals("FLOAT"))
                                    {
                                        varType.Add(item2, datatype);
                                        varData.Add(item2, 0.0);
                                    }
                                    else if (datatype.Equals("CHAR"))
                                    {
                                        varType.Add(item2, datatype);
                                        varData.Add(item2, "");
                                    }
                                    else
                                    {
                                        richtxtResult.Text += "Data Type Are Not Used In This Language " + item2 + " At Line " + i + "\n";
                                    }

                                }
                                else
                                {

                                    richtxtResult.Text += "Already varaible Declared " + item2 + " At Line " + i + "\n";
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AssignAlreadyDecVariables(string v, int i)
        {
            NewTech = null;
            //string variables = v.Trim().Split(' ')[1];
            foreach (var item in v.Trim().Split(' '))
            {
                if (item != "")
                {
                    foreach (var item1 in item.Trim().Split(' '))
                    {
                        if (item1 != "")
                            NewTech += item1;
                    }
                }

            }
            string LHS = NewTech.Trim().Split('=')[0];
            string RHS = NewTech.Trim().Split('=')[1];
            if (varType.ContainsKey(LHS))
            {
                foreach (var item2 in RHS.Trim().Split(' '))
                {
                    if (item2 != "")
                    {
                        if (item2.StartsWith("@") && !item2.EndsWith("@"))
                        {
                            if (varType.ContainsKey(item2) == true)
                            {
                                try
                                {
                                    if (varType[LHS].Equals("INT"))
                                    {
                                        varData[LHS] = Convert.ToInt32(varData[item2].ToString().Split('.').First());
                                    }
                                    else if (varType[LHS].Equals("FLOAT"))
                                    {
                                        varData[LHS] = float.Parse(varData[item2].ToString()) + "f";
                                    }
                                    else if (varType[LHS].Equals("CHAR"))
                                    {
                                        varData[LHS] = char.Parse(varData[item2].ToString());
                                    }
                                }
                                catch (Exception)
                                {
                                    richtxtResult.Text += " Parsing Error " + item2 + " At line " + i.ToString() + "\n";
                                }
                            }
                            else
                            {
                                richtxtResult.Text += "Variable Are Not Declared " + item2 + " At line " + i.ToString() + "\n";
                            }
                        }
                        else
                        {
                            if (varType.ContainsKey(LHS) == true)
                            {
                                if (item2.Contains(".") || !item2.Contains(".") && varType[LHS].Equals("FLOAT"))
                                {

                                    if (varData.ContainsKey(LHS))
                                    {
                                        varData[LHS] = float.Parse(item2.ToString()) + "f";
                                    }
                                    else
                                    {
                                        varData.Add(LHS, float.Parse(item2.ToString()));
                                    }
                                }
                                else if (!item2.Contains(".") && varType[LHS].Equals("INT"))
                                {
                                    if (varData.ContainsKey(LHS))
                                    {
                                        varData[LHS] = Convert.ToInt32(item2.ToString());
                                    }
                                    else
                                    {
                                        varData.Add(LHS, Convert.ToInt32(item2.ToString()));
                                    }
                                }
                                else if (!item2.Contains(".") && varType[LHS].Equals("CHAR"))
                                {
                                    try
                                    {


                                        varData[LHS] = char.Parse(item2.ToString());


                                    }
                                    catch (Exception)
                                    {
                                        //else
                                        //{
                                        richtxtResult.Text += " Variable Can't Parse " + LHS + " At line " + i.ToString() + "\n";
                                        //}
                                    }
                                }
                                else
                                {
                                    richtxtResult.Text += " Value Can't Parse " + LHS + " At line " + i.ToString() + "\n";
                                }
                            }
                            else
                            {
                                richtxtResult.Text += "Variable Are Not Declared " + item2 + " At line " + i.ToString() + "\n";
                            }
                        }
                    }
                }
            }
            else
            {
                richtxtResult.Text += "Variable Are Not Declared " + LHS + " At line " + i.ToString() + "\n";
            }

        }

        private void VarInsertData(string v, int i)
        {
            //string[] variables = v.Trim().Split(';');
            string[] variables = v.Trim().Split(' ');

            foreach (var item in variables)
            {
                if (item != "")
                {
                    if (item.Equals("INT") || item.Equals("FLOAT") || item.Equals("CHAR"))
                    {
                        datatype = item;
                    }
                    else
                    {
                        foreach (var item1 in item.Trim().Split('='))
                        {
                            if (item1 != "")
                            {
                                if (item1.StartsWith("@") && !item1.EndsWith("@"))
                                {
                                    Key = item1;
                                }
                                else if (varType.ContainsKey(Key.ToString()) == false)

                                {
                                    varType.Add(Key, datatype);
                                    varData.Add(Key, item1);

                                }
                                else if (varType.ContainsKey(Key.ToString()) == true && variables[0].ToString() != datatype)
                                {
                                    if (varData.ContainsKey(Key.ToString()) == true)
                                    {
                                        varData[Key] = item1;
                                    }
                                    else
                                    {
                                        varData.Add(Key, item1);
                                    }
                                }
                                else
                                {
                                    richtxtResult.Text += " Already Declare Variable " + Key + " At line " + i.ToString() + "\n";
                                }
                            }
                        }
                    }
                }
            }
        }

        public void VarDeclaration(string data, int i)
        {
            //variable Add in hastable

            string[] variables = data.Trim().Split(' ');
            //string[] variables = collonChecking.Trim().Split(' ');
            foreach (var item in variables)
            {
                if (item != "")
                {
                    if (item.Equals("INT") || item.Equals("FLOAT") || item.Equals("CHAR"))
                    {
                        datatype = item;
                    }
                    else
                    {
                        if (varType.ContainsKey(item.ToString()) == false)//does not contain hashtable key then add
                        {

                            if (datatype.Equals("INT"))
                            {
                                varType.Add(item, datatype);
                                varData.Add(item, 0);
                            }
                            else if (datatype.Equals("FLOAT"))
                            {
                                varType.Add(item, datatype);
                                varData.Add(item, 0 + "f");
                            }
                            else if (datatype.Equals("CHAR"))
                            {
                                varType.Add(item, datatype);
                                varData.Add(item, "");
                            }
                            else
                            {
                                richtxtResult.Text += "Data Type Are Not Used In This Language " + item + " At Line " + i + "\n";
                            }
                        }
                        else
                        {

                            richtxtResult.Text += "Already varaible Declared " + item + " At Line " + i + "\n";
                        }
                    }
                }
            }
        }

    }
}
