// --- НАЧАЛО ФАЙЛА kalori\Form1.Designer.cs ---
namespace kalori
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container(); // Добавлено для поддержки ToolTip, если понадобится
            this.btnShowBmrCalc = new System.Windows.Forms.Button();
            this.btnShowWaterCalc = new System.Windows.Forms.Button();
            this.btnShowObesityCalc = new System.Windows.Forms.Button();
            this.panelBmr = new System.Windows.Forms.Panel();
            this.lblCarbsResult = new System.Windows.Forms.Label();
            this.lblFatResult = new System.Windows.Forms.Label();
            this.lblProteinResult = new System.Windows.Forms.Label();
            this.lblTdeeResult = new System.Windows.Forms.Label();
            this.lblBmrResult = new System.Windows.Forms.Label();
            this.btnCalculateBmr = new System.Windows.Forms.Button();
            this.cmbActivityLevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBmrWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBmrHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBmrAge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelWater = new System.Windows.Forms.Panel();
            this.lblWaterResult = new System.Windows.Forms.Label();
            this.btnCalculateWater = new System.Windows.Forms.Button();
            this.txtWaterWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelObesity = new System.Windows.Forms.Panel();
            this.lblObesityStatusResult = new System.Windows.Forms.Label();
            this.lblBmiResult = new System.Windows.Forms.Label();
            this.btnCalculateObesity = new System.Windows.Forms.Button();
            this.txtObesityWeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObesityHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel(); // Панель-контейнер для других панелей
            this.panelBmr.SuspendLayout();
            this.panelWater.SuspendLayout();
            this.panelObesity.SuspendLayout();
            this.panelContainer.SuspendLayout(); // Добавлено
            this.SuspendLayout();
            //
            // btnShowBmrCalc
            //
            this.btnShowBmrCalc.Location = new System.Drawing.Point(12, 12);
            this.btnShowBmrCalc.Name = "btnShowBmrCalc";
            this.btnShowBmrCalc.Size = new System.Drawing.Size(180, 35);
            this.btnShowBmrCalc.TabIndex = 0;
            this.btnShowBmrCalc.Text = "Расчет БЖУ/Калорий";
            this.btnShowBmrCalc.UseVisualStyleBackColor = true;
            this.btnShowBmrCalc.Click += new System.EventHandler(this.BtnShowBmrCalc_Click);
            //
            // btnShowWaterCalc
            //
            this.btnShowWaterCalc.Location = new System.Drawing.Point(198, 12);
            this.btnShowWaterCalc.Name = "btnShowWaterCalc";
            this.btnShowWaterCalc.Size = new System.Drawing.Size(180, 35);
            this.btnShowWaterCalc.TabIndex = 1;
            this.btnShowWaterCalc.Text = "Расчет Воды";
            this.btnShowWaterCalc.UseVisualStyleBackColor = true;
            this.btnShowWaterCalc.Click += new System.EventHandler(this.BtnShowWaterCalc_Click);
            //
            // btnShowObesityCalc
            //
            this.btnShowObesityCalc.Location = new System.Drawing.Point(384, 12);
            this.btnShowObesityCalc.Name = "btnShowObesityCalc";
            this.btnShowObesityCalc.Size = new System.Drawing.Size(180, 35);
            this.btnShowObesityCalc.TabIndex = 2;
            this.btnShowObesityCalc.Text = "Расчет ИМТ/Ожирения";
            this.btnShowObesityCalc.UseVisualStyleBackColor = true;
            this.btnShowObesityCalc.Click += new System.EventHandler(this.BtnShowObesityCalc_Click);
            //
            // panelContainer
            //
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Controls.Add(this.panelObesity); // Порядок добавления важен для BringToFront, но не для Dock=Fill
            this.panelContainer.Controls.Add(this.panelWater);
            this.panelContainer.Controls.Add(this.panelBmr);
            this.panelContainer.Location = new System.Drawing.Point(12, 53); // Под кнопками
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(776, 385); // Размер под форму
            this.panelContainer.TabIndex = 3;
            //
            // panelBmr
            //
            this.panelBmr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBmr.Controls.Add(this.lblCarbsResult);
            this.panelBmr.Controls.Add(this.lblFatResult);
            this.panelBmr.Controls.Add(this.lblProteinResult);
            this.panelBmr.Controls.Add(this.lblTdeeResult);
            this.panelBmr.Controls.Add(this.lblBmrResult);
            this.panelBmr.Controls.Add(this.btnCalculateBmr);
            this.panelBmr.Controls.Add(this.cmbActivityLevel);
            this.panelBmr.Controls.Add(this.label5);
            this.panelBmr.Controls.Add(this.cmbGender);
            this.panelBmr.Controls.Add(this.label4);
            this.panelBmr.Controls.Add(this.txtBmrWeight);
            this.panelBmr.Controls.Add(this.label3);
            this.panelBmr.Controls.Add(this.txtBmrHeight);
            this.panelBmr.Controls.Add(this.label2);
            this.panelBmr.Controls.Add(this.txtBmrAge);
            this.panelBmr.Controls.Add(this.label1);
            this.panelBmr.Dock = System.Windows.Forms.DockStyle.Fill; // Заполняет panelContainer
            this.panelBmr.Location = new System.Drawing.Point(0, 0);
            this.panelBmr.Name = "panelBmr";
            this.panelBmr.Size = new System.Drawing.Size(776, 385); // Размер соответствует контейнеру
            this.panelBmr.TabIndex = 0; // Таб-индекс внутри контейнера
            this.panelBmr.Visible = false; // Скрыта по умолчанию
            //
            // lblCarbsResult
            //
            this.lblCarbsResult.AutoSize = true;
            this.lblCarbsResult.Location = new System.Drawing.Point(17, 319);
            this.lblCarbsResult.Name = "lblCarbsResult";
            this.lblCarbsResult.Size = new System.Drawing.Size(63, 13); // Скорректировано
            this.lblCarbsResult.TabIndex = 15;
            this.lblCarbsResult.Text = "Углеводы:";
            //
            // lblFatResult
            //
            this.lblFatResult.AutoSize = true;
            this.lblFatResult.Location = new System.Drawing.Point(17, 296);
            this.lblFatResult.Name = "lblFatResult";
            this.lblFatResult.Size = new System.Drawing.Size(41, 13);
            this.lblFatResult.TabIndex = 14;
            this.lblFatResult.Text = "Жиры:";
            //
            // lblProteinResult
            //
            this.lblProteinResult.AutoSize = true;
            this.lblProteinResult.Location = new System.Drawing.Point(17, 273);
            this.lblProteinResult.Name = "lblProteinResult";
            this.lblProteinResult.Size = new System.Drawing.Size(41, 13);
            this.lblProteinResult.TabIndex = 13;
            this.lblProteinResult.Text = "Белки:";
            //
            // lblTdeeResult
            //
            this.lblTdeeResult.AutoSize = true;
            this.lblTdeeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTdeeResult.Location = new System.Drawing.Point(17, 250);
            this.lblTdeeResult.Name = "lblTdeeResult";
            this.lblTdeeResult.Size = new System.Drawing.Size(187, 13);
            this.lblTdeeResult.TabIndex = 12;
            this.lblTdeeResult.Text = "Суточная потребность (TDEE):";
            //
            // lblBmrResult
            //
            this.lblBmrResult.AutoSize = true;
            this.lblBmrResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBmrResult.Location = new System.Drawing.Point(17, 227);
            this.lblBmrResult.Name = "lblBmrResult";
            this.lblBmrResult.Size = new System.Drawing.Size(177, 13);
            this.lblBmrResult.TabIndex = 11;
            this.lblBmrResult.Text = "Базовый метаболизм (BMR):";
            //
            // btnCalculateBmr
            //
            this.btnCalculateBmr.Location = new System.Drawing.Point(20, 177);
            this.btnCalculateBmr.Name = "btnCalculateBmr";
            this.btnCalculateBmr.Size = new System.Drawing.Size(100, 30);
            this.btnCalculateBmr.TabIndex = 10;
            this.btnCalculateBmr.Text = "Рассчитать";
            this.btnCalculateBmr.UseVisualStyleBackColor = true;
            this.btnCalculateBmr.Click += new System.EventHandler(this.BtnCalculateBmr_Click);
            //
            // cmbActivityLevel
            //
            this.cmbActivityLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivityLevel.FormattingEnabled = true;
            this.cmbActivityLevel.Items.AddRange(new object[] {
            "Сидячий",
            "Легкая активность",
            "Умеренная активность",
            "Высокая активность",
            "Очень высокая активность"});
            this.cmbActivityLevel.Location = new System.Drawing.Point(147, 137);
            this.cmbActivityLevel.Name = "cmbActivityLevel";
            this.cmbActivityLevel.Size = new System.Drawing.Size(187, 21);
            this.cmbActivityLevel.TabIndex = 9;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Уровень активности:";
            //
            // cmbGender
            //
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.cmbGender.Location = new System.Drawing.Point(147, 105);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 21);
            this.cmbGender.TabIndex = 7;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Пол:";
            //
            // txtBmrWeight
            //
            this.txtBmrWeight.Location = new System.Drawing.Point(147, 74);
            this.txtBmrWeight.Name = "txtBmrWeight";
            this.txtBmrWeight.Size = new System.Drawing.Size(100, 20);
            this.txtBmrWeight.TabIndex = 5;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вес (кг):";
            //
            // txtBmrHeight
            //
            this.txtBmrHeight.Location = new System.Drawing.Point(147, 45);
            this.txtBmrHeight.Name = "txtBmrHeight";
            this.txtBmrHeight.Size = new System.Drawing.Size(100, 20);
            this.txtBmrHeight.TabIndex = 3;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Рост (см):";
            //
            // txtBmrAge
            //
            this.txtBmrAge.Location = new System.Drawing.Point(147, 16);
            this.txtBmrAge.Name = "txtBmrAge";
            this.txtBmrAge.Size = new System.Drawing.Size(100, 20);
            this.txtBmrAge.TabIndex = 1;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Возраст (лет):";
            //
            // panelWater
            //
            this.panelWater.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWater.Controls.Add(this.lblWaterResult);
            this.panelWater.Controls.Add(this.btnCalculateWater);
            this.panelWater.Controls.Add(this.txtWaterWeight);
            this.panelWater.Controls.Add(this.label6);
            this.panelWater.Dock = System.Windows.Forms.DockStyle.Fill; // Заполняет panelContainer
            this.panelWater.Location = new System.Drawing.Point(0, 0);
            this.panelWater.Name = "panelWater";
            this.panelWater.Size = new System.Drawing.Size(776, 385); // Размер соответствует контейнеру
            this.panelWater.TabIndex = 1; // Таб-индекс внутри контейнера
            this.panelWater.Visible = false; // Скрыта по умолчанию
            //
            // lblWaterResult
            //
            this.lblWaterResult.AutoSize = true;
            this.lblWaterResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWaterResult.Location = new System.Drawing.Point(17, 108);
            this.lblWaterResult.Name = "lblWaterResult";
            this.lblWaterResult.Size = new System.Drawing.Size(212, 16);
            this.lblWaterResult.TabIndex = 3; // Обновлен таб-индекс
            this.lblWaterResult.Text = "Реком. потребление воды:";
            //
            // btnCalculateWater
            //
            this.btnCalculateWater.Location = new System.Drawing.Point(20, 58);
            this.btnCalculateWater.Name = "btnCalculateWater";
            this.btnCalculateWater.Size = new System.Drawing.Size(100, 30);
            this.btnCalculateWater.TabIndex = 2; // Обновлен таб-индекс
            this.btnCalculateWater.Text = "Рассчитать";
            this.btnCalculateWater.UseVisualStyleBackColor = true;
            this.btnCalculateWater.Click += new System.EventHandler(this.BtnCalculateWater_Click);
            //
            // txtWaterWeight
            //
            this.txtWaterWeight.Location = new System.Drawing.Point(147, 16);
            this.txtWaterWeight.Name = "txtWaterWeight";
            this.txtWaterWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWaterWeight.TabIndex = 1; // Обновлен таб-индекс
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 0; // Обновлен таб-индекс
            this.label6.Text = "Вес (кг):";
            //
            // panelObesity
            //
            this.panelObesity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelObesity.Controls.Add(this.lblObesityStatusResult);
            this.panelObesity.Controls.Add(this.lblBmiResult);
            this.panelObesity.Controls.Add(this.btnCalculateObesity);
            this.panelObesity.Controls.Add(this.txtObesityWeight);
            this.panelObesity.Controls.Add(this.label8);
            this.panelObesity.Controls.Add(this.txtObesityHeight);
            this.panelObesity.Controls.Add(this.label7);
            this.panelObesity.Dock = System.Windows.Forms.DockStyle.Fill; // Заполняет panelContainer
            this.panelObesity.Location = new System.Drawing.Point(0, 0);
            this.panelObesity.Name = "panelObesity";
            this.panelObesity.Size = new System.Drawing.Size(776, 385); // Размер соответствует контейнеру
            this.panelObesity.TabIndex = 2; // Таб-индекс внутри контейнера
            this.panelObesity.Visible = false; // Скрыта по умолчанию
            //
            // lblObesityStatusResult
            //
            this.lblObesityStatusResult.AutoSize = true;
            this.lblObesityStatusResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblObesityStatusResult.Location = new System.Drawing.Point(17, 148);
            this.lblObesityStatusResult.Name = "lblObesityStatusResult";
            this.lblObesityStatusResult.Size = new System.Drawing.Size(50, 15);
            this.lblObesityStatusResult.TabIndex = 6; // Таб-индекс
            this.lblObesityStatusResult.Text = "Статус:";
            //
            // lblBmiResult
            //
            this.lblBmiResult.AutoSize = true;
            this.lblBmiResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBmiResult.Location = new System.Drawing.Point(17, 119);
            this.lblBmiResult.Name = "lblBmiResult";
            this.lblBmiResult.Size = new System.Drawing.Size(193, 16);
            this.lblBmiResult.TabIndex = 5; // Таб-индекс
            this.lblBmiResult.Text = "Индекс Массы Тела (ИМТ):";
            //
            // btnCalculateObesity
            //
            this.btnCalculateObesity.Location = new System.Drawing.Point(20, 74);
            this.btnCalculateObesity.Name = "btnCalculateObesity";
            this.btnCalculateObesity.Size = new System.Drawing.Size(100, 30);
            this.btnCalculateObesity.TabIndex = 4; // Таб-индекс
            this.btnCalculateObesity.Text = "Рассчитать";
            this.btnCalculateObesity.UseVisualStyleBackColor = true;
            this.btnCalculateObesity.Click += new System.EventHandler(this.BtnCalculateObesity_Click);
            //
            // txtObesityWeight
            //
            this.txtObesityWeight.Location = new System.Drawing.Point(147, 45); // Позиция X скорректирована
            this.txtObesityWeight.Name = "txtObesityWeight";
            this.txtObesityWeight.Size = new System.Drawing.Size(100, 20);
            this.txtObesityWeight.TabIndex = 3; // Таб-индекс
            //
            // label8
            //
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 2; // Таб-индекс
            this.label8.Text = "Вес (кг):";
            //
            // txtObesityHeight
            //
            this.txtObesityHeight.Location = new System.Drawing.Point(147, 16); // Позиция X скорректирована
            this.txtObesityHeight.Name = "txtObesityHeight";
            this.txtObesityHeight.Size = new System.Drawing.Size(100, 20);
            this.txtObesityHeight.TabIndex = 1; // Таб-индекс
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 0; // Таб-индекс
            this.label7.Text = "Рост (см):";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContainer); // Добавляем контейнер
            this.Controls.Add(this.btnShowObesityCalc); // Добавляем кнопки НАД контейнером
            this.Controls.Add(this.btnShowWaterCalc);
            this.Controls.Add(this.btnShowBmrCalc);
            this.MinimumSize = new System.Drawing.Size(600, 400); // Можно настроить под контент
            this.Name = "Form1";
            this.Text = "Калькулятор Здоровья"; // Общее название
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBmr.ResumeLayout(false);
            this.panelBmr.PerformLayout();
            this.panelWater.ResumeLayout(false);
            this.panelWater.PerformLayout();
            this.panelObesity.ResumeLayout(false);
            this.panelObesity.PerformLayout();
            this.panelContainer.ResumeLayout(false); // Добавлено
            this.ResumeLayout(false);

        }
        #endregion

        // --- Объявления контролов (восстановлены) ---
        private System.Windows.Forms.Button btnShowBmrCalc;
        private System.Windows.Forms.Button btnShowWaterCalc;
        private System.Windows.Forms.Button btnShowObesityCalc;
        private System.Windows.Forms.Panel panelBmr;
        private System.Windows.Forms.Label lblCarbsResult;
        private System.Windows.Forms.Label lblFatResult;
        private System.Windows.Forms.Label lblProteinResult;
        private System.Windows.Forms.Label lblTdeeResult;
        private System.Windows.Forms.Label lblBmrResult;
        private System.Windows.Forms.Button btnCalculateBmr;
        private System.Windows.Forms.ComboBox cmbActivityLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBmrWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBmrHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBmrAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelWater;
        private System.Windows.Forms.Label lblWaterResult;
        private System.Windows.Forms.Button btnCalculateWater;
        private System.Windows.Forms.TextBox txtWaterWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelObesity;
        private System.Windows.Forms.Label lblObesityStatusResult;
        private System.Windows.Forms.Label lblBmiResult;
        private System.Windows.Forms.Button btnCalculateObesity;
        private System.Windows.Forms.TextBox txtObesityWeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObesityHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelContainer; // Контейнер для панелей
    }
}
// --- КОНЕЦ ФАЙЛА kalori\Form1.Designer.cs ---