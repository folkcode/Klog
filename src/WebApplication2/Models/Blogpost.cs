using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klog.Models {
   public class Blogpost {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int Hits { get; set; }
        public string Author { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }
        public string Category { get; set; }
        public string Keywords { get; set; }
        public string UniqueKey { get; set; }
        public string AuthorUNID { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public string genUniqueKey() {
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] CharArr = chars.ToCharArray();
            string key = "";
            int arrLen = CharArr.Length;

            Random rand = new Random();
            for (int i=0;i<11;i++) {
                key += CharArr[rand.Next(0, arrLen)];
            }
            return key;
        }
    }
}
