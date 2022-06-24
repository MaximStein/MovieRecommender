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
            this.searchInputTextBox = new System.Windows.Forms.TextBox();
            this.searchResultListBox = new System.Windows.Forms.ListBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchResultsLabel = new System.Windows.Forms.Label();
            this.recommendationsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.selectionMovieBox = new MovieRecommender.MovieBox();
            this.SuspendLayout();
            // 
            // searchInputTextBox
            // 
            this.searchInputTextBox.Location = new System.Drawing.Point(10, 9);
            this.searchInputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchInputTextBox.Name = "searchInputTextBox";
            this.searchInputTextBox.Size = new System.Drawing.Size(233, 23);
            this.searchInputTextBox.TabIndex = 0;
            // 
            // searchResultListBox
            // 
            this.searchResultListBox.FormattingEnabled = true;
            this.searchResultListBox.ItemHeight = 15;
            this.searchResultListBox.Location = new System.Drawing.Point(10, 46);
            this.searchResultListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchResultListBox.Name = "searchResultListBox";
            this.searchResultListBox.Size = new System.Drawing.Size(375, 229);
            this.searchResultListBox.TabIndex = 2;
            this.searchResultListBox.SelectedIndexChanged += new System.EventHandler(this.searchResultListBox_SelectedIndexChanged);
            this.searchResultListBox.SelectedValueChanged += new System.EventHandler(this.searchResultListBox_SelectedValueChangedAsync);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(259, 9);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(126, 24);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "suchen";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchResultsLabel
            // 
            this.searchResultsLabel.AutoSize = true;
            this.searchResultsLabel.Location = new System.Drawing.Point(10, 296);
            this.searchResultsLabel.Name = "searchResultsLabel";
            this.searchResultsLabel.Size = new System.Drawing.Size(0, 15);
            this.searchResultsLabel.TabIndex = 4;
            // 
            // recommendationsPanel
            // 
            this.recommendationsPanel.AutoScroll = true;
            this.recommendationsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.recommendationsPanel.Location = new System.Drawing.Point(0, 398);
            this.recommendationsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.recommendationsPanel.Name = "recommendationsPanel";
            this.recommendationsPanel.Padding = new System.Windows.Forms.Padding(10);
            this.recommendationsPanel.Size = new System.Drawing.Size(975, 356);
            this.recommendationsPanel.TabIndex = 6;
            // 
            // selectionMovieBox
            // 
            this.selectionMovieBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectionMovieBox.Location = new System.Drawing.Point(391, 11);
            this.selectionMovieBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectionMovieBox.MaximumSize = new System.Drawing.Size(200, 320);
            this.selectionMovieBox.Name = "selectionMovieBox";
            this.selectionMovieBox.Size = new System.Drawing.Size(198, 318);
            this.selectionMovieBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 754);
            this.Controls.Add(this.selectionMovieBox);
            this.Controls.Add(this.recommendationsPanel);
            this.Controls.Add(this.searchResultsLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchResultListBox);
            this.Controls.Add(this.searchInputTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox searchInputTextBox;
        private ListBox searchResultListBox;
        private Button searchButton;
        private Label searchResultsLabel;
        private FlowLayoutPanel recommendationsPanel;
        private MovieBox selectionMovieBox;
    }
}