using System.Reflection;

namespace Reflection_App_G1
{
    public partial class frmReflection : Form
    {
        public frmReflection()
        {
            InitializeComponent();
        }

        private void btnDouble_Click(object sender, EventArgs e)
        {
            double total = 149.99;
            System.Type type = total.GetType();
            MessageBox.Show(total + " is of type " + type);
        }

        private void btnString_Click(object sender, EventArgs e)
        {
            String hello = "Hello World";
            System.Type type = hello.GetType();
            MessageBox.Show(hello + " is of type " + type);
        }

        private void btnTypes_Click(object sender, EventArgs e)
        {
            //file path needed for the Assembly
            //use the richtextbox AppendText to have the results displayed 
            Assembly a = Assembly.LoadFrom("C:\\Users\\user\\Documents\\PROG6212\\PROG6212-Group1-2024-main\\Reflection_App_G1\\Reflection_App_G1\\bin\\Debug\\net8.0-windows\\Reflection_App_G1.dll");
            rtbTypes.AppendText("Details: " + a.Location + Environment.NewLine);
            rtbTypes.AppendText("Name: " + a.GetName() + Environment.NewLine);
            Type[] types = a.GetTypes();
            rtbTypes.AppendText("Number of Types: " + types.Count() + Environment.NewLine
                                 + "List of types: " + Environment.NewLine);
            foreach (Type t in types)
            {
                rtbTypes.Text += t.Name + Environment.NewLine;
            }

        }

        private void btnArrayList_Click(object sender, EventArgs e)
        {
            Type MyType = Type.GetType("System.Collections.ArrayList");
            MemberInfo[] Mymemberinfoarray = MyType.GetMembers();

            rtbArrayList.AppendText(Mymemberinfoarray.Length + "items in " + Environment.NewLine);
            if (MyType.IsPublic)
            {
                rtbArrayList.AppendText(MyType.FullName + "is public" + Environment.NewLine);

            }
            else 
            {
                rtbArrayList.AppendText(MyType.FullName + "is private" + Environment.NewLine);

            }

            foreach (MemberInfo mi in Mymemberinfoarray) 
            { 
                rtbArrayList.AppendText (mi.Name + " (" + mi.MemberType + ") "+ Environment.NewLine);
            }
        }
    }
}
