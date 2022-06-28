namespace MovieRecommender
{
    partial class MovieBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        const String tmdbPosterImagaPath = @"https://image.tmdb.org/t/p/w154/";

        private Pocos.MovieDetails _movieDetails = null;
        
        public Pocos.MovieDetails MovieDetails
        {
            get { return this._movieDetails; }
            set
            {
                this._movieDetails = value;
                this.Name = "" + value.id;
                MovieTitle = value.title;
                PosterImageUrl = GetMoviePosterImageUrl(value.poster_path);
                MovieReleaseYear = "" + value.release_date.Year;
                MovieRating = "★ " + value.vote_average + "/10";
                MovieGenres = string.Join(", ", value.genres.Select(g => g.name).ToArray());
            }
        }

        public int MovieId { get { return this._movieDetails.id; } }

        public MovieBox(Pocos.MovieDetails m, EventHandler closeButtonHandler) : this()
        {
          
            if (closeButtonHandler != null)
                closeButton.Click += closeButtonHandler;
            else
                closeButton.Hide();

            this.MovieDetails = m;
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test");
        }


        public void AddCloseButtonHandler(EventHandler h)
        {
            closeButton.Visible = true;
            closeButton.Click += h;
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
            this.closeButton = new System.Windows.Forms.Button();
            this.genresLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).BeginInit();
            this.SuspendLayout();
            // 
            // posterImage
            // 
            this.posterImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.posterImage.ImageLocation = "https://image.tmdb.org/t/p/w154/2jEN9v4myEXgtX6fdkOdGW1noLr.jpg";
            this.posterImage.Location = new System.Drawing.Point(8, 9);
            this.posterImage.Name = "posterImage";
            this.posterImage.Size = new System.Drawing.Size(157, 235);
            this.posterImage.TabIndex = 0;
            this.posterImage.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(-1, 244);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(177, 40);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "a very very very long movie title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // releaseYearLabel
            // 
            this.releaseYearLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.releaseYearLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.releaseYearLabel.Location = new System.Drawing.Point(8, 318);
            this.releaseYearLabel.Name = "releaseYearLabel";
            this.releaseYearLabel.Size = new System.Drawing.Size(70, 24);
            this.releaseYearLabel.TabIndex = 2;
            this.releaseYearLabel.Text = "label1";
            this.releaseYearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ratingLabel
            // 
            this.ratingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ratingLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ratingLabel.Location = new System.Drawing.Point(90, 318);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(75, 24);
            this.ratingLabel.TabIndex = 3;
            this.ratingLabel.Text = "label1";
            this.ratingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(146, -1);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "✕";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // genresLabel
            // 
            this.genresLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.genresLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.genresLabel.Location = new System.Drawing.Point(-1, 281);
            this.genresLabel.Name = "genresLabel";
            this.genresLabel.Size = new System.Drawing.Size(177, 42);
            this.genresLabel.TabIndex = 5;
            this.genresLabel.Text = "genre1, genre2, genre3, genre4";
            this.genresLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MovieBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.genresLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.releaseYearLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.posterImage);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 27);
            this.MaximumSize = new System.Drawing.Size(200, 350);
            this.Name = "MovieBox";
            this.Size = new System.Drawing.Size(175, 348);
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox posterImage;
        private Label titleLabel;
        private Label releaseYearLabel;
        private Label ratingLabel;
        private Button closeButton;
        private Label genresLabel;
    }
}
