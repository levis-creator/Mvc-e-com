﻿namespace MyMvc.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ItemClient>? ItemClients { get; set; }

    }
}
