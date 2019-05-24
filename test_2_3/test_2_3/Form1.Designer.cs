namespace test2point3
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonStart.Location = new System.Drawing.Point(338, 193);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(132, 98);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStartClick);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonExit.Location = new System.Drawing.Point(338, 60);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(132, 98);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "EXIT";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Visible = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExitClick);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Black;
            this.progressBar1.Location = new System.Drawing.Point(29, 371);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(703, 41);
            this.progressBar1.TabIndex = 3;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStart);
            this.MaximumSize = new System.Drawing.Size(816, 488);
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "Form";
            this.Text = "BestApplication";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

