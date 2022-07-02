namespace MovieRecommender
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchInputTextBox = new System.Windows.Forms.TextBox();
            this.SearchResultListBox = new System.Windows.Forms.ListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.searchResultsLabel = new System.Windows.Forms.Label();
            this.MovieSelectionPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.GetRecommendationsButton = new System.Windows.Forms.Button();
            this.ClearSelectionButton = new System.Windows.Forms.Button();
            this.RatingWeightBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectionCountLabel = new System.Windows.Forms.Label();
            this.RecommendationsBox = new System.Windows.Forms.GroupBox();
            this.RecommendationsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.RatingWeightBar)).BeginInit();
            this.RecommendationsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchInputTextBox
            // 
            this.SearchInputTextBox.Location = new System.Drawing.Point(11, 32);
            this.SearchInputTextBox.Name = "SearchInputTextBox";
            this.SearchInputTextBox.Size = new System.Drawing.Size(267, 27);
            this.SearchInputTextBox.TabIndex = 0;
            // 
            // SearchResultListBox
            // 
            this.SearchResultListBox.FormattingEnabled = true;
            this.SearchResultListBox.ItemHeight = 20;
            this.SearchResultListBox.Location = new System.Drawing.Point(11, 65);
            this.SearchResultListBox.Name = "SearchResultListBox";
            this.SearchResultListBox.Size = new System.Drawing.Size(358, 364);
            this.SearchResultListBox.TabIndex = 2;
            this.SearchResultListBox.SelectedValueChanged += new System.EventHandler(this.searchResultListBox_SelectedValueChangedAsync);
            this.SearchResultListBox.DoubleClick += new System.EventHandler(this.searchResultListBox_DoubleClick);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(284, 30);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(85, 30);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "suchen";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // searchResultsLabel
            // 
            this.searchResultsLabel.Location = new System.Drawing.Point(18, 442);
            this.searchResultsLabel.Name = "searchResultsLabel";
            this.searchResultsLabel.Size = new System.Drawing.Size(155, 20);
            this.searchResultsLabel.TabIndex = 4;
            // 
            // MovieSelectionPanel
            // 
            this.MovieSelectionPanel.AutoScroll = true;
            this.MovieSelectionPanel.Location = new System.Drawing.Point(375, 65);
            this.MovieSelectionPanel.Name = "MovieSelectionPanel";
            this.MovieSelectionPanel.Size = new System.Drawing.Size(1016, 364);
            this.MovieSelectionPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select Movies:";
            // 
            // GetRecommendationsButton
            // 
            this.GetRecommendationsButton.Location = new System.Drawing.Point(375, 438);
            this.GetRecommendationsButton.Name = "GetRecommendationsButton";
            this.GetRecommendationsButton.Size = new System.Drawing.Size(723, 29);
            this.GetRecommendationsButton.TabIndex = 9;
            this.GetRecommendationsButton.Text = "get recommendations";
            this.GetRecommendationsButton.UseVisualStyleBackColor = true;
            this.GetRecommendationsButton.Click += new System.EventHandler(this.GetRecommendationsButton_Click);
            // 
            // ClearSelectionButton
            // 
            this.ClearSelectionButton.Location = new System.Drawing.Point(471, 30);
            this.ClearSelectionButton.Name = "ClearSelectionButton";
            this.ClearSelectionButton.Size = new System.Drawing.Size(140, 29);
            this.ClearSelectionButton.TabIndex = 10;
            this.ClearSelectionButton.Text = "clear selection";
            this.ClearSelectionButton.UseVisualStyleBackColor = true;
            this.ClearSelectionButton.Click += new System.EventHandler(this.ClearSelectionButton_Click);
            // 
            // RatingWeightBar
            // 
            this.RatingWeightBar.Location = new System.Drawing.Point(792, 473);
            this.RatingWeightBar.Name = "RatingWeightBar";
            this.RatingWeightBar.Size = new System.Drawing.Size(306, 56);
            this.RatingWeightBar.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(689, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "rating weight";
            // 
            // SelectionCountLabel
            // 
            this.SelectionCountLabel.AutoSize = true;
            this.SelectionCountLabel.Location = new System.Drawing.Point(376, 34);
            this.SelectionCountLabel.Name = "SelectionCountLabel";
            this.SelectionCountLabel.Size = new System.Drawing.Size(76, 20);
            this.SelectionCountLabel.TabIndex = 13;
            this.SelectionCountLabel.Text = "0 selected";
            // 
            // RecommendationsBox
            // 
            this.RecommendationsBox.Controls.Add(this.RecommendationsPanel);
            this.RecommendationsBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RecommendationsBox.Location = new System.Drawing.Point(0, 560);
            this.RecommendationsBox.Margin = new System.Windows.Forms.Padding(10);
            this.RecommendationsBox.Name = "RecommendationsBox";
            this.RecommendationsBox.Size = new System.Drawing.Size(1421, 382);
            this.RecommendationsBox.TabIndex = 14;
            this.RecommendationsBox.TabStop = false;
            this.RecommendationsBox.Text = "recommendations";
            // 
            // RecommendationsPanel
            // 
            this.RecommendationsPanel.AutoScroll = true;
            this.RecommendationsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecommendationsPanel.Location = new System.Drawing.Point(3, 23);
            this.RecommendationsPanel.Name = "RecommendationsPanel";
            this.RecommendationsPanel.Size = new System.Drawing.Size(1415, 356);
            this.RecommendationsPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 942);
            this.Controls.Add(this.RecommendationsBox);
            this.Controls.Add(this.SelectionCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RatingWeightBar);
            this.Controls.Add(this.ClearSelectionButton);
            this.Controls.Add(this.GetRecommendationsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MovieSelectionPanel);
            this.Controls.Add(this.searchResultsLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchResultListBox);
            this.Controls.Add(this.SearchInputTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.RatingWeightBar)).EndInit();
            this.RecommendationsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SearchInputTextBox;
        private ListBox SearchResultListBox;
        private Button SearchButton;
        private Label searchResultsLabel;
        private FlowLayoutPanel MovieSelectionPanel;
        private Label label1;
        private Button GetRecommendationsButton;
        private Button ClearSelectionButton;
        private TrackBar RatingWeightBar;
        private Label label2;
        private Label SelectionCountLabel;
        private GroupBox RecommendationsBox;
        private FlowLayoutPanel RecommendationsPanel;
    }
}