using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klog.Models {
    public interface IBlogRepository {
        IEnumerable<Blogpost> getPosts(int postCount);
    }
}
