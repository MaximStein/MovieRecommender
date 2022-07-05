from sklearn.feature_extraction.text import TfidfVectorizer
# Import Pandas
import pandas as pd
#from sklearn.metrics.pairwise import linear_kernel
from sklearn.metrics.pairwise import cosine_similarity
from ast import literal_eval
import numpy as np
from nltk.stem.snowball import SnowballStemmer
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
        if len(names) > 3:
            names = names[:3]
        return names
    
    return []

def clean_data(x):
    if isinstance(x, list):
        return [str.lower(i.replace(" ", "")) for i in x]
    else:        
        if isinstance(x, str):
            return str.lower(x.replace(" ", ""))
        else:
            return ''

def create_soup(x):
    return ' '.join(x['keywords']) + ' ' + ' '.join(x['cast']) + ' ' + x['director'] + ' '+ x['director'] + ' '+ x['director'] + ' ' + ' '.join(x['genres'])


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
        self.metadata = self.metadata.drop([19730, 29503, 35587, 28700, 25897])

        self.metadata['id'] = self.metadata['id'].astype('int')

        self.metadata = self.metadata.merge(credits, on='id')
        self.metadata = self.metadata.merge(keywords, on='id')

        features = ['cast', 'crew', 'keywords', 'genres']
        for feature in features:
            self.metadata[feature] = self.metadata[feature].apply(literal_eval)
       
        self.metadata['year'] = pd.to_datetime(self.metadata['release_date'], errors='coerce').apply(lambda x: str(x).split('-')[0] if x != np.nan else np.nan)

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
        self.metadata['keywords'] = self.metadata['keywords'].apply(stem, args=(stemmer,))

        features = ['cast', 'keywords', 'director', 'genres']
        for feature in features:
            self.metadata[feature] = self.metadata[feature].apply(clean_data)

        self.metadata['soup'] = self.metadata.apply(create_soup, axis=1)
        
        count = CountVectorizer(analyzer='word',ngram_range=(1, 2),min_df=0, stop_words='english')
        count_matrix = count.fit_transform(self.metadata['soup'])
        self.cosine_sim = cosine_similarity(count_matrix, count_matrix)
        
        self.metadata = self.metadata.reset_index()
        titles = self.metadata['title']
      
      # self.indices = pd.Series(self.metadata.index, index=self.metadata['title'])
        self.indices = pd.Series(self.metadata.index, index=self.metadata['id'])

       
recommender = MovieRecommender()

#wird auf windows in das user verzeichnis gespeichert
file = open('movieRecommender.txt', 'wb')
pickle.dump(recommender, file)
file.close()
