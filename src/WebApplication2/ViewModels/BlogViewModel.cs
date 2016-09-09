using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klog.ViewModels
{
    public class BlogViewModel
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public int Hits { get; set; }
        public string Author { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }
        public string Category { get; set; }
        public string Keywords { get; set; }
        public string UniqueKey { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
