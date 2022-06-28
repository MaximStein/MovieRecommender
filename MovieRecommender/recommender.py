
import pickle
import pandas as pd
import json
import sys

pd.options.mode.chained_assignment = None  # default='warn'

class MovieRecommender:
    pass
    
def weighted_rating(x,vote_counts_quantile,vote_averages_mean):
        v = x['vote_count']
        R = x['vote_average']
        return (v/(v+vote_counts_quantile) * R) + (vote_counts_quantile/(vote_counts_quantile+v) * vote_averages_mean)



def get_recommendations(title,titles,indices,cosine_sim):
    idx = indices[title]    
    sim_scores = list(enumerate(cosine_sim[idx]))
    sim_scores = sorted(sim_scores, key=lambda x: x[1], reverse=True)
    sim_scores = sim_scores[1:21]
    movie_indices = [i[0] for i in sim_scores]

    return titles.iloc[movie_indices]


def improved_recommendations(title, metadata, indices, cosine_sim):
    idx = indices[title]
    sim_scores = list(enumerate(cosine_sim[idx]))
    sim_scores = sorted(sim_scores, key=lambda x: x[1], reverse=True)
    sim_scores = sim_scores[1:26]
    movie_indices = [i[0] for i in sim_scores]
    
    movies = metadata.iloc[movie_indices][['title', 'vote_count', 'vote_average', 'year']]
    vote_counts = movies[movies['vote_count'].notnull()]['vote_count'].astype('int')
    vote_averages = movies[movies['vote_average'].notnull()]['vote_average'].astype('int')
    C = vote_averages.mean()
    m = vote_counts.quantile(0.60)
    qualified = movies[(movies['vote_count'] >= m) & (movies['vote_count'].notnull()) & (movies['vote_average'].notnull())]
    qualified['vote_count'] = qualified['vote_count'].astype('int')
    qualified['vote_average'] = qualified['vote_average'].astype('int')
    qualified['wr'] = qualified.apply(weighted_rating, args=(m,C,), axis=1)
    qualified = qualified.sort_values('wr', ascending=False).head(10)
    return qualified


def get_sim_score(x, sim_scores):
    for s in sim_scores:
        if x.name == s[0]:
            return s[1]

#rating_weight 0 bis 1
def get_order_score(x, rating_weight):
    #r = (x['weighted_rating'] * .1 + .5)-1     # -0.5 bis 0.5

    #r = rating_weight * r + 1

    #return x['wr'] * rating_weight + x['sim_score']
    #return r * x['sim_score']
    r = (x['weighted_rating'] - 5) * rating_weight + 5
    #print(str(r)+' | '+str(x['weighted_rating']))
    return r * x['sim_score']

def get_similarity_scores(id,indices,cosine_sim):
    idx = indices[id]
    sim_scores = list(enumerate(cosine_sim[idx]))
    sim_scores = sorted(sim_scores, key=lambda x: x[1], reverse=True)
    #sim_scores = sim_scores[1:26]
    sim_scores = sim_scores[1:150]
    return sim_scores


def get_average(sim_scores, movie_index):
    count = 0
    score_sum = 0

    for t in sim_scores:
        if t[0] == movie_index:
            count += 1
            score_sum += t[1]

    return score_sum / count

def contains_movie_index(sim_scores, index):
    for x in sim_scores:
        if x[0] == index:
            return True
    return False

def improved_recommendations_3(movie_ids, metadata, indices, cosine_sim, rating_weight=1):
    #print('rating weight: '+str(rating_weight))
    combined_sim_scores = []

    for id in movie_ids:
        scores = get_similarity_scores(id,indices,cosine_sim)
        combined_sim_scores.extend(scores)
    
    sim_scores = []

    for s in combined_sim_scores:
        if not contains_movie_index(sim_scores,s[0]):
            average = get_average(combined_sim_scores, s[0])
            score_tuple = (s[0], average)
            sim_scores.append(score_tuple)

    movie_indices = [i[0] for i in sim_scores]
    
    movies = metadata.iloc[movie_indices][['title', 'vote_count', 'vote_average', 'year','id']]
    vote_counts = movies[movies['vote_count'].notnull()]['vote_count'].astype('int')
    vote_averages = movies[movies['vote_average'].notnull()]['vote_average'].astype('int')
    C = vote_averages.mean()
    m = vote_counts.quantile(0.60)
    qualified = movies[(movies['vote_count'] >= m) & (movies['vote_count'].notnull()) & (movies['vote_average'].notnull())]
    qualified['sim_score'] = qualified.apply(get_sim_score, args=(sim_scores,), axis=1)
    qualified['vote_count'] = qualified['vote_count'].astype('int')
    qualified['vote_average'] = qualified['vote_average'].astype('int')
    qualified['weighted_rating'] = qualified.apply(weighted_rating, args=(m,C,), axis=1)
    qualified['order_score'] = qualified.apply(get_order_score, args=(rating_weight,), axis=1)
    #qualified = qualified.sort_values('wr', ascending=False).head(10)
    qualified = qualified.sort_values('order_score', ascending=False).head(15)
    qualified['json'] = qualified.apply(lambda x: x.to_json(), axis=1)
    return qualified[['id','title','year','weighted_rating','sim_score','order_score','json']]

f = open("C:/users/maxim/movieRecommender.txt", "rb")
r = pickle.load(f)
f.close()


ids = [int(i) for i in sys.argv[1].split(',')]
rating_weight = float(sys.argv[2])
results = improved_recommendations_3(ids, r.metadata, r.indices, r.cosine_sim, rating_weight)
#print(results)
output = '['
for i in results.index:
    output += results.loc[i]['json']+','
output += ']'

print(output)



#155
#print(improved_recommendations_2('Pulp Fiction', r.metadata, r.indices, r.cosine_sim, 0))
#print(improved_recommendations_2('Pulp Fiction', r.metadata, r.indices, r.cosine_sim, .5))

#print(get_recommendations('Pulp Fiction', r.titles, r.indices, r.cosine_sim))
