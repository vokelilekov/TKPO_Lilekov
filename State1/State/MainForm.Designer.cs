namespace State
{
    partial class MainForm
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
            this.btnCall = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnRecharge = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.txtRechargeAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(249, 205);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(148, 60);
            this.btnCall.TabIndex = 0;
            this.btnCall.Text = "CALL";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(95, 205);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(148, 60);
            this.btnAnswer.TabIndex = 1;
            this.btnAnswer.Text = "ANSWER";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(403, 205);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(148, 60);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "END";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnRecharge
            // 
            this.btnRecharge.Location = new System.Drawing.Point(249, 378);
            this.btnRecharge.Name = "btnRecharge";
            this.btnRecharge.Size = new System.Drawing.Size(148, 60);
            this.btnRecharge.TabIndex = 3;
            this.btnRecharge.Text = "RECHARGE";
            this.btnRecharge.UseVisualStyleBackColor = true;
            this.btnRecharge.Click += new System.EventHandler(this.btnRecharge_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(55, 43);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(164, 20);
            this.lblState.TabIndex = 4;
            this.lblState.Text = "Текущее состояние: ";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(246, 116);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(151, 20);
            this.lblBalance.TabIndex = 5;
            this.lblBalance.Text = "Баланс: 50 единиц";
            // 
            // txtRechargeAmount
            // 
            this.txtRechargeAmount.Location = new System.Drawing.Point(249, 322);
            this.txtRechargeAmount.Name = "txtRechargeAmount";
            this.txtRechargeAmount.Size = new System.Drawing.Size(148, 26);
            this.txtRechargeAmount.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(667, 511);
            this.Controls.Add(this.txtRechargeAmount);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnRecharge);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.btnCall);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnRecharge;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox txtRechargeAmount;
    }
}

