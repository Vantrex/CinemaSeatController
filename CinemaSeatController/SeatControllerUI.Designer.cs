namespace CinemaSeatController
{
    partial class SeatControllerUI
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
            this.priceLabel = new System.Windows.Forms.Label();
            this.premiumPriceLabel = new System.Windows.Forms.Label();
            this.earnedMoney = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(12, 9);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(30, 13);
            this.priceLabel.TabIndex = 0;
            this.priceLabel.Text = "price";
            // 
            // premiumPriceLabel
            // 
            this.premiumPriceLabel.AutoSize = true;
            this.premiumPriceLabel.Location = new System.Drawing.Point(109, 9);
            this.premiumPriceLabel.Name = "premiumPriceLabel";
            this.premiumPriceLabel.Size = new System.Drawing.Size(73, 13);
            this.premiumPriceLabel.TabIndex = 1;
            this.premiumPriceLabel.Text = "premium Price";
            // 
            // earnedMoney
            // 
            this.earnedMoney.AutoSize = true;
            this.earnedMoney.Location = new System.Drawing.Point(12, 34);
            this.earnedMoney.Name = "earnedMoney";
            this.earnedMoney.Size = new System.Drawing.Size(93, 13);
            this.earnedMoney.TabIndex = 2;
            this.earnedMoney.Text = "Earned money: 0$";
            // 
            // SeatControllerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.earnedMoney);
            this.Controls.Add(this.premiumPriceLabel);
            this.Controls.Add(this.priceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SeatControllerUI";
            this.Text = "Cinema Seats";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label premiumPriceLabel;
        private System.Windows.Forms.Label earnedMoney;
    }
}