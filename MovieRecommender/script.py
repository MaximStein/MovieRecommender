#Import TfIdfVectorizer from scikit-learn
#from curses import meta
from sklearn.feature_extraction.text import TfidfVectorizer
# Import Pandas
import pandas as pd
# Import linear_kernel
from sklearn.metrics.pairwise import linear_kernel
# Compute the Cosine Similarity matrix based on the count_matrix
from sklearn.metrics.pairwise import cosine_similarity
# Parse the stringified features into their corresponding python objects
from ast import literal_eval
# Import Numpy
import numpy as np
from nltk.stem.snowball import SnowballStemmer
# Import CountVectorizer and create the count matrix
from sklearn.feature_extraction.text import CountVectorizer

class MovieRecommender:
    def get_director(x):
        for i in x:
            if i['job'] == 'Director':
                return i['name']
        return np.nan

    def get_list(x):
        if isinstance(x, list):
            names = [i['name'] for i in x]
            #Check if more than 3 elements exist. If yes, return only first three. If no, return entire list.
            if len(names) > 3:
                names = names[:3]
            return names

        #Return empty list in case of missing/malformed data
        return []

    def clean_data(x):
        if isinstance(x, list):
            return [str.lower(i.replace(" ", "")) for i in x]
        else:
            #Check if director exists. If not, return empty string
            if isinstance(x, str):
                return str.lower(x.replace(" ", ""))
            else:
                return ''

    def create_soup(x):
        return ' '.join(x['keywords']) + ' ' + ' '.join(x['cast']) + ' ' + x['director'] + ' '+ x['director'] + ' '+ x['director'] + ' ' + ' '.join(x['genres'])
        
    metadata = pd.read_csv('C:/Code/ML/movies_archive/movies_metadata.csv', low_memory=False)
    credits = pd.read_csv('C:/Code/ML/movies_archive/credits.csv')
    keywords = pd.read_csv('C:/Code/ML/movies_archive/keywords.csv')

    # Remove rows with bad IDs.
    metadata = metadata.drop([19730, 29503, 35587, 28700])

    keywords['id'] = keywords['id'].astype('int')
    credits['id'] = credits['id'].astype('int')
    metadata['id'] = metadata['id'].astype('int')

    metadata = metadata.merge(credits, on='id')
    metadata = metadata.merge(keywords, on='id')

    features = ['cast', 'crew', 'keywords', 'genres']
    for feature in features:
        metadata[feature] = metadata[feature].apply(literal_eval)

    vote_counts = metadata[metadata['vote_count'].notnull()]['vote_count'].astype('int')
    vote_averages = metadata[metadata['vote_average'].notnull()]['vote_average'].astype('int')
    C = vote_averages.mean()
    metadata['year'] = pd.to_datetime(metadata['release_date'], errors='coerce').apply(lambda x: str(x).split('-')[0] if x != np.nan else np.nan)

    m = vote_counts.quantile(0.95)

    def weighted_rating(self,x):
        v = x['vote_count']
        R = x['vote_average']
        return (v/(v+self.m) * R) + (self.m/(self.m+v) * self.C)

    metadata['director'] = metadata['crew'].apply(get_director)


    features = ['cast', 'keywords', 'genres']
    for feature in features:
        metadata[feature] = metadata[feature].apply(get_list)

    #metadata['keywords'] = metadata['keywords'].apply(lambda x: [str.lower(i.replace(" ", "")) for i in x])

    s = metadata.apply(lambda x: pd.Series(x['keywords']),axis=1).stack().reset_index(level=1, drop=True)
    s.name = 'keyword'
    s = s.value_counts()
    s = s[s > 1]
    stemmer = SnowballStemmer('english')


    def filter_keywords(self,x):
        words = []
        for i in x:
            if i in self.s:
                words.append(i)
        return words

    def stem(self, x):
        return [self.stemmer.stem(i) for i in x]
    

    metadata['keywords'] = metadata['keywords'].apply(filter_keywords)
    #metadata['keywords'] = metadata['keywords'].apply(lambda x: [self.stemmer.stem(i) for i in x])
    metadata['keywords'] = metadata['keywords'].apply(stem)


    # Apply clean_data function to your features.
    features = ['cast', 'keywords', 'director', 'genres']
    for feature in features:
        metadata[feature] = metadata[feature].apply(clean_data)

    # Create a new soup feature
    metadata['soup'] = metadata.apply(create_soup, axis=1)

    #print(metadata[['soup']].head(2))

    #count = CountVectorizer(stop_words='english')
    count = CountVectorizer(analyzer='word',ngram_range=(1, 2),min_df=0, stop_words='english')
    count_matrix = count.fit_transform(metadata['soup'])
    cosine_sim = cosine_similarity(count_matrix, count_matrix)

    # Reset index of your main DataFrame and construct reverse mapping as before
    metadata = metadata.reset_index()
    titles = metadata['title']
    indices = pd.Series(metadata.index, index=metadata['title'])

    #Define a TF-IDF Vectorizer Object. Remove all english stop words such as 'the', 'a'
    #tfidf = TfidfVectorizer(stop_words='english')

    def get_recommendations(self,title):
        idx = self.indices[title]    
        sim_scores = list(enumerate(self.cosine_sim[idx]))
        sim_scores = sorted(sim_scores, key=lambda x: x[1], reverse=True)
        sim_scores = sim_scores[1:21]
        movie_indices = [i[0] for i in sim_scores]

        return self.titles.iloc[movie_indices]


    def improved_recommendations(self,title):
        idx = self.indices[title]
        sim_scores = list(enumerate(self.cosine_sim[idx]))
        sim_scores = sorted(sim_scores, key=lambda x: x[1], reverse=True)
        sim_scores = sim_scores[1:26]
        movie_indices = [i[0] for i in sim_scores]
        
        movies = self.metadata.iloc[movie_indices][['title', 'vote_count', 'vote_average', 'year']]
        vote_counts = movies[movies['vote_count'].notnull()]['vote_count'].astype('int')
        vote_averages = movies[movies['vote_average'].notnull()]['vote_average'].astype('int')
        C = vote_averages.mean()
        m = vote_counts.quantile(0.60)
        qualified = movies[(movies['vote_count'] >= m) & (movies['vote_count'].notnull()) & (movies['vote_average'].notnull())]
        qualified['vote_count'] = qualified['vote_count'].astype('int')
        qualified['vote_average'] = qualified['vote_average'].astype('int')
        qualified['wr'] = qualified.apply(self.weighted_rating, axis=1)
        qualified = qualified.sort_values('wr', ascending=False).head(10)
        return qualified

#print(get_recommendations('Pulp Fiction'))
recommender = MovieRecommender()
print(recommender.improved_recommendations('Pulp Fiction'))
