using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klog.Models {
    public class BlogRepository : IBlogRepository {
        private BlogContext _context;
       // private ILogger<BlogRepository> _logger;

        public BlogRepository(BlogContext context /*, ILogger<BlogRepository> logger */) {
            _context = context;
           // _logger = logger;
        }

        public IEnumerable<Blogpost> getPosts(int postCount) {
            try {
                postCount= (postCount > 12) ?  12 : postCount;

                return postCount ==0 ? 
                    _context.Posts.OrderBy(t => t.Hits).ToList() :
                    _context.Posts.OrderBy(t => t.Hits).Take(postCount).ToList();
            } catch (Exception ex) {
               // _logger.LogError("Could not get posts from database.", ex);
                return null;
            }
        }
    }
}
