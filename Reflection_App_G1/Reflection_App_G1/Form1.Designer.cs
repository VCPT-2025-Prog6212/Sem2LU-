namespace Reflection_App_G1
{
    partial class frmReflection
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDouble = new Button();
            btnString = new Button();
            btnTypes = new Button();
            btnAssemblies = new Button();
            btnArrayList = new Button();
            rtbTypes = new RichTextBox();
            rtbAssemblies = new RichTextBox();
            rtbArrayList = new RichTextBox();
            SuspendLayout();
            // 
            // btnDouble
            // 
            btnDouble.Location = new Point(61, 42);
            btnDouble.Name = "btnDouble";
            btnDouble.Size = new Size(152, 67);
            btnDouble.TabIndex = 0;
            btnDouble.Text = "Double";
            btnDouble.UseVisualStyleBackColor = true;
            btnDouble.Click += btnDouble_Click;
            // 
            // btnString
            // 
            btnString.Location = new Point(423, 42);
            btnString.Name = "btnString";
            btnString.Size = new Size(155, 67);
            btnString.TabIndex = 1;
            btnString.Text = "String";
            btnString.UseVisualStyleBackColor = true;
            btnString.Click += btnString_Click;
            // 
            // btnTypes
            // 
            btnTypes.Location = new Point(12, 149);
            btnTypes.Name = "btnTypes";
            btnTypes.Size = new Size(161, 130);
            btnTypes.TabIndex = 2;
            btnTypes.Text = "Types within the DLL";
            btnTypes.UseVisualStyleBackColor = true;
            btnTypes.Click += btnTypes_Click;
            // 
            // btnAssemblies
            // 
            btnAssemblies.Location = new Point(12, 324);
            btnAssemblies.Name = "btnAssemblies";
            btnAssemblies.Size = new Size(161, 110);
            btnAssemblies.TabIndex = 3;
            btnAssemblies.Text = "Assemblies in this app";
            btnAssemblies.UseVisualStyleBackColor = true;
            // 
            // btnArrayList
            // 
            btnArrayList.Location = new Point(5, 505);
            btnArrayList.Name = "btnArrayList";
            btnArrayList.Size = new Size(168, 116);
            btnArrayList.TabIndex = 4;
            btnArrayList.Text = "ArrayList Collection";
            btnArrayList.UseVisualStyleBackColor = true;
            btnArrayList.Click += btnArrayList_Click;
            // 
            // rtbTypes
            // 
            rtbTypes.Location = new Point(179, 149);
            rtbTypes.Name = "rtbTypes";
            rtbTypes.Size = new Size(832, 144);
            rtbTypes.TabIndex = 5;
            rtbTypes.Text = "";
            // 
            // rtbAssemblies
            // 
            rtbAssemblies.Location = new Point(179, 313);
            rtbAssemblies.Name = "rtbAssemblies";
            rtbAssemblies.Size = new Size(832, 144);
            rtbAssemblies.TabIndex = 6;
            rtbAssemblies.Text = "";
            // 
            // rtbArrayList
            // 
            rtbArrayList.Location = new Point(179, 492);
            rtbArrayList.Name = "rtbArrayList";
            rtbArrayList.Size = new Size(832, 144);
            rtbArrayList.TabIndex = 7;
            rtbArrayList.Text = "";
            // 
            // frmReflection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 671);
            Controls.Add(rtbArrayList);
            Controls.Add(rtbAssemblies);
            Controls.Add(rtbTypes);
            Controls.Add(btnArrayList);
            Controls.Add(btnAssemblies);
            Controls.Add(btnTypes);
            Controls.Add(btnString);
            Controls.Add(btnDouble);
            Name = "frmReflection";
            Text = "Reflection";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDouble;
        private Button btnString;
        private Button btnTypes;
        private Button btnAssemblies;
        private Button btnArrayList;
        private RichTextBox rtbTypes;
        private RichTextBox rtbAssemblies;
        private RichTextBox rtbArrayList;
    }
}
