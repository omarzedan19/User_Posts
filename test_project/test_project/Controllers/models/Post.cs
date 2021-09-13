using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_project.Controllers.models
{
    public class Post
    {
        public Post(int id, string title, string body)
        {
            this.id = id;
            this.title = title;
            this.body = body;
        }

        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
