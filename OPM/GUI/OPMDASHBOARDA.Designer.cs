
namespace OPM.GUI
{
    partial class OPMDASHBOARDA
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
            this.components = new System.ComponentModel.Container();
            this.panCatalog = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.treeViewOPM = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuNewContract = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewPO = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewNTKT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewDP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewPL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuCreatDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.panContent = new System.Windows.Forms.Panel();
            this.panCatalog.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCatalog
            // 
            this.panCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panCatalog.BackColor = System.Drawing.Color.Lavender;
            this.panCatalog.Controls.Add(this.label1);
            this.panCatalog.Controls.Add(this.tb_search);
            this.panCatalog.Controls.Add(this.treeViewOPM);
            this.panCatalog.Location = new System.Drawing.Point(12, 17);
            this.panCatalog.Name = "panCatalog";
            this.panCatalog.Size = new System.Drawing.Size(242, 885);
            this.panCatalog.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm kiếm mã hợp đồng:";
            // 
            // tb_search
            // 
            this.tb_search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.tb_search.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tb_search.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_search.Location = new System.Drawing.Point(3, 32);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(239, 29);
            this.tb_search.TabIndex = 1;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // treeViewOPM
            // 
            this.treeViewOPM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewOPM.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.treeViewOPM.ContextMenuStrip = this.contextMenuStrip;
            this.treeViewOPM.FullRowSelect = true;
            this.treeViewOPM.ItemHeight = 20;
            this.treeViewOPM.LabelEdit = true;
            this.treeViewOPM.Location = new System.Drawing.Point(3, 78);
            this.treeViewOPM.Name = "treeViewOPM";
            this.treeViewOPM.Size = new System.Drawing.Size(239, 804);
            this.treeViewOPM.TabIndex = 0;
            this.treeViewOPM.DoubleClick += new System.EventHandler(this.TreeViewOPM_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuNewContract,
            this.toolStripMenuNewPO,
            this.toolStripMenuNewNTKT,
            this.toolStripMenuNewDP,
            this.toolStripMenuNewPL,
            this.toolStripMenuSave,
            this.toolStripMenuCreatDoc});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(175, 158);
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // toolStripMenuNewContract
            // 
            this.toolStripMenuNewContract.Name = "toolStripMenuNewContract";
            this.toolStripMenuNewContract.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewContract.Text = "Tạo mới Hợp đồng";
            // 
            // toolStripMenuNewPO
            // 
            this.toolStripMenuNewPO.Name = "toolStripMenuNewPO";
            this.toolStripMenuNewPO.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewPO.Text = "Tạo mới PO";
            // 
            // toolStripMenuNewNTKT
            // 
            this.toolStripMenuNewNTKT.CheckOnClick = true;
            this.toolStripMenuNewNTKT.Name = "toolStripMenuNewNTKT";
            this.toolStripMenuNewNTKT.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewNTKT.Text = "Tạo mới NTKT";
            // 
            // toolStripMenuNewDP
            // 
            this.toolStripMenuNewDP.Name = "toolStripMenuNewDP";
            this.toolStripMenuNewDP.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewDP.Text = "Tạo mới DP";
            // 
            // toolStripMenuNewPL
            // 
            this.toolStripMenuNewPL.Name = "toolStripMenuNewPL";
            this.toolStripMenuNewPL.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuNewPL.Text = "Tạo mới PL";
            // 
            // toolStripMenuSave
            // 
            this.toolStripMenuSave.Name = "toolStripMenuSave";
            this.toolStripMenuSave.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuSave.Text = "Save";
            // 
            // toolStripMenuCreatDoc
            // 
            this.toolStripMenuCreatDoc.Name = "toolStripMenuCreatDoc";
            this.toolStripMenuCreatDoc.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuCreatDoc.Text = "Creat Document";
            // 
            // panContent
            // 
            this.panContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panContent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panContent.Location = new System.Drawing.Point(260, 17);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(1160, 885);
            this.panContent.TabIndex = 2;
            // 
            // OPMDASHBOARDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1420, 911);
            this.Controls.Add(this.panContent);
            this.Controls.Add(this.panCatalog);
            this.Name = "OPMDASHBOARDA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPMDASHBOARDA";
            this.Load += new System.EventHandler(this.OPMDASHBOARDA_Load);
            this.panCatalog.ResumeLayout(false);
            this.panCatalog.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panCatalog;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.TreeView treeViewOPM;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewContract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewPO;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewNTKT;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCreatDoc;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewDP;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewPL;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Label label1;
    }
}