
namespace ClientService
{
    partial class frmSettings
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.newBlackListButton = new DevExpress.XtraEditors.SimpleButton();
            this.newBlackList = new DevExpress.XtraEditors.TextEdit();
            this.deleteBlackListButton = new DevExpress.XtraEditors.SimpleButton();
            this.editBlackListButton = new DevExpress.XtraEditors.SimpleButton();
            this.renameBlackList = new DevExpress.XtraEditors.TextEdit();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.addWordButton = new DevExpress.XtraEditors.SimpleButton();
            this.addWord = new DevExpress.XtraEditors.TextEdit();
            this.separatorControl3 = new DevExpress.XtraEditors.SeparatorControl();
            this.editWord = new DevExpress.XtraEditors.TextEdit();
            this.deleteWordButton = new DevExpress.XtraEditors.SimpleButton();
            this.editWordButton = new DevExpress.XtraEditors.SimpleButton();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.newRedirectUrl = new DevExpress.XtraEditors.TextEdit();
            this.editRedirectUrl = new DevExpress.XtraEditors.TextEdit();
            this.addRedirectButton = new DevExpress.XtraEditors.SimpleButton();
            this.newRedirect = new DevExpress.XtraEditors.TextEdit();
            this.deleteRedirectButton = new DevExpress.XtraEditors.SimpleButton();
            this.editRedirectButton = new DevExpress.XtraEditors.SimpleButton();
            this.editRedirect = new DevExpress.XtraEditors.TextEdit();
            this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newBlackList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.renameBlackList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newRedirectUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRedirectUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newRedirect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRedirect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.newBlackListButton);
            this.groupControl1.Controls.Add(this.newBlackList);
            this.groupControl1.Controls.Add(this.deleteBlackListButton);
            this.groupControl1.Controls.Add(this.editBlackListButton);
            this.groupControl1.Controls.Add(this.renameBlackList);
            this.groupControl1.Controls.Add(this.separatorControl1);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(24, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(768, 266);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Заблокированные сайты";
            // 
            // newBlackListButton
            // 
            this.newBlackListButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newBlackListButton.Appearance.Options.UseFont = true;
            this.newBlackListButton.Location = new System.Drawing.Point(557, 148);
            this.newBlackListButton.Name = "newBlackListButton";
            this.newBlackListButton.Size = new System.Drawing.Size(197, 34);
            this.newBlackListButton.TabIndex = 8;
            this.newBlackListButton.Text = "Добавить адрес";
            this.newBlackListButton.Click += new System.EventHandler(this.newBlackListButton_Click);
            // 
            // newBlackList
            // 
            this.newBlackList.EditValue = "";
            this.newBlackList.Location = new System.Drawing.Point(557, 58);
            this.newBlackList.Name = "newBlackList";
            this.newBlackList.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newBlackList.Properties.Appearance.Options.UseFont = true;
            this.newBlackList.Properties.AutoHeight = false;
            this.newBlackList.Properties.MaxLength = 25;
            this.newBlackList.Properties.NullText = "Новый адрес";
            this.newBlackList.Size = new System.Drawing.Size(197, 34);
            this.newBlackList.TabIndex = 7;
            // 
            // deleteBlackListButton
            // 
            this.deleteBlackListButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteBlackListButton.Appearance.Options.UseFont = true;
            this.deleteBlackListButton.Location = new System.Drawing.Point(310, 188);
            this.deleteBlackListButton.Name = "deleteBlackListButton";
            this.deleteBlackListButton.Size = new System.Drawing.Size(197, 36);
            this.deleteBlackListButton.TabIndex = 6;
            this.deleteBlackListButton.Text = "Удалить сайт";
            this.deleteBlackListButton.Click += new System.EventHandler(this.deleteBlackListButton_Click);
            // 
            // editBlackListButton
            // 
            this.editBlackListButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editBlackListButton.Appearance.Options.UseFont = true;
            this.editBlackListButton.Location = new System.Drawing.Point(310, 148);
            this.editBlackListButton.Name = "editBlackListButton";
            this.editBlackListButton.Size = new System.Drawing.Size(197, 34);
            this.editBlackListButton.TabIndex = 5;
            this.editBlackListButton.Text = "Изменить адрес";
            this.editBlackListButton.Click += new System.EventHandler(this.editBlackListButton_Click);
            // 
            // renameBlackList
            // 
            this.renameBlackList.EditValue = "";
            this.renameBlackList.Location = new System.Drawing.Point(310, 58);
            this.renameBlackList.Name = "renameBlackList";
            this.renameBlackList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.renameBlackList.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.renameBlackList.Properties.Appearance.Options.UseFont = true;
            this.renameBlackList.Properties.AutoHeight = false;
            this.renameBlackList.Properties.MaxLength = 25;
            this.renameBlackList.Properties.NullText = "Измененный адрес сайта";
            this.renameBlackList.Size = new System.Drawing.Size(197, 34);
            this.renameBlackList.TabIndex = 4;
            // 
            // separatorControl1
            // 
            this.separatorControl1.LineColor = System.Drawing.Color.Black;
            this.separatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl1.Location = new System.Drawing.Point(492, 24);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(75, 237);
            this.separatorControl1.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(5, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(298, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.groupControl3.Appearance.Options.UseBorderColor = true;
            this.groupControl3.Controls.Add(this.addWordButton);
            this.groupControl3.Controls.Add(this.addWord);
            this.groupControl3.Controls.Add(this.separatorControl3);
            this.groupControl3.Controls.Add(this.editWord);
            this.groupControl3.Controls.Add(this.deleteWordButton);
            this.groupControl3.Controls.Add(this.editWordButton);
            this.groupControl3.Controls.Add(this.searchControl1);
            this.groupControl3.Controls.Add(this.listBoxControl1);
            this.groupControl3.Location = new System.Drawing.Point(798, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(211, 538);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Стоп слова";
            // 
            // addWordButton
            // 
            this.addWordButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addWordButton.Appearance.Options.UseFont = true;
            this.addWordButton.Location = new System.Drawing.Point(5, 460);
            this.addWordButton.Name = "addWordButton";
            this.addWordButton.Size = new System.Drawing.Size(197, 34);
            this.addWordButton.TabIndex = 11;
            this.addWordButton.Text = "Добавить слово";
            this.addWordButton.Click += new System.EventHandler(this.addWordButton_Click);
            // 
            // addWord
            // 
            this.addWord.EditValue = "";
            this.addWord.Location = new System.Drawing.Point(5, 400);
            this.addWord.Name = "addWord";
            this.addWord.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addWord.Properties.Appearance.Options.UseFont = true;
            this.addWord.Properties.AutoHeight = false;
            this.addWord.Properties.MaxLength = 25;
            this.addWord.Properties.NullText = "Новый адрес";
            this.addWord.Size = new System.Drawing.Size(197, 34);
            this.addWord.TabIndex = 10;
            // 
            // separatorControl3
            // 
            this.separatorControl3.LineColor = System.Drawing.Color.Black;
            this.separatorControl3.Location = new System.Drawing.Point(5, 354);
            this.separatorControl3.Name = "separatorControl3";
            this.separatorControl3.Size = new System.Drawing.Size(201, 52);
            this.separatorControl3.TabIndex = 9;
            // 
            // editWord
            // 
            this.editWord.EditValue = "";
            this.editWord.Location = new System.Drawing.Point(5, 232);
            this.editWord.Name = "editWord";
            this.editWord.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.editWord.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editWord.Properties.Appearance.Options.UseFont = true;
            this.editWord.Properties.AutoHeight = false;
            this.editWord.Properties.MaxLength = 25;
            this.editWord.Properties.NullText = "Измененный адрес сайта";
            this.editWord.Size = new System.Drawing.Size(197, 34);
            this.editWord.TabIndex = 9;
            // 
            // deleteWordButton
            // 
            this.deleteWordButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteWordButton.Appearance.Options.UseFont = true;
            this.deleteWordButton.Location = new System.Drawing.Point(5, 312);
            this.deleteWordButton.Name = "deleteWordButton";
            this.deleteWordButton.Size = new System.Drawing.Size(197, 36);
            this.deleteWordButton.TabIndex = 8;
            this.deleteWordButton.Text = "Удалить слово";
            this.deleteWordButton.Click += new System.EventHandler(this.deleteWordButton_Click);
            // 
            // editWordButton
            // 
            this.editWordButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editWordButton.Appearance.Options.UseFont = true;
            this.editWordButton.Location = new System.Drawing.Point(5, 272);
            this.editWordButton.Name = "editWordButton";
            this.editWordButton.Size = new System.Drawing.Size(197, 34);
            this.editWordButton.TabIndex = 7;
            this.editWordButton.Text = "Изменить слово";
            this.editWordButton.Click += new System.EventHandler(this.editWordButton_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(5, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.searchControl1.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchControl1.Properties.Appearance.Options.UseBackColor = true;
            this.searchControl1.Properties.Appearance.Options.UseFont = true;
            this.searchControl1.Properties.AutoHeight = false;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(197, 35);
            this.searchControl1.TabIndex = 1;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.listBoxControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxControl1.Appearance.Options.UseBackColor = true;
            this.listBoxControl1.Appearance.Options.UseFont = true;
            this.listBoxControl1.Location = new System.Drawing.Point(5, 76);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(197, 148);
            this.listBoxControl1.TabIndex = 0;
            this.listBoxControl1.SelectedValueChanged += new System.EventHandler(this.listBoxControl1_SelectedValueChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.groupControl2.Appearance.Options.UseBorderColor = true;
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.newRedirectUrl);
            this.groupControl2.Controls.Add(this.editRedirectUrl);
            this.groupControl2.Controls.Add(this.addRedirectButton);
            this.groupControl2.Controls.Add(this.newRedirect);
            this.groupControl2.Controls.Add(this.deleteRedirectButton);
            this.groupControl2.Controls.Add(this.editRedirectButton);
            this.groupControl2.Controls.Add(this.editRedirect);
            this.groupControl2.Controls.Add(this.separatorControl2);
            this.groupControl2.Controls.Add(this.gridControl2);
            this.groupControl2.Location = new System.Drawing.Point(24, 284);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(768, 266);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Сайты переадресации";
            // 
            // newRedirectUrl
            // 
            this.newRedirectUrl.EditValue = "";
            this.newRedirectUrl.Location = new System.Drawing.Point(557, 98);
            this.newRedirectUrl.Name = "newRedirectUrl";
            this.newRedirectUrl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newRedirectUrl.Properties.Appearance.Options.UseFont = true;
            this.newRedirectUrl.Properties.AutoHeight = false;
            this.newRedirectUrl.Properties.NullText = "Новый адрес";
            this.newRedirectUrl.Size = new System.Drawing.Size(197, 34);
            this.newRedirectUrl.TabIndex = 10;
            // 
            // editRedirectUrl
            // 
            this.editRedirectUrl.EditValue = "";
            this.editRedirectUrl.Location = new System.Drawing.Point(310, 98);
            this.editRedirectUrl.Name = "editRedirectUrl";
            this.editRedirectUrl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editRedirectUrl.Properties.Appearance.Options.UseFont = true;
            this.editRedirectUrl.Properties.AutoHeight = false;
            this.editRedirectUrl.Properties.NullText = "Измененный адрес сайта";
            this.editRedirectUrl.Size = new System.Drawing.Size(197, 34);
            this.editRedirectUrl.TabIndex = 9;
            // 
            // addRedirectButton
            // 
            this.addRedirectButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addRedirectButton.Appearance.Options.UseFont = true;
            this.addRedirectButton.Location = new System.Drawing.Point(557, 148);
            this.addRedirectButton.Name = "addRedirectButton";
            this.addRedirectButton.Size = new System.Drawing.Size(197, 34);
            this.addRedirectButton.TabIndex = 8;
            this.addRedirectButton.Text = "Добавить адрес";
            this.addRedirectButton.Click += new System.EventHandler(this.addRedirectButton_Click);
            // 
            // newRedirect
            // 
            this.newRedirect.EditValue = "";
            this.newRedirect.Location = new System.Drawing.Point(557, 58);
            this.newRedirect.Name = "newRedirect";
            this.newRedirect.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newRedirect.Properties.Appearance.Options.UseFont = true;
            this.newRedirect.Properties.AutoHeight = false;
            this.newRedirect.Properties.NullText = "Новый адрес";
            this.newRedirect.Size = new System.Drawing.Size(197, 34);
            this.newRedirect.TabIndex = 7;
            // 
            // deleteRedirectButton
            // 
            this.deleteRedirectButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteRedirectButton.Appearance.Options.UseFont = true;
            this.deleteRedirectButton.Location = new System.Drawing.Point(310, 188);
            this.deleteRedirectButton.Name = "deleteRedirectButton";
            this.deleteRedirectButton.Size = new System.Drawing.Size(197, 36);
            this.deleteRedirectButton.TabIndex = 6;
            this.deleteRedirectButton.Text = "Удалить сайт";
            this.deleteRedirectButton.Click += new System.EventHandler(this.deleteRedirectButton_Click);
            // 
            // editRedirectButton
            // 
            this.editRedirectButton.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editRedirectButton.Appearance.Options.UseFont = true;
            this.editRedirectButton.Location = new System.Drawing.Point(310, 148);
            this.editRedirectButton.Name = "editRedirectButton";
            this.editRedirectButton.Size = new System.Drawing.Size(197, 34);
            this.editRedirectButton.TabIndex = 5;
            this.editRedirectButton.Text = "Изменить адрес";
            this.editRedirectButton.Click += new System.EventHandler(this.editRedirectButton_Click);
            // 
            // editRedirect
            // 
            this.editRedirect.EditValue = "";
            this.editRedirect.Location = new System.Drawing.Point(310, 58);
            this.editRedirect.Name = "editRedirect";
            this.editRedirect.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editRedirect.Properties.Appearance.Options.UseFont = true;
            this.editRedirect.Properties.AutoHeight = false;
            this.editRedirect.Properties.NullText = "Измененный адрес сайта";
            this.editRedirect.Size = new System.Drawing.Size(197, 34);
            this.editRedirect.TabIndex = 4;
            // 
            // separatorControl2
            // 
            this.separatorControl2.LineColor = System.Drawing.Color.Black;
            this.separatorControl2.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl2.Location = new System.Drawing.Point(492, 24);
            this.separatorControl2.Name = "separatorControl2";
            this.separatorControl2.Size = new System.Drawing.Size(75, 237);
            this.separatorControl2.TabIndex = 3;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(5, 24);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(298, 200);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 579);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmSettings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newBlackList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.renameBlackList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newRedirectUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRedirectUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newRedirect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRedirect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit renameBlackList;
        private DevExpress.XtraEditors.SimpleButton deleteBlackListButton;
        private DevExpress.XtraEditors.SimpleButton editBlackListButton;
        private DevExpress.XtraEditors.SimpleButton newBlackListButton;
        private DevExpress.XtraEditors.TextEdit newBlackList;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton addRedirectButton;
        private DevExpress.XtraEditors.TextEdit newRedirect;
        private DevExpress.XtraEditors.SimpleButton deleteRedirectButton;
        private DevExpress.XtraEditors.SimpleButton editRedirectButton;
        private DevExpress.XtraEditors.TextEdit editRedirect;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.TextEdit newRedirectUrl;
        private DevExpress.XtraEditors.TextEdit editRedirectUrl;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.TextEdit editWord;
        private DevExpress.XtraEditors.SimpleButton deleteWordButton;
        private DevExpress.XtraEditors.SimpleButton editWordButton;
        private DevExpress.XtraEditors.SimpleButton addWordButton;
        private DevExpress.XtraEditors.TextEdit addWord;
        private DevExpress.XtraEditors.SeparatorControl separatorControl3;
    }
}