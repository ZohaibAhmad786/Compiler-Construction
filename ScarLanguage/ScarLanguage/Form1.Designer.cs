﻿namespace ScarLanguage
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
            this.richtxtInputCode = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richtxtResult = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richtxtInputCode
            // 
            this.richtxtInputCode.Location = new System.Drawing.Point(21, 19);
            this.richtxtInputCode.Name = "richtxtInputCode";
            this.richtxtInputCode.Size = new System.Drawing.Size(403, 219);
            this.richtxtInputCode.TabIndex = 0;
            this.richtxtInputCode.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Compile Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richtxtResult
            // 
            this.richtxtResult.Location = new System.Drawing.Point(21, 19);
            this.richtxtResult.Name = "richtxtResult";
            this.richtxtResult.Size = new System.Drawing.Size(403, 120);
            this.richtxtResult.TabIndex = 2;
            this.richtxtResult.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richtxtInputCode);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(31, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 285);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Code Area";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richtxtResult);
            this.groupBox2.Location = new System.Drawing.Point(31, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 157);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result Area";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richtxtInputCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richtxtResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

