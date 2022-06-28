using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using MovieRecommender.Pocos;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace MovieRecommender
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();
        bool isWaitingForRecommendations = false;
        const String csvLocation = @"C:/Code/ML/movies_archive/movies_metadata.csv";

        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower().Replace("_", ""),
        };

        public Form1()
        {

            InitializeComponent();
            SearchResultListBox.ValueMember = "Id";
            SearchResultListBox.DisplayMember = "NiceString";

            Load += async (sender, args) =>
            {

                SelectMovie(155);
                var movie1 = await GetMovieDetailsAsync("155");
                var movie2 = await GetMovieDetailsAsync("49026");
                var movie3 = await GetMovieDetailsAsync("49040");
                var movie4 = await GetMovieDetailsAsync("949");


                /*  selectionMovieBox.LoadMovieData(movie1);
                  selectionMovieBox.SetCloseButtonHandler((sender, args) => { 
                      recommendationsPanel.Controls.Clear();
                      recommendationsPanel.Controls.Add(new MovieBox(movie1));
                      recommendationsPanel.Controls.Add(new MovieBox(movie2));
                      recommendationsPanel.Controls.Add(new MovieBox(movie3));
                      recommendationsPanel.Controls.Add(new MovieBox(movie4));                
                  });
                 */
                //recommendationsPanel.Controls.Add(new MovieBox());

            };
        }

        private async Task searchResultListBox_SelectedIndexChangedAsync(object sender, EventArgs e)
        {

        }


        private String getMovieApiCallUrl(String id)
        {
            return "https://api.themoviedb.org/3/movie/" + id + "?api_key=a7af9a07f435184d6005c1e608db0bb7";
        }

        private async Task<MovieDetails> GetMovieDetailsAsync(String id)
        {
            HttpResponseMessage response = await client.GetAsync(getMovieApiCallUrl(id));
            var content = await response.Content.ReadAsStringAsync();
            Pocos.MovieDetails m = Newtonsoft.Json.JsonConvert.DeserializeObject<Pocos.MovieDetails>(content);
            return m;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //GetMovieDetails("1659815648");
            SearchCsvFile(SearchInputTextBox.Text);
        }

        private void SearchCsvFile(String text)
        {
            Console.WriteLine("searching File");
            using (var reader = new StreamReader(csvLocation))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                var resultList = new List<MoviesMetadataRow>();
                //var r = csv.GetRecord<MoviesMetadataRow>();
                while (csv.Read())
                {
                    try
                    {
                        var r = csv.GetRecord<MoviesMetadataRow>();
                        if (r.OriginalTitle.ToLower().Contains(text))
                            resultList.Add(r);
                    }
                    catch (ReaderException ex)
                    {
                        //Console.WriteLine(ex.Message);
                    }
                    catch (TypeConverterException ex2)
                    {

                    }
                }

                var count = resultList.Count();


                if (count > 0)
                {
                    SearchResultListBox.Items.Clear();
                    //searchResultListBox.Items.AddRange(searchResults.Take(50).ToArray());
                    SearchResultListBox.Items.AddRange(resultList.ToArray());
                }
                
                UpdateSelectionLabels();
            }
        }

        private async void searchResultListBox_SelectedValueChangedAsync(object sender, EventArgs e)
        {

        }

        private async void SelectMovie(int id)
        {
            if (!MovieSelectionPanel.Controls.ContainsKey("" + id))
            {
                var data = await GetMovieDetailsAsync("" + id);
                if (data != null)
                {
                    var box = new MovieBox(data, (o, eventArgs) => UnselectMovie(id));
                    MovieSelectionPanel.Controls.Add(box);
                }
            }

            UpdateSelectionLabels();
        }

        private void UnselectMovie(int id)
        {
            MovieSelectionPanel.Controls.RemoveByKey("" + id);
            UpdateSelectionLabels();
        }

        private void UpdateSelectionLabels()
        {
            searchResultsLabel.Text = SearchResultListBox.Items.Count + " search results";
            SelectionCountLabel.Text = MovieSelectionPanel.Controls.OfType<MovieBox>().Count()+" selected"; 
            
        }

        private void searchResultListBox_DoubleClick(object sender, EventArgs e)
        {
            var item = (MoviesMetadataRow)SearchResultListBox.SelectedItem;
            if (item != null)
            {
                SelectMovie(item.Id);
            }
        }

        private void ClearSelectionButton_Click(object sender, EventArgs e)
        {
            MovieSelectionPanel.Controls.Clear();
        }

        private void SetWaitingState(bool waiting)
        {
            isWaitingForRecommendations = waiting;
            GetRecommendationsButton.Enabled = !waiting;
            Cursor.Current = waiting ? Cursors.WaitCursor : Cursors.Default;
        }

        private double GetRatingWeight()
        {
            return 1d * RatingWeightBar.Value / 10;
        }

        private void GetRecommendationsButton_Click(object sender, EventArgs e)
        {
            if(!isWaitingForRecommendations)
            {
                RecommendationsPanel.Controls.Clear();
                SetWaitingState(true);
                var ids = MovieSelectionPanel.Controls.OfType<MovieBox>().Select(c => c.MovieId);

                Program.GetRecommendations(ids, GetRatingWeight(), async (results) =>
                {
                    SetWaitingState(false);
                    if(results != null)
                    {
                        foreach(var item in results)
                        {
                            var data = await GetMovieDetailsAsync("" + item.id);
                            Console.WriteLine("Adding movie " + item.title + " to recommendations");
                            RecommendationsPanel.Controls.Add(new MovieBox(data, null));
                        }
                    }

                });
            }
        }

    }
}