namespace _7_2_ex
{
    partial class Watch
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
            this.components = new System.ComponentModel.Container();
            this.WatchTimer = new System.Windows.Forms.Timer(this.components);
            this.LabelHours2 = new System.Windows.Forms.Label();
            this.LabelHours1 = new System.Windows.Forms.Label();
            this.LabelMinutes2 = new System.Windows.Forms.Label();
            this.LabelMinutes1 = new System.Windows.Forms.Label();
            this.LabelSeconds2 = new System.Windows.Forms.Label();
            this.LabelSeconds1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WatchTimer
            // 
            this.WatchTimer.Interval = 1;
            this.WatchTimer.Tick += new System.EventHandler(this.WatchTimer_Tick);
            // 
            // LabelHours2
            // 
            this.LabelHours2.AutoSize = true;
            this.LabelHours2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelHours2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelHours2.ForeColor = System.Drawing.Color.White;
            this.LabelHours2.Location = new System.Drawing.Point(24, 21);
            this.LabelHours2.Name = "LabelHours2";
            this.LabelHours2.Size = new System.Drawing.Size(57, 63);
            this.LabelHours2.TabIndex = 0;
            this.LabelHours2.Text = "0";
            // 
            // LabelHours1
            // 
            this.LabelHours1.AutoSize = true;
            this.LabelHours1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelHours1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelHours1.ForeColor = System.Drawing.Color.White;
            this.LabelHours1.Location = new System.Drawing.Point(63, 21);
            this.LabelHours1.Name = "LabelHours1";
            this.LabelHours1.Size = new System.Drawing.Size(57, 63);
            this.LabelHours1.TabIndex = 1;
            this.LabelHours1.Text = "0";
            // 
            // LabelMinutes2
            // 
            this.LabelMinutes2.AutoSize = true;
            this.LabelMinutes2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelMinutes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMinutes2.ForeColor = System.Drawing.Color.White;
            this.LabelMinutes2.Location = new System.Drawing.Point(146, 21);
            this.LabelMinutes2.Name = "LabelMinutes2";
            this.LabelMinutes2.Size = new System.Drawing.Size(57, 63);
            this.LabelMinutes2.TabIndex = 2;
            this.LabelMinutes2.Text = "0";
            // 
            // LabelMinutes1
            // 
            this.LabelMinutes1.AutoSize = true;
            this.LabelMinutes1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelMinutes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMinutes1.ForeColor = System.Drawing.Color.White;
            this.LabelMinutes1.Location = new System.Drawing.Point(185, 21);
            this.LabelMinutes1.Name = "LabelMinutes1";
            this.LabelMinutes1.Size = new System.Drawing.Size(57, 63);
            this.LabelMinutes1.TabIndex = 3;
            this.LabelMinutes1.Text = "0";
            // 
            // LabelSeconds2
            // 
            this.LabelSeconds2.AutoSize = true;
            this.LabelSeconds2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelSeconds2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSeconds2.ForeColor = System.Drawing.Color.White;
            this.LabelSeconds2.Location = new System.Drawing.Point(267, 21);
            this.LabelSeconds2.Name = "LabelSeconds2";
            this.LabelSeconds2.Size = new System.Drawing.Size(57, 63);
            this.LabelSeconds2.TabIndex = 4;
            this.LabelSeconds2.Text = "0";
            // 
            // LabelSeconds1
            // 
            this.LabelSeconds1.AutoSize = true;
            this.LabelSeconds1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LabelSeconds1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelSeconds1.ForeColor = System.Drawing.Color.White;
            this.LabelSeconds1.Location = new System.Drawing.Point(306, 21);
            this.LabelSeconds1.Name = "LabelSeconds1";
            this.LabelSeconds1.Size = new System.Drawing.Size(57, 63);
            this.LabelSeconds1.TabIndex = 5;
            this.LabelSeconds1.Text = "0";
            // 
            // Watch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(384, 102);
            this.Controls.Add(this.LabelSeconds1);
            this.Controls.Add(this.LabelSeconds2);
            this.Controls.Add(this.LabelMinutes1);
            this.Controls.Add(this.LabelMinutes2);
            this.Controls.Add(this.LabelHours1);
            this.Controls.Add(this.LabelHours2);
            this.MaximumSize = new System.Drawing.Size(400, 140);
            this.MinimumSize = new System.Drawing.Size(400, 140);
            this.Name = "Watch";
            this.Text = "Watch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer WatchTimer;
        private System.Windows.Forms.Label LabelHours2;
        private System.Windows.Forms.Label LabelHours1;
        private System.Windows.Forms.Label LabelMinutes2;
        private System.Windows.Forms.Label LabelMinutes1;
        private System.Windows.Forms.Label LabelSeconds2;
        private System.Windows.Forms.Label LabelSeconds1;
    }
}

