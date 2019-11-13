using Newtonsoft.Json;

namespace GoMangrove.Scripts
{
    public class Tweet
    {
        [JsonProperty("created_at")]
        public string created_at;
        [JsonProperty("id")]
        public int id;
        [JsonProperty("post")]
        public string post;
        [JsonProperty("total_like")]
        public int total_like;
        [JsonProperty("total_retweet")]
        public int total_retweet;
        [JsonProperty("username")]
        public string username;

        public Tweet() { }

        public Tweet(string created_at, int id, string post, int total_like, int total_retweet,string username)
        {
            this.created_at = created_at;
            this.id = id;
            this.post = post;
            this.total_like = total_like;
            this.total_retweet = total_retweet;
            this.username = username;
        }

        public string getCreate()
        {
            return created_at;
        }

        public void setCreate(string created_at)
        {
            this.created_at = created_at;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int created_at)
        {
            this.id = id;
        }

        public string getPost()
        {
            return post;
        }

        public void setPost(string created_at)
        {
            this.post = post;
        }

        public int getTotalLike()
        {
            return total_like;
        }

        public void setTotalLike(int created_at)
        {
            this.total_like = total_like;
        }

        public int getTotalRetweet()
        {
            return total_retweet;
        }

        public void setTotalRetweet(int created_at)
        {
            this.total_retweet = total_retweet;
        }

    }
}