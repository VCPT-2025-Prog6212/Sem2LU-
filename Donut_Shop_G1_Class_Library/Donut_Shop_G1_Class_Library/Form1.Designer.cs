namespace Donut_Shop_G1_Class_Library
{
    partial class Form1
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
            btnOrder = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtbDonuts = new TextBox();
            txtbCoffee = new TextBox();
            SuspendLayout();
            // 
            // btnOrder
            // 
            btnOrder.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrder.Location = new Point(123, 299);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(200, 49);
            btnOrder.TabIndex = 0;
            btnOrder.Text = "Order";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 131);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 1;
            label1.Text = "Qty Donut:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 206);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 2;
            label2.Text = "Qty Coffee:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 40);
            label3.Name = "label3";
            label3.Size = new Size(293, 40);
            label3.TabIndex = 3;
            label3.Text = "My Donut-Shop";
            // 
            // txtbDonuts
            // 
            txtbDonuts.Location = new Point(184, 128);
            txtbDonuts.Name = "txtbDonuts";
            txtbDonuts.Size = new Size(150, 31);
            txtbDonuts.TabIndex = 4;
            // 
            // txtbCoffee
            // 
            txtbCoffee.Location = new Point(184, 206);
            txtbCoffee.Name = "txtbCoffee";
            txtbCoffee.Size = new Size(150, 31);
            txtbCoffee.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 406);
            Controls.Add(txtbCoffee);
            Controls.Add(txtbDonuts);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOrder);
            Name = "Form1";
            Text = "My Donut Shop ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOrder;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtbDonuts;
        private TextBox txtbCoffee;
    }
}
