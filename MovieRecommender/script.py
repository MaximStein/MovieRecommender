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
import pickle

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

###################

####################

def filter_keywords(x,s):
    words = []
    for i in x:
        if i in s:
            words.append(i)
    return words

def stem(x, stemmer):
    return [stemmer.stem(i) for i in x]

credits = pd.read_csv('C:/Code/ML/movies_archive/credits.csv')
keywords = pd.read_csv('C:/Code/ML/movies_archive/keywords.csv')

keywords['id'] = keywords['id'].astype('int')
credits['id'] = credits['id'].astype('int')

class MovieRecommender:

    def __init__(self):
        self.metadata = pd.read_csv('C:/Code/ML/movies_archive/movies_metadata.csv', low_memory=False)
        # Remove rows with bad IDs.
        self.metadata = self.metadata.drop([19730, 29503, 35587, 28700])

        self.metadata['id'] = self.metadata['id'].astype('int')

        self.metadata = self.metadata.merge(credits, on='id')
        self.metadata = self.metadata.merge(keywords, on='id')

        features = ['cast', 'crew', 'keywords', 'genres']
        for feature in features:
            self.metadata[feature] = self.metadata[feature].apply(literal_eval)

        #vote_counts = self.metadata[self.metadata['vote_count'].notnull()]['vote_count'].astype('int')
       # vote_averages = self.metadata[self.metadata['vote_average'].notnull()]['vote_average'].astype('int')
       # self.vote_averages_mean = vote_averages.mean()
        self.metadata['year'] = pd.to_datetime(self.metadata['release_date'], errors='coerce').apply(lambda x: str(x).split('-')[0] if x != np.nan else np.nan)

       # self.vote_counts_quantile = vote_counts.quantile(0.95)

        self.metadata['director'] = self.metadata['crew'].apply(get_director)
        
        features = ['cast', 'keywords', 'genres']
        for feature in features:
            self.metadata[feature] = self.metadata[feature].apply(get_list)

        s = self.metadata.apply(lambda x: pd.Series(x['keywords']),axis=1).stack().reset_index(level=1, drop=True)
        s.name = 'keyword'
        s = s.value_counts()
        s = s[s > 1]
        stemmer = SnowballStemmer('english')

    
        self.metadata['keywords'] = self.metadata['keywords'].apply(filter_keywords, args=(s,))
        #metadata['keywords'] = metadata['keywords'].apply(lambda x: [self.stemmer.stem(i) for i in x])
        self.metadata['keywords'] = self.metadata['keywords'].apply(stem, args=(stemmer,))

        #metadata['keywords'] = metadata['keywords'].apply(lambda x: [str.lower(i.replace(" ", "")) for i in x])       
        #  # Apply clean_data function to your features.
        features = ['cast', 'keywords', 'director', 'genres']
        for feature in features:
            self.metadata[feature] = self.metadata[feature].apply(clean_data)

        # Create a new soup feature
        self.metadata['soup'] = self.metadata.apply(create_soup, axis=1)

        #print(metadata[['soup']].head(2))
        #count = CountVectorizer(stop_words='english')
        count = CountVectorizer(analyzer='word',ngram_range=(1, 2),min_df=0, stop_words='english')
        count_matrix = count.fit_transform(self.metadata['soup'])
        self.cosine_sim = cosine_similarity(count_matrix, count_matrix)

        # Reset index of your main DataFrame and construct reverse mapping as before
        self.metadata = self.metadata.reset_index()
        titles = self.metadata['title']
      
      #  self.indices = pd.Series(self.metadata.index, index=self.metadata['title'])
        self.indices = pd.Series(self.metadata.index, index=self.metadata['id'])

        #Define a TF-IDF Vectorizer Object. Remove all english stop words such as 'the', 'a'
        #tfidf = TfidfVectorizer(stop_words='english')


########################################

recommender = MovieRecommender()

file = open('movieRecommender.txt', 'wb')
pickle.dump(recommender, file)
file.close()


#print(get_recommendations('Pulp Fiction'))

#print(improved_recommendations('Pulp Fiction', recommender.metadata, recommender.indices, recommender.cosine_sim))
