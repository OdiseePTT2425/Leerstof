using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    internal class UserRepository
    {
        private UserContext _context = new UserContext();

        public List<User> GetAll() {
            return _context.Users.Include("Cars").Include("FavoriteCar").ToList();
        }

        public void Add(User user) { 
            _context.Users.Add(user);
            _context.SaveChanges(); // Nooit vergeten
        }
        public void Update(User user) {
            _context.SaveChanges();
        }
        
        public void Delete(User user) { 
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
