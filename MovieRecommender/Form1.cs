using CsvHelper;
using CsvHelper.Configuration;
using MovieRecommender.Pocos;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace MovieRecommender
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();

        const String csvLocation = @"C:/Code/ML/movies_archive/movies_metadata.csv";
        const String tmdbApiKey = "api_key=a7af9a07f435184d6005c1e608db0bb7";

        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.ToLower().Replace("_",""),
        };

        public Form1()
        {
           
            InitializeComponent();
            searchResultListBox.ValueMember = "Id";
            searchResultListBox.DisplayMember = "NiceString";

            selectionMovieBox.Visible = false;

            Load += async (sender, args) =>
            {
                
                var movie1 = await GetMovieDetailsAsync("155");
                var movie2 = await GetMovieDetailsAsync("49026");
                var movie3 = await GetMovieDetailsAsync("49040");
                var movie4 = await GetMovieDetailsAsync("949");


                selectionMovieBox.LoadMovieData(movie1);
                selectionMovieBox.SetOnButtonClick((sender, args) => { 
                    recommendationsPanel.Controls.Clear();
                    recommendationsPanel.Controls.Add(new MovieBox(movie1));
                    recommendationsPanel.Controls.Add(new MovieBox(movie2));
                    recommendationsPanel.Controls.Add(new MovieBox(movie3));
                    recommendationsPanel.Controls.Add(new MovieBox(movie4));                
                });

                //recommendationsPanel.Controls.Add(new MovieBox());

            };  
        }

        private void searchResultListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private String getMovieApiCallUrl(String id)
        {
            return "https://api.themoviedb.org/3/movie/"+id+ "?api_key=a7af9a07f435184d6005c1e608db0bb7";
        }

        private async Task<MovieDetails> GetMovieDetailsAsync(String id)
        {
            HttpResponseMessage response = await client.GetAsync(getMovieApiCallUrl(id));
            var content = await response.Content.ReadAsStringAsync();
            Pocos.MovieDetails m = Newtonsoft.Json.JsonConvert.DeserializeObject<Pocos.MovieDetails>(content);
            Console.WriteLine(m.toString());
            return m;  
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //GetMovieDetails("1659815648");
            SearchCsvFile(searchInputTextBox.Text);
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
                }

             
                var count = resultList.Count();
                searchResultsLabel.Text = count + " results found";

                if (count > 0)
                {
                    searchResultListBox.Items.Clear();
                    //searchResultListBox.Items.AddRange(searchResults.Take(50).ToArray());
                    searchResultListBox.Items.AddRange(resultList.ToArray());
                }
            }
        }

        private async void searchResultListBox_SelectedValueChangedAsync(object sender, EventArgs e)
        {
            var item = (MoviesMetadataRow)searchResultListBox.SelectedItem;
            if(item != null)
            {
                var data = await GetMovieDetailsAsync(item.Id);
                if(data != null)
                {
                    selectionMovieBox.LoadMovieData(data);
                    selectionMovieBox.Visible = true;          
                }
            }
        }

    }
}