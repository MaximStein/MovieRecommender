namespace MovieRecommender
{
    partial class MovieBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        const String tmdbPosterImagaPath = @"https://image.tmdb.org/t/p/w154/";

        public MovieBox(Pocos.MovieDetails m) : this()
        {
            LoadMovieData(m);
            
        }

        private String GetMoviePosterImageUrl(String posterFileName)
        {
            return tmdbPosterImagaPath + posterFileName;
        }
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

        public string PosterImageUrl
        {
            set { posterImage.ImageLocation = value; }
        }


        public string MovieTitle { 
            set { titleLabel.Text = value; } 
        }

        public string MovieReleaseYear
        {
            set { releaseYearLabel.Text = value; }
        }

        public void LoadMovieData(Pocos.MovieDetails m) {
            MovieTitle = m.title;
            PosterImageUrl = GetMoviePosterImageUrl(m.poster_path);
            MovieReleaseYear = ""+m.release_date.Year;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.posterImage = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.releaseYearLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).BeginInit();
            this.SuspendLayout();
            // 
            // posterImage
            // 
            this.posterImage.ImageLocation = "https://image.tmdb.org/t/p/w154/2jEN9v4myEXgtX6fdkOdGW1noLr.jpg";
            this.posterImage.Location = new System.Drawing.Point(38, 3);
            this.posterImage.Name = "posterImage";
            this.posterImage.Size = new System.Drawing.Size(157, 234);
            this.posterImage.TabIndex = 0;
            this.posterImage.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.titleLabel.Location = new System.Drawing.Point(3, 254);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(229, 23);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "label1";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // releaseYearLabel
            // 
            this.releaseYearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.releaseYearLabel.Location = new System.Drawing.Point(-12, 277);
            this.releaseYearLabel.Name = "releaseYearLabel";
            this.releaseYearLabel.Size = new System.Drawing.Size(132, 22);
            this.releaseYearLabel.TabIndex = 2;
            this.releaseYearLabel.Text = "label1";
            this.releaseYearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ratingLabel
            // 
            this.ratingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ratingLabel.Location = new System.Drawing.Point(111, 277);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(121, 22);
            this.ratingLabel.TabIndex = 3;
            this.ratingLabel.Text = "label1";
            this.ratingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MovieBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.releaseYearLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.posterImage);
            this.MaximumSize = new System.Drawing.Size(235, 350);
            this.Name = "MovieBox";
            this.Size = new System.Drawing.Size(235, 350);
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox posterImage;
        private Label titleLabel;
        private Label releaseYearLabel;
        private Label ratingLabel;
    }
}
