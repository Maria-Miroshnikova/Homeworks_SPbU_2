namespace test_1_2
{
    partial class FollowButton
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
            this.buttonFollow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFollow
            // 
            this.buttonFollow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonFollow.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFollow.ForeColor = System.Drawing.Color.Black;
            this.buttonFollow.Location = new System.Drawing.Point(12, 12);
            this.buttonFollow.Name = "buttonFollow";
            this.buttonFollow.Size = new System.Drawing.Size(120, 56);
            this.buttonFollow.TabIndex = 0;
            this.buttonFollow.Text = "follow me!";
            this.buttonFollow.UseVisualStyleBackColor = false;
            this.buttonFollow.Click += new System.EventHandler(this.buttonFollow_Click);
            this.buttonFollow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonFollow_MouseMove);
            // 
            // FollowButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFollow);
            this.MaximumSize = new System.Drawing.Size(816, 488);
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "FollowButton";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFollow;
    }
}

