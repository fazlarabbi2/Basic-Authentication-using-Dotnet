namespace BasicAuthenticationDemo.Models
{
    namespace BasicAuthenticationDemo.Models
    {
        // Interface defining the contract for user repository operations.
        public interface IUserRepository
        {
            Task<User?> ValidateUser(string username, string password); // Method to validate a user's credentials.
            Task<List<User>> GetAllUsers(); // Method to retrieve all users.
            Task<User?> GetUserById(int id); // Method to fetch a single user by ID.
            Task<User> AddUser(User user); // Method to add a new user.
            Task<User> UpdateUser(User user); // Method to update an existing user's details.
            Task DeleteUser(int id); // Method to delete a user by ID.
        }

        // Concrete implementation of IUserRepository.
        public class UserRepository : IUserRepository
        {
            // In-memory list of users.
            private List<User> users = new List<User>
            {
                // Initial set of users. Use hashed passwords in a production environment.
                new User { Id = 1, Username = "admin", Password = "admin" },
                new User { Id = 2, Username = "user", Password = "user" },
                new User { Id = 3, Username = "Pranaya", Password = "Test@1234" },
                new User { Id = 4, Username = "Kumar", Password = "Admin@123" }
            };

            // Validates user credentials against the stored list.
            public async Task<User?> ValidateUser(string username, string password)
            {
                await Task.Delay(100); // Simulates a delay, mimicking database latency.
                return users.FirstOrDefault(u => u.Username == username && u.Password == password); // Returns the user if credentials match.
            }

            // Retrieves all users.
            public async Task<List<User>> GetAllUsers()
            {
                await Task.Delay(100); // Simulates a delay.
                return users.ToList(); // Converts the list of users to a new list and returns it.
            }

            // Retrieves a user by ID.
            public async Task<User?> GetUserById(int id)
            {
                await Task.Delay(100); // Simulates a delay.
                return users.FirstOrDefault(u => u.Id == id); // Returns the user if found.
            }

            // Adds a new user if no duplicate ID is found.
            public async Task<User> AddUser(User user)
            {
                await Task.Delay(100); // Simulates a delay.
                if (users.Any(u => u.Id == user.Id))
                {
                    throw new Exception("User already exists with the given ID."); // Exception if user with same ID exists.
                }

                users.Add(user); // Adds the new user to the list.
                return user; // Returns the added user.
            }

            // Updates an existing user's details.
            public async Task<User> UpdateUser(User user)
            {
                await Task.Delay(100); // Simulates a delay.
                var existingUser = await GetUserById(user.Id); // Fetches the user by ID.
                if (existingUser == null)
                {
                    throw new Exception("User not found."); // Throws an exception if user not found.
                }

                existingUser.Username = user.Username; // Updates username.
                existingUser.Password = user.Password; // Updates password, consider hashing in production.
                return existingUser; // Returns the updated user.
            }

            // Deletes a user by ID.
            public async Task DeleteUser(int id)
            {
                await Task.Delay(100); // Simulates a delay.
                var user = await GetUserById(id); // Fetches the user by ID.
                if (user == null)
                {
                    throw new Exception("User not found."); // Throws an exception if user not found.
                }

                users.Remove(user); // Removes the user from the list.
            }
        }
    }
}
