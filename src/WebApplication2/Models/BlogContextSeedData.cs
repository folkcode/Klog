using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klog.Models {
    public class BlogContextSeedData {
        private BlogContext _context;
        private UserManager<BlogUser> _userManager;

        public BlogContextSeedData(BlogContext context, UserManager<BlogUser> userManager) {
            _userManager = userManager;
            _context = context;
        }

        public async Task EnsureSeedDataAsync() {
            var checkEmail = _userManager.FindByEmailAsync("soida.kaspars@gmail.com");
            if (checkEmail == null) {
                var newUser = new BlogUser {
                    UserName = "Kaspars",
                    Email = "soida.kaspars@gmail.com"
                };

                await _userManager.CreateAsync(newUser, "6248094lol");

            }

            if (!_context.Posts.Any()) {
                //add new data
                var firstPost = new Blogpost() {
                    Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elementum enim. Donec id turpis ante. Duis est odio, pharetra id risus sit amet, venenatis porta turpis. Praesent tincidunt ante odio, ac vulputate justo porta quis. Pellentesque rutrum tellus ac eros iaculis tempor. Phasellus vel cursus tellus, nec sagittis turpis. Vivamus id feugiat turpis. Nunc tincidunt, tortor vitae sagittis ultricies, libero augue rhoncus libero, vel congue eros nibh in leo. Mauris a auctor velit, dapibus convallis ipsum. Phasellus commodo in tellus semper mollis. Maecenas quis risus lectus. Mauris porttitor, tortor quis hendrerit lobortis, velit lectus bibendum metus, ut vestibulum nibh velit eu arcu. Suspendisse non ipsum consequat, consectetur est fermentum, congue justo. Curabitur aliquet nisi mi, at tempus eros eleifend nec.
In sit amet nibh commodo, venenatis neque id, bibendum elit. Vivamus eu tellus nunc. Aliquam blandit ut purus a dapibus. Cras tellus odio, eleifend at nisi ut, ullamcorper malesuada arcu. Nunc auctor tortor et arcu sollicitudin, sed ultrices dolor eleifend. Sed dictum ipsum ut justo consequat, sit amet consequat orci semper. Morbi vel dui ante. Maecenas accumsan arcu elementum metus fermentum sagittis. Mauris eleifend urna id elementum consequat. Nunc dictum viverra quam, id elementum arcu.
Fusce venenatis luctus magna, sit amet dictum sem cursus sed. Nunc portt",
                    Title = "First Entry!",
                    Author = "Kaspars",
                    AuthorUNID = "1",
                    Category = "Blog",
                    Keywords = "First;Entry;Test;Hey",

                    Comments = new List<Comment>() {
                        new Comment() {Body = "LOREM IPSUM COMMENTUM", Author = "Kaspars"},
                        new Comment() {Body = "SICK COMMENT BRAH", Author = "Kaspars"}
                    }

                };

                var SecondPost = new Blogpost() {
                    Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elementum enim. Donec id turpis ante. Duis est odio, pharetra id risus sit amet, venenatis porta turpis. Praesent tincidunt ante odio, ac vulputate justo porta quis. Pellentesque rutrum tellus ac eros iaculis tempor. Phasellus vel cursus tellus, nec sagittis turpis. Vivamus id feugiat turpis. Nunc tincidunt, tortor vitae sagittis ultricies, libero augue rhoncus libero, vel congue eros nibh in leo. Mauris a auctor velit, dapibus convallis ipsum. Phasellus commodo in tellus semper mollis. Maecenas quis risus lectus. Mauris porttitor, tortor quis hendrerit lobortis, velit lectus bibendum metus, ut vestibulum nibh velit eu arcu. Suspendisse non ipsum consequat, consectetur est fermentum, congue justo. Curabitur aliquet nisi mi, at tempus eros eleifend nec.
In sit amet nibh commodo, venenatis neque id, bibendum elit. Vivamus eu tellus nunc. Aliquam blandit ut purus a dapibus. Cras tellus odio, eleifend at nisi ut, ullamcorper malesuada arcu. Nunc auctor tortor et arcu sollicitudin, sed ultrices dolor eleifend. Sed dictum ipsum ut justo consequat, sit amet consequat orci semper. Morbi vel dui ante. Maecenas accumsan arcu elementum metus fermentum sagittis. Mauris eleifend urna id elementum consequat. Nunc dictum viverra quam, id elementum arcu.
Fusce venenatis luctus magna, sit amet dictum sem cursus sed. Nunc porttitor pellentesque risus at vestibulum. Proin mauris dui, pharetra sed laoreet in, egestas nec leo. Pellentesque id pharetra magna. Aliquam viverra tempus venenatis. Sed magna dui, porta at vulputate a, euismod non massa. Donec consectetur tortor cursus, pretium justo sit amet, iaculis neque. Integer ut eleifend felis. Interdum et malesuada fames ac ante ipsum primis in faucibus. Morbi volutpat magna vitae mauris fringilla mollis. Etiam finibus pharetra lorem in rutrum. Morbi aliquam lectus elit, non pellentesque augue sollicitudin in. Donec mollis ultricies est, quis vestibulum sem.
Fusce id lorem ac dui sollicitudin mollis. Donec vel nisl condimentum, egestas augue eget, posuere ipsum. Nullam vulputate eget felis et porttitor. Proin consectetur nisl et justo commodo vulputate. Etiam vitae sapien faucibus, molestie felis id, pulvinar neque. Mauris sodales erat in odio suscipit congue. Nam aliquam sapien sit amet semper tempus. Sed vulputate rhoncus rutrum. Praesent in velit eget ex hendrerit congue sit amet eget enim.
Sed vitae lacinia elit. Curabitur et metus a arcu sollicitudin viverra non sit amet sapien. Aenean id ante massa. Sed ac lorem lectus. Donec mollis urna non tempor pretium. Duis non congue odio. Vestibulum scelerisque elit elit, ut cursus risus pharetra a. Duis finibus purus auctor, tempus magna non, facilisis nisi. Quisque tincidunt ut odio sed bibendum. In hac habitasse platea dictumst. Vestibulum eu luctus quam, nec dapibus justo. Praesent egestas risus vel erat lacinia fermentum. Etiam accumsan eu odio a pulvinar. Donec sagittis turpis dolor, vel vestibulum diam tempor ut.",
                    Title = "Lorem ipsum stuff",
                    Author = "Kaspars",
                    AuthorUNID = "1",
                    Category = "Blog",
                    Keywords = "Lorem;Ipsum",

                    Comments = new List<Comment>() {
                        new Comment() {Body="Just a test", Author = "Kaspars", AuthorUNID = "1"},
                        new Comment() {Body="HYAHAYAHAYAYHAYAYYAHYAYHAY", Author="Kaspars", AuthorUNID="1"},
                        new Comment() {Body=@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elementum enim. Donec id turpis ante. Duis est odio, pharetra id risus sit amet, venenatis porta turpis. Praesent tincidunt ante odio, ac vulputate justo porta quis. Pellentesque rutrum tellus ac eros iaculis tempor. Phasellus vel cursus tellus, nec sagittis turpis. Vivamus id feugiat turpis. Nunc tincidunt, tortor vitae sagittis ultricies, libero augue rhoncus libero, vel congue eros nibh in leo. Mauris a auctor velit, dapibus convallis ipsum. Phasellus commodo in tellus semper mollis. Maecenas quis risus lectus. Mauris porttitor, tortor quis hendrerit lobortis, velit lectus bibendum metus, ut vestibulum nibh velit eu arcu. Suspendisse non ipsum consequat, consectetur est fermentum, congue justo. Curabitur aliquet nisi mi, at tempus eros eleifend nec.
In sit amet nibh commodo, venenatis neque id, bibendum elit. Vivamus eu tellus nunc. Aliquam blandit ut purus a dapibus. Cras tellus odio, eleifend at nisi ut, ullamcorper malesuada arcu. Nunc auctor tortor et arcu sollicitudin, sed ultrices dolor eleifend. Sed dictum ipsum ut justo consequat, sit amet consequat orci semper. Morbi vel dui ante. Maecenas accumsan arcu elementum metus fermentum sagittis. Mauris eleifend urna id elementum consequat. Nunc dictum viverra quam, id elementum arcu.
Fusce venenatis luctus magna, sit amet dictum sem cursus sed. Nunc portt", 
Author = "Kaspars", AuthorUNID ="1" }
                    }
                };
               firstPost.UniqueKey = firstPost.genUniqueKey();
                _context.Posts.Add(firstPost);
                _context.Comments.AddRange(firstPost.Comments);

                SecondPost.UniqueKey = SecondPost.genUniqueKey();
                _context.Posts.Add(SecondPost);
                _context.Comments.AddRange(SecondPost.Comments);

               _context.SaveChanges();
            }
        }
    }
}
