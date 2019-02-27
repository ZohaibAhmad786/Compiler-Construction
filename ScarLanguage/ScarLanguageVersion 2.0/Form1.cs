using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data;

namespace ScarLanguageVersion_2._0
{
    public partial class Form1 : Form
    {
        string res = null;
        string variable = null;
        //double res = 0;
        string varAssign;
        string assign;
        string varValue;
        Hashtable ht = new Hashtable();
        Hashtable ht1 = new Hashtable();
        string datatype = null;
        bool flag = true;
        string result;
        string[] dtype_varaible;
        string NewTech;
        string call = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            string alpha1 = null, alpha=null;
            string var = null;
            #region Variable Declaration
            txtErrorArea.Clear();
            DataTable dt = new DataTable();
            flag = true;
            ht.Clear();
            ht1.Clear();

            string[] Lines = txtCode.Lines;

            for (int i = 0; i < Lines.Count(); i++)
            {
                //1 VALIDATE LOOP
                //2 VALIDATE FUNCTION
                //3 FUNCTION CALL
                

                //varAssign = null;
                //NewTech = null;
                //LOOOPS AND CONDITIONAL STATEMENT WRITE HERE.
                if (Lines[i].Trim().EndsWith(";"))
                {
                    if (Lines[i].Contains(";"))
                    {
                        string[] collonChecking = Lines[i].Trim().Split(';');      // For multiple variable declaration 
                                                                                   // txtErrorArea.Text += "Collon Breaking " + collonChecking.Count() + " \n"; // checking how many Collon Exit in single lines
                        
                        foreach (var item in collonChecking)
                        {
                            varAssign = null;
                            NewTech = null;
                            
                            if (item != "")
                            {
                                //string[] dtype_varaible = item.Trim().Split(' ');
                                //dtype_varaible.Count();
                                if (item.Trim().Contains("INT") || item.Trim().Contains("FLOAT") || item.Trim().Contains("CHAR"))
                                {
                                    
                                    dtype_varaible = item.Trim().Split(' ');
                                    foreach (var op in dtype_varaible)
                                    {
                                        if (op != "")
                                        {
                                            if (op.Trim().Contains("INT") || op.Trim().Contains("FLOAT") || op.Trim().Contains("CHAR"))
                                            {
                                                alpha = op;
                                            }
                                            else
                                            {
                                                alpha1 +=op;
                                            }
                                        }
                                    }
                                    alpha1 = alpha + " " + alpha1;
                                    dtype_varaible = alpha1.Trim().Split(' ');
                                    
                                }
                                else
                                {
                                    foreach (var A in item.Trim().Split(' '))
                                    {
                                        NewTech += A;
                                    }
                                    dtype_varaible = NewTech.Trim().Split(' ');
                                }
                                 
                                foreach (var item1 in dtype_varaible)
                                {

                                    if (item1 != "")
                                    {

                                        //#region CHECK START INT FLOAT CHAR
                                        if (dtype_varaible[0].StartsWith("INT") || dtype_varaible[0].StartsWith("FLOAT") || dtype_varaible[0].StartsWith("CHAR"))//
                                        {//
                                            if (item1.Equals("INT") || item1.Equals("FLOAT") || item1.Equals("CHAR"))
                                            {
                                                datatype = item1;                //Getting datatype
                                            }
                                            else
                                            {

                                                if (item1.TrimStart().TrimEnd().Contains(","))
                                                {
                                                    #region Comma spliting

                                                    string[] CommaArray = item1.Trim().Split(',');
                                                    foreach (var item2 in CommaArray)
                                                    {
                                                        try
                                                        {
                                                            if (item2.Trim().Contains("="))
                                                            {
                                                                foreach (var a in item2.Trim().Split(' '))
                                                                {
                                                                    if (a != "")
                                                                    {
                                                                        foreach (var b in a.Trim().Split('='))
                                                                        {
                                                                            if (b != "")
                                                                            {
                                                                                if (b.Trim().StartsWith("@") && !b.Trim().EndsWith("@"))
                                                                                {
                                                                                    assign = b;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (b != "" && flag == true)
                                                                                    {
                                                                                        if (dtype_varaible[0] != datatype && ht.ContainsKey(assign.ToLower()) == true)
                                                                                        //if (ht.ContainsKey(var.ToLower()))
                                                                                        {
                                                                                            if (ht1.ContainsKey(assign.ToLower()))
                                                                                            {
                                                                                                ht1[assign.ToLower()] = b;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                ht1.Add(assign.ToLower(), b);
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (!ht.ContainsKey(assign.ToLower())/* && Convert.ToString(ht[assign.ToLower()]) != datatype*/)
                                                                                            {
                                                                                                ht.Add(assign.ToLower(), datatype);
                                                                                                ht1.Add(assign.ToLower(), b);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                txtErrorArea.Text += "Already intialize Datatype " + datatype + " Variable " + var + "Lines " + i + " \n";
                                                                                                flag = false;
                                                                                            }
                                                                                        }
                                                                                        //flag = true;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        txtErrorArea.Text += "Value Assignment Error " + b + " line " + i + " \n";
                                                                                        flag = false;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                //multitimes == repeated
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                            }
                                                            else if (item2.StartsWith("@") && !item2.EndsWith("@"))
                                                            {
                                                                ht.Add(item2.ToLower(), datatype);
                                                            }

                                                            else
                                                            {
                                                                if (item2 != "")
                                                                {
                                                                    txtErrorArea.Text += "Variable Declaration Error " + item2 + " line " + i + " \n";
                                                                    flag = false;
                                                                }
                                                                else
                                                                {
                                                                    flag = true;
                                                                }
                                                            }
                                                        }
                                                        catch (Exception)
                                                        {
                                                            txtErrorArea.Text += "Varabile DECLARATION ERROR Repeated " + item2 + " line " + i + " \n";
                                                            flag = false;
                                                        }
                                                    }
                                                    #endregion
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        #region Never start with '=' other portion in else statement


                                                        if (item1.Trim().StartsWith("="))
                                                        {
                                                            txtErrorArea.Text += "Assignment Error " + item1 + " line " + i + " \n";
                                                            flag = false;
                                                        }
                                                        else
                                                        {
                                                            #region var never start and end with only @
                                                            if (item1.StartsWith("@") && !item1.EndsWith("@"))
                                                            {

                                                                // ht.Add(item3.ToLower(), datatype);
                                                                if (item1.Contains("="))
                                                                {
                                                                    string[] assignOp = item1.Trim().Split('=');
                                                                    foreach (var item3 in assignOp)
                                                                    {
                                                                        // string expression = item1;
                                                                        if (item3.Trim().StartsWith("="))
                                                                        {
                                                                            //Error
                                                                        }
                                                                        else
                                                                        {
                                                                            if (item3.Trim().StartsWith("@") && !item3.Trim().EndsWith("@"))
                                                                            {
                                                                                var = item3;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (item3 != "" && flag == true)
                                                                                {
                                                                                    if (dtype_varaible[0] != datatype && ht.ContainsKey(var.ToLower()) == true)
                                                                                    //if (ht.ContainsKey(var.ToLower()))
                                                                                    {
                                                                                        if (ht1.ContainsKey(var.ToLower()))
                                                                                        {
                                                                                            ht1[var.ToLower()] = item3;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            ht1.Add(var.ToLower(), item3);
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (!ht.ContainsKey(var.ToLower()) && Convert.ToString(ht[var.ToLower()]) != datatype)
                                                                                        {

                                                                                            try
                                                                                            {
                                                                                                ht.Add(var.ToLower(), datatype);
                                                                                                if (ht[var.ToLower()].Equals("INT"))
                                                                                                {
                                                                                                    ht1.Add(var.ToLower(), Convert.ToInt32(item3));
                                                                                                    flag = true;
                                                                                                }
                                                                                                else if (ht[var.ToLower()].Equals("FLOAT"))
                                                                                                {
                                                                                                    ht1.Add(var.ToLower(), float.Parse(item3.ToString()));
                                                                                                    flag = true;
                                                                                                }
                                                                                                else if (ht[var.ToLower()].Equals("CHAR"))
                                                                                                {
                                                                                                    if (item3.Length > 0 && item3.Length <= 1)
                                                                                                    {//error value inChar
                                                                                                        ht1.Add(var.ToLower(), item3[0]);
                                                                                                        flag = true;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        //length greater than 1
                                                                                                        txtErrorArea.Text += "Length greate than 1 char " + item3 + " Variable " + var + "Lines " + i + " \n";
                                                                                                        flag = false;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    txtErrorArea.Text += "Unknown data type " + datatype + " Variable " + var + "Lines " + i + " \n";
                                                                                                    flag = false;
                                                                                                }
                                                                                                //ht1.Add(var.ToLower(), item3);

                                                                                            }
                                                                                            catch (Exception)
                                                                                            {
                                                                                                txtErrorArea.Text += "Parsing Error " + datatype + " Variable " + var + "Lines " + i + " \n";
                                                                                                flag = false;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            txtErrorArea.Text += "Already intialize Datatype " + datatype + " Variable " + var + "Lines " + i + " \n";
                                                                                            flag = false;
                                                                                        }
                                                                                    }
                                                                                    //flag = true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    txtErrorArea.Text += "Value Assignment Error " + item3 + " line " + i + " \n";
                                                                                    flag = false;
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    #region only single @A Var Dec

                                                                    if (item1.StartsWith("@") && !item1.EndsWith("@"))
                                                                    {

                                                                        ht.Add(item1.ToLower(), datatype);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (item1 != "")
                                                                        {
                                                                            txtErrorArea.Text += "Variable Declaration Error " + item1 + " line " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            flag = true;
                                                                        }
                                                                    }
                                                                    #endregion
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (item1 != "")
                                                                {
                                                                    txtErrorArea.Text += "Variable Declaration Error " + item1 + " line " + i + " \n";
                                                                    flag = false;
                                                                }
                                                                else
                                                                {
                                                                    flag = true;
                                                                }
                                                            }
                                                            #endregion
                                                        }
                                                        #endregion
                                                    }
                                                    #region MyRegion
                                                    //catch (Exception EX)
                                                    //{
                                                    //    txtErrorArea.Text += EX + " " + item1 + " line " + i + " \n";
                                                    //    flag = false;
                                                    //}


                                                    //else
                                                    //{
                                                    //    #region only single @A Var Dec
                                                    //    if (item1.StartsWith("@"))
                                                    //    {
                                                    //        ht.Add(item1.ToLower(), datatype);
                                                    //    }
                                                    //    else
                                                    //    {
                                                    //        if (item1 != "")
                                                    //        {
                                                    //            txtErrorArea.Text += "Variable Declaration Error " + item1 + " line " + i + " \n";
                                                    //            flag = false;
                                                    //        }
                                                    //        else
                                                    //        {
                                                    //            flag = true;
                                                    //        }
                                                    //    }
                                                    //    #endregion
                                                    //}

                                                    //}
                                                    #endregion
                                                    catch (Exception)
                                                    {
                                                        txtErrorArea.Text += "Varabile DECLARATION ERROR Repeated " + item1 + " line " + i + " \n";
                                                        flag = false;
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }//
                                        else
                                        {
                                            #region Start First Step
                                            varAssign = item1;
                                            if (varAssign.Trim().Contains(","))
                                            {
                                                foreach (var firstcheck in varAssign.Trim().Split(','))
                                                {
                                                    if (firstcheck.Trim().Contains("=") && firstcheck.Trim().Contains("+") || firstcheck.Trim().Contains("-") || firstcheck.Trim().Contains("*") || firstcheck.Trim().Contains("/"))
                                                    {
                                                        variable = firstcheck.Trim().Split('=')[0];
                                                        string DMASValues = firstcheck.Trim().Split('=')[1];
                                                        char[] EVAL = DMASValues.ToCharArray();
                                                        int count = EVAL.Length;


                                                        foreach (var zs in EVAL)
                                                        {
                                                            if (zs.Equals('@'))
                                                            {
                                                                call += zs;
                                                            }
                                                            else if (zs.Equals('A') || zs.Equals('B') || zs.Equals('C') || zs.Equals('D') ||
                                                                zs.Equals('E') || zs.Equals('F') || zs.Equals('G') || zs.Equals('H') ||
                                                                zs.Equals('I') || zs.Equals('J') || zs.Equals('K') || zs.Equals('L') ||
                                                                zs.Equals('M') || zs.Equals('N') || zs.Equals('O') || zs.Equals('P') ||
                                                                zs.Equals('Q') || zs.Equals('R') || zs.Equals('S') || zs.Equals('T') ||
                                                                zs.Equals('U') || zs.Equals('V') || zs.Equals('W') || zs.Equals('X') ||
                                                                zs.Equals('Y') || zs.Equals('Z'))
                                                            {
                                                                call += zs;
                                                            }
                                                            else if (zs.Equals('0') || zs.Equals('1') || zs.Equals('2') || zs.Equals('3') || zs.Equals('4') ||
                                                               zs.Equals('5') || zs.Equals('6') || zs.Equals('7') || zs.Equals('8') || zs.Equals('9'))
                                                            {
                                                                res += zs;
                                                            }
                                                            else
                                                            {
                                                                #region +
                                                                if (zs.Equals('+'))
                                                                {
                                                                    if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                    {
                                                                        if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                        {
                                                                            try
                                                                            {
                                                                                if (ht[call.ToLower()].Equals("INT"))
                                                                                {
                                                                                    res += Convert.ToInt32(ht1[call.ToLower()]) + "+";

                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                                {
                                                                                    res += float.Parse(ht1[call.ToLower()].ToString()) + "+";
                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("CHAR"))
                                                                                {
                                                                                    res += double.Parse(ht1[call.ToLower()].ToString()) + "+";
                                                                                }
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                                flag = false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                        call = "";
                                                                    }
                                                                    else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                    {
                                                                        res += "+";
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    #endregion
                                                                }
                                                                else if (zs.Equals('-'))
                                                                {
                                                                    #region -
                                                                    if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                    {
                                                                        if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                        {
                                                                            try
                                                                            {
                                                                                if (ht[call.ToLower()].Equals("INT"))
                                                                                {
                                                                                    res += Convert.ToInt32(ht1[call.ToLower()]) + "-";

                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                                {
                                                                                    res += float.Parse(ht1[call.ToLower()].ToString()) + "-";
                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("CHAR"))
                                                                                {
                                                                                    res += double.Parse(ht1[call.ToLower()].ToString()) + "-";
                                                                                }
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                                flag = false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                        call = "";
                                                                    }
                                                                    else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                    {
                                                                        res += "-";
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    #endregion
                                                                }
                                                                else if (zs.Equals('*'))
                                                                {
                                                                    #region *
                                                                    if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                    {
                                                                        if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                        {
                                                                            try
                                                                            {
                                                                                if (ht[call.ToLower()].Equals("INT"))
                                                                                {
                                                                                    res += Convert.ToInt32(ht1[call.ToLower()]) + "*";

                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                                {
                                                                                    res += float.Parse(ht1[call.ToLower()].ToString()) + "*";
                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("CHAR"))
                                                                                {
                                                                                    res += double.Parse(ht1[call.ToLower()].ToString()) + "*";
                                                                                }
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                                flag = false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                        call = "";
                                                                    }
                                                                    else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                    {
                                                                        res += "*";
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    #endregion
                                                                }
                                                                else if (zs.Equals('/'))
                                                                {
                                                                    #region /
                                                                    if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                    {
                                                                        if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                        {
                                                                            try
                                                                            {
                                                                                if (ht[call.ToLower()].Equals("INT"))
                                                                                {
                                                                                    res += Convert.ToInt32(ht1[call.ToLower()]) + "/";

                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                                {
                                                                                    res += float.Parse(ht1[call.ToLower()].ToString()) + "/";
                                                                                }
                                                                                else if (ht[call.ToLower()].Equals("CHAR"))
                                                                                {
                                                                                    res += double.Parse(ht1[call.ToLower()].ToString()) + "/";
                                                                                }
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                                flag = false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                        call = "";
                                                                    }
                                                                    else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                    {
                                                                        res += "/";
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    #endregion
                                                                }


                                                            }

                                                        }
                                                        //DataTable dt = new DataTable();
                                                        //if (res.EndsWith("+"))
                                                        //{
                                                        //    string a = res.Split('+')[0];
                                                        //    string asn = dt.Compute(a, null).ToString();
                                                        //}
                                                        //else
                                                        //{
                                                        //--------------------------------------------------------------------------
                                                        if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                        {
                                                            if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                            {
                                                                try
                                                                {
                                                                    if (ht[call.ToLower()].Equals("INT"))
                                                                    {
                                                                        res += Convert.ToInt32(ht1[call.ToLower()]) ;

                                                                    }
                                                                    else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                    {
                                                                        res += float.Parse(ht1[call.ToLower()].ToString());
                                                                    }
                                                                    else if (ht[call.ToLower()].Equals("CHAR"))
                                                                    {
                                                                        res += double.Parse(ht1[call.ToLower()].ToString()) ;
                                                                    }
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                    flag = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                flag = false;
                                                            }
                                                            call = "";
                                                        }
                                                        //--------------------------------------------------------------------------
                                                        
                                                        //}

                                                        //
                                                    }
                                                    else if (firstcheck.Trim().Contains("="))
                                                    {
                                                        foreach (var checking in firstcheck.Trim().Split('='))
                                                        {
                                                            if (checking != "")
                                                            {
                                                                if (checking.Trim().StartsWith("@") && !checking.Trim().EndsWith("@"))
                                                                {
                                                                    varValue = checking;
                                                                }
                                                                else if (!checking.Trim().StartsWith("@") && !checking.Trim().EndsWith("@"))
                                                                {
                                                                    if (ht.ContainsKey(varValue.ToLower()))
                                                                    {
                                                                        if (ht[varValue.ToLower()].Equals("INT"))
                                                                        {
                                                                            ht1[varValue.ToLower()] = Convert.ToInt32(checking);
                                                                            flag = true;
                                                                        }
                                                                        else if (ht[var.ToLower()].Equals("FLOAT"))
                                                                        {
                                                                            ht1[varValue.ToLower()] = float.Parse(checking.ToString());
                                                                            flag = true;
                                                                        }
                                                                        else if (ht[varValue.ToLower()].Equals("CHAR"))
                                                                        {
                                                                            if (checking.Length > 0 && checking.Length <= 1)
                                                                            {//error value inChar
                                                                                ht1[varValue.ToLower()] = checking[0];
                                                                                flag = true;
                                                                            }
                                                                            else
                                                                            {
                                                                                //length greater than 1
                                                                                txtErrorArea.Text += "Length greate than 1 char " + checking + " Variable " + var + "Lines " + i + " \n";
                                                                                flag = false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            txtErrorArea.Text += "Unknown data type " + ht[varValue] + " Variable " + var + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //you have must declare this varaible
                                                                        txtErrorArea.Text += "Unknown variable " + varValue + " Variable " + var + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    txtErrorArea.Text += "Variable Error " + checking + " line " + i + " \n";
                                                                    flag = false;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else if (firstcheck.Trim().StartsWith("@") && firstcheck.Trim().EndsWith("@"))
                                                    {
                                                        if (ht.ContainsKey(firstcheck.ToLower()))
                                                        {

                                                        }
                                                        else
                                                        {
                                                            txtErrorArea.Text += "Varabile DECLARATION ERROR Repeated " + firstcheck + " line " + i + " \n";
                                                            flag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        txtErrorArea.Text += "@ missing " + firstcheck + " line " + i + " \n";
                                                        flag = false;
                                                    }
                                                    //
                                                    //if (flag == true)
                                                    //{
                                                    //    string asn = dt.Compute(res, null).ToString();
                                                    //    ht1[variable.ToLower()] = asn;
                                                    //    res = null;
                                                    //}
                                                    try
                                                    {
                                                        if (flag == true)
                                                        {
                                                            string asn = dt.Compute(res, null).ToString();
                                                            ht1[variable.ToLower()] = asn;
                                                            res = null;
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        txtErrorArea.Text += "Char Can't be parse" + "" + "Lines " + i + " \n";
                                                        flag = false;
                                                    }
                                                }
                                            }
                                            else
                                            {

                                                //ifstatment contains + / - then neext if statemnt make else if* 
                                                if (varAssign.Trim().Contains("=") && varAssign.Trim().Contains("+") || varAssign.Trim().Contains("-") || varAssign.Trim().Contains("*") || varAssign.Trim().Contains("/"))
                                                {
                                                    //
                                                    string variable = varAssign.Trim().Split('=')[0];
                                                    string DMASValues= varAssign.Trim().Split('=')[1];
                                                    char[] EVAL = DMASValues.ToCharArray();
                                                    int count = EVAL.Length;

                                                   
                                                    foreach (var zs in EVAL)
                                                    {
                                                        if (zs.Equals('@'))
                                                        {
                                                            call += zs;
                                                        }
                                                        else if(zs.Equals('A')|| zs.Equals('B') || zs.Equals('C') || zs.Equals('D') ||
                                                            zs.Equals('E') || zs.Equals('F') || zs.Equals('G') || zs.Equals('H') ||
                                                            zs.Equals('I') || zs.Equals('J') || zs.Equals('K') || zs.Equals('L') ||
                                                            zs.Equals('M') || zs.Equals('N') || zs.Equals('O') || zs.Equals('P') ||
                                                            zs.Equals('Q') || zs.Equals('R') || zs.Equals('S') || zs.Equals('T') ||
                                                            zs.Equals('U') || zs.Equals('V') || zs.Equals('W') || zs.Equals('X') ||
                                                            zs.Equals('Y') || zs.Equals('Z') )
                                                        {
                                                            call += zs;
                                                        }else if (zs.Equals('0') || zs.Equals('1') || zs.Equals('2') || zs.Equals('3')|| zs.Equals('4') ||
                                                            zs.Equals('5') || zs.Equals('6') || zs.Equals('7') || zs.Equals('8') || zs.Equals('9') )
                                                        {
                                                            res += zs;
                                                        }else
                                                        {
                                                            
                                                            if (zs.Equals('+'))
                                                            {
                                                                if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                {
                                                                    if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                    {
                                                                        try
                                                                        {
                                                                            if (ht[call.ToLower()].Equals("INT"))
                                                                            {
                                                                                res += Convert.ToInt32(ht1[call.ToLower()]) + "+";

                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                            {
                                                                                res += float.Parse(ht1[call.ToLower()].ToString()) + "+";
                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("CHAR"))
                                                                            {
                                                                                res += double.Parse(ht1[call.ToLower()].ToString()) + "+";
                                                                            }
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                            txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    call = "";
                                                                }
                                                                else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                {
                                                                    res += "+";
                                                                }
                                                                else
                                                                {
                                                                    txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                    flag = false;
                                                                }
                                                            }
                                                            else if(zs.Equals('-'))
                                                            {
                                                                if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                {
                                                                    if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                    {
                                                                        try
                                                                        {
                                                                            if (ht[call.ToLower()].Equals("INT"))
                                                                            {
                                                                                res += Convert.ToInt32(ht1[call.ToLower()]) + "-";

                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                            {
                                                                                res += float.Parse(ht1[call.ToLower()].ToString()) + "-";
                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("CHAR"))
                                                                            {
                                                                                res += double.Parse(ht1[call.ToLower()].ToString()) + "-";
                                                                            }
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                            txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    call = "";
                                                                }
                                                                else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                {
                                                                    res += "-";
                                                                }
                                                                else
                                                                {
                                                                    txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                    flag = false;
                                                                }
                                                            }
                                                            else if (zs.Equals('*'))
                                                            {
                                                                if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                {
                                                                    if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                    {
                                                                        try
                                                                        {
                                                                            if (ht[call.ToLower()].Equals("INT"))
                                                                            {
                                                                                res += Convert.ToInt32(ht1[call.ToLower()]) + "*";

                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                            {
                                                                                res += float.Parse(ht1[call.ToLower()].ToString()) + "*";
                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("CHAR"))
                                                                            {
                                                                                res += double.Parse(ht1[call.ToLower()].ToString()) + "*";
                                                                            }
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                            txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    call = "";
                                                                }
                                                                else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                {
                                                                    res += "*";
                                                                }
                                                                else
                                                                {
                                                                    txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                    flag = false;
                                                                }
                                                            }
                                                            else if (zs.Equals('/'))
                                                            {
                                                                if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                                {
                                                                    if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                                    {
                                                                        try
                                                                        {
                                                                            if (ht[call.ToLower()].Equals("INT"))
                                                                            {
                                                                                res += Convert.ToInt32(ht1[call.ToLower()]) + "/";

                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                            {
                                                                                res += float.Parse(ht1[call.ToLower()].ToString()) + "/";
                                                                            }
                                                                            else if (ht[call.ToLower()].Equals("CHAR"))
                                                                            {
                                                                                res += double.Parse(ht1[call.ToLower()].ToString()) + "/";
                                                                            }
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                            txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "vARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                    call = "";
                                                                }
                                                                else if (!call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call == null)
                                                                {
                                                                    res += "/";
                                                                }
                                                                else
                                                                {
                                                                    txtErrorArea.Text += "Variable are not Declare" + call + "" + "Lines " + i + " \n";
                                                                    flag = false;
                                                                }
                                                            }
                                                            
                                                        }
                                                        
                                                    }
                                                    //DataTable dt = new DataTable();
                                                    //if (res.EndsWith("+"))
                                                    //{
                                                    //    string a = res.Split('+')[0];
                                                    //    string asn = dt.Compute(a, null).ToString();
                                                    //}
                                                    //else
                                                    //{
                                                    //---------------------------------------------------------------
                                                    

                                                    if (call.Trim().StartsWith("@") && !call.Trim().EndsWith("@") || call != "")
                                                    {
                                                        if (ht.ContainsKey(call.ToLower()) && ht1.ContainsKey(call.ToLower()))
                                                        {
                                                            try
                                                            {
                                                                if (ht[call.ToLower()].Equals("INT"))
                                                                {
                                                                    res += Convert.ToInt32(ht1[call.ToLower()]) ;

                                                                }
                                                                else if (ht[call.ToLower()].Equals("FLOAT"))
                                                                {
                                                                    res += float.Parse(ht1[call.ToLower()].ToString());
                                                                }
                                                                else if (ht[call.ToLower()].Equals("CHAR"))
                                                                {
                                                                    res += double.Parse(ht1[call.ToLower()].ToString()) ;
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                txtErrorArea.Text += ex + "" + "Lines " + i + " \n";
                                                                flag = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            txtErrorArea.Text += "VARIABLE NOT DECLARED" + "" + "Lines " + i + " \n";
                                                            flag = false;
                                                        }
                                                        call = "";
                                                    }
                                                    //---------------------------------------------------------------
                                                    try
                                                    {
                                                        if (flag==true)
                                                        {
                                                            string asn = dt.Compute(res, null).ToString();
                                                            ht1[variable.ToLower()] = asn;
                                                            res = null;
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        txtErrorArea.Text += " Can't be parse" + "" + "Lines " + i + " \n";
                                                        flag = false;
                                                    }
                                                    //}

                                                    //
                                                }
                                                else if (varAssign.Trim().Contains("="))
                                                {
                                                    foreach (var checking in varAssign.Trim().Split('='))
                                                    {
                                                        if (checking != "")
                                                        {
                                                            if (checking.Trim().StartsWith("@") && !checking.Trim().EndsWith("@"))
                                                            {
                                                                varValue = checking;
                                                            }else if (!checking.Trim().StartsWith("@") && !checking.Trim().EndsWith("@"))
                                                            {
                                                                if (ht.ContainsKey(varValue.ToLower()))
                                                                {
                                                                    if (ht[varValue.ToLower()].Equals("INT"))
                                                                    {
                                                                        ht1[varValue.ToLower()]= Convert.ToInt32(checking);
                                                                        flag = true;
                                                                    }
                                                                    else if (ht[var.ToLower()].Equals("FLOAT"))
                                                                    {
                                                                        ht1[varValue.ToLower()] = float.Parse(checking.ToString());
                                                                        flag = true;
                                                                    }
                                                                    else if (ht[varValue.ToLower()].Equals("CHAR"))
                                                                    {
                                                                        if (checking.Length > 0 && checking.Length <= 1)
                                                                        {//error value inChar
                                                                            ht1[varValue.ToLower()] = checking[0];
                                                                            flag = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            //length greater than 1
                                                                            txtErrorArea.Text += "Length greate than 1 char " + checking + " Variable " + var + "Lines " + i + " \n";
                                                                            flag = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        txtErrorArea.Text += "Unknown data type " + ht[varValue] + " Variable " + var + "Lines " + i + " \n";
                                                                        flag = false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    //you have must declare this varaible
                                                                    txtErrorArea.Text += "Unknown variable " + varValue + " Variable " + var + "Lines " + i + " \n";
                                                                    flag = false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                txtErrorArea.Text += "Variable Error " + checking + " line " + i + " \n";
                                                                flag = false;
                                                            }
                                                        }
                                                    }
                                                }
                                                else if (varAssign.Trim().StartsWith("@") && !varAssign.Trim().EndsWith("@"))
                                                {
                                                    if (ht.ContainsKey(varAssign.ToLower()))
                                                    {

                                                    }
                                                    else
                                                    {
                                                        txtErrorArea.Text += "Varabile DECLARATION ERROR Repeated " + varAssign + " line " + i + " \n";
                                                        flag = false;
                                                    }
                                                }
                                                else
                                                {
                                                    txtErrorArea.Text += "@ missing " + varAssign + " line " + i + " \n";
                                                    flag = false;
                                                }
                                            }
                                            #endregion
                                            #region rough 2
                                            //varAssign = null;
                                            ////SAVED IN FILE
                                            //foreach (var A in item.Trim().Split(' '))
                                            //{
                                            //    varAssign += A;
                                            //}
                                            //varValue = varAssign;
                                            //if (varValue.Trim().Contains(","))
                                            //{
                                            //    string[] arraycommasplitting = varValue.Trim().Split(',');
                                            //    foreach (var a in arraycommasplitting)
                                            //    {

                                            //        string LHS = a.Trim().Split('=')[0];
                                            //        string RHS = a.Trim().Split('=')[1];
                                            //        if (RHS.Trim().Contains("/"))
                                            //        {

                                            //        }
                                            //        else if (RHS.Trim().Contains("*"))
                                            //        {

                                            //        }
                                            //        else if (RHS.Trim().Contains("+"))
                                            //        {

                                            //        }
                                            //        else if (RHS.Trim().Contains("-"))
                                            //        {

                                            //        }
                                            //        else
                                            //        {

                                            //        }
                                            //    }
                                            //}
                                            //else
                                            //{

                                            //CHECK FIRST THE VARIBALE IS IN HAST TABLE OR NOR THEN PROCESS FORWARD IT OTHWERISE 
                                            //not contains Comma
                                            //string LHS = varValue.Trim().Split('=')[0];
                                            //string RHS = varValue.Trim().Split('=')[1];
                                            //if (RHS.Trim().Contains("/"))
                                            //{
                                            //    DataTable dt = new DataTable();
                                            //    string LhS = RHS.Trim().Split('/')[0];
                                            //    string RhS = RHS.Trim().Split('/')[1];
                                            //    if (LhS.StartsWith("@") && !LhS.EndsWith("@"))
                                            //    {

                                            //        if (ht.ContainsKey(LhS.ToLower()) && ht1.ContainsKey(LhS.ToLower()))
                                            //        {
                                            //            if (ht[LhS.ToLower()].Equals("INT"))
                                            //            {
                                            //                result+= Convert.ToInt32(ht1[LhS.ToLower()])+"/";
                                            //                flag = true;
                                            //            }
                                            //            else if (ht[LhS.ToLower()].Equals("FLOAT"))
                                            //            {
                                            //                result+= float.Parse(ht1[LhS.ToLower()].ToString());
                                            //                flag = true;
                                            //            }
                                            //            else
                                            //            {
                                            //                //error value inChar
                                            //            }
                                            //        }
                                            //        else
                                            //        {
                                            //            txtErrorArea.Text += "Error 420";
                                            //            flag = false;
                                            //        }
                                            //    }
                                            //    else if (RhS.StartsWith("@") && !RhS.EndsWith("@"))
                                            //    {

                                            //        if (ht.ContainsKey(RhS.ToLower()) && ht1.ContainsKey(RhS.ToLower()))
                                            //        {
                                            //            if (ht[RhS.ToLower()].Equals("INT"))
                                            //            {
                                            //                result+= Convert.ToInt32( ht1[RhS.ToLower()]);
                                            //                //res = num1 / num2;
                                            //                flag = true;
                                            //            }
                                            //            else if(ht[RhS.ToLower()].Equals("FLOAT"))
                                            //            {
                                            //                result+= float.Parse(ht1[RhS.ToLower()].ToString());
                                            //                //res = fnum1 / fnum2;
                                            //                flag = true;
                                            //            }else
                                            //            {
                                            //                //error value inChar
                                            //            }

                                            //        }
                                            //        else
                                            //        {
                                            //            txtErrorArea.Text += "Error 421";
                                            //            flag = false;
                                            //        }
                                            //    }
                                            //    if (!LhS.StartsWith("@") && !LhS.EndsWith("@"))
                                            //    {
                                            //        result += Convert.ToInt32(RhS).ToString()+"/";
                                            //        //res = num1 / num2;
                                            //    }
                                            //    else if (!RhS.StartsWith("@") && !RhS.EndsWith("@"))
                                            //    {
                                            //       result += Convert.ToInt32(RhS);
                                            //       // res = num1 / num2;

                                            //    }
                                            //    result = ""+Convert.ToInt32( dt.Compute("([0-9]{0,9}/S[0-9]{0,9})", result));


                                            //}
                                            //else if (RHS.Trim().Contains("*"))
                                            //{

                                            //}
                                            //else if (RHS.Trim().Contains("+"))
                                            //{

                                            //}
                                            //else if (RHS.Trim().Contains("-"))
                                            //{

                                            //}
                                            //else
                                            //{
                                            //    if (ht.ContainsKey(LHS.ToLower()) && ht1.ContainsKey(LHS.ToLower()) && flag == true)
                                            //    {
                                            //        //YHN PAR PHLY HT1 MN DATA INSERT KRNA HA

                                            //        ht1[LHS.ToLower()] = RHS;


                                            //    }
                                            //    else if (ht.ContainsKey(LHS.ToLower()) && !ht1.ContainsKey(LHS.ToLower()))
                                            //    {
                                            //        ht1.Add(LHS.ToLower(), RHS);
                                            //    }
                                            //    else
                                            //    {
                                            //        txtErrorArea.Text += "variable are repeated , '=' repeated " + LHS + " Lines " + i + "\n";
                                            //        flag = false;

                                            //    }
                                            //}
                                            //}
                                            #endregion
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    txtErrorArea.Text += "The Error ';' on Line " + i + "\n";
                    flag = false;
                }


            }
            if (flag == true)
            {
                txtErrorArea.Text += "Variable succesfull declared \n ";
            }

            #region HASH_TABLE DATA
            txtoutPut.Clear();
            foreach (var entries in ht.Keys)
            {
                txtoutPut.Text += "Key = " + entries + "  Datatype = " + ht[entries] + " \n ";
            }
            foreach (var entries in ht1.Keys)
            {
                txtoutPut.Text += "Key = " + entries + "  Datatype = " + ht1[entries] + " \n ";
            }
            #endregion

            #region HardCode Value Assignment or Value Input
            #endregion

            #region Mathematic Operation
            #endregion



        }

        private void txtoutPut_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

#region Rough Work
/*    
 *    
 *    else if (item1.Trim().Contains('/'))
                                        {
                                            try
                                            {
                                                string oparatorSolving = item1.Trim().Split('=')[0];
                                                foreach (var item4 in oparatorSolving)
                                                {

                                                }
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        else if (item1.Trim().Contains('*'))
                                        {
                                            try
                                            {
                                                string[] oparatorSolving = item1.Trim().Split('=');
                                                foreach (var item4 in oparatorSolving)
                                                {

                                                }
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        else if (item1.Trim().Contains('+'))
                                        {
                                            try
                                            {
                                                string[] oparatorSolving = item1.Trim().Split('=');
                                                foreach (var item4 in oparatorSolving)
                                                {

                                                }
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        else if (item1.Trim().Contains('-'))
                                        {
                                            try
                                            {
                                                string[] oparatorSolving = item1.Trim().Split('=');
                                                foreach (var item4 in oparatorSolving)
                                                {

                                                }
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        
     
    */
#endregion