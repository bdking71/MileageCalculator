namespace Mileage_Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetMileage = new System.Windows.Forms.Button();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbToAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTo = new System.Windows.Forms.Label();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGetMileage
            // 
            this.btnGetMileage.Location = new System.Drawing.Point(593, 99);
            this.btnGetMileage.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetMileage.Name = "btnGetMileage";
            this.btnGetMileage.Size = new System.Drawing.Size(164, 40);
            this.btnGetMileage.TabIndex = 0;
            this.btnGetMileage.Text = "Get Mileage";
            this.btnGetMileage.UseVisualStyleBackColor = true;
            this.btnGetMileage.Click += new System.EventHandler(this.btnGetMileage_Click);
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(207, 20);
            this.tbFrom.Margin = new System.Windows.Forms.Padding(4);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(550, 32);
            this.tbFrom.TabIndex = 1;
            this.tbFrom.Text = "448 Lincoln Ave, Lincoln Park, Michigan 48146";
            // 
            // tbToAddress
            // 
            this.tbToAddress.Location = new System.Drawing.Point(207, 59);
            this.tbToAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbToAddress.Name = "tbToAddress";
            this.tbToAddress.Size = new System.Drawing.Size(550, 32);
            this.tbToAddress.TabIndex = 2;
            this.tbToAddress.Text = "200 Museum Dr, Lansing, MI 48933 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Address";
            // 
            // tbTo
            // 
            this.tbTo.AutoSize = true;
            this.tbTo.Location = new System.Drawing.Point(68, 62);
            this.tbTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(120, 25);
            this.tbTo.TabIndex = 4;
            this.tbTo.Text = "To Address";
            // 
            // tbDistance
            // 
            this.tbDistance.Location = new System.Drawing.Point(332, 179);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.Size = new System.Drawing.Size(131, 32);
            this.tbDistance.TabIndex = 5;
            this.tbDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Miles";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 223);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDistance);
            this.Controls.Add(this.tbTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbToAddress);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.btnGetMileage);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Mileage Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetMileage;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbToAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tbTo;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.Label label3;
    }
}

