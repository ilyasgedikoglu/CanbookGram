﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class CANBOOKGRAMEntities : DbContext
{
    public CANBOOKGRAMEntities()
        : base("name=CANBOOKGRAMEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Comment> Comment { get; set; }
    public virtual DbSet<Followed> Followed { get; set; }
    public virtual DbSet<Follower> Follower { get; set; }
    public virtual DbSet<Like> Like { get; set; }
    public virtual DbSet<Photo> Photo { get; set; }
    public virtual DbSet<Text> Text { get; set; }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<SenderMessageDetail> SenderMessageDetail { get; set; }
    public virtual DbSet<UserMessage> UserMessage { get; set; }
}
