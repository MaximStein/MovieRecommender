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
          //  this.Margin = new Padding(20);
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

        public string MovieRating
        {
            set { ratingLabel.Text = value; }
        }
        
        public string MovieGenres
        {
            set { genresLabel.Text = value; }
        }

        public void LoadMovieData(Pocos.MovieDetails m) {
            MovieTitle = m.title;
            PosterImageUrl = GetMoviePosterImageUrl(m.poster_path);
            MovieReleaseYear = ""+m.release_date.Year;
            MovieRating = "★ "+m.vote_average + "/10";
            MovieGenres = string.Join(", ", m.genres.Select(g => g.name).ToArray());
        }

        private void getRecommendationsButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test");
        }


        public void SetOnButtonClick(EventHandler h)
        {
            getRecommendationsButton.Click += h;
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
            this.getRecommendationsButton = new System.Windows.Forms.Button();
            this.genresLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).BeginInit();
            this.SuspendLayout();
            // 
            // posterImage
            // 
            this.posterImage.ImageLocation = "https://image.tmdb.org/t/p/w154/2jEN9v4myEXgtX6fdkOdGW1noLr.jpg";
            this.posterImage.Location = new System.Drawing.Point(32, 14);
            this.posterImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.posterImage.Name = "posterImage";
            this.posterImage.Size = new System.Drawing.Size(137, 176);
            this.posterImage.TabIndex = 0;
            this.posterImage.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(3, 190);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(192, 37);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "label1";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // releaseYearLabel
            // 
            this.releaseYearLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.releaseYearLabel.Location = new System.Drawing.Point(32, 250);
            this.releaseYearLabel.Name = "releaseYearLabel";
            this.releaseYearLabel.Size = new System.Drawing.Size(59, 25);
            this.releaseYearLabel.TabIndex = 2;
            this.releaseYearLabel.Text = "label1";
            this.releaseYearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ratingLabel
            // 
            this.ratingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ratingLabel.Location = new System.Drawing.Point(97, 250);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(72, 25);
            this.ratingLabel.TabIndex = 3;
            this.ratingLabel.Text = "label1";
            this.ratingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // getRecommendationsButton
            // 
            this.getRecommendationsButton.Location = new System.Drawing.Point(32, 277);
            this.getRecommendationsButton.Name = "getRecommendationsButton";
            this.getRecommendationsButton.Size = new System.Drawing.Size(137, 30);
            this.getRecommendationsButton.TabIndex = 4;
            this.getRecommendationsButton.Text = "get recommendations";
            this.getRecommendationsButton.UseVisualStyleBackColor = true;
            this.getRecommendationsButton.Click += new System.EventHandler(this.getRecommendationsButton_Click);
            // 
            // genresLabel
            // 
            this.genresLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.genresLabel.Location = new System.Drawing.Point(3, 222);
            this.genresLabel.Name = "genresLabel";
            this.genresLabel.Size = new System.Drawing.Size(192, 25);
            this.genresLabel.TabIndex = 5;
            this.genresLabel.Text = "genre1, genre2";
            this.genresLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MovieBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.genresLabel);
            this.Controls.Add(this.getRecommendationsButton);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.releaseYearLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.posterImage);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 20);
            this.MaximumSize = new System.Drawing.Size(200, 320);
            this.Name = "MovieBox";
            this.Size = new System.Drawing.Size(198, 318);
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox posterImage;
        private Label titleLabel;
        private Label releaseYearLabel;
        private Label ratingLabel;
        private Button getRecommendationsButton;
        private Label genresLabel;
    }
}
