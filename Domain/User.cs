﻿namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }  
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
