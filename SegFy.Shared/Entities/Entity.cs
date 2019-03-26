using Flunt.Notifications;
using System;

namespace SegFy.Shared.Entities
{
    public class Entity : Notifiable
    {
        public int Id { get; private set; }
    }
}
