namespace WowRealmlistManager
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvRealmlist = new System.Windows.Forms.ListView();
            this.colhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsRealmList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListExpansion = new System.Windows.Forms.ImageList(this.components);
            this.cmsRealmList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvRealmlist
            // 
            this.lvRealmlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhName,
            this.colhAddress,
            this.colhVersion});
            this.lvRealmlist.ContextMenuStrip = this.cmsRealmList;
            this.lvRealmlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRealmlist.FullRowSelect = true;
            this.lvRealmlist.Location = new System.Drawing.Point(0, 0);
            this.lvRealmlist.MultiSelect = false;
            this.lvRealmlist.Name = "lvRealmlist";
            this.lvRealmlist.Size = new System.Drawing.Size(588, 341);
            this.lvRealmlist.SmallImageList = this.imageListExpansion;
            this.lvRealmlist.TabIndex = 1;
            this.lvRealmlist.UseCompatibleStateImageBehavior = false;
            this.lvRealmlist.View = System.Windows.Forms.View.Details;
            this.lvRealmlist.DoubleClick += new System.EventHandler(this.StartClickEvent);
            // 
            // colhName
            // 
            this.colhName.Text = "Name";
            this.colhName.Width = 300;
            // 
            // colhAddress
            // 
            this.colhAddress.Text = "Address";
            this.colhAddress.Width = 200;
            // 
            // colhVersion
            // 
            this.colhVersion.Text = "Version";
            this.colhVersion.Width = 80;
            // 
            // cmsRealmList
            // 
            this.cmsRealmList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWebsite});
            this.cmsRealmList.Name = "cmsRealmList";
            this.cmsRealmList.ShowImageMargin = false;
            this.cmsRealmList.Size = new System.Drawing.Size(92, 26);
            this.cmsRealmList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRealmList_Opening);
            // 
            // tsmiWebsite
            // 
            this.tsmiWebsite.Name = "tsmiWebsite";
            this.tsmiWebsite.Size = new System.Drawing.Size(91, 22);
            this.tsmiWebsite.Text = "Website";
            this.tsmiWebsite.Click += new System.EventHandler(this.WebsiteClickEvent);
            // 
            // imageListExpansion
            // 
            this.imageListExpansion.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListExpansion.ImageStream")));
            this.imageListExpansion.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListExpansion.Images.SetKeyName(0, "wow.png");
            this.imageListExpansion.Images.SetKeyName(1, "bc.gif");
            this.imageListExpansion.Images.SetKeyName(2, "wrath.png");
            this.imageListExpansion.Images.SetKeyName(3, "cata.png");
            this.imageListExpansion.Images.SetKeyName(4, "mists.png");
            this.imageListExpansion.Images.SetKeyName(5, "wod.png");
            this.imageListExpansion.Images.SetKeyName(6, "legion.png");
            this.imageListExpansion.Images.SetKeyName(7, "bfa.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 341);
            this.Controls.Add(this.lvRealmlist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "World of Warcraft Realmlist Manager";
            this.cmsRealmList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRealmlist;
        private System.Windows.Forms.ColumnHeader colhName;
        private System.Windows.Forms.ColumnHeader colhVersion;
        private System.Windows.Forms.ColumnHeader colhAddress;
        private System.Windows.Forms.ImageList imageListExpansion;
        private System.Windows.Forms.ContextMenuStrip cmsRealmList;
        private System.Windows.Forms.ToolStripMenuItem tsmiWebsite;
    }
}

